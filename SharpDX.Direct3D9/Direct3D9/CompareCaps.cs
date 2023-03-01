using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000047 RID: 71
	[Flags]
	public enum CompareCaps
	{
		// Token: 0x040005AC RID: 1452
		Never = 1,
		// Token: 0x040005AD RID: 1453
		Less = 2,
		// Token: 0x040005AE RID: 1454
		Equal = 4,
		// Token: 0x040005AF RID: 1455
		LessEqual = 8,
		// Token: 0x040005B0 RID: 1456
		Greater = 16,
		// Token: 0x040005B1 RID: 1457
		NotEqual = 32,
		// Token: 0x040005B2 RID: 1458
		GreaterEqual = 64,
		// Token: 0x040005B3 RID: 1459
		Always = 128
	}
}
