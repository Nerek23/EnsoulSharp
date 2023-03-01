using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000049 RID: 73
	[Flags]
	public enum PresentFlags
	{
		// Token: 0x04000147 RID: 327
		Test = 1,
		// Token: 0x04000148 RID: 328
		DoNotSequence = 2,
		// Token: 0x04000149 RID: 329
		Restart = 4,
		// Token: 0x0400014A RID: 330
		DoNotWait = 8,
		// Token: 0x0400014B RID: 331
		StereoPreferRight = 16,
		// Token: 0x0400014C RID: 332
		StereoTemporaryMono = 32,
		// Token: 0x0400014D RID: 333
		RestrictToOutput = 64,
		// Token: 0x0400014E RID: 334
		UseDuration = 256,
		// Token: 0x0400014F RID: 335
		AllowTearing = 512,
		// Token: 0x04000150 RID: 336
		None = 0
	}
}
