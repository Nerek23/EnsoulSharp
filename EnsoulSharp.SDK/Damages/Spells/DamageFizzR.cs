using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000186 RID: 390
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.R, 0)]
	public class DamageFizzR : DamageSpell
	{
		// Token: 0x06000AAA RID: 2730 RVA: 0x0003B114 File Offset: 0x00039314
		public DamageFizzR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0003B12A File Offset: 0x0003932A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000681 RID: 1665
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
