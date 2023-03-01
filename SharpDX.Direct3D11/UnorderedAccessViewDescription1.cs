using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000165 RID: 357
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct UnorderedAccessViewDescription1
	{
		// Token: 0x04000ADC RID: 2780
		[FieldOffset(0)]
		public Format Format;

		// Token: 0x04000ADD RID: 2781
		[FieldOffset(4)]
		public UnorderedAccessViewDimension Dimension;

		// Token: 0x04000ADE RID: 2782
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.BufferResource Buffer;

		// Token: 0x04000ADF RID: 2783
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture1DResource Texture1D;

		// Token: 0x04000AE0 RID: 2784
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture1DArrayResource Texture1DArray;

		// Token: 0x04000AE1 RID: 2785
		[FieldOffset(8)]
		public UnorderedAccessViewDescription1.Texture2DResource Texture2D;

		// Token: 0x04000AE2 RID: 2786
		[FieldOffset(8)]
		public UnorderedAccessViewDescription1.Texture2DArrayResource Texture2DArray;

		// Token: 0x04000AE3 RID: 2787
		[FieldOffset(8)]
		public UnorderedAccessViewDescription.Texture3DResource Texture3D;

		// Token: 0x02000166 RID: 358
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DResource
		{
			// Token: 0x04000AE4 RID: 2788
			public int MipSlice;

			// Token: 0x04000AE5 RID: 2789
			public int PlaneSlice;
		}

		// Token: 0x02000167 RID: 359
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct Texture2DArrayResource
		{
			// Token: 0x04000AE6 RID: 2790
			public int MipSlice;

			// Token: 0x04000AE7 RID: 2791
			public int FirstArraySlice;

			// Token: 0x04000AE8 RID: 2792
			public int ArraySize;

			// Token: 0x04000AE9 RID: 2793
			public int PlaneSlice;
		}
	}
}
