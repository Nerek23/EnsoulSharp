using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011A RID: 282
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akali", SpellSlot.R, 1)]
	public class DamageAkaliR1 : DamageSpell
	{
		// Token: 0x0600095D RID: 2397 RVA: 0x00038C2D File Offset: 0x00036E2D
		public DamageAkaliR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00038C4C File Offset: 0x00036E4C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAkaliR1.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
			if (target.HealthPercent <= 30f)
			{
				return 2.0 * num;
			}
			float num2 = 2.86f * (100f - target.HealthPercent) / 100f + 1f;
			return num * (double)num2;
		}

		// Token: 0x04000601 RID: 1537
		private static readonly double[] damages = new double[]
		{
			60.0,
			130.0,
			200.0
		};
	}
}
