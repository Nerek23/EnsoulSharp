using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B6 RID: 694
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sion", SpellSlot.Q, 0)]
	public class DamageSionQ : DamageSpell
	{
		// Token: 0x06000E3B RID: 3643 RVA: 0x00041436 File Offset: 0x0003F636
		public DamageSionQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x0004144C File Offset: 0x0003F64C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSionQ.damages[level] + DamageSionQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x040007C9 RID: 1993
		private static readonly double[] damages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};

		// Token: 0x040007CA RID: 1994
		private static readonly double[] damagePercents = new double[]
		{
			0.45,
			0.525,
			0.6,
			0.675,
			0.75
		};
	}
}
