using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000353 RID: 851
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Aphelios")]
	public class DamageApheliosPassiveA : IPassiveDamage
	{
		// Token: 0x0600101D RID: 4125 RVA: 0x00044824 File Offset: 0x00042A24
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.GetBuff("aphelioscalibrumbonusrangedebuff").Caster != null && target.GetBuff("aphelioscalibrumbonusrangedebuff").Caster.IsValid && target.GetBuff("aphelioscalibrumbonusrangedebuff").Caster.Compare(source))
			{
				return 15.0 + 0.2 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0004489D File Offset: 0x00042A9D
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("aphelioscalibrumbonusrangedebuff");
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x000448AA File Offset: 0x00042AAA
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x000448AD File Offset: 0x00042AAD
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
