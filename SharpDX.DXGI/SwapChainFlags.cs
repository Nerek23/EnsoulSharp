using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000050 RID: 80
	[Flags]
	public enum SwapChainFlags
	{
		// Token: 0x0400016C RID: 364
		Nonprerotated = 1,
		// Token: 0x0400016D RID: 365
		AllowModeSwitch = 2,
		// Token: 0x0400016E RID: 366
		GdiCompatible = 4,
		// Token: 0x0400016F RID: 367
		RestrictedContent = 8,
		// Token: 0x04000170 RID: 368
		RestrictSharedResourceDriver = 16,
		// Token: 0x04000171 RID: 369
		DisplayOnly = 32,
		// Token: 0x04000172 RID: 370
		FrameLatencyWaitAbleObject = 64,
		// Token: 0x04000173 RID: 371
		ForegroundLayer = 128,
		// Token: 0x04000174 RID: 372
		FullScreenVideo = 256,
		// Token: 0x04000175 RID: 373
		YuvVideo = 512,
		// Token: 0x04000176 RID: 374
		HwProtected = 1024,
		// Token: 0x04000177 RID: 375
		AllowTearing = 2048,
		// Token: 0x04000178 RID: 376
		RestrictedToAllHolographicDisplayS = 4096,
		// Token: 0x04000179 RID: 377
		None = 0
	}
}
