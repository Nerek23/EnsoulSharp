using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000176 RID: 374
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorCaps
	{
		// Token: 0x04000B41 RID: 2881
		public int DeviceCaps;

		// Token: 0x04000B42 RID: 2882
		public int FeatureCaps;

		// Token: 0x04000B43 RID: 2883
		public int FilterCaps;

		// Token: 0x04000B44 RID: 2884
		public int InputFormatCaps;

		// Token: 0x04000B45 RID: 2885
		public int AutoStreamCaps;

		// Token: 0x04000B46 RID: 2886
		public int StereoCaps;

		// Token: 0x04000B47 RID: 2887
		public int RateConversionCapsCount;

		// Token: 0x04000B48 RID: 2888
		public int MaxInputStreams;

		// Token: 0x04000B49 RID: 2889
		public int MaxStreamStates;
	}
}
