using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200005B RID: 91
	[Flags]
	public enum Filter
	{
		// Token: 0x0400064D RID: 1613
		None = 1,
		// Token: 0x0400064E RID: 1614
		Point = 2,
		// Token: 0x0400064F RID: 1615
		Linear = 3,
		// Token: 0x04000650 RID: 1616
		Triangle = 4,
		// Token: 0x04000651 RID: 1617
		Box = 5,
		// Token: 0x04000652 RID: 1618
		MirrorU = 65536,
		// Token: 0x04000653 RID: 1619
		MirrorV = 131072,
		// Token: 0x04000654 RID: 1620
		MirrorW = 262144,
		// Token: 0x04000655 RID: 1621
		Mirror = 458752,
		// Token: 0x04000656 RID: 1622
		Dither = 524288,
		// Token: 0x04000657 RID: 1623
		DitherDiffusion = 1048576,
		// Token: 0x04000658 RID: 1624
		SrgbIn = 2097152,
		// Token: 0x04000659 RID: 1625
		SrgbOut = 4194304,
		// Token: 0x0400065A RID: 1626
		Srgb = 6291456,
		// Token: 0x0400065B RID: 1627
		Default = -1
	}
}
