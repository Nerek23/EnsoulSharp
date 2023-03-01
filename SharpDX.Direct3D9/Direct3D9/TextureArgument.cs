using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200008E RID: 142
	[Flags]
	public enum TextureArgument
	{
		// Token: 0x040008A3 RID: 2211
		SelectMask = 15,
		// Token: 0x040008A4 RID: 2212
		Diffuse = 0,
		// Token: 0x040008A5 RID: 2213
		Current = 1,
		// Token: 0x040008A6 RID: 2214
		Texture = 2,
		// Token: 0x040008A7 RID: 2215
		TFactor = 3,
		// Token: 0x040008A8 RID: 2216
		Specular = 4,
		// Token: 0x040008A9 RID: 2217
		Temp = 5,
		// Token: 0x040008AA RID: 2218
		Constant = 6,
		// Token: 0x040008AB RID: 2219
		Complement = 16,
		// Token: 0x040008AC RID: 2220
		AlphaReplicate = 32
	}
}
