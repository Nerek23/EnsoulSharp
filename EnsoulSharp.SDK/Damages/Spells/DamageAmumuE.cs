using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000120 RID: 288
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Amumu", SpellSlot.E, 0)]
	public class DamageAmumuE : DamageSpell
	{
		// Token: 0x0600096F RID: 2415 RVA: 0x00038E49 File Offset: 0x00037049
		public DamageAmumuE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00038E5F File Offset: 0x0003705F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAmumuE.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000607 RID: 1543
		private static readonly double[] damages = new double[]
		{
			65.0,
			100.0,
			135.0,
			170.0,
			205.0
		};
	}
}
