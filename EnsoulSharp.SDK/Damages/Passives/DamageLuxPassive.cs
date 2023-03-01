using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A5 RID: 933
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Lux")]
	public class DamageLuxPassive : IPassiveDamage
	{
		// Token: 0x060011E7 RID: 4583 RVA: 0x000476D8 File Offset: 0x000458D8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(10 + 10 * source.Level) + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x000476F9 File Offset: 0x000458F9
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("LuxIlluminatingFraulein") && target.GetBuff("LuxIlluminatingFraulein").Caster.Compare(source);
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x00047720 File Offset: 0x00045920
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x00047723 File Offset: 0x00045923
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
