using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000277 RID: 631
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rammus", SpellSlot.R, 0)]
	public class DamageRammusR : DamageSpell
	{
		// Token: 0x06000D7E RID: 3454 RVA: 0x0003FE83 File Offset: 0x0003E083
		public DamageRammusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0003FE99 File Offset: 0x0003E099
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRammusR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400077F RID: 1919
		private static readonly double[] damages = new double[]
		{
			100.0,
			175.0,
			250.0
		};
	}
}
