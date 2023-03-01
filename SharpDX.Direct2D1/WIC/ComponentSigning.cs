using System;

namespace SharpDX.WIC
{
	// Token: 0x0200003F RID: 63
	[Flags]
	public enum ComponentSigning
	{
		// Token: 0x040000CF RID: 207
		Signed = 1,
		// Token: 0x040000D0 RID: 208
		Unsigned = 2,
		// Token: 0x040000D1 RID: 209
		Safe = 4,
		// Token: 0x040000D2 RID: 210
		Disabled = -2147483648
	}
}
