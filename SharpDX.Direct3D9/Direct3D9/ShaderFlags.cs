using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000084 RID: 132
	[Flags]
	public enum ShaderFlags
	{
		// Token: 0x04000849 RID: 2121
		Debug = 1,
		// Token: 0x0400084A RID: 2122
		SkipValidation = 2,
		// Token: 0x0400084B RID: 2123
		SkipOptimization = 4,
		// Token: 0x0400084C RID: 2124
		PackMatrixRowMajor = 8,
		// Token: 0x0400084D RID: 2125
		PackMatrixColumnMajor = 16,
		// Token: 0x0400084E RID: 2126
		PartialPrecision = 32,
		// Token: 0x0400084F RID: 2127
		ForceVSSoftwareNoOpt = 64,
		// Token: 0x04000850 RID: 2128
		ForcePSSoftwareNoOpt = 128,
		// Token: 0x04000851 RID: 2129
		NoPreshader = 256,
		// Token: 0x04000852 RID: 2130
		AvoidFlowControl = 512,
		// Token: 0x04000853 RID: 2131
		PreferFlowControl = 1024,
		// Token: 0x04000854 RID: 2132
		EnableBackwardsCompatibility = 4096,
		// Token: 0x04000855 RID: 2133
		IeeeStrictness = 8192,
		// Token: 0x04000856 RID: 2134
		UseLegacyD3DX9_31Dll = 65536,
		// Token: 0x04000857 RID: 2135
		OptimizationLevel0 = 16384,
		// Token: 0x04000858 RID: 2136
		OptimizationLevel1 = 0,
		// Token: 0x04000859 RID: 2137
		OptimizationLevel2 = 49152,
		// Token: 0x0400085A RID: 2138
		OptimizationLevel3 = 32768,
		// Token: 0x0400085B RID: 2139
		None = 0
	}
}
