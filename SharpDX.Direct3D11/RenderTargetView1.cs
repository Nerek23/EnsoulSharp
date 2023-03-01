using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003E RID: 62
	[Guid("ffbe2e23-f011-418a-ac56-5ceed7c5b94b")]
	public class RenderTargetView1 : RenderTargetView
	{
		// Token: 0x060002AD RID: 685 RVA: 0x0000B278 File Offset: 0x00009478
		public RenderTargetView1(Device3 device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateRenderTargetView1(resource, null, this);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000B2A1 File Offset: 0x000094A1
		public RenderTargetView1(Device3 device, Resource resource, RenderTargetViewDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateRenderTargetView1(resource, new RenderTargetViewDescription1?(description), this);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000B2BC File Offset: 0x000094BC
		public RenderTargetView1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000B2C5 File Offset: 0x000094C5
		public new static explicit operator RenderTargetView1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderTargetView1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000B2DC File Offset: 0x000094DC
		public RenderTargetViewDescription1 Description1
		{
			get
			{
				RenderTargetViewDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000B2F4 File Offset: 0x000094F4
		internal unsafe void GetDescription1(out RenderTargetViewDescription1 desc1Ref)
		{
			desc1Ref = default(RenderTargetViewDescription1);
			fixed (RenderTargetViewDescription1* ptr = &desc1Ref)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
