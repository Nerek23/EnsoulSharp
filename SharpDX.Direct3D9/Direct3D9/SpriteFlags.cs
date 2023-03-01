using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000085 RID: 133
	[Flags]
	public enum SpriteFlags
	{
		// Token: 0x0400085D RID: 2141
		DoNotSaveState = 1,
		// Token: 0x0400085E RID: 2142
		DoNotModifyRenderState = 2,
		// Token: 0x0400085F RID: 2143
		ObjectSpace = 4,
		// Token: 0x04000860 RID: 2144
		Billboard = 8,
		// Token: 0x04000861 RID: 2145
		AlphaBlend = 16,
		// Token: 0x04000862 RID: 2146
		SortTexture = 32,
		// Token: 0x04000863 RID: 2147
		SortDepthFrontToBack = 64,
		// Token: 0x04000864 RID: 2148
		SortDepthBackToFront = 128,
		// Token: 0x04000865 RID: 2149
		DoNotAddRefTexture = 256,
		// Token: 0x04000866 RID: 2150
		None = 0
	}
}
