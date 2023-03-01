using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019A RID: 410
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gragas", SpellSlot.R, 0)]
	public class DamageGragasR : DamageSpell
	{
		// Token: 0x06000AE6 RID: 2790 RVA: 0x0003B7B9 File Offset: 0x000399B9
		public DamageGragasR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0003B7CF File Offset: 0x000399CF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGragasR.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000699 RID: 1689
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
