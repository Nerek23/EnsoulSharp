using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000049 RID: 73
	[Guid("f8fb5c27-c6b3-4f75-a4c8-439af2ef564c")]
	public class Texture1D : Resource
	{
		// Token: 0x060002E0 RID: 736 RVA: 0x0000B84E File Offset: 0x00009A4E
		public Texture1D(Device device, Texture1DDescription description) : base(IntPtr.Zero)
		{
			device.CreateTexture1D(ref description, null, this);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000B868 File Offset: 0x00009A68
		public Texture1D(Device device, Texture1DDescription description, params DataStream[] data) : base(IntPtr.Zero)
		{
			DataBox[] array = null;
			if (data != null && data.Length != 0)
			{
				array = new DataBox[data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DataPointer = data[i].DataPointer;
				}
			}
			device.CreateTexture1D(ref description, array, this);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		public Texture1D(Device device, Texture1DDescription description, params IntPtr[] data) : base(IntPtr.Zero)
		{
			DataBox[] array = null;
			if (data != null && data.Length != 0)
			{
				array = new DataBox[data.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].DataPointer = data[i];
				}
			}
			device.CreateTexture1D(ref description, array, this);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000B911 File Offset: 0x00009B11
		public Texture1D(Device device, Texture1DDescription description, DataBox[] data) : base(IntPtr.Zero)
		{
			device.CreateTexture1D(ref description, data, this);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000B928 File Offset: 0x00009B28
		public override int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			Texture1DDescription description = this.Description;
			mipSize = Resource.CalculateMipSize(mipSlice, description.Width);
			return Resource.CalculateSubResourceIndex(mipSlice, arraySlice, description.MipLevels);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000028DE File Offset: 0x00000ADE
		public Texture1D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000B957 File Offset: 0x00009B57
		public new static explicit operator Texture1D(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Texture1D(nativePtr);
			}
			return null;
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000B970 File Offset: 0x00009B70
		public Texture1DDescription Description
		{
			get
			{
				Texture1DDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000B988 File Offset: 0x00009B88
		internal unsafe void GetDescription(out Texture1DDescription descRef)
		{
			descRef = default(Texture1DDescription);
			fixed (Texture1DDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
