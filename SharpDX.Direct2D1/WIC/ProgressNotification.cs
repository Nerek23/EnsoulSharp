using System;

namespace SharpDX.WIC
{
	// Token: 0x0200005C RID: 92
	[Flags]
	public enum ProgressNotification
	{
		// Token: 0x0400015D RID: 349
		Begin = 65536,
		// Token: 0x0400015E RID: 350
		End = 131072,
		// Token: 0x0400015F RID: 351
		Frequent = 262144,
		// Token: 0x04000160 RID: 352
		All = -65536
	}
}
