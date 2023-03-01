using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D5 RID: 981
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageSonaMarkPassive : IPassiveDamage
	{
		// Token: 0x060012F3 RID: 4851 RVA: 0x00049250 File Offset: 0x00047450
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("sonaqprocattacker"))
			{
				AIHeroClient aiheroClient = target.GetBuff("sonaqprocattacker").Caster as AIHeroClient;
				if (aiheroClient != null && aiheroClient.Compare(source))
				{
					SpellDataInst spell = aiheroClient.Spellbook.GetSpell(SpellSlot.Q);
					if (spell != null && spell.Level > 0)
					{
						double amount = DamageSonaMarkPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.2 * (double)aiheroClient.TotalMagicalDamage;
						return aiheroClient.CalculateMagicDamage(target, amount);
					}
				}
			}
			return 0.0;
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x000492E4 File Offset: 0x000474E4
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("sonaqprocattacker");
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000492F1 File Offset: 0x000474F1
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000492F4 File Offset: 0x000474F4
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x040008D5 RID: 2261
		private static readonly double[] damages = new double[]
		{
			10.0,
			15.0,
			20.0,
			25.0,
			30.0
		};
	}
}
