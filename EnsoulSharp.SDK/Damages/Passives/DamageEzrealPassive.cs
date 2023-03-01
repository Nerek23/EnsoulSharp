using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036D RID: 877
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ezreal")]
	public class DamageEzrealPassive : IPassiveDamage
	{
		// Token: 0x060010AD RID: 4269 RVA: 0x000456CC File Offset: 0x000438CC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("ezrealwattach"))
			{
				BuffInstance buff = target.GetBuff("ezrealwattach");
				if (buff != null && (buff.Caster != null & buff.Caster.Compare(source)))
				{
					SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
					if (spell != null && spell.Level > 0)
					{
						return DamageEzrealPassive.damages[spell.Level - 1] + 0.6 * (double)source.GetBonusPhysicalDamage() + DamageEzrealPassive.damagePercents[spell.Level - 1] * (double)source.TotalMagicalDamage;
					}
				}
			}
			return 0.0;
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0004576A File Offset: 0x0004396A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("ezrealwattach");
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x00045777 File Offset: 0x00043977
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0004577A File Offset: 0x0004397A
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000884 RID: 2180
		private static readonly double[] damages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};

		// Token: 0x04000885 RID: 2181
		private static readonly double[] damagePercents = new double[]
		{
			0.7,
			0.75,
			0.8,
			0.85,
			0.9
		};
	}
}
