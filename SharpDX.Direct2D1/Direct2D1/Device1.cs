using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C6 RID: 454
	[Guid("d21768e1-23a4-4823-a14b-7c3eba85d658")]
	public class Device1 : Device
	{
		// Token: 0x060008D5 RID: 2261 RVA: 0x0001919B File Offset: 0x0001739B
		public Device1(Factory2 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000191B0 File Offset: 0x000173B0
		public Device1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x000191B9 File Offset: 0x000173B9
		public new static explicit operator Device1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x000191D0 File Offset: 0x000173D0
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x000191D8 File Offset: 0x000173D8
		public RenderingPriority RenderingPriority
		{
			get
			{
				return this.GetRenderingPriority();
			}
			set
			{
				this.SetRenderingPriority(value);
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000191E1 File Offset: 0x000173E1
		internal unsafe RenderingPriority GetRenderingPriority()
		{
			return calli(SharpDX.Direct2D1.RenderingPriority(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00015B00 File Offset: 0x00013D00
		internal unsafe void SetRenderingPriority(RenderingPriority renderingPriority)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, renderingPriority, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00019204 File Offset: 0x00017404
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext1 deviceContext1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			deviceContext1.NativePointer = zero;
			result.CheckError();
		}
	}
}
