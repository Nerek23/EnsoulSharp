using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CE RID: 718
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Swain", SpellSlot.R, 0)]
	public class DamageSwainR : DamageSpell
	{
		// Token: 0x06000E83 RID: 3715 RVA: 0x00041C16 File Offset: 0x0003FE16
		public DamageSwainR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00041C2C File Offset: 0x0003FE2C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSwainR.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E5 RID: 2021
		private static readonly double[] damages = new double[]
		{
			150.0,
			225.0,
			300.0
		};
	}
}
