using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006A RID: 106
	[Guid("8a6bb301-7e7e-41F4-a8e0-5b32f7f99b18")]
	public class Output3 : Output2
	{
		// Token: 0x060001C2 RID: 450 RVA: 0x000071D9 File Offset: 0x000053D9
		public Output3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000071E2 File Offset: 0x000053E2
		public new static explicit operator Output3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output3(nativePtr);
			}
			return null;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000071FC File Offset: 0x000053FC
		public unsafe OverlaySupportFlags CheckOverlaySupport(Format enumFormat, IUnknown concernedDeviceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(concernedDeviceRef);
			OverlaySupportFlags result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, enumFormat, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
