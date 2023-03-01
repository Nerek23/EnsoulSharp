using System;

namespace SharpDX.DXGI
{
	// Token: 0x0200003B RID: 59
	public enum GraphicsPreemptionGranularity
	{
		// Token: 0x04000107 RID: 263
		DmaBufferBoundary,
		// Token: 0x04000108 RID: 264
		PrimitiveBoundary,
		// Token: 0x04000109 RID: 265
		TriangleBoundary,
		// Token: 0x0400010A RID: 266
		PixelBoundary,
		// Token: 0x0400010B RID: 267
		InstructionBoundary
	}
}
