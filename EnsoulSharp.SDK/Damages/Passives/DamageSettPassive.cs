using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000382 RID: 898
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Sett")]
	public class DamageSettPassive : IPassiveDamage
	{
		// Token: 0x0600111F RID: 4383 RVA: 0x000461EC File Offset: 0x000443EC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				double num = DamageSettPassive.damages[Math.Min(spell.Level - 1, 4)] + (DamageSettPassive.damagePercents[Math.Min(spell.Level - 1, 4)] + 0.01 * (double)source.TotalAttackDamage) * (0.01 * (double)target.MaxHealth);
				if (target.IsJungle())
				{
					num = Math.Min(400.0, num);
				}
				return num;
			}
			return 0.0;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x00046283 File Offset: 0x00044483
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("SettQ");
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x00046290 File Offset: 0x00044490
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x00046293 File Offset: 0x00044493
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000892 RID: 2194
		private static readonly double[] damages = new double[]
		{
			10.0,
			20.0,
			30.0,
			40.0,
			50.0
		};

		// Token: 0x04000893 RID: 2195
		private static readonly double[] damagePercents = new double[]
		{
			0.01,
			0.015,
			0.02,
			0.025,
			0.03
		};
	}
}
