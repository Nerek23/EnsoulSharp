using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000143 RID: 323
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Braum", SpellSlot.R, 0)]
	public class DamageBraumR : DamageSpell
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x00039A25 File Offset: 0x00037C25
		public DamageBraumR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00039A3B File Offset: 0x00037C3B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBraumR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400062F RID: 1583
		private static readonly double[] damages = new double[]
		{
			150.0,
			300.0,
			450.0
		};
	}
}
