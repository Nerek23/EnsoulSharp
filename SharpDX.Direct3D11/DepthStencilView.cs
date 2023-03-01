using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000012 RID: 18
	[Guid("9fdac92a-1876-48c3-afad-25b94f84a9b6")]
	public class DepthStencilView : ResourceView
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00002F20 File Offset: 0x00001120
		public DepthStencilView(Device device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateDepthStencilView(resource, null, this);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F49 File Offset: 0x00001149
		public DepthStencilView(Device device, Resource resource, DepthStencilViewDescription description) : base(IntPtr.Zero)
		{
			device.CreateDepthStencilView(resource, new DepthStencilViewDescription?(description), this);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F64 File Offset: 0x00001164
		public DepthStencilView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002F6D File Offset: 0x0000116D
		public new static explicit operator DepthStencilView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DepthStencilView(nativePtr);
			}
			return null;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002F84 File Offset: 0x00001184
		public DepthStencilViewDescription Description
		{
			get
			{
				DepthStencilViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002F9C File Offset: 0x0000119C
		internal unsafe void GetDescription(out DepthStencilViewDescription descRef)
		{
			descRef = default(DepthStencilViewDescription);
			fixed (DepthStencilViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
