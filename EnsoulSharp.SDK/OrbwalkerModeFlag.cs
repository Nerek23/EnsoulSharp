using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000018 RID: 24
	[Flags]
	public enum OrbwalkerModeFlag
	{
		// Token: 0x0400008E RID: 142
		None = -1,
		// Token: 0x0400008F RID: 143
		Combo = 1,
		// Token: 0x04000090 RID: 144
		Harass = 2,
		// Token: 0x04000091 RID: 145
		LaneClear = 3,
		// Token: 0x04000092 RID: 146
		LastHit = 4,
		// Token: 0x04000093 RID: 147
		Flee = 5,
		// Token: 0x04000094 RID: 148
		Custom = 6
	}
}
