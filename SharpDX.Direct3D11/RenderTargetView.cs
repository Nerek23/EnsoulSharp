using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003D RID: 61
	[Guid("dfdba067-0b8d-4865-875b-d7b4516cc164")]
	public class RenderTargetView : ResourceView
	{
		// Token: 0x060002A7 RID: 679 RVA: 0x0000B1C8 File Offset: 0x000093C8
		public RenderTargetView(Device device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateRenderTargetView(resource, null, this);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000B1F1 File Offset: 0x000093F1
		public RenderTargetView(Device device, Resource resource, RenderTargetViewDescription description) : base(IntPtr.Zero)
		{
			device.CreateRenderTargetView(resource, new RenderTargetViewDescription?(description), this);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00002F64 File Offset: 0x00001164
		public RenderTargetView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000B20C File Offset: 0x0000940C
		public new static explicit operator RenderTargetView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderTargetView(nativePtr);
			}
			return null;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000B224 File Offset: 0x00009424
		public RenderTargetViewDescription Description
		{
			get
			{
				RenderTargetViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000B23C File Offset: 0x0000943C
		internal unsafe void GetDescription(out RenderTargetViewDescription descRef)
		{
			descRef = default(RenderTargetViewDescription);
			fixed (RenderTargetViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
