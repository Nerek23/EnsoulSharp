using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200015E RID: 350
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct UnorderedAccessViewDescription
	{
		// Token: 0x04000AC6 RID: 2758
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000AC7 RID: 2759
		[FieldOffset(4)]
		public UnorderedAccessViewDimension Dimension;

		// Token: 0x04000AC8 RID: 2760
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.BufferResource Buffer;

		// Token: 0x04000AC9 RID: 2761
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000ACA RID: 2762
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000ACB RID: 2763
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture2DResource Texture2D;

		// Token: 0x04000ACC RID: 2764
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000ACD RID: 2765
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture3DResource Texture3D;

		// Token: 0x0200015F RID: 351
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct BufferResource
		{
			// Token: 0x04000ACE RID: 2766
			public int FirstElement;

			// Token: 0x04000ACF RID: 2767
			public int ElementCount;

			// Token: 0x04000AD0 RID: 2768
			public UnorderedAccessViewBufferFlags Flags;
		}

		// Token: 0x02000160 RID: 352
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DResource
		{
			// Token: 0x04000AD1 RID: 2769
			public int MipSlice;
		}

		// Token: 0x02000161 RID: 353
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture1DArrayResource
		{
			// Token: 0x04000AD2 RID: 2770
			public int MipSlice;

			// Token: 0x04000AD3 RID: 2771
			public int FirstArraySlice;

			// Token: 0x04000AD4 RID: 2772
			public int ArraySize;
		}

		// Token: 0x02000162 RID: 354
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x04000AD5 RID: 2773
			public int MipSlice;
		}

		// Token: 0x02000163 RID: 355
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000AD6 RID: 2774
			public int MipSlice;

			// Token: 0x04000AD7 RID: 2775
			public int FirstArraySlice;

			// Token: 0x04000AD8 RID: 2776
			public int ArraySize;
		}

		// Token: 0x02000164 RID: 356
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture3DResource
		{
			// Token: 0x04000AD9 RID: 2777
			public int MipSlice;

			// Token: 0x04000ADA RID: 2778
			public int FirstWSlice;

			// Token: 0x04000ADB RID: 2779
			public int WSize;
		}
	}
}
