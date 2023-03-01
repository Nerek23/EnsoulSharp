using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C7 RID: 455
	[Guid("a44472e1-8dfb-4e60-8492-6e2861c9ca8b")]
	public class Device2 : Device1
	{
		// Token: 0x060008DD RID: 2269 RVA: 0x0001924D File Offset: 0x0001744D
		public Device2(Factory3 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00019262 File Offset: 0x00017462
		public Device2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001926B File Offset: 0x0001746B
		public new static explicit operator Device2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x00019284 File Offset: 0x00017484
		public Device DxgiDevice
		{
			get
			{
				Device result;
				this.GetDxgiDevice(out result);
				return result;
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0001929C File Offset: 0x0001749C
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext2 deviceContext2)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			deviceContext2.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000192E8 File Offset: 0x000174E8
		public unsafe void FlushDeviceContexts(Bitmap bitmap)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00019328 File Offset: 0x00017528
		internal unsafe void GetDxgiDevice(out Device dxgiDevice)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				dxgiDevice = new Device(zero);
			}
			else
			{
				dxgiDevice = null;
			}
			result.CheckError();
		}
	}
}
