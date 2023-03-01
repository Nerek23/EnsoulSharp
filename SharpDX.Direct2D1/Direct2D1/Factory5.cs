using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000304 RID: 772
	[Guid("c4349994-838e-4b0f-8cab-44997d9eeacc")]
	public class Factory5 : Factory4
	{
		// Token: 0x06000D9D RID: 3485 RVA: 0x00025BC7 File Offset: 0x00023DC7
		public Factory5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00025BD0 File Offset: 0x00023DD0
		public new static explicit operator Factory5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory5(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x00025BE8 File Offset: 0x00023DE8
		internal unsafe void CreateDevice(Device dxgiDevice, Device4 d2dDevice4)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			d2dDevice4.NativePointer = zero;
			result.CheckError();
		}
	}
}
