using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000122 RID: 290
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Amumu", SpellSlot.R, 0)]
	public class DamageAmumuR : DamageSpell
	{
		// Token: 0x06000975 RID: 2421 RVA: 0x00038EDB File Offset: 0x000370DB
		public DamageAmumuR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00038EF1 File Offset: 0x000370F1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAmumuR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000609 RID: 1545
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
