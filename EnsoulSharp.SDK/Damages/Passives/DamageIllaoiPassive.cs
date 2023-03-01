using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000396 RID: 918
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Illaoi")]
	public class DamageIllaoiPassive : IPassiveDamage
	{
		// Token: 0x06001192 RID: 4498 RVA: 0x00046DA0 File Offset: 0x00044FA0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return (DamageIllaoiPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.04 * (double)source.TotalAttackDamage / 100.0) * (double)target.MaxHealth;
			}
			return 0.0;
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x00046E08 File Offset: 0x00045008
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("IllaoiW");
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x00046E15 File Offset: 0x00045015
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x00046E18 File Offset: 0x00045018
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008A4 RID: 2212
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.035,
			0.04,
			0.045,
			0.05
		};
	}
}
