using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200008F RID: 143
	[Flags]
	public enum TileCopyFlags
	{
		// Token: 0x040007E6 RID: 2022
		NoOverwrite = 1,
		// Token: 0x040007E7 RID: 2023
		LinearBufferToSwizzledTiledResource = 2,
		// Token: 0x040007E8 RID: 2024
		SwizzledTiledResourceToLinearBuffer = 4,
		// Token: 0x040007E9 RID: 2025
		None = 0
	}
}
