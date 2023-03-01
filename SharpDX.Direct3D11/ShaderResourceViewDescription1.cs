using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200014D RID: 333
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ShaderResourceViewDescription1
	{
		// Token: 0x04000A68 RID: 2664
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000A69 RID: 2665
		[FieldOffset(4)]
		public ShaderResourceViewDimension Dimension;

		// Token: 0x04000A6A RID: 2666
		[FieldOffset(8)]
		public ShaderResourceViewDescription.BufferResource Buffer;

		// Token: 0x04000A6B RID: 2667
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000A6C RID: 2668
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000A6D RID: 2669
		[FieldOffset(8)]
		public ShaderResourceViewDescription1.Texture2DResource1 Texture2D;

		// Token: 0x04000A6E RID: 2670
		[FieldOffset(8)]
		public ShaderResourceViewDescription1.Texture2DArrayResource1 Texture2DArray;

		// Token: 0x04000A6F RID: 2671
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DMultisampledResource Texture2DMS;

		// Token: 0x04000A70 RID: 2672
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DMultisampledArrayResource Texture2DMSArray;

		// Token: 0x04000A71 RID: 2673
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture3DResource Texture3D;

		// Token: 0x04000A72 RID: 2674
		[FieldOffset(8)]
		public ShaderResourceViewDescription.TextureCubeResource TextureCube;

		// Token: 0x04000A73 RID: 2675
		[FieldOffset(8)]
		public ShaderResourceViewDescription.TextureCubeArrayResource TextureCubeArray;

		// Token: 0x04000A74 RID: 2676
		[FieldOffset(8)]
		public ShaderResourceViewDescription.ExtendedBufferResource BufferEx;

		// Token: 0x0200014E RID: 334
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource1
		{
			// Token: 0x04000A75 RID: 2677
			public int MostDetailedMip;

			// Token: 0x04000A76 RID: 2678
			public int MipLevels;

			// Token: 0x04000A77 RID: 2679
			public int PlaneSlice;
		}

		// Token: 0x0200014F RID: 335
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource1
		{
			// Token: 0x04000A78 RID: 2680
			public int MostDetailedMip;

			// Token: 0x04000A79 RID: 2681
			public int MipLevels;

			// Token: 0x04000A7A RID: 2682
			public int FirstArraySlice;

			// Token: 0x04000A7B RID: 2683
			public int ArraySize;

			// Token: 0x04000A7C RID: 2684
			public int PlaneSlice;
		}
	}
}
