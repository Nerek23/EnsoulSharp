using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200008D RID: 141
	[Flags]
	public enum TextureAddressCaps
	{
		// Token: 0x0400089C RID: 2204
		Wrap = 1,
		// Token: 0x0400089D RID: 2205
		Mirror = 2,
		// Token: 0x0400089E RID: 2206
		Clamp = 4,
		// Token: 0x0400089F RID: 2207
		Border = 8,
		// Token: 0x040008A0 RID: 2208
		IndependentUV = 16,
		// Token: 0x040008A1 RID: 2209
		MirrorOnce = 32
	}
}
