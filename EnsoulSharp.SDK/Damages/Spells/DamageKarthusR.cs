using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D5 RID: 469
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karthus", SpellSlot.R, 0)]
	public class DamageKarthusR : DamageSpell
	{
		// Token: 0x06000B9C RID: 2972 RVA: 0x0003CAD6 File Offset: 0x0003ACD6
		public DamageKarthusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0003CAEC File Offset: 0x0003ACEC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarthusR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D8 RID: 1752
		private static readonly double[] damages = new double[]
		{
			250.0,
			350.0,
			500.0
		};
	}
}
