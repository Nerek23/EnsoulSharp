using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E4 RID: 740
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Thresh", SpellSlot.E, 0)]
	public class DamageThreshE : DamageSpell
	{
		// Token: 0x06000EC5 RID: 3781 RVA: 0x000423D5 File Offset: 0x000405D5
		public DamageThreshE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x000423EB File Offset: 0x000405EB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageThreshE.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007FC RID: 2044
		private static readonly double[] damages = new double[]
		{
			75.0,
			115.0,
			155.0,
			195.0,
			235.0
		};
	}
}
