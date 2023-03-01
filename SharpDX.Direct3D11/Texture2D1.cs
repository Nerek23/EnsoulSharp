using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200004B RID: 75
	[Guid("51218251-1E33-4617-9CCB-4D3A4367E7BB")]
	public class Texture2D1 : Texture2D
	{
		// Token: 0x060002F1 RID: 753 RVA: 0x0000BB03 File Offset: 0x00009D03
		public Texture2D1(Device3 device, Texture2DDescription1 description) : base(IntPtr.Zero)
		{
			device.CreateTexture2D1(ref description, null, this);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000BB1C File Offset: 0x00009D1C
		public Texture2D1(Device3 device, Texture2DDescription1 description, params DataRectangle[] data) : base(IntPtr.Zero)
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
			device.CreateTexture2D1(ref description, array, this);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000BB8E File Offset: 0x00009D8E
		public Texture2D1(Device3 device, Texture2DDescription1 description, DataBox[] data) : base(IntPtr.Zero)
		{
			device.CreateTexture2D1(ref description, data, this);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000BBA8 File Offset: 0x00009DA8
		public override int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			Texture2DDescription description = base.Description;
			mipSize = Resource.CalculateMipSize(mipSlice, description.Height);
			return Resource.CalculateSubResourceIndex(mipSlice, arraySlice, description.MipLevels);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000BBD7 File Offset: 0x00009DD7
		public Texture2D1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000BBE0 File Offset: 0x00009DE0
		public new static explicit operator Texture2D1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Texture2D1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000BBF8 File Offset: 0x00009DF8
		public Texture2DDescription1 Description1
		{
			get
			{
				Texture2DDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000BC10 File Offset: 0x00009E10
		internal unsafe void GetDescription1(out Texture2DDescription1 descRef)
		{
			descRef = default(Texture2DDescription1);
			fixed (Texture2DDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
