using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000056 RID: 86
	[Flags]
	public enum BindFlags
	{
		// Token: 0x04000103 RID: 259
		VertexBuffer = 1,
		// Token: 0x04000104 RID: 260
		IndexBuffer = 2,
		// Token: 0x04000105 RID: 261
		ConstantBuffer = 4,
		// Token: 0x04000106 RID: 262
		ShaderResource = 8,
		// Token: 0x04000107 RID: 263
		StreamOutput = 16,
		// Token: 0x04000108 RID: 264
		RenderTarget = 32,
		// Token: 0x04000109 RID: 265
		DepthStencil = 64,
		// Token: 0x0400010A RID: 266
		UnorderedAccess = 128,
		// Token: 0x0400010B RID: 267
		Decoder = 512,
		// Token: 0x0400010C RID: 268
		VideoEncoder = 1024,
		// Token: 0x0400010D RID: 269
		None = 0
	}
}
