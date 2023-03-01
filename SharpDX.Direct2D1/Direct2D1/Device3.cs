using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C8 RID: 456
	[Guid("852f2087-802c-4037-ab60-ff2e7ee6fc01")]
	public class Device3 : Device2
	{
		// Token: 0x060008E4 RID: 2276 RVA: 0x00019383 File Offset: 0x00017583
		public Device3(Factory4 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00019398 File Offset: 0x00017598
		public Device3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x000193A1 File Offset: 0x000175A1
		public new static explicit operator Device3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device3(nativePtr);
			}
			return null;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x000193B8 File Offset: 0x000175B8
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext3 deviceContext3)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			deviceContext3.NativePointer = zero;
			result.CheckError();
		}
	}
}
