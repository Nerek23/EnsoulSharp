using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000071 RID: 113
	[Flags]
	public enum PixelShaderCaps
	{
		// Token: 0x04000743 RID: 1859
		ArbitrarySwizzle = 1,
		// Token: 0x04000744 RID: 1860
		GradientInstructions = 2,
		// Token: 0x04000745 RID: 1861
		Predication = 4,
		// Token: 0x04000746 RID: 1862
		NoDependentReadLimit = 8,
		// Token: 0x04000747 RID: 1863
		NoTextureInstructionLimit = 16,
		// Token: 0x04000748 RID: 1864
		None = 0
	}
}
