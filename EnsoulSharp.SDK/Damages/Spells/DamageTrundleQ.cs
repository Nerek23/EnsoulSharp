using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002EA RID: 746
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Trundle", SpellSlot.Q, 0)]
	public class DamageTrundleQ : DamageSpell
	{
		// Token: 0x06000ED7 RID: 3799 RVA: 0x000425A9 File Offset: 0x000407A9
		public DamageTrundleQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x000425BF File Offset: 0x000407BF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTrundleQ.damages[level] + DamageTrundleQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000803 RID: 2051
		private static readonly double[] damages = new double[]
		{
			20.0,
			40.0,
			60.0,
			80.0,
			100.0
		};

		// Token: 0x04000804 RID: 2052
		private static readonly double[] damagePercents = new double[]
		{
			0.15,
			0.25,
			0.35,
			0.45,
			0.55
		};
	}
}
