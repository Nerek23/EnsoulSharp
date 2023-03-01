using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200005D RID: 93
	[Flags]
	public enum ComputeShaderFormatSupport
	{
		// Token: 0x04000145 RID: 325
		AtomicAdd = 1,
		// Token: 0x04000146 RID: 326
		AtomicBitwiseOperations = 2,
		// Token: 0x04000147 RID: 327
		AtomicCompareStoreOrCompareExchange = 4,
		// Token: 0x04000148 RID: 328
		AtomicExchange = 8,
		// Token: 0x04000149 RID: 329
		AtomicSignedMinimumOrMaximum = 16,
		// Token: 0x0400014A RID: 330
		AtomicUnsignedMinimumOrMaximum = 32,
		// Token: 0x0400014B RID: 331
		TypedLoad = 64,
		// Token: 0x0400014C RID: 332
		TypedStore = 128,
		// Token: 0x0400014D RID: 333
		OutputMergerLogicOperation = 256,
		// Token: 0x0400014E RID: 334
		Tiled = 512,
		// Token: 0x0400014F RID: 335
		Shareable = 1024,
		// Token: 0x04000150 RID: 336
		MultiplaneOverlay = 16384,
		// Token: 0x04000151 RID: 337
		None = 0
	}
}
