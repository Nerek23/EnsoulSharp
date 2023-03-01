using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000063 RID: 99
	[Guid("4C8798B7-1D88-4A0F-B59B-B93F600DE8C8")]
	public class ISurfaceImageSourceManagerNative : ComObject
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000272E File Offset: 0x0000092E
		public ISurfaceImageSourceManagerNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006D29 File Offset: 0x00004F29
		public new static explicit operator ISurfaceImageSourceManagerNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISurfaceImageSourceManagerNative(nativePtr);
			}
			return null;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00006D40 File Offset: 0x00004F40
		public unsafe void FlushAllSurfacesWithDevice(IUnknown device)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(device);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
