using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000302 RID: 770
	[Guid("0869759f-4f00-413f-b03e-2bda45404d0f")]
	public class Factory3 : Factory2
	{
		// Token: 0x06000D97 RID: 3479 RVA: 0x00025ACD File Offset: 0x00023CCD
		public Factory3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00025AD6 File Offset: 0x00023CD6
		public new static explicit operator Factory3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory3(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00025AF0 File Offset: 0x00023CF0
		internal unsafe void CreateDevice(Device dxgiDevice, Device2 d2dDevice2)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			d2dDevice2.NativePointer = zero;
			result.CheckError();
		}
	}
}
