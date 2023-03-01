using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039A RID: 922
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Jayce")]
	public class DamageJaycePassive : IPassiveDamage
	{
		// Token: 0x060011A8 RID: 4520 RVA: 0x00046FA0 File Offset: 0x000451A0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageJaycePassive.damages[Math.Min(spell.Level - 1, 5)] * (double)source.TotalAttackDamage;
			}
			return (double)source.TotalAttackDamage;
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x00046FEA File Offset: 0x000451EA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("jaycehypercharge");
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x00046FF7 File Offset: 0x000451F7
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x00046FFA File Offset: 0x000451FA
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008A6 RID: 2214
		private static readonly double[] damages = new double[]
		{
			0.7,
			0.78,
			0.86,
			0.94,
			1.02,
			1.1
		};
	}
}
