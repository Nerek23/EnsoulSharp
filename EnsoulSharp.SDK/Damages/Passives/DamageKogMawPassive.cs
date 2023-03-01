using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A2 RID: 930
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "KogMaw")]
	public class DamageKogMawPassive : IPassiveDamage
	{
		// Token: 0x060011D6 RID: 4566 RVA: 0x0004751C File Offset: 0x0004571C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0 && spell.Ammo == 1)
			{
				return (DamageKogMawPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.01 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
			}
			return 0.0;
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x0004758D File Offset: 0x0004578D
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("kogmawbioarcanebarrage");
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0004759A File Offset: 0x0004579A
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0004759D File Offset: 0x0004579D
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008AD RID: 2221
		private static readonly double[] damages = new double[]
		{
			0.035,
			0.0425,
			0.05,
			0.0575,
			0.065
		};
	}
}
