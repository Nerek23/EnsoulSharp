using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200017D RID: 381
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorRateConversionCaps
	{
		// Token: 0x04000B66 RID: 2918
		public int PastFrames;

		// Token: 0x04000B67 RID: 2919
		public int FutureFrames;

		// Token: 0x04000B68 RID: 2920
		public int ProcessorCaps;

		// Token: 0x04000B69 RID: 2921
		public int ITelecineCaps;

		// Token: 0x04000B6A RID: 2922
		public int CustomRateCount;
	}
}
