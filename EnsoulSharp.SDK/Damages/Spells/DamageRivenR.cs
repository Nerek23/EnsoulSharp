using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000297 RID: 663
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Riven", SpellSlot.R, 0)]
	public class DamageRivenR : DamageSpell
	{
		// Token: 0x06000DDE RID: 3550 RVA: 0x00040907 File Offset: 0x0003EB07
		public DamageRivenR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00040920 File Offset: 0x0003EB20
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageRivenR.mindamages[level] + 0.6 * (double)source.GetBonusAaDamage();
			double val = DamageRivenR.maxdamages[level] + 0.6 * (double)source.GetBonusAaDamage();
			float num2 = (100f - (target.MaxHealth - target.Health) / target.MaxHealth * 100f) * 0.02667f;
			return Math.Min(num * (double)num2, val);
		}

		// Token: 0x040007A5 RID: 1957
		private static readonly double[] mindamages = new double[]
		{
			100.0,
			150.0,
			200.0
		};

		// Token: 0x040007A6 RID: 1958
		private static readonly double[] maxdamages = new double[]
		{
			300.0,
			450.0,
			600.0
		};
	}
}
