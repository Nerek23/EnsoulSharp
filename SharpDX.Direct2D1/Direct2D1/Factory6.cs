using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000305 RID: 773
	[Guid("f9976f46-f642-44c1-97ca-da32ea2a2635")]
	public class Factory6 : Factory5
	{
		// Token: 0x06000DA0 RID: 3488 RVA: 0x00025C43 File Offset: 0x00023E43
		public Factory6(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00025C4C File Offset: 0x00023E4C
		public new static explicit operator Factory6(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory6(nativePtr);
			}
			return null;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00025C64 File Offset: 0x00023E64
		internal unsafe void CreateDevice(Device dxgiDevice, Device5 d2dDevice5)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			d2dDevice5.NativePointer = zero;
			result.CheckError();
		}
	}
}
