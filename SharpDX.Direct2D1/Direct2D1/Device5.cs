using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CA RID: 458
	[Guid("d55ba0a4-6405-4694-aef5-08ee1a4358b4")]
	public class Device5 : Device4
	{
		// Token: 0x060008F0 RID: 2288 RVA: 0x000194D2 File Offset: 0x000176D2
		public Device5(Factory6 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000194E7 File Offset: 0x000176E7
		public Device5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x000194F0 File Offset: 0x000176F0
		public new static explicit operator Device5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device5(nativePtr);
			}
			return null;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00019508 File Offset: 0x00017708
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext5 deviceContext5)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			deviceContext5.NativePointer = zero;
			result.CheckError();
		}
	}
}
