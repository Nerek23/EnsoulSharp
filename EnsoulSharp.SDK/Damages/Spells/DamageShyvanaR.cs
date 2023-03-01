using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B1 RID: 689
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shyvana", SpellSlot.R, 0)]
	public class DamageShyvanaR : DamageSpell
	{
		// Token: 0x06000E2C RID: 3628 RVA: 0x000412A3 File Offset: 0x0003F4A3
		public DamageShyvanaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x000412B9 File Offset: 0x0003F4B9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShyvanaR.damages[level] + 1.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007C3 RID: 1987
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
