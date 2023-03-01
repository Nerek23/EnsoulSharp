using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BA RID: 698
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sivir", SpellSlot.Q, 0)]
	public class DamageSivirQ : DamageSpell
	{
		// Token: 0x06000E47 RID: 3655 RVA: 0x000415AF File Offset: 0x0003F7AF
		public DamageSivirQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x000415C5 File Offset: 0x0003F7C5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSivirQ.damages[level] + DamageSivirQ.damagePercents[level] * (double)source.TotalAttackDamage + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D0 RID: 2000
		private static readonly double[] damages = new double[]
		{
			15.0,
			30.0,
			45.0,
			60.0,
			75.0
		};

		// Token: 0x040007D1 RID: 2001
		private static readonly double[] damagePercents = new double[]
		{
			0.8,
			0.85,
			0.9,
			0.95,
			1.0
		};
	}
}
