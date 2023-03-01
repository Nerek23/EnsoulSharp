using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004E RID: 78
	[Guid("28acf509-7f5c-48f6-8611-f316010a6380")]
	public class UnorderedAccessView : ResourceView
	{
		// Token: 0x06000307 RID: 775 RVA: 0x0000BDEC File Offset: 0x00009FEC
		public UnorderedAccessView(Device device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateUnorderedAccessView(resource, null, this);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000BE15 File Offset: 0x0000A015
		public UnorderedAccessView(Device device, Resource resource, UnorderedAccessViewDescription description) : base(IntPtr.Zero)
		{
			device.CreateUnorderedAccessView(resource, new UnorderedAccessViewDescription?(description), this);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00002F64 File Offset: 0x00001164
		public UnorderedAccessView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000BE30 File Offset: 0x0000A030
		public new static explicit operator UnorderedAccessView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new UnorderedAccessView(nativePtr);
			}
			return null;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000BE48 File Offset: 0x0000A048
		public UnorderedAccessViewDescription Description
		{
			get
			{
				UnorderedAccessViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000BE60 File Offset: 0x0000A060
		internal unsafe void GetDescription(out UnorderedAccessViewDescription descRef)
		{
			descRef = default(UnorderedAccessViewDescription);
			fixed (UnorderedAccessViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
