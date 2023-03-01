using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032C RID: 812
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xerath", SpellSlot.E, 0)]
	public class DamageXerathE : DamageSpell
	{
		// Token: 0x06000F9D RID: 3997 RVA: 0x00043BAD File Offset: 0x00041DAD
		public DamageXerathE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x00043BC3 File Offset: 0x00041DC3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXerathE.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400084E RID: 2126
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
