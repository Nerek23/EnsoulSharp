using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200008F RID: 143
	[Flags]
	public enum TextureCaps
	{
		// Token: 0x040008AE RID: 2222
		Perspective = 1,
		// Token: 0x040008AF RID: 2223
		Pow2 = 2,
		// Token: 0x040008B0 RID: 2224
		Alpha = 4,
		// Token: 0x040008B1 RID: 2225
		SquareOnly = 32,
		// Token: 0x040008B2 RID: 2226
		TextureRepeatNotScaledBySize = 64,
		// Token: 0x040008B3 RID: 2227
		AlphaPalette = 128,
		// Token: 0x040008B4 RID: 2228
		NonPow2Conditional = 256,
		// Token: 0x040008B5 RID: 2229
		Projected = 1024,
		// Token: 0x040008B6 RID: 2230
		CubeMap = 2048,
		// Token: 0x040008B7 RID: 2231
		VolumeMap = 8192,
		// Token: 0x040008B8 RID: 2232
		MipMap = 16384,
		// Token: 0x040008B9 RID: 2233
		MipVolumeMap = 32768,
		// Token: 0x040008BA RID: 2234
		MipCubeMap = 65536,
		// Token: 0x040008BB RID: 2235
		CubeMapPow2 = 131072,
		// Token: 0x040008BC RID: 2236
		VolumeMapPow2 = 262144,
		// Token: 0x040008BD RID: 2237
		NoProjectedBumpEnvironment = 2097152
	}
}
