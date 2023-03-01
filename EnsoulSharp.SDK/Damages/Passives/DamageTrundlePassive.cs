using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C2 RID: 962
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Trundle")]
	public class DamageTrundlePassive : IPassiveDamage
	{
		// Token: 0x06001287 RID: 4743 RVA: 0x00048704 File Offset: 0x00046904
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageTrundlePassive.damages[Math.Min(spell.Level - 1, 4)] + DamageTrundlePassive.damagePercents[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00048765 File Offset: 0x00046965
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("TrundleTrollSmash");
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00048772 File Offset: 0x00046972
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x00048775 File Offset: 0x00046975
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008C4 RID: 2244
		private static readonly double[] damages = new double[]
		{
			20.0,
			40.0,
			60.0,
			80.0,
			100.0
		};

		// Token: 0x040008C5 RID: 2245
		private static readonly double[] damagePercents = new double[]
		{
			0.1,
			0.2,
			0.3,
			0.4,
			0.5
		};
	}
}
