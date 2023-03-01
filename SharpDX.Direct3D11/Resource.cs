using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003F RID: 63
	[Guid("dc8e63f3-d12b-4952-b47b-5e45026a862d")]
	public class Resource : DeviceChild
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0000B32F File Offset: 0x0000952F
		public static T FromSwapChain<T>(SwapChain swapChain, int index) where T : Resource
		{
			return swapChain.GetBackBuffer<T>(index);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000B338 File Offset: 0x00009538
		public static int CalculateSubResourceIndex(int mipSlice, int arraySlice, int mipLevel)
		{
			return mipLevel * arraySlice + mipSlice;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000B33F File Offset: 0x0000953F
		public static int CalculateMipSize(int mipLevel, int baseSize)
		{
			baseSize >>= mipLevel;
			if (baseSize <= 0)
			{
				return 1;
			}
			return baseSize;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000B350 File Offset: 0x00009550
		public virtual int CalculateSubResourceIndex(int mipSlice, int arraySlice, out int mipSize)
		{
			throw new NotImplementedException("This method is not implemented for this kind of resource");
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00002075 File Offset: 0x00000275
		public Resource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000B35C File Offset: 0x0000955C
		public new static explicit operator Resource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Resource(nativePtr);
			}
			return null;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000B374 File Offset: 0x00009574
		public ResourceDimension Dimension
		{
			get
			{
				ResourceDimension result;
				this.GetDimension(out result);
				return result;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000B38A File Offset: 0x0000958A
		// (set) Token: 0x060002BB RID: 699 RVA: 0x0000B392 File Offset: 0x00009592
		public int EvictionPriority
		{
			get
			{
				return this.GetEvictionPriority();
			}
			set
			{
				this.SetEvictionPriority(value);
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000B39C File Offset: 0x0000959C
		internal unsafe void GetDimension(out ResourceDimension resourceDimensionRef)
		{
			fixed (ResourceDimension* ptr = &resourceDimensionRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000B3CF File Offset: 0x000095CF
		internal unsafe void SetEvictionPriority(int evictionPriority)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, evictionPriority, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000B3EF File Offset: 0x000095EF
		internal unsafe int GetEvictionPriority()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x040000CE RID: 206
		public const int MaximumMipLevels = 15;

		// Token: 0x040000CF RID: 207
		public const int ResourceSizeInMegabytes = 128;

		// Token: 0x040000D0 RID: 208
		public const int MaximumTexture1DArraySize = 2048;

		// Token: 0x040000D1 RID: 209
		public const int MaximumTexture2DArraySize = 2048;

		// Token: 0x040000D2 RID: 210
		public const int MaximumTexture1DSize = 16384;

		// Token: 0x040000D3 RID: 211
		public const int MaximumTexture2DSize = 16384;

		// Token: 0x040000D4 RID: 212
		public const int MaximumTexture3DSize = 2048;

		// Token: 0x040000D5 RID: 213
		public const int MaximumTextureCubeSize = 16384;
	}
}
