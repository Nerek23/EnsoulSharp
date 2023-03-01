using System;
using System.Collections.Generic;
using System.Text;
using SharpDX.Collections;

namespace SharpDX.Diagnostics
{
	// Token: 0x020000AD RID: 173
	public static class ObjectTracker
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000359 RID: 857 RVA: 0x000099E0 File Offset: 0x00007BE0
		// (remove) Token: 0x0600035A RID: 858 RVA: 0x00009A14 File Offset: 0x00007C14
		public static event EventHandler<ComObjectEventArgs> Tracked;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600035B RID: 859 RVA: 0x00009A48 File Offset: 0x00007C48
		// (remove) Token: 0x0600035C RID: 860 RVA: 0x00009A7C File Offset: 0x00007C7C
		public static event EventHandler<ComObjectEventArgs> UnTracked;

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00009AB0 File Offset: 0x00007CB0
		private static Dictionary<IntPtr, List<ObjectReference>> ObjectReferences
		{
			get
			{
				Dictionary<IntPtr, List<ObjectReference>> result;
				if (Configuration.UseThreadStaticObjectTracking)
				{
					if (ObjectTracker.threadStaticObjectReferences == null)
					{
						ObjectTracker.threadStaticObjectReferences = new Dictionary<IntPtr, List<ObjectReference>>(EqualityComparer.DefaultIntPtr);
					}
					result = ObjectTracker.threadStaticObjectReferences;
				}
				else
				{
					if (ObjectTracker.processGlobalObjectReferences == null)
					{
						ObjectTracker.processGlobalObjectReferences = new Dictionary<IntPtr, List<ObjectReference>>(EqualityComparer.DefaultIntPtr);
					}
					result = ObjectTracker.processGlobalObjectReferences;
				}
				return result;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00009B00 File Offset: 0x00007D00
		public static string GetStackTrace()
		{
			string stackTrace;
			try
			{
				throw new ObjectTracker.GetStackTraceException();
			}
			catch (ObjectTracker.GetStackTraceException ex)
			{
				stackTrace = ex.StackTrace;
			}
			return stackTrace;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00009B2C File Offset: 0x00007D2C
		public static void Track(ComObject comObject)
		{
			if (comObject == null || comObject.NativePointer == IntPtr.Zero)
			{
				return;
			}
			Dictionary<IntPtr, List<ObjectReference>> objectReferences = ObjectTracker.ObjectReferences;
			lock (objectReferences)
			{
				List<ObjectReference> list;
				if (!ObjectTracker.ObjectReferences.TryGetValue(comObject.NativePointer, out list))
				{
					list = new List<ObjectReference>();
					ObjectTracker.ObjectReferences.Add(comObject.NativePointer, list);
				}
				list.Add(new ObjectReference(DateTime.Now, comObject, (ObjectTracker.StackTraceProvider != null) ? ObjectTracker.StackTraceProvider() : string.Empty));
				ObjectTracker.OnTracked(comObject);
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00009BD8 File Offset: 0x00007DD8
		public static List<ObjectReference> Find(IntPtr comObjectPtr)
		{
			Dictionary<IntPtr, List<ObjectReference>> objectReferences = ObjectTracker.ObjectReferences;
			lock (objectReferences)
			{
				List<ObjectReference> collection;
				if (ObjectTracker.ObjectReferences.TryGetValue(comObjectPtr, out collection))
				{
					return new List<ObjectReference>(collection);
				}
			}
			return new List<ObjectReference>();
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00009C30 File Offset: 0x00007E30
		public static ObjectReference Find(ComObject comObject)
		{
			Dictionary<IntPtr, List<ObjectReference>> objectReferences = ObjectTracker.ObjectReferences;
			lock (objectReferences)
			{
				List<ObjectReference> list;
				if (ObjectTracker.ObjectReferences.TryGetValue(comObject.NativePointer, out list))
				{
					foreach (ObjectReference objectReference in list)
					{
						if (objectReference.Object.Target == comObject)
						{
							return objectReference;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00009CD0 File Offset: 0x00007ED0
		public static void UnTrack(ComObject comObject)
		{
			if (comObject == null || comObject.NativePointer == IntPtr.Zero)
			{
				return;
			}
			Dictionary<IntPtr, List<ObjectReference>> objectReferences = ObjectTracker.ObjectReferences;
			lock (objectReferences)
			{
				List<ObjectReference> list;
				if (ObjectTracker.ObjectReferences.TryGetValue(comObject.NativePointer, out list))
				{
					for (int i = list.Count - 1; i >= 0; i--)
					{
						ObjectReference objectReference = list[i];
						if (objectReference.Object.Target == comObject)
						{
							list.RemoveAt(i);
						}
						else if (!objectReference.IsAlive)
						{
							list.RemoveAt(i);
						}
					}
					if (list.Count == 0)
					{
						ObjectTracker.ObjectReferences.Remove(comObject.NativePointer);
					}
					ObjectTracker.OnUnTracked(comObject);
				}
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00009D98 File Offset: 0x00007F98
		public static List<ObjectReference> FindActiveObjects()
		{
			List<ObjectReference> list = new List<ObjectReference>();
			Dictionary<IntPtr, List<ObjectReference>> objectReferences = ObjectTracker.ObjectReferences;
			lock (objectReferences)
			{
				foreach (List<ObjectReference> list2 in ObjectTracker.ObjectReferences.Values)
				{
					foreach (ObjectReference objectReference in list2)
					{
						if (objectReference.IsAlive)
						{
							list.Add(objectReference);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00009E5C File Offset: 0x0000805C
		public static string ReportActiveObjects()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (ObjectReference objectReference in ObjectTracker.FindActiveObjects())
			{
				string text = objectReference.ToString();
				if (!string.IsNullOrEmpty(text))
				{
					stringBuilder.AppendFormat("[{0}]: {1}", num, text);
					object target = objectReference.Object.Target;
					if (target != null)
					{
						string name = target.GetType().Name;
						int num2;
						if (!dictionary.TryGetValue(name, out num2))
						{
							dictionary[name] = 0;
						}
						else
						{
							dictionary[name] = num2 + 1;
						}
					}
				}
				num++;
			}
			List<string> list = new List<string>(dictionary.Keys);
			list.Sort();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Count per Type:");
			foreach (string text2 in list)
			{
				stringBuilder.AppendFormat("{0} : {1}", text2, dictionary[text2]);
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00009FA8 File Offset: 0x000081A8
		private static void OnTracked(ComObject obj)
		{
			EventHandler<ComObjectEventArgs> tracked = ObjectTracker.Tracked;
			if (tracked != null)
			{
				tracked(null, new ComObjectEventArgs(obj));
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00009FCC File Offset: 0x000081CC
		private static void OnUnTracked(ComObject obj)
		{
			EventHandler<ComObjectEventArgs> unTracked = ObjectTracker.UnTracked;
			if (unTracked != null)
			{
				unTracked(null, new ComObjectEventArgs(obj));
			}
		}

		// Token: 0x04001239 RID: 4665
		private static Dictionary<IntPtr, List<ObjectReference>> processGlobalObjectReferences;

		// Token: 0x0400123A RID: 4666
		[ThreadStatic]
		private static Dictionary<IntPtr, List<ObjectReference>> threadStaticObjectReferences;

		// Token: 0x0400123D RID: 4669
		public static Func<string> StackTraceProvider = new Func<string>(ObjectTracker.GetStackTrace);

		// Token: 0x020000AE RID: 174
		private class GetStackTraceException : Exception
		{
		}
	}
}
