using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000383 RID: 899
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Sylas")]
	public class DamageSylasPassive : IPassiveDamage
	{
		// Token: 0x06001125 RID: 4389 RVA: 0x000462CC File Offset: 0x000444CC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(1.3f * source.TotalAttackDamage + 0.25f * source.TotalMagicalDamage);
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x000462E8 File Offset: 0x000444E8
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("SylasPassiveAttack");
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x000462F5 File Offset: 0x000444F5
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x000462F8 File Offset: 0x000444F8
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
