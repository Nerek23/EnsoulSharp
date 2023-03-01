using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000135 RID: 309
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct RenderTargetViewDescription
	{
		// Token: 0x04000A11 RID: 2577
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000A12 RID: 2578
		[FieldOffset(4)]
		public RenderTargetViewDimension Dimension;

		// Token: 0x04000A13 RID: 2579
		[FieldOffset(8)]
		public RenderTargetViewDescription.BufferResource Buffer;

		// Token: 0x04000A14 RID: 2580
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000A15 RID: 2581
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000A16 RID: 2582
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DResource Texture2D;

		// Token: 0x04000A17 RID: 2583
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000A18 RID: 2584
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DMultisampledResource Texture2DMS;

		// Token: 0x04000A19 RID: 2585
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture2DMultisampledArrayResource Texture2DMSArray;

		// Token: 0x04000A1A RID: 2586
		[FieldOffset(8)]
		public RenderTargetViewDescription.Texture3DResource Texture3D;

		// Token: 0x02000136 RID: 310
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct BufferResource
		{
			// Token: 0x04000A1B RID: 2587
			[FieldOffset(0)]
			public int FirstElement;

			// Token: 0x04000A1C RID: 2588
			[FieldOffset(0)]
			public int ElementOffset;

			// Token: 0x04000A1D RID: 2589
			[FieldOffset(4)]
			public int ElementCount;

			// Token: 0x04000A1E RID: 2590
			[FieldOffset(4)]
			public int ElementWidth;
		}

		// Token: 0x02000137 RID: 311
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DResource
		{
			// Token: 0x04000A1F RID: 2591
			public int MipSlice;
		}

		// Token: 0x02000138 RID: 312
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DArrayResource
		{
			// Token: 0x04000A20 RID: 2592
			public int MipSlice;

			// Token: 0x04000A21 RID: 2593
			public int FirstArraySlice;

			// Token: 0x04000A22 RID: 2594
			public int ArraySize;
		}

		// Token: 0x02000139 RID: 313
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x04000A23 RID: 2595
			public int MipSlice;
		}

		// Token: 0x0200013A RID: 314
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledResource
		{
			// Token: 0x04000A24 RID: 2596
			public int UnusedFieldNothingToDefine;
		}

		// Token: 0x0200013B RID: 315
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000A25 RID: 2597
			public int MipSlice;

			// Token: 0x04000A26 RID: 2598
			public int FirstArraySlice;

			// Token: 0x04000A27 RID: 2599
			public int ArraySize;
		}

		// Token: 0x0200013C RID: 316
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DMultisampledArrayResource
		{
			// Token: 0x04000A28 RID: 2600
			public int FirstArraySlice;

			// Token: 0x04000A29 RID: 2601
			public int ArraySize;
		}

		// Token: 0x0200013D RID: 317
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture3DResource
		{
			// Token: 0x04000A2A RID: 2602
			public int MipSlice;

			// Token: 0x04000A2B RID: 2603
			public int FirstDepthSlice;

			// Token: 0x04000A2C RID: 2604
			public int DepthSliceCount;
		}
	}
}
