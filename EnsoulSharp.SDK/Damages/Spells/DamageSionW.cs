using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B9 RID: 697
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sion", SpellSlot.W, 0)]
	public class DamageSionW : DamageSpell
	{
		// Token: 0x06000E44 RID: 3652 RVA: 0x00041540 File Offset: 0x0003F740
		public DamageSionW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00041556 File Offset: 0x0003F756
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSionW.damages[level] + 0.4 * (double)source.TotalMagicalDamage + DamageSionW.damagePercents[level] * (double)target.MaxHealth;
		}

		// Token: 0x040007CE RID: 1998
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};

		// Token: 0x040007CF RID: 1999
		private static readonly double[] damagePercents = new double[]
		{
			0.1,
			0.11,
			0.12,
			0.13,
			0.14
		};
	}
}
