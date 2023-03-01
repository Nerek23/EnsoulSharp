using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006B RID: 107
	[Guid("dc7dca35-2196-414d-9F53-617884032a60")]
	public class Output4 : Output3
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x0000724C File Offset: 0x0000544C
		public Output4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00007255 File Offset: 0x00005455
		public new static explicit operator Output4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output4(nativePtr);
			}
			return null;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000726C File Offset: 0x0000546C
		public unsafe OverlayColorSpaceSupportFlags CheckOverlayColorSpaceSupport(Format format, ColorSpaceType colorSpace, IUnknown concernedDeviceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(concernedDeviceRef);
			OverlayColorSpaceSupportFlags result;
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, format, colorSpace, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
