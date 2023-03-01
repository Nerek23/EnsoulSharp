using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000076 RID: 118
	[Flags]
	public enum PresentInterval
	{
		// Token: 0x0400076E RID: 1902
		Default = 0,
		// Token: 0x0400076F RID: 1903
		One = 1,
		// Token: 0x04000770 RID: 1904
		Two = 2,
		// Token: 0x04000771 RID: 1905
		Three = 4,
		// Token: 0x04000772 RID: 1906
		Four = 8,
		// Token: 0x04000773 RID: 1907
		Immediate = -2147483648
	}
}
