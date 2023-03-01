using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C3 RID: 451
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jhin", SpellSlot.R, 0)]
	public class DamageJhinR : DamageSpell
	{
		// Token: 0x06000B67 RID: 2919 RVA: 0x0003C434 File Offset: 0x0003A634
		public DamageJhinR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0003C44A File Offset: 0x0003A64A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageJhinR.damages[level] + 0.25 * (double)source.GetTotalAaDamage();
			return num + num * (double)Math.Min(3f, (100f - target.HealthPercent) * 3f);
		}

		// Token: 0x040006C2 RID: 1730
		private static readonly double[] damages = new double[]
		{
			50.0,
			125.0,
			200.0
		};
	}
}
