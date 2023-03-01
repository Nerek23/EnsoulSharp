using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000132 RID: 306
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ashe", SpellSlot.R, 0)]
	public class DamageAsheR : DamageSpell
	{
		// Token: 0x060009A5 RID: 2469 RVA: 0x0003954D File Offset: 0x0003774D
		public DamageAsheR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00039563 File Offset: 0x00037763
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAsheR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400061F RID: 1567
		private static readonly double[] damages = new double[]
		{
			200.0,
			400.0,
			600.0
		};
	}
}
