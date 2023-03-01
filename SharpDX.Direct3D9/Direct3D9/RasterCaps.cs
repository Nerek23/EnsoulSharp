using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200007A RID: 122
	[Flags]
	public enum RasterCaps
	{
		// Token: 0x0400079F RID: 1951
		Dither = 1,
		// Token: 0x040007A0 RID: 1952
		DepthTest = 16,
		// Token: 0x040007A1 RID: 1953
		FogVertex = 128,
		// Token: 0x040007A2 RID: 1954
		FogTable = 256,
		// Token: 0x040007A3 RID: 1955
		MipMapLodBias = 8192,
		// Token: 0x040007A4 RID: 1956
		ZBufferLessHsr = 32768,
		// Token: 0x040007A5 RID: 1957
		FogRange = 65536,
		// Token: 0x040007A6 RID: 1958
		Anisotropy = 131072,
		// Token: 0x040007A7 RID: 1959
		WBuffer = 262144,
		// Token: 0x040007A8 RID: 1960
		WFog = 1048576,
		// Token: 0x040007A9 RID: 1961
		ZFog = 2097152,
		// Token: 0x040007AA RID: 1962
		ColorPerspective = 4194304,
		// Token: 0x040007AB RID: 1963
		ScissorTest = 16777216,
		// Token: 0x040007AC RID: 1964
		SlopeScaleDepthBias = 33554432,
		// Token: 0x040007AD RID: 1965
		DepthBias = 67108864,
		// Token: 0x040007AE RID: 1966
		MultisampleToggle = 134217728
	}
}
