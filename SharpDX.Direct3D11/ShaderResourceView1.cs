using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000045 RID: 69
	[Guid("91308b87-9040-411d-8c67-c39253ce3802")]
	public class ShaderResourceView1 : ShaderResourceView
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x0000B670 File Offset: 0x00009870
		public ShaderResourceView1(Device3 device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateShaderResourceView1(resource, null, this);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B699 File Offset: 0x00009899
		public ShaderResourceView1(Device3 device, Resource resource, ShaderResourceViewDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateShaderResourceView1(resource, new ShaderResourceViewDescription1?(description), this);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B6B4 File Offset: 0x000098B4
		public ShaderResourceView1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B6BD File Offset: 0x000098BD
		public new static explicit operator ShaderResourceView1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ShaderResourceView1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x0000B6D4 File Offset: 0x000098D4
		public ShaderResourceViewDescription1 Description1
		{
			get
			{
				ShaderResourceViewDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B6EC File Offset: 0x000098EC
		internal unsafe void GetDescription1(out ShaderResourceViewDescription1 desc1Ref)
		{
			desc1Ref = default(ShaderResourceViewDescription1);
			fixed (ShaderResourceViewDescription1* ptr = &desc1Ref)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
