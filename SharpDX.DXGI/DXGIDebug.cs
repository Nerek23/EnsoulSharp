using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000009 RID: 9
	[Guid("119E7452-DE9E-40fe-8806-88F90C12B441")]
	public class DXGIDebug : ComObject
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00002710 File Offset: 0x00000910
		public static DXGIDebug TryCreate()
		{
			IntPtr nativePtr;
			if (!DebugInterface.TryCreateComPtr<DXGIDebug>(out nativePtr))
			{
				return null;
			}
			return new DXGIDebug(nativePtr);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000272E File Offset: 0x0000092E
		public DXGIDebug(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002737 File Offset: 0x00000937
		public new static explicit operator DXGIDebug(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DXGIDebug(nativePtr);
			}
			return null;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002750 File Offset: 0x00000950
		public unsafe void ReportLiveObjects(Guid apiid, DebugRloFlags flags)
		{
			calli(System.Int32(System.Void*,System.Guid,System.Int32), this._nativePointer, apiid, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
