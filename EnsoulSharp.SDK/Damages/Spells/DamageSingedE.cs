using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B3 RID: 691
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Singed", SpellSlot.E, 0)]
	public class DamageSingedE : DamageSpell
	{
		// Token: 0x06000E32 RID: 3634 RVA: 0x00041335 File Offset: 0x0003F535
		public DamageSingedE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0004134B File Offset: 0x0003F54B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSingedE.damages[level] + 0.75 * (double)source.TotalMagicalDamage + DamageSingedE.damagePercents[level] * (double)target.MaxHealth;
		}

		// Token: 0x040007C5 RID: 1989
		private static readonly double[] damages = new double[]
		{
			50.0,
			60.0,
			70.0,
			80.0,
			90.0
		};

		// Token: 0x040007C6 RID: 1990
		private static readonly double[] damagePercents = new double[]
		{
			0.06,
			0.065,
			0.07,
			0.075,
			0.08
		};
	}
}
