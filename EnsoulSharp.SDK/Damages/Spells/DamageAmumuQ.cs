using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000121 RID: 289
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Amumu", SpellSlot.Q, 0)]
	public class DamageAmumuQ : DamageSpell
	{
		// Token: 0x06000972 RID: 2418 RVA: 0x00038E92 File Offset: 0x00037092
		public DamageAmumuQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00038EA8 File Offset: 0x000370A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAmumuQ.damages[level] + 0.85 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000608 RID: 1544
		private static readonly double[] damages = new double[]
		{
			70.0,
			95.0,
			120.0,
			145.0,
			170.0
		};
	}
}
