using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000052 RID: 82
	[Flags]
	public enum Usage
	{
		// Token: 0x04000180 RID: 384
		ShaderInput = 16,
		// Token: 0x04000181 RID: 385
		RenderTargetOutput = 32,
		// Token: 0x04000182 RID: 386
		BackBuffer = 64,
		// Token: 0x04000183 RID: 387
		Shared = 128,
		// Token: 0x04000184 RID: 388
		ReadOnly = 256,
		// Token: 0x04000185 RID: 389
		DiscardOnPresent = 512,
		// Token: 0x04000186 RID: 390
		UnorderedAccess = 1024
	}
}
