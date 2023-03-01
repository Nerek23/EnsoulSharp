using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004C RID: 76
	[Guid("037e866e-f56d-4357-a8af-9dabbe6e250e")]
	public class Texture3D : Resource
	{
		// Token: 0x060002F9 RID: 761 RVA: 0x0000BC4B File Offset: 0x00009E4B
		public Texture3D(Device device, Texture3DDescription description) : base(IntPtr.Zero)
		{
			device.CreateTexture3D(ref description, null, this);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000BC62 File Offset: 0x00009E62
		public Texture3D(Device device, Texture3DDescription description, DataBox[] data) : base(IntPtr.Zero)
		{
			device.CreateTexture3D(ref description, data, this);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000BC7C File Offset: 0x00009E7C
		public override int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			Texture3DDescription description = this.Description;
			mipSize = Resource.CalculateMipSize(mipSlice, description.Depth);
			return Resource.CalculateSubResourceIndex(mipSlice, arraySlice, description.MipLevels);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000028DE File Offset: 0x00000ADE
		public Texture3D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000BCAB File Offset: 0x00009EAB
		public new static explicit operator Texture3D(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Texture3D(nativePtr);
			}
			return null;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		public Texture3DDescription Description
		{
			get
			{
				Texture3DDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000BCDC File Offset: 0x00009EDC
		internal unsafe void GetDescription(out Texture3DDescription descRef)
		{
			descRef = default(Texture3DDescription);
			fixed (Texture3DDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
