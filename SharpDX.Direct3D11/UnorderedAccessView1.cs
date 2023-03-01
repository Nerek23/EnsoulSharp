using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004F RID: 79
	[Guid("7b3b6153-a886-4544-ab37-6537c8500403")]
	public class UnorderedAccessView1 : UnorderedAccessView
	{
		// Token: 0x0600030D RID: 781 RVA: 0x0000BE9C File Offset: 0x0000A09C
		public UnorderedAccessView1(Device3 device, Resource resource) : base(IntPtr.Zero)
		{
			device.CreateUnorderedAccessView1(resource, null, this);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000BEC5 File Offset: 0x0000A0C5
		public UnorderedAccessView1(Device3 device, Resource resource, UnorderedAccessViewDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateUnorderedAccessView1(resource, new UnorderedAccessViewDescription1?(description), this);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000BEE0 File Offset: 0x0000A0E0
		public UnorderedAccessView1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000BEE9 File Offset: 0x0000A0E9
		public new static explicit operator UnorderedAccessView1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new UnorderedAccessView1(nativePtr);
			}
			return null;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000BF00 File Offset: 0x0000A100
		public UnorderedAccessViewDescription1 Description1
		{
			get
			{
				UnorderedAccessViewDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0000BF18 File Offset: 0x0000A118
		internal unsafe void GetDescription1(out UnorderedAccessViewDescription1 desc1Ref)
		{
			desc1Ref = default(UnorderedAccessViewDescription1);
			fixed (UnorderedAccessViewDescription1* ptr = &desc1Ref)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
