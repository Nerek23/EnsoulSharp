using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C0 RID: 704
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sona", SpellSlot.R, 0)]
	public class DamageSonaR : DamageSpell
	{
		// Token: 0x06000E59 RID: 3673 RVA: 0x000417C6 File Offset: 0x0003F9C6
		public DamageSonaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000417DC File Offset: 0x0003F9DC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSonaR.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D7 RID: 2007
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
