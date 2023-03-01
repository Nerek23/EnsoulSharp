using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200005B RID: 91
	[Flags]
	public enum ColorWriteMaskFlags : byte
	{
		// Token: 0x04000136 RID: 310
		Red = 1,
		// Token: 0x04000137 RID: 311
		Green = 2,
		// Token: 0x04000138 RID: 312
		Blue = 4,
		// Token: 0x04000139 RID: 313
		Alpha = 8,
		// Token: 0x0400013A RID: 314
		All = 15
	}
}
