using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025C RID: 604
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ornn", SpellSlot.R, 0)]
	public class DamageOrnnR : DamageSpell
	{
		// Token: 0x06000D2E RID: 3374 RVA: 0x0003F630 File Offset: 0x0003D830
		public DamageOrnnR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0003F646 File Offset: 0x0003D846
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOrnnR.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000763 RID: 1891
		private static readonly double[] damages = new double[]
		{
			125.0,
			175.0,
			225.0
		};
	}
}
