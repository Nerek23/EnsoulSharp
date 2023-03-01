using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000380 RID: 896
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Qiyana")]
	public class DamageQiyanaPassive : IPassiveDamage
	{
		// Token: 0x06001115 RID: 4373 RVA: 0x00046155 File Offset: 0x00044355
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(11 + 4 * source.Level) + 0.3 * (double)source.GetBonusPhysicalDamage() + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x00046187 File Offset: 0x00044387
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return !target.HasBuff("qiyanapassivecd_base") && !target.HasBuff("qiyanapassivecd_rock") && !target.HasBuff("qiyanapassivecd_water") && !target.HasBuff("qiyanapassivecd_grass");
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x000461C0 File Offset: 0x000443C0
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x000461C3 File Offset: 0x000443C3
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
