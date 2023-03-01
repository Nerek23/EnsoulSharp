using System;

namespace EnsoulSharp
{
	// Token: 0x02000034 RID: 52
	[Flags]
	public enum SpellState
	{
		// Token: 0x0400032C RID: 812
		Ready = 0,
		// Token: 0x0400032D RID: 813
		NoSpell = 2,
		// Token: 0x0400032E RID: 814
		NotLearned = 4,
		// Token: 0x0400032F RID: 815
		Disabled = 8,
		// Token: 0x04000330 RID: 816
		Unknown = 10,
		// Token: 0x04000331 RID: 817
		Surpressed = 16,
		// Token: 0x04000332 RID: 818
		Cooldown = 32,
		// Token: 0x04000333 RID: 819
		NoMana = 64
	}
}
