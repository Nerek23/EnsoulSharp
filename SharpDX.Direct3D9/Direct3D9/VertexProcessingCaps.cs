using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000A0 RID: 160
	[Flags]
	public enum VertexProcessingCaps
	{
		// Token: 0x0400097F RID: 2431
		TextureGen = 1,
		// Token: 0x04000980 RID: 2432
		MaterialSource7 = 2,
		// Token: 0x04000981 RID: 2433
		DirectionalLights = 8,
		// Token: 0x04000982 RID: 2434
		PositionalLights = 16,
		// Token: 0x04000983 RID: 2435
		LocalViewer = 32,
		// Token: 0x04000984 RID: 2436
		Tweening = 64,
		// Token: 0x04000985 RID: 2437
		TexGenSphereMap = 256,
		// Token: 0x04000986 RID: 2438
		NoTexGenNonLocalViewer = 512
	}
}
