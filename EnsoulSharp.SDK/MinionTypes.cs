using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200003B RID: 59
	[Flags]
	public enum MinionTypes
	{
		// Token: 0x04000165 RID: 357
		Unknown = 0,
		// Token: 0x04000166 RID: 358
		All = 1,
		// Token: 0x04000167 RID: 359
		Normal = 2,
		// Token: 0x04000168 RID: 360
		Ranged = 4,
		// Token: 0x04000169 RID: 361
		Melee = 8,
		// Token: 0x0400016A RID: 362
		Siege = 16,
		// Token: 0x0400016B RID: 363
		Super = 32,
		// Token: 0x0400016C RID: 364
		Ward = 64,
		// Token: 0x0400016D RID: 365
		JunglePlant = 128
	}
}
