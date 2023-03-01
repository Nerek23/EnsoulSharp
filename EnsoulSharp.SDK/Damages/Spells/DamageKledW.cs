using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E6 RID: 486
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kled", SpellSlot.W, 0)]
	public class DamageKledW : DamageSpell
	{
		// Token: 0x06000BCE RID: 3022 RVA: 0x0003D0CB File Offset: 0x0003B2CB
		public DamageKledW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0003D0E1 File Offset: 0x0003B2E1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledW.damages[level] + (DamageKledW.damagePercents[level] + 0.05 * (double)source.GetBonusPhysicalDamage() / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x040006E9 RID: 1769
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};

		// Token: 0x040006EA RID: 1770
		private static readonly double[] damagePercents = new double[]
		{
			0.045,
			0.05,
			0.055,
			0.06,
			0.065
		};
	}
}
