using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BD RID: 957
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "TahmKench")]
	public class DamageTahmKenchPassive : IPassiveDamage
	{
		// Token: 0x0600126D RID: 4717 RVA: 0x000484E6 File Offset: 0x000466E6
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(8 + 3 * (source.Level - 1)) + 0.025 * (double)source.BonusHealth;
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00048507 File Offset: 0x00046707
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x0004850A File Offset: 0x0004670A
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0004850D File Offset: 0x0004670D
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
