using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000393 RID: 915
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Gnar")]
	public class DamageGnarPassive : IPassiveDamage
	{
		// Token: 0x06001180 RID: 4480 RVA: 0x00046BB0 File Offset: 0x00044DB0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				double num = DamageGnarPassive.damages[spell.Level - 1] + DamageGnarPassive.damagePercents[spell.Level - 1] * (double)target.MaxHealth + (double)source.TotalAttackDamage;
				if (target.IsJungle())
				{
					num = Math.Min((double)(300f + source.TotalAttackDamage), num);
				}
				return num;
			}
			return 0.0;
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x00046C2B File Offset: 0x00044E2B
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("gnarwproc") == 2;
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x00046C3B File Offset: 0x00044E3B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x00046C3E File Offset: 0x00044E3E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008A0 RID: 2208
		private static readonly double[] damages = new double[]
		{
			0.0,
			10.0,
			20.0,
			30.0,
			40.0
		};

		// Token: 0x040008A1 RID: 2209
		private static readonly double[] damagePercents = new double[]
		{
			0.06,
			0.08,
			0.1,
			0.12,
			0.14
		};
	}
}
