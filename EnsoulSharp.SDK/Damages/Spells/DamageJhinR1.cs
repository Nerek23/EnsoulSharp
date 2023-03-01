using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C4 RID: 452
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jhin", SpellSlot.R, 1)]
	public class DamageJhinR1 : DamageSpell
	{
		// Token: 0x06000B6A RID: 2922 RVA: 0x0003C49D File Offset: 0x0003A69D
		public DamageJhinR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0003C4BA File Offset: 0x0003A6BA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageJhinR1.damages[level] + 0.4 * (double)source.GetTotalAaDamage();
			return num + num * (double)Math.Min(3f, (100f - target.HealthPercent) * 3f);
		}

		// Token: 0x040006C3 RID: 1731
		private static readonly double[] damages = new double[]
		{
			100.0,
			250.0,
			400.0
		};
	}
}
