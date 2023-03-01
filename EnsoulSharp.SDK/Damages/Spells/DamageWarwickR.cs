using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000325 RID: 805
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Warwick", SpellSlot.R, 0)]
	public class DamageWarwickR : DamageSpell
	{
		// Token: 0x06000F88 RID: 3976 RVA: 0x00043993 File Offset: 0x00041B93
		public DamageWarwickR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x000439A9 File Offset: 0x00041BA9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageWarwickR.damages[level] + 1.67 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000846 RID: 2118
		private static readonly double[] damages = new double[]
		{
			175.0,
			350.0,
			525.0
		};
	}
}
