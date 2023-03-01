using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000258 RID: 600
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Orianna", SpellSlot.R, 0)]
	public class DamageOriannaR : DamageSpell
	{
		// Token: 0x06000D22 RID: 3362 RVA: 0x0003F4FA File Offset: 0x0003D6FA
		public DamageOriannaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0003F510 File Offset: 0x0003D710
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOriannaR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400075F RID: 1887
		private static readonly double[] damages = new double[]
		{
			200.0,
			275.0,
			350.0
		};
	}
}
