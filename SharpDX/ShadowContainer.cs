using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200002E RID: 46
	internal class ShadowContainer : DisposeBase
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00004A31 File Offset: 0x00002C31
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00004A39 File Offset: 0x00002C39
		public IntPtr[] Guids { get; private set; }

		// Token: 0x06000165 RID: 357 RVA: 0x00004A44 File Offset: 0x00002C44
		public unsafe void Initialize(ICallbackable callbackable)
		{
			callbackable.Shadow = this;
			Type type = callbackable.GetType();
			Dictionary<Type, List<Type>> obj = ShadowContainer.typeToShadowTypes;
			List<Type> list;
			lock (obj)
			{
				if (!ShadowContainer.typeToShadowTypes.TryGetValue(type, out list))
				{
					IEnumerable<Type> implementedInterfaces = type.GetTypeInfo().ImplementedInterfaces;
					list = new List<Type>();
					list.AddRange(implementedInterfaces);
					ShadowContainer.typeToShadowTypes.Add(type, list);
					foreach (Type type2 in implementedInterfaces)
					{
						if (ShadowAttribute.Get(type2) == null)
						{
							list.Remove(type2);
						}
						else
						{
							foreach (Type item in type2.GetTypeInfo().ImplementedInterfaces)
							{
								list.Remove(item);
							}
						}
					}
				}
			}
			CppObjectShadow cppObjectShadow = null;
			foreach (Type type3 in list)
			{
				CppObjectShadow cppObjectShadow2 = (CppObjectShadow)Activator.CreateInstance(ShadowAttribute.Get(type3).Type);
				cppObjectShadow2.Initialize(callbackable);
				if (cppObjectShadow == null)
				{
					cppObjectShadow = cppObjectShadow2;
					this.guidToShadow.Add(ComObjectShadow.IID_IUnknown, cppObjectShadow);
				}
				this.guidToShadow.Add(Utilities.GetGuidFromType(type3), cppObjectShadow2);
				foreach (Type type4 in type3.GetTypeInfo().ImplementedInterfaces)
				{
					if (ShadowAttribute.Get(type4) != null)
					{
						this.guidToShadow.Add(Utilities.GetGuidFromType(type4), cppObjectShadow2);
					}
				}
			}
			int num = 0;
			foreach (Guid a in this.guidToShadow.Keys)
			{
				if (a != Utilities.GetGuidFromType(typeof(IInspectable)) && a != Utilities.GetGuidFromType(typeof(IUnknown)))
				{
					num++;
				}
			}
			this.guidPtr = Marshal.AllocHGlobal(Utilities.SizeOf<Guid>() * num);
			this.Guids = new IntPtr[num];
			int num2 = 0;
			Guid* ptr = (Guid*)((void*)this.guidPtr);
			foreach (Guid guid in this.guidToShadow.Keys)
			{
				if (!(guid == Utilities.GetGuidFromType(typeof(IInspectable))) && !(guid == Utilities.GetGuidFromType(typeof(IUnknown))))
				{
					ptr[num2] = guid;
					this.Guids[num2] = new IntPtr((void*)(ptr + num2));
					num2++;
				}
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00004D94 File Offset: 0x00002F94
		internal IntPtr Find(Type type)
		{
			return this.Find(Utilities.GetGuidFromType(type));
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004DA4 File Offset: 0x00002FA4
		internal IntPtr Find(Guid guidType)
		{
			CppObjectShadow cppObjectShadow = this.FindShadow(guidType);
			if (cppObjectShadow != null)
			{
				return cppObjectShadow.NativePointer;
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00004DC8 File Offset: 0x00002FC8
		internal CppObjectShadow FindShadow(Guid guidType)
		{
			CppObjectShadow result;
			this.guidToShadow.TryGetValue(guidType, out result);
			return result;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00004DE8 File Offset: 0x00002FE8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (CppObjectShadow cppObjectShadow in this.guidToShadow.Values)
				{
					cppObjectShadow.Dispose();
				}
				this.guidToShadow.Clear();
				if (this.guidPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.guidPtr);
					this.guidPtr = IntPtr.Zero;
				}
			}
		}

		// Token: 0x04000056 RID: 86
		private readonly Dictionary<Guid, CppObjectShadow> guidToShadow = new Dictionary<Guid, CppObjectShadow>();

		// Token: 0x04000057 RID: 87
		private static readonly Dictionary<Type, List<Type>> typeToShadowTypes = new Dictionary<Type, List<Type>>();

		// Token: 0x04000058 RID: 88
		private IntPtr guidPtr;
	}
}
