using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200003F RID: 63
	[Flags]
	public enum Caps3
	{
		// Token: 0x04000573 RID: 1395
		AlphaFullScreenFlipOrDiscard = 32,
		// Token: 0x04000574 RID: 1396
		LinearToSrgbPresentation = 128,
		// Token: 0x04000575 RID: 1397
		CopyToVideoMemory = 256,
		// Token: 0x04000576 RID: 1398
		CopyToSystemMemory = 512,
		// Token: 0x04000577 RID: 1399
		DXVAHd = 1024,
		// Token: 0x04000578 RID: 1400
		None = 0
	}
}
