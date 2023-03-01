using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000378 RID: 888
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kled")]
	public class DamageKledPassiveA : IPassiveDamage
	{
		// Token: 0x060010E9 RID: 4329 RVA: 0x00045CFC File Offset: 0x00043EFC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0 && spell.Ammo == 1)
			{
				return DamageKledPassiveA.damages[Math.Min(spell.Level - 1, 4)] + (DamageKledPassiveA.damagePercents[Math.Min(spell.Level - 1, 4)] + 0.05 * (double)source.GetBonusPhysicalDamage() / 100.0) * (double)target.MaxHealth;
			}
			return 0.0;
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x00045D82 File Offset: 0x00043F82
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("kledwactive");
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x00045D8F File Offset: 0x00043F8F
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x00045D92 File Offset: 0x00043F92
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400088D RID: 2189
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};

		// Token: 0x0400088E RID: 2190
		private static readonly double[] damagePercents = new double[]
		{
			0.045,
			0.05,
			0.055,
			0.06,
			0.065
		};
	}
}
