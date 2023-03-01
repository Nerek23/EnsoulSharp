using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010F RID: 271
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aatrox", SpellSlot.Q, 1)]
	public class DamageAatroxQ1 : DamageSpell
	{
		// Token: 0x0600093C RID: 2364 RVA: 0x00038868 File Offset: 0x00036A68
		public DamageAatroxQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00038888 File Offset: 0x00036A88
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAatroxQ1.damages[level] + DamageAatroxQ1.damagePercents[level] * (double)source.TotalAttackDamage;
			if (target.IsMinion())
			{
				return 0.44999998807907104 * num;
			}
			return num;
		}

		// Token: 0x040005F4 RID: 1524
		private static readonly double[] damages = new double[]
		{
			12.5,
			37.5,
			62.5,
			87.5,
			112.5
		};

		// Token: 0x040005F5 RID: 1525
		private static readonly double[] damagePercents = new double[]
		{
			0.6875,
			0.75,
			0.8125,
			0.875,
			0.9375
		};
	}
}
