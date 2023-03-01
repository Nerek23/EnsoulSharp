using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A0 RID: 928
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kayle")]
	public class DamageKaylePassive : IPassiveDamage
	{
		// Token: 0x060011CA RID: 4554 RVA: 0x00047360 File Offset: 0x00045560
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				if (source.Level >= 16)
				{
					return DamageKaylePassive.damages[Math.Min(spell.Level - 1, 4)] + 0.1 * (double)source.GetBonusPhysicalDamage() + 0.25 * (double)source.TotalMagicalDamage;
				}
				if (source.Level >= 11 && source.HasBuff("kayleenragecounter") && source.GetBuffCount("kayleenragecounter") == 5)
				{
					return DamageKaylePassive.damages[Math.Min(spell.Level - 1, 4)] + 0.1 * (double)source.GetBonusPhysicalDamage() + 0.25 * (double)source.TotalMagicalDamage;
				}
			}
			return 0.0;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x00047436 File Offset: 0x00045636
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x00047439 File Offset: 0x00045639
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0004743C File Offset: 0x0004563C
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008AA RID: 2218
		private static readonly double[] damages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};
	}
}
