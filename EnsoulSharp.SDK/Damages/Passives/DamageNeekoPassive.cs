using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037E RID: 894
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Neeko")]
	public class DamageNeekoPassive : IPassiveDamage
	{
		// Token: 0x0600110A RID: 4362 RVA: 0x0004603C File Offset: 0x0004423C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageNeekoPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.6 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x00046092 File Offset: 0x00044292
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("neekowpassiveready");
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0004609F File Offset: 0x0004429F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x000460A2 File Offset: 0x000442A2
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000891 RID: 2193
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
