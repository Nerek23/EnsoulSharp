using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000042 RID: 66
	[Guid("da6fea51-564c-4487-9810-f0d0f9b4e3a5")]
	public class SamplerState : DeviceChild
	{
		// Token: 0x060002C5 RID: 709 RVA: 0x0000B4C3 File Offset: 0x000096C3
		public SamplerState(Device device, SamplerStateDescription description) : base(IntPtr.Zero)
		{
			device.CreateSamplerState(ref description, this);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00002075 File Offset: 0x00000275
		public SamplerState(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000B4D9 File Offset: 0x000096D9
		public new static explicit operator SamplerState(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SamplerState(nativePtr);
			}
			return null;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000B4F0 File Offset: 0x000096F0
		public SamplerStateDescription Description
		{
			get
			{
				SamplerStateDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000B508 File Offset: 0x00009708
		internal unsafe void GetDescription(out SamplerStateDescription descRef)
		{
			descRef = default(SamplerStateDescription);
			fixed (SamplerStateDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
