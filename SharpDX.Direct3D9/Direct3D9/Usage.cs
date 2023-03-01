using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200009A RID: 154
	[Flags]
	public enum Usage
	{
		// Token: 0x04000938 RID: 2360
		RenderTarget = 1,
		// Token: 0x04000939 RID: 2361
		DepthStencil = 2,
		// Token: 0x0400093A RID: 2362
		Dynamic = 512,
		// Token: 0x0400093B RID: 2363
		NonSecure = 8388608,
		// Token: 0x0400093C RID: 2364
		AutoGenerateMipMap = 1024,
		// Token: 0x0400093D RID: 2365
		DisplacementMap = 16384,
		// Token: 0x0400093E RID: 2366
		QueryLegacyBumpMap = 32768,
		// Token: 0x0400093F RID: 2367
		QuerySrgbRead = 65536,
		// Token: 0x04000940 RID: 2368
		QueryFilter = 131072,
		// Token: 0x04000941 RID: 2369
		QuerySrgbWrite = 262144,
		// Token: 0x04000942 RID: 2370
		QueryPostPixelShaderBlending = 524288,
		// Token: 0x04000943 RID: 2371
		QueryVertexTexture = 1048576,
		// Token: 0x04000944 RID: 2372
		QueryWrapAndMip = 2097152,
		// Token: 0x04000945 RID: 2373
		WriteOnly = 8,
		// Token: 0x04000946 RID: 2374
		SoftwareProcessing = 16,
		// Token: 0x04000947 RID: 2375
		DoNotClip = 32,
		// Token: 0x04000948 RID: 2376
		Points = 64,
		// Token: 0x04000949 RID: 2377
		RTPatches = 128,
		// Token: 0x0400094A RID: 2378
		NPatches = 256,
		// Token: 0x0400094B RID: 2379
		TextApi = 268435456,
		// Token: 0x0400094C RID: 2380
		RestrictedContent = 2048,
		// Token: 0x0400094D RID: 2381
		RestrictSharedResource = 8192,
		// Token: 0x0400094E RID: 2382
		RestrictSharedResourceDriver = 4096,
		// Token: 0x0400094F RID: 2383
		None = 0
	}
}
