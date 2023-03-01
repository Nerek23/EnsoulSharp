using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200006B RID: 107
	[Flags]
	public enum NormalMapFlags
	{
		// Token: 0x04000715 RID: 1813
		MirrorU = 65536,
		// Token: 0x04000716 RID: 1814
		MirrorV = 131072,
		// Token: 0x04000717 RID: 1815
		Mirror = 196608,
		// Token: 0x04000718 RID: 1816
		InvertSign = 524288,
		// Token: 0x04000719 RID: 1817
		ComputeOcclusion = 1048576
	}
}
