using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038D RID: 909
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "DrMundo")]
	public class DamageDrMundoPassive : IPassiveDamage
	{
		// Token: 0x0600115D RID: 4445 RVA: 0x00046780 File Offset: 0x00044980
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				double num = DamageDrMundoPassive.basicdamages[Math.Min(spell.Level - 1, 4)];
				double val = DamageDrMundoPassive.maxdamages[Math.Min(spell.Level - 1, 4)];
				double num2 = Math.Min(Math.Round((double)(100f - source.HealthPercent)), 40.0);
				return Math.Min(num * (1.0 + num2 * 0.015), val);
			}
			return 0.0;
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x00046816 File Offset: 0x00044A16
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("Masochism");
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x00046823 File Offset: 0x00044A23
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x00046826 File Offset: 0x00044A26
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400089A RID: 2202
		private static readonly double[] basicdamages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};

		// Token: 0x0400089B RID: 2203
		private static readonly double[] maxdamages = new double[]
		{
			25.0,
			30.0,
			35.0,
			40.0,
			45.0
		};
	}
}
