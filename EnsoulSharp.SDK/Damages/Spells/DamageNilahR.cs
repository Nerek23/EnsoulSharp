using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000103 RID: 259
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nilah", SpellSlot.R, 0)]
	public class DamageNilahR : DamageSpell
	{
		// Token: 0x06000918 RID: 2328 RVA: 0x00038456 File Offset: 0x00036656
		public DamageNilahR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x0003846C File Offset: 0x0003666C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNilahR.r1damages[level] + DamageNilahR.r2damages[level] + 2.6 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040005E5 RID: 1509
		private static readonly double[] r1damages = new double[]
		{
			60.0,
			120.0,
			180.0
		};

		// Token: 0x040005E6 RID: 1510
		private static readonly double[] r2damages = new double[]
		{
			125.0,
			225.0,
			325.0
		};
	}
}
