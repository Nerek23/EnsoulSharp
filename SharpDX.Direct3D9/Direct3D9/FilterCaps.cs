using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200005C RID: 92
	[Flags]
	public enum FilterCaps
	{
		// Token: 0x0400065D RID: 1629
		MinPoint = 256,
		// Token: 0x0400065E RID: 1630
		MinLinear = 512,
		// Token: 0x0400065F RID: 1631
		MinAnisotropic = 1024,
		// Token: 0x04000660 RID: 1632
		MinPyramidalQuad = 2048,
		// Token: 0x04000661 RID: 1633
		MinGaussianQuad = 4096,
		// Token: 0x04000662 RID: 1634
		MipPoint = 65536,
		// Token: 0x04000663 RID: 1635
		MipLinear = 131072,
		// Token: 0x04000664 RID: 1636
		ConvolutionMono = 262144,
		// Token: 0x04000665 RID: 1637
		MagPoint = 16777216,
		// Token: 0x04000666 RID: 1638
		MagLinear = 33554432,
		// Token: 0x04000667 RID: 1639
		MagAnisotropic = 67108864,
		// Token: 0x04000668 RID: 1640
		MagPyramidalQuad = 134217728,
		// Token: 0x04000669 RID: 1641
		MagGaussianQuad = 268435456
	}
}
