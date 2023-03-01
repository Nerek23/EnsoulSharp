using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000093 RID: 147
	[Flags]
	public enum TextureOperationCaps
	{
		// Token: 0x040008E8 RID: 2280
		Disable = 1,
		// Token: 0x040008E9 RID: 2281
		SelectArg1 = 2,
		// Token: 0x040008EA RID: 2282
		SelectArg2 = 4,
		// Token: 0x040008EB RID: 2283
		Modulate = 8,
		// Token: 0x040008EC RID: 2284
		Modulate2X = 16,
		// Token: 0x040008ED RID: 2285
		Modulate4X = 32,
		// Token: 0x040008EE RID: 2286
		Add = 64,
		// Token: 0x040008EF RID: 2287
		AddSigned = 128,
		// Token: 0x040008F0 RID: 2288
		AddSigned2X = 256,
		// Token: 0x040008F1 RID: 2289
		Subtract = 512,
		// Token: 0x040008F2 RID: 2290
		AddSmooth = 1024,
		// Token: 0x040008F3 RID: 2291
		BlendDiffuseAlpha = 2048,
		// Token: 0x040008F4 RID: 2292
		BlendTextureAlpha = 4096,
		// Token: 0x040008F5 RID: 2293
		BlendFactorAlpha = 8192,
		// Token: 0x040008F6 RID: 2294
		BlendTextureAlphaPM = 16384,
		// Token: 0x040008F7 RID: 2295
		BlendCurrentAlpha = 32768,
		// Token: 0x040008F8 RID: 2296
		Premodulate = 65536,
		// Token: 0x040008F9 RID: 2297
		ModulateAlphaAddColor = 131072,
		// Token: 0x040008FA RID: 2298
		ModulateColorAddAlpha = 262144,
		// Token: 0x040008FB RID: 2299
		ModulateInvAlphaAddColor = 524288,
		// Token: 0x040008FC RID: 2300
		ModulateInvColorAddAlpha = 1048576,
		// Token: 0x040008FD RID: 2301
		BumpEnvironmentMap = 2097152,
		// Token: 0x040008FE RID: 2302
		BumpEnvironmentMapLuminance = 4194304,
		// Token: 0x040008FF RID: 2303
		DotProduct3 = 8388608,
		// Token: 0x04000900 RID: 2304
		MultiplyAdd = 16777216,
		// Token: 0x04000901 RID: 2305
		Lerp = 33554432
	}
}
