using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000303 RID: 771
	[Guid("bd4ec2d2-0662-4bee-ba8e-6f29f032e096")]
	public class Factory4 : Factory3
	{
		// Token: 0x06000D9A RID: 3482 RVA: 0x00025B4B File Offset: 0x00023D4B
		public Factory4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00025B54 File Offset: 0x00023D54
		public new static explicit operator Factory4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory4(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00025B6C File Offset: 0x00023D6C
		internal unsafe void CreateDevice(Device dxgiDevice, Device3 d2dDevice3)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(dxgiDevice);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			d2dDevice3.NativePointer = zero;
			result.CheckError();
		}
	}
}
