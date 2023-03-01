using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004A RID: 74
	[Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
	public class Texture2D : Resource
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0000B9C3 File Offset: 0x00009BC3
		public Texture2D(Device device, Texture2DDescription description) : base(IntPtr.Zero)
		{
			device.CreateTexture2D(ref description, null, this);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000B9DC File Offset: 0x00009BDC
		public Texture2D(Device device, Texture2DDescription description, params DataRectangle[] data) : base(IntPtr.Zero)
		{
			DataBox[] array = null;
			if (data != null && data.Length != 0)
			{
				array = new DataBox[data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DataPointer = data[i].DataPointer;
					array[i].RowPitch = data[i].Pitch;
				}
			}
			device.CreateTexture2D(ref description, array, this);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000BA4E File Offset: 0x00009C4E
		public Texture2D(Device device, Texture2DDescription description, DataBox[] data) : base(IntPtr.Zero)
		{
			device.CreateTexture2D(ref description, data, this);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000BA68 File Offset: 0x00009C68
		public override int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			Texture2DDescription description = this.Description;
			mipSize = Resource.CalculateMipSize(mipSlice, description.Height);
			return Resource.CalculateSubResourceIndex(mipSlice, arraySlice, description.MipLevels);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000028DE File Offset: 0x00000ADE
		public Texture2D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000BA97 File Offset: 0x00009C97
		public new static explicit operator Texture2D(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Texture2D(nativePtr);
			}
			return null;
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000BAB0 File Offset: 0x00009CB0
		public Texture2DDescription Description
		{
			get
			{
				Texture2DDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		internal unsafe void GetDescription(out Texture2DDescription descRef)
		{
			descRef = default(Texture2DDescription);
			fixed (Texture2DDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
