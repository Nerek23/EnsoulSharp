using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036F RID: 879
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Galio")]
	public class DamageGalioPassiveA : IPassiveDamage
	{
		// Token: 0x060010B8 RID: 4280 RVA: 0x000457F4 File Offset: 0x000439F4
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			float num = 4.118f + 10.882f * (float)source.Level + source.TotalAttackDamage + source.TotalMagicalDamage * 0.5f + source.BonusSpellBlock * 0.6f;
			if (Math.Abs(source.Crit - 1f) < 1E-45f)
			{
				return (double)(4.118f + 10.882f * (float)source.Level + source.TotalAttackDamage * source.GetCritMultiplier(false) + source.TotalMagicalDamage * 0.5f + source.BonusSpellBlock * 0.6f);
			}
			return (double)num;
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0004588E File Offset: 0x00043A8E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("galiopassivebuff");
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0004589B File Offset: 0x00043A9B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0004589E File Offset: 0x00043A9E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
