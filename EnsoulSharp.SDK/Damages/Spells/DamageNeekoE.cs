using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020E RID: 526
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Neeko", SpellSlot.E, 0)]
	public class DamageNeekoE : DamageSpell
	{
		// Token: 0x06000C45 RID: 3141 RVA: 0x0003DDED File Offset: 0x0003BFED
		public DamageNeekoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0003DE03 File Offset: 0x0003C003
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNeekoE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000712 RID: 1810
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
