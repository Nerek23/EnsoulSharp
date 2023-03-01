using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BE RID: 702
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Skarner", SpellSlot.R, 0)]
	public class DamageSkarnerR : DamageSpell
	{
		// Token: 0x06000E53 RID: 3667 RVA: 0x00041722 File Offset: 0x0003F922
		public DamageSkarnerR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00041738 File Offset: 0x0003F938
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSkarnerR.damages[level] + 0.6 * (double)source.GetTotalAaDamage() + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D5 RID: 2005
		private static readonly double[] damages = new double[]
		{
			20.0,
			60.0,
			100.0
		};
	}
}
