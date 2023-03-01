using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200009D RID: 157
	[Flags]
	public enum VertexFormat
	{
		// Token: 0x0400095C RID: 2396
		Reserved0 = 1,
		// Token: 0x0400095D RID: 2397
		PositionMask = 16398,
		// Token: 0x0400095E RID: 2398
		Position = 2,
		// Token: 0x0400095F RID: 2399
		PositionRhw = 4,
		// Token: 0x04000960 RID: 2400
		PositionBlend1 = 6,
		// Token: 0x04000961 RID: 2401
		PositionBlend2 = 8,
		// Token: 0x04000962 RID: 2402
		PositionBlend3 = 10,
		// Token: 0x04000963 RID: 2403
		PositionBlend4 = 12,
		// Token: 0x04000964 RID: 2404
		PositionBlend5 = 14,
		// Token: 0x04000965 RID: 2405
		PositionW = 16386,
		// Token: 0x04000966 RID: 2406
		Normal = 16,
		// Token: 0x04000967 RID: 2407
		PointSize = 32,
		// Token: 0x04000968 RID: 2408
		Diffuse = 64,
		// Token: 0x04000969 RID: 2409
		Specular = 128,
		// Token: 0x0400096A RID: 2410
		TextureCountMask = 3840,
		// Token: 0x0400096B RID: 2411
		TextureCountShift = 8,
		// Token: 0x0400096C RID: 2412
		Texture0 = 0,
		// Token: 0x0400096D RID: 2413
		Texture1 = 256,
		// Token: 0x0400096E RID: 2414
		Texture2 = 512,
		// Token: 0x0400096F RID: 2415
		Texture3 = 768,
		// Token: 0x04000970 RID: 2416
		Texture4 = 1024,
		// Token: 0x04000971 RID: 2417
		Texture5 = 1280,
		// Token: 0x04000972 RID: 2418
		Texture6 = 1536,
		// Token: 0x04000973 RID: 2419
		Texture7 = 1792,
		// Token: 0x04000974 RID: 2420
		Texture8 = 2048,
		// Token: 0x04000975 RID: 2421
		LastBetaUByte4 = 4096,
		// Token: 0x04000976 RID: 2422
		LastBetaColor = 32768,
		// Token: 0x04000977 RID: 2423
		None = 0
	}
}
