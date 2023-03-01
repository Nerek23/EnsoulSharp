using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000170 RID: 368
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoDecoderConfig
	{
		// Token: 0x04000B19 RID: 2841
		public Guid GuidConfigBitstreamEncryption;

		// Token: 0x04000B1A RID: 2842
		public Guid GuidConfigMBcontrolEncryption;

		// Token: 0x04000B1B RID: 2843
		public Guid GuidConfigResidDiffEncryption;

		// Token: 0x04000B1C RID: 2844
		public int ConfigBitstreamRaw;

		// Token: 0x04000B1D RID: 2845
		public int ConfigMBcontrolRasterOrder;

		// Token: 0x04000B1E RID: 2846
		public int ConfigResidDiffHost;

		// Token: 0x04000B1F RID: 2847
		public int ConfigSpatialResid8;

		// Token: 0x04000B20 RID: 2848
		public int ConfigResid8Subtraction;

		// Token: 0x04000B21 RID: 2849
		public int ConfigSpatialHost8or9Clipping;

		// Token: 0x04000B22 RID: 2850
		public int ConfigSpatialResidInterleaved;

		// Token: 0x04000B23 RID: 2851
		public int ConfigIntraResidUnsigned;

		// Token: 0x04000B24 RID: 2852
		public int ConfigResidDiffAccelerator;

		// Token: 0x04000B25 RID: 2853
		public int ConfigHostInverseScan;

		// Token: 0x04000B26 RID: 2854
		public int ConfigSpecificIDCT;

		// Token: 0x04000B27 RID: 2855
		public int Config4GroupedCoefs;

		// Token: 0x04000B28 RID: 2856
		public short ConfigMinRenderTargetBuffCount;

		// Token: 0x04000B29 RID: 2857
		public short ConfigDecoderSpecific;
	}
}
