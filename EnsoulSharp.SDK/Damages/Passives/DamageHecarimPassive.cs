using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000395 RID: 917
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Hecarim")]
	public class DamageHecarimPassive : IPassiveDamage
	{
		// Token: 0x0600118C RID: 4492 RVA: 0x00046D14 File Offset: 0x00044F14
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageHecarimPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00046D6A File Offset: 0x00044F6A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("hecarimrampspeed");
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x00046D77 File Offset: 0x00044F77
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x00046D7A File Offset: 0x00044F7A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008A3 RID: 2211
		private static readonly double[] damages = new double[]
		{
			45.0,
			75.0,
			105.0,
			135.0,
			165.0
		};
	}
}
