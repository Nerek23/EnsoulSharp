using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037F RID: 895
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ornn")]
	public class DamageOrnnPassive : IPassiveDamage
	{
		// Token: 0x06001110 RID: 4368 RVA: 0x000460C8 File Offset: 0x000442C8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)((source.Level < 3) ? 7 : ((source.Level < 6) ? 8 : ((source.Level < 9) ? 9 : ((source.Level < 12) ? 10 : ((source.Level < 15) ? 11 : ((source.Level < 18) ? 12 : 13)))))) / 100.0 * (double)target.MaxHealth;
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x0004613A File Offset: 0x0004433A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("ornnvulnerabledebuff");
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x00046147 File Offset: 0x00044347
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x0004614A File Offset: 0x0004434A
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
