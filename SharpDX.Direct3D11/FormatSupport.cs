using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000076 RID: 118
	[Flags]
	public enum FormatSupport
	{
		// Token: 0x040001FB RID: 507
		Buffer = 1,
		// Token: 0x040001FC RID: 508
		InputAssemblyVertexBuffer = 2,
		// Token: 0x040001FD RID: 509
		InputAssemblyIndexBuffer = 4,
		// Token: 0x040001FE RID: 510
		StreamOutputBuffer = 8,
		// Token: 0x040001FF RID: 511
		Texture1D = 16,
		// Token: 0x04000200 RID: 512
		Texture2D = 32,
		// Token: 0x04000201 RID: 513
		Texture3D = 64,
		// Token: 0x04000202 RID: 514
		TextureCube = 128,
		// Token: 0x04000203 RID: 515
		ShaderLoad = 256,
		// Token: 0x04000204 RID: 516
		ShaderSample = 512,
		// Token: 0x04000205 RID: 517
		ShaderSampleComparison = 1024,
		// Token: 0x04000206 RID: 518
		ShaderSampleMonoText = 2048,
		// Token: 0x04000207 RID: 519
		Mip = 4096,
		// Token: 0x04000208 RID: 520
		MipAutogen = 8192,
		// Token: 0x04000209 RID: 521
		RenderTarget = 16384,
		// Token: 0x0400020A RID: 522
		Blendable = 32768,
		// Token: 0x0400020B RID: 523
		DepthStencil = 65536,
		// Token: 0x0400020C RID: 524
		CpuLockable = 131072,
		// Token: 0x0400020D RID: 525
		MultisampleResolve = 262144,
		// Token: 0x0400020E RID: 526
		Display = 524288,
		// Token: 0x0400020F RID: 527
		CastWithinBitLayout = 1048576,
		// Token: 0x04000210 RID: 528
		MultisampleRenderTarget = 2097152,
		// Token: 0x04000211 RID: 529
		MultisampleLoad = 4194304,
		// Token: 0x04000212 RID: 530
		ShaderGather = 8388608,
		// Token: 0x04000213 RID: 531
		BackBufferCast = 16777216,
		// Token: 0x04000214 RID: 532
		TypedUnorderedAccessView = 33554432,
		// Token: 0x04000215 RID: 533
		ShaderGatherComparison = 67108864,
		// Token: 0x04000216 RID: 534
		DecoderOutput = 134217728,
		// Token: 0x04000217 RID: 535
		VideoProcessorOutput = 268435456,
		// Token: 0x04000218 RID: 536
		VideoProcessorInput = 536870912,
		// Token: 0x04000219 RID: 537
		VideoEncoder = 1073741824,
		// Token: 0x0400021A RID: 538
		None = 0
	}
}
