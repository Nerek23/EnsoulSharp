using System;
using System.Runtime.InteropServices;
using SharpDX.Diagnostics;

namespace SharpDX
{
	// Token: 0x02000007 RID: 7
	[Guid("00000000-0000-0000-C000-000000000046")]
	public class ComObject : CppObject, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600001E RID: 30 RVA: 0x0000232B File Offset: 0x0000052B
		public ComObject(object iunknowObject)
		{
			base.NativePointer = Marshal.GetIUnknownForObject(iunknowObject);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000233F File Offset: 0x0000053F
		protected ComObject()
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002348 File Offset: 0x00000548
		public virtual void QueryInterface(Guid guid, out IntPtr outPtr)
		{
			((IUnknown)this).QueryInterface(ref guid, out outPtr).CheckError();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002368 File Offset: 0x00000568
		public virtual IntPtr QueryInterfaceOrNull(Guid guid)
		{
			IntPtr zero = IntPtr.Zero;
			((IUnknown)this).QueryInterface(ref guid, out zero);
			return zero;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002388 File Offset: 0x00000588
		public static bool EqualsComObject<T>(T left, T right) where T : ComObject
		{
			return object.Equals(left, right) || (left != null && right != null && left.NativePointer == right.NativePointer);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000023D8 File Offset: 0x000005D8
		public virtual T QueryInterface<T>() where T : ComObject
		{
			IntPtr comObjectPtr;
			this.QueryInterface(Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002404 File Offset: 0x00000604
		internal virtual T QueryInterfaceUnsafe<T>()
		{
			IntPtr comObjectPtr;
			this.QueryInterface(Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointerUnsafe<T>(comObjectPtr);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002430 File Offset: 0x00000630
		public static T As<T>(object comObject) where T : ComObject
		{
			T result;
			using (ComObject comObject2 = new ComObject(Marshal.GetIUnknownForObject(comObject)))
			{
				result = comObject2.QueryInterface<T>();
			}
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002470 File Offset: 0x00000670
		public static T As<T>(IntPtr iunknownPtr) where T : ComObject
		{
			T result;
			using (ComObject comObject = new ComObject(iunknownPtr))
			{
				result = comObject.QueryInterface<T>();
			}
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024A8 File Offset: 0x000006A8
		internal static T AsUnsafe<T>(IntPtr iunknownPtr)
		{
			T result;
			using (ComObject comObject = new ComObject(iunknownPtr))
			{
				result = comObject.QueryInterfaceUnsafe<T>();
			}
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024E0 File Offset: 0x000006E0
		public static T QueryInterface<T>(object comObject) where T : ComObject
		{
			T result;
			using (ComObject comObject2 = new ComObject(Marshal.GetIUnknownForObject(comObject)))
			{
				result = comObject2.QueryInterface<T>();
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002520 File Offset: 0x00000720
		public static T QueryInterfaceOrNull<T>(IntPtr comPointer) where T : ComObject
		{
			if (comPointer == IntPtr.Zero)
			{
				return default(T);
			}
			Guid guidFromType = Utilities.GetGuidFromType(typeof(T));
			IntPtr comObjectPtr;
			if (!Marshal.QueryInterface(comPointer, ref guidFromType, out comObjectPtr).Failure)
			{
				return CppObject.FromPointerUnsafe<T>(comObjectPtr);
			}
			return default(T);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000257D File Offset: 0x0000077D
		public virtual T QueryInterfaceOrNull<T>() where T : ComObject
		{
			return CppObject.FromPointer<T>(this.QueryInterfaceOrNull(Utilities.GetGuidFromType(typeof(T))));
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000259C File Offset: 0x0000079C
		protected void QueryInterfaceFrom<T>(T fromObject) where T : ComObject
		{
			IntPtr nativePointer;
			fromObject.QueryInterface(Utilities.GetGuidFromType(base.GetType()), out nativePointer);
			base.NativePointer = nativePointer;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000025C8 File Offset: 0x000007C8
		Result IUnknown.QueryInterface(ref Guid guid, out IntPtr comObject)
		{
			return Marshal.QueryInterface(base.NativePointer, ref guid, out comObject);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000025DC File Offset: 0x000007DC
		int IUnknown.AddReference()
		{
			if (base.NativePointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("COM Object pointer is null");
			}
			return Marshal.AddRef(base.NativePointer);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002606 File Offset: 0x00000806
		int IUnknown.Release()
		{
			if (base.NativePointer == IntPtr.Zero)
			{
				throw new InvalidOperationException("COM Object pointer is null");
			}
			return Marshal.Release(base.NativePointer);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002630 File Offset: 0x00000830
		protected override void Dispose(bool disposing)
		{
			if (base.NativePointer != IntPtr.Zero)
			{
				if (!disposing && Configuration.EnableTrackingReleaseOnFinalizer && !Configuration.EnableReleaseOnFinalizer)
				{
					ObjectReference arg = ObjectTracker.Find(this);
					Action<string> logMemoryLeakWarning = ComObject.LogMemoryLeakWarning;
					if (logMemoryLeakWarning != null)
					{
						logMemoryLeakWarning(string.Format("Warning: Live ComObject [0x{0:X}], potential memory leak: {1}", base.NativePointer.ToInt64(), arg));
					}
				}
				if (disposing || Configuration.EnableReleaseOnFinalizer)
				{
					((IUnknown)this).Release();
				}
				if (Configuration.EnableObjectTracking)
				{
					ObjectTracker.UnTrack(this);
				}
				this._nativePointer = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000026C2 File Offset: 0x000008C2
		protected override void NativePointerUpdating()
		{
			if (Configuration.EnableObjectTracking)
			{
				ObjectTracker.UnTrack(this);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000026D1 File Offset: 0x000008D1
		protected override void NativePointerUpdated(IntPtr oldNativePointer)
		{
			if (Configuration.EnableObjectTracking)
			{
				ObjectTracker.Track(this);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000026E0 File Offset: 0x000008E0
		public ComObject(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000026E9 File Offset: 0x000008E9
		public static explicit operator ComObject(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComObject(nativePtr);
			}
			return null;
		}

		// Token: 0x04000006 RID: 6
		public static Action<string> LogMemoryLeakWarning = delegate(string warning)
		{
		};
	}
}
