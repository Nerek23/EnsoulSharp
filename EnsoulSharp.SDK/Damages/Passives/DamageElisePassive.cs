using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036A RID: 874
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Elise")]
	public class DamageElisePassive : IPassiveDamage
	{
		// Token: 0x0600109C RID: 4252 RVA: 0x0004554C File Offset: 0x0004374C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.R);
			if (spell != null && spell.Level > 0)
			{
				return DamageElisePassive.damages[Math.Min(spell.Level - 1, 2)] + 0.2 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x000455A2 File Offset: 0x000437A2
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("EliseR");
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x000455AF File Offset: 0x000437AF
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x000455B2 File Offset: 0x000437B2
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000882 RID: 2178
		private static readonly double[] damages = new double[]
		{
			10.0,
			20.0,
			30.0
		};
	}
}
