using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039D RID: 925
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Jinx")]
	public class DamageJinxPassive : IPassiveDamage
	{
		// Token: 0x060011B9 RID: 4537 RVA: 0x00047160 File Offset: 0x00045360
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return 0.1 * (double)source.TotalAttackDamage * (double)source.GetCritMultiplier(true);
			}
			return 0.0;
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x000471AA File Offset: 0x000453AA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("JinxQ");
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x000471B7 File Offset: 0x000453B7
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x000471BA File Offset: 0x000453BA
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
