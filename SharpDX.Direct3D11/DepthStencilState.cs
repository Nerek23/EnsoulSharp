using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000010 RID: 16
	[Guid("03823efb-8d8f-4e1c-9aa2-f64bb2cbfdf1")]
	public class DepthStencilState : DeviceChild
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00002DDF File Offset: 0x00000FDF
		public DepthStencilState(Device device, DepthStencilStateDescription description) : base(IntPtr.Zero)
		{
			device.CreateDepthStencilState(ref description, this);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002075 File Offset: 0x00000275
		public DepthStencilState(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002DF5 File Offset: 0x00000FF5
		public new static explicit operator DepthStencilState(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DepthStencilState(nativePtr);
			}
			return null;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002E0C File Offset: 0x0000100C
		public DepthStencilStateDescription Description
		{
			get
			{
				DepthStencilStateDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E24 File Offset: 0x00001024
		internal unsafe void GetDescription(out DepthStencilStateDescription descRef)
		{
			descRef = default(DepthStencilStateDescription);
			fixed (DepthStencilStateDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
