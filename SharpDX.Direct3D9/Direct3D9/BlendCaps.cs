using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200003A RID: 58
	[Flags]
	public enum BlendCaps
	{
		// Token: 0x0400054D RID: 1357
		Zero = 1,
		// Token: 0x0400054E RID: 1358
		One = 2,
		// Token: 0x0400054F RID: 1359
		SourceColor = 4,
		// Token: 0x04000550 RID: 1360
		InverseSourceColor = 8,
		// Token: 0x04000551 RID: 1361
		SourceAlpha = 16,
		// Token: 0x04000552 RID: 1362
		InverseSourceAlpha = 32,
		// Token: 0x04000553 RID: 1363
		DestinationAlpha = 64,
		// Token: 0x04000554 RID: 1364
		InverseDestinationAlpha = 128,
		// Token: 0x04000555 RID: 1365
		DestinationColor = 256,
		// Token: 0x04000556 RID: 1366
		InverseDestinationColor = 512,
		// Token: 0x04000557 RID: 1367
		SourceAlphaSaturated = 1024,
		// Token: 0x04000558 RID: 1368
		Bothsrcalpha = 2048,
		// Token: 0x04000559 RID: 1369
		BothInverseSourceAlpha = 4096,
		// Token: 0x0400055A RID: 1370
		BlendFactor = 8192,
		// Token: 0x0400055B RID: 1371
		SourceColor2 = 16384,
		// Token: 0x0400055C RID: 1372
		InverseSourceColor2 = 32768
	}
}
