using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004D RID: 77
	[Guid("0C711683-2853-4846-9BB0-F3E60639E46A")]
	public class Texture3D1 : Texture3D
	{
		// Token: 0x06000300 RID: 768 RVA: 0x0000BD17 File Offset: 0x00009F17
		public Texture3D1(Device3 device, Texture3DDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateTexture3D1(ref description, null, this);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000BD2E File Offset: 0x00009F2E
		public Texture3D1(Device3 device, Texture3DDescription1 description, DataBox[] data) : base(IntPtr.Zero)
		{
			device.CreateTexture3D1(ref description, data, this);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000BD48 File Offset: 0x00009F48
		public override int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			Texture3DDescription description = base.Description;
			mipSize = Resource.CalculateMipSize(mipSlice, description.Depth);
			return Resource.CalculateSubResourceIndex(mipSlice, arraySlice, description.MipLevels);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000BD77 File Offset: 0x00009F77
		public Texture3D1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000BD80 File Offset: 0x00009F80
		public new static explicit operator Texture3D1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Texture3D1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000BD98 File Offset: 0x00009F98
		public Texture3DDescription1 Description1
		{
			get
			{
				Texture3DDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		internal unsafe void GetDescription1(out Texture3DDescription1 descRef)
		{
			descRef = default(Texture3DDescription1);
			fixed (Texture3DDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
