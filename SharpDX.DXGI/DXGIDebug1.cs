using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200000A RID: 10
	[Guid("c5a05f0c-16f2-4adf-9f4d-a8c4d58ac550")]
	public class DXGIDebug1 : DXGIDebug
	{
		// Token: 0x0600002C RID: 44 RVA: 0x0000278C File Offset: 0x0000098C
		public new static DXGIDebug1 TryCreate()
		{
			IntPtr nativePtr;
			if (!DebugInterface.TryCreateComPtr<DXGIDebug1>(out nativePtr))
			{
				return null;
			}
			return new DXGIDebug1(nativePtr);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000027AA File Offset: 0x000009AA
		public DXGIDebug1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000027B3 File Offset: 0x000009B3
		public new static explicit operator DXGIDebug1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DXGIDebug1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000027CA File Offset: 0x000009CA
		public RawBool IsLeakTrackingEnabledForThread
		{
			get
			{
				return this.IsLeakTrackingEnabledForThread_();
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000027D2 File Offset: 0x000009D2
		public unsafe void EnableLeakTrackingForThread()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000027F1 File Offset: 0x000009F1
		public unsafe void DisableLeakTrackingForThread()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002810 File Offset: 0x00000A10
		internal unsafe RawBool IsLeakTrackingEnabledForThread_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}
	}
}
