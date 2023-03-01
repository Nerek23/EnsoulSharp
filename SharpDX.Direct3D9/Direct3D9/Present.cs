using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000074 RID: 116
	[Flags]
	public enum Present
	{
		// Token: 0x04000753 RID: 1875
		BackBuffersMaximum = 3,
		// Token: 0x04000754 RID: 1876
		BackBuffersMaximumEx = 30,
		// Token: 0x04000755 RID: 1877
		DoNotWait = 1,
		// Token: 0x04000756 RID: 1878
		LinearContent = 2,
		// Token: 0x04000757 RID: 1879
		DoNotFlip = 4,
		// Token: 0x04000758 RID: 1880
		FlipRestart = 8,
		// Token: 0x04000759 RID: 1881
		VideoRestrictToMonitor = 16,
		// Token: 0x0400075A RID: 1882
		UpdateOverlayOnly = 32,
		// Token: 0x0400075B RID: 1883
		HideOverlay = 64,
		// Token: 0x0400075C RID: 1884
		UpdateColorKey = 128,
		// Token: 0x0400075D RID: 1885
		ForceImmediate = 256,
		// Token: 0x0400075E RID: 1886
		RateDefault = 0,
		// Token: 0x0400075F RID: 1887
		None = 0
	}
}
