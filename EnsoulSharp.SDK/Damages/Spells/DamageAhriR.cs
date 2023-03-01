using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000115 RID: 277
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ahri", SpellSlot.R, 0)]
	public class DamageAhriR : DamageSpell
	{
		// Token: 0x0600094E RID: 2382 RVA: 0x00038A9B File Offset: 0x00036C9B
		public DamageAhriR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00038AB1 File Offset: 0x00036CB1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAhriR.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005FC RID: 1532
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0
		};
	}
}
