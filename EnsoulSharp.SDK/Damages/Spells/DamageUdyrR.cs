using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F4 RID: 756
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Udyr", SpellSlot.R, 0)]
	public class DamageUdyrR : DamageSpell
	{
		// Token: 0x06000EF5 RID: 3829 RVA: 0x0004296B File Offset: 0x00040B6B
		public DamageUdyrR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00042981 File Offset: 0x00040B81
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageUdyrR.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400080F RID: 2063
		private static readonly double[] damages = new double[]
		{
			20.0,
			36.0,
			52.0,
			68.0,
			84.0,
			100.0
		};
	}
}
