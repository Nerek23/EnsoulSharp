using System;

namespace SharpDX.Multimedia
{
	// Token: 0x0200007A RID: 122
	[Flags]
	public enum Speakers
	{
		// Token: 0x04000DBE RID: 3518
		FrontLeft = 1,
		// Token: 0x04000DBF RID: 3519
		FrontRight = 2,
		// Token: 0x04000DC0 RID: 3520
		FrontCenter = 4,
		// Token: 0x04000DC1 RID: 3521
		LowFrequency = 8,
		// Token: 0x04000DC2 RID: 3522
		BackLeft = 16,
		// Token: 0x04000DC3 RID: 3523
		BackRight = 32,
		// Token: 0x04000DC4 RID: 3524
		FrontLeftOfCenter = 64,
		// Token: 0x04000DC5 RID: 3525
		FrontRightOfCenter = 128,
		// Token: 0x04000DC6 RID: 3526
		BackCenter = 256,
		// Token: 0x04000DC7 RID: 3527
		SideLeft = 512,
		// Token: 0x04000DC8 RID: 3528
		SideRight = 1024,
		// Token: 0x04000DC9 RID: 3529
		TopCenter = 2048,
		// Token: 0x04000DCA RID: 3530
		TopFrontLeft = 4096,
		// Token: 0x04000DCB RID: 3531
		TopFrontCenter = 8192,
		// Token: 0x04000DCC RID: 3532
		TopFrontRight = 16384,
		// Token: 0x04000DCD RID: 3533
		TopBackLeft = 32768,
		// Token: 0x04000DCE RID: 3534
		TopBackCenter = 65536,
		// Token: 0x04000DCF RID: 3535
		TopBackRight = 131072,
		// Token: 0x04000DD0 RID: 3536
		Reserved = 2147221504,
		// Token: 0x04000DD1 RID: 3537
		All = -2147483648,
		// Token: 0x04000DD2 RID: 3538
		None = 0
	}
}
