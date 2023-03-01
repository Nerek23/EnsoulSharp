using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000044 RID: 68
	[Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2")]
	public class ShaderResourceView : ResourceView
	{
		// Token: 0x060002CB RID: 715 RVA: 0x0000B5C0 File Offset: 0x000097C0
		public ShaderResourceView(Device device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateShaderResourceView(resource, null, this);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000B5E9 File Offset: 0x000097E9
		public ShaderResourceView(Device device, Resource resource, ShaderResourceViewDescription description) : base(IntPtr.Zero)
		{
			device.CreateShaderResourceView(resource, new ShaderResourceViewDescription?(description), this);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00002F64 File Offset: 0x00001164
		public ShaderResourceView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000B604 File Offset: 0x00009804
		public new static explicit operator ShaderResourceView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ShaderResourceView(nativePtr);
			}
			return null;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002CF RID: 719 RVA: 0x0000B61C File Offset: 0x0000981C
		public ShaderResourceViewDescription Description
		{
			get
			{
				ShaderResourceViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000B634 File Offset: 0x00009834
		internal unsafe void GetDescription(out ShaderResourceViewDescription descRef)
		{
			descRef = default(ShaderResourceViewDescription);
			fixed (ShaderResourceViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
