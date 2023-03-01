using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200008B RID: 139
	[Flags]
	public enum TangentOptions
	{
		// Token: 0x04000888 RID: 2184
		WrapU = 1,
		// Token: 0x04000889 RID: 2185
		WrapV = 2,
		// Token: 0x0400088A RID: 2186
		WrapUV = 3,
		// Token: 0x0400088B RID: 2187
		DontNormalizePartials = 4,
		// Token: 0x0400088C RID: 2188
		DontOrthogonalize = 8,
		// Token: 0x0400088D RID: 2189
		OrthogonalizeFromV = 16,
		// Token: 0x0400088E RID: 2190
		OrthogonalizeFromU = 32,
		// Token: 0x0400088F RID: 2191
		WeightByArea = 64,
		// Token: 0x04000890 RID: 2192
		WeightEqual = 128,
		// Token: 0x04000891 RID: 2193
		WindCW = 256,
		// Token: 0x04000892 RID: 2194
		CalculateNormals = 512,
		// Token: 0x04000893 RID: 2195
		GenerateInPlace = 1024,
		// Token: 0x04000894 RID: 2196
		None = 0
	}
}
