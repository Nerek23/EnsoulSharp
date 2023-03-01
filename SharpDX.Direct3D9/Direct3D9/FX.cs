using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200005F RID: 95
	[Flags]
	public enum FX
	{
		// Token: 0x040006B2 RID: 1714
		DoNotSaveState = 1,
		// Token: 0x040006B3 RID: 1715
		DoNotSaveShaderState = 2,
		// Token: 0x040006B4 RID: 1716
		DoNotSaveSamplerState = 4,
		// Token: 0x040006B5 RID: 1717
		NotCloneable = 2048,
		// Token: 0x040006B6 RID: 1718
		LargeAddressAware = 131072,
		// Token: 0x040006B7 RID: 1719
		None = 0
	}
}
