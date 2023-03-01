using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012A RID: 298
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Annie", SpellSlot.R, 0)]
	public class DamageAnnieR : DamageSpell
	{
		// Token: 0x0600098D RID: 2445 RVA: 0x0003916D File Offset: 0x0003736D
		public DamageAnnieR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00039183 File Offset: 0x00037383
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAnnieR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000612 RID: 1554
		private static readonly double[] damages = new double[]
		{
			150.0,
			275.0,
			400.0
		};
	}
}
