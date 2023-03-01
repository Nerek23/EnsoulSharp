using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A9 RID: 681
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shaco", SpellSlot.R, 0)]
	public class DamageShacoR : DamageSpell
	{
		// Token: 0x06000E14 RID: 3604 RVA: 0x00040F17 File Offset: 0x0003F117
		public DamageShacoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00040F2D File Offset: 0x0003F12D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShacoR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007B8 RID: 1976
		private static readonly double[] damages = new double[]
		{
			150.0,
			225.0,
			300.0
		};
	}
}
