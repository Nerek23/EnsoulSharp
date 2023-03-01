using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000141 RID: 321
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ShaderResourceViewDescription
	{
		// Token: 0x04000A3D RID: 2621
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000A3E RID: 2622
		[FieldOffset(4)]
		public ShaderResourceViewDimension Dimension;

		// Token: 0x04000A3F RID: 2623
		[FieldOffset(8)]
		public ShaderResourceViewDescription.BufferResource Buffer;

		// Token: 0x04000A40 RID: 2624
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000A41 RID: 2625
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000A42 RID: 2626
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DResource Texture2D;

		// Token: 0x04000A43 RID: 2627
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000A44 RID: 2628
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DMultisampledResource Texture2DMS;

		// Token: 0x04000A45 RID: 2629
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture2DMultisampledArrayResource Texture2DMSArray;

		// Token: 0x04000A46 RID: 2630
		[FieldOffset(8)]
		public ShaderResourceViewDescription.Texture3DResource Texture3D;

		// Token: 0x04000A47 RID: 2631
		[FieldOffset(8)]
		public ShaderResourceViewDescription.TextureCubeResource TextureCube;

		// Token: 0x04000A48 RID: 2632
		[FieldOffset(8)]
		public ShaderResourceViewDescription.TextureCubeArrayResource TextureCubeArray;

		// Token: 0x04000A49 RID: 2633
		[FieldOffset(8)]
		public ShaderResourceViewDescription.ExtendedBufferResource BufferEx;

		// Token: 0x02000142 RID: 322
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct BufferResource
		{
			// Token: 0x04000A4A RID: 2634
			[FieldOffset(0)]
			public int FirstElement;

			// Token: 0x04000A4B RID: 2635
			[FieldOffset(0)]
			public int ElementOffset;

			// Token: 0x04000A4C RID: 2636
			[FieldOffset(4)]
			public int ElementCount;

			// Token: 0x04000A4D RID: 2637
			[FieldOffset(4)]
			public int ElementWidth;
		}

		// Token: 0x02000143 RID: 323
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ExtendedBufferResource
		{
			// Token: 0x04000A4E RID: 2638
			public int FirstElement;

			// Token: 0x04000A4F RID: 2639
			public int ElementCount;

			// Token: 0x04000A50 RID: 2640
			public ShaderResourceViewExtendedBufferFlags Flags;
		}

		// Token: 0x02000144 RID: 324
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DResource
		{
			// Token: 0x04000A51 RID: 2641
			public int MostDetailedMip;

			// Token: 0x04000A52 RID: 2642
			public int MipLevels;
		}

		// Token: 0x02000145 RID: 325
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DArrayResource
		{
			// Token: 0x04000A53 RID: 2643
			public int MostDetailedMip;

			// Token: 0x04000A54 RID: 2644
			public int MipLevels;

			// Token: 0x04000A55 RID: 2645
			public int FirstArraySlice;

			// Token: 0x04000A56 RID: 2646
			public int ArraySize;
		}

		// Token: 0x02000146 RID: 326
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x04000A57 RID: 2647
			public int MostDetailedMip;

			// Token: 0x04000A58 RID: 2648
			public int MipLevels;
		}

		// Token: 0x02000147 RID: 327
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000A59 RID: 2649
			public int MostDetailedMip;

			// Token: 0x04000A5A RID: 2650
			public int MipLevels;

			// Token: 0x04000A5B RID: 2651
			public int FirstArraySlice;

			// Token: 0x04000A5C RID: 2652
			public int ArraySize;
		}

		// Token: 0x02000148 RID: 328
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture3DResource
		{
			// Token: 0x04000A5D RID: 2653
			public int MostDetailedMip;

			// Token: 0x04000A5E RID: 2654
			public int MipLevels;
		}

		// Token: 0x02000149 RID: 329
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TextureCubeResource
		{
			// Token: 0x04000A5F RID: 2655
			public int MostDetailedMip;

			// Token: 0x04000A60 RID: 2656
			public int MipLevels;
		}

		// Token: 0x0200014A RID: 330
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TextureCubeArrayResource
		{
			// Token: 0x04000A61 RID: 2657
			public int MostDetailedMip;

			// Token: 0x04000A62 RID: 2658
			public int MipLevels;

			// Token: 0x04000A63 RID: 2659
			public int First2DArrayFace;

			// Token: 0x04000A64 RID: 2660
			public int CubeCount;
		}

		// Token: 0x0200014B RID: 331
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledResource
		{
			// Token: 0x04000A65 RID: 2661
			public int UnusedFieldNothingToDefine;
		}

		// Token: 0x0200014C RID: 332
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledArrayResource
		{
			// Token: 0x04000A66 RID: 2662
			public int FirstArraySlice;

			// Token: 0x04000A67 RID: 2663
			public int ArraySize;
		}
	}
}
