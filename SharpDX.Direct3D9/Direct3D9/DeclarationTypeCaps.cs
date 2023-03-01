using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000051 RID: 81
	[Flags]
	public enum DeclarationTypeCaps
	{
		// Token: 0x040005F8 RID: 1528
		UByte4 = 1,
		// Token: 0x040005F9 RID: 1529
		UByte4N = 2,
		// Token: 0x040005FA RID: 1530
		Short2N = 4,
		// Token: 0x040005FB RID: 1531
		Short4N = 8,
		// Token: 0x040005FC RID: 1532
		UShort2N = 16,
		// Token: 0x040005FD RID: 1533
		UShort4N = 32,
		// Token: 0x040005FE RID: 1534
		UDec3 = 64,
		// Token: 0x040005FF RID: 1535
		Dec3N = 128,
		// Token: 0x04000600 RID: 1536
		HalfTwo = 256,
		// Token: 0x04000601 RID: 1537
		HalfFour = 512
	}
}
