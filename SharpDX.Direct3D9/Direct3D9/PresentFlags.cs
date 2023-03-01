using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000075 RID: 117
	[Flags]
	public enum PresentFlags
	{
		// Token: 0x04000761 RID: 1889
		LockableBackBuffer = 1,
		// Token: 0x04000762 RID: 1890
		DiscardDepthStencil = 2,
		// Token: 0x04000763 RID: 1891
		DeviceClip = 4,
		// Token: 0x04000764 RID: 1892
		Video = 16,
		// Token: 0x04000765 RID: 1893
		NoAutoRotate = 32,
		// Token: 0x04000766 RID: 1894
		UnprunedMode = 64,
		// Token: 0x04000767 RID: 1895
		OverlayLimitedRgb = 128,
		// Token: 0x04000768 RID: 1896
		OverlayYCbCrBt709 = 256,
		// Token: 0x04000769 RID: 1897
		OverlayYCbCrXvYCC = 512,
		// Token: 0x0400076A RID: 1898
		RestrictedContent = 1024,
		// Token: 0x0400076B RID: 1899
		RestrictSharedResourceDriver = 2048,
		// Token: 0x0400076C RID: 1900
		None = 0
	}
}
