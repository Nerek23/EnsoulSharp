using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200003E RID: 62
	[Flags]
	public enum Caps2
	{
		// Token: 0x0400056B RID: 1387
		FullScreenGamma = 131072,
		// Token: 0x0400056C RID: 1388
		CanCalibrateGamma = 1048576,
		// Token: 0x0400056D RID: 1389
		CanManageResource = 268435456,
		// Token: 0x0400056E RID: 1390
		DynamicTextures = 536870912,
		// Token: 0x0400056F RID: 1391
		CanAutoGenerateMipMap = 1073741824,
		// Token: 0x04000570 RID: 1392
		CanShareResource = -2147483648,
		// Token: 0x04000571 RID: 1393
		None = 0
	}
}
