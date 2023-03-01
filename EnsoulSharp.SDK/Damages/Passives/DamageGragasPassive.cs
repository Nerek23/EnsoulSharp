using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000394 RID: 916
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Gragas")]
	public class DamageGragasPassive : IPassiveDamage
	{
		// Token: 0x06001186 RID: 4486 RVA: 0x00046C78 File Offset: 0x00044E78
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageGragasPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.07 * (double)target.MaxHealth + 0.7 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x00046CE0 File Offset: 0x00044EE0
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("gragaswattackbuff");
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x00046CED File Offset: 0x00044EED
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x00046CF0 File Offset: 0x00044EF0
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008A2 RID: 2210
		private static readonly double[] damages = new double[]
		{
			20.0,
			50.0,
			80.0,
			110.0,
			140.0
		};
	}
}
