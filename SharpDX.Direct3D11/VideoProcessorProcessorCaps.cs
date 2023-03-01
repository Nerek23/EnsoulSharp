using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000A5 RID: 165
	public enum VideoProcessorProcessorCaps
	{
		// Token: 0x0400086F RID: 2159
		DeinterlaceBlend = 1,
		// Token: 0x04000870 RID: 2160
		DeinterlaceBob,
		// Token: 0x04000871 RID: 2161
		DeinterlaceAdaptive = 4,
		// Token: 0x04000872 RID: 2162
		DeinterlaceMotionCompensation = 8,
		// Token: 0x04000873 RID: 2163
		InverseTelecine = 16,
		// Token: 0x04000874 RID: 2164
		FrameRateConversion = 32
	}
}
