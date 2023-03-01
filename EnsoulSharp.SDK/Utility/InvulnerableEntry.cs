using System;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x0200007D RID: 125
	public class InvulnerableEntry
	{
		// Token: 0x060004C4 RID: 1220 RVA: 0x00023C0C File Offset: 0x00021E0C
		public InvulnerableEntry(string buffName)
		{
			this.BuffName = buffName;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00023C1B File Offset: 0x00021E1B
		public string BuffName { get; }

		// Token: 0x04000293 RID: 659
		public string ChampionName;

		// Token: 0x04000294 RID: 660
		public Func<AIBaseClient, DamageType, bool> CheckFunction;

		// Token: 0x04000295 RID: 661
		public DamageType? DamageType;

		// Token: 0x04000296 RID: 662
		public bool IsShield;

		// Token: 0x04000297 RID: 663
		public int MinHealthPercent;
	}
}
