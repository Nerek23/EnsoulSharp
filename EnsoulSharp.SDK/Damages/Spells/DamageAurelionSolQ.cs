using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000135 RID: 309
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("AurelionSol", SpellSlot.Q, 0)]
	public class DamageAurelionSolQ : DamageSpell
	{
		// Token: 0x060009AE RID: 2478 RVA: 0x00039620 File Offset: 0x00037820
		public DamageAurelionSolQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x00039636 File Offset: 0x00037836
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (double)(20 + level) + DamageAurelionSolQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000622 RID: 1570
		private static readonly double[] damages = new double[]
		{
			40.0,
			50.0,
			60.0,
			70.0,
			80.0
		};
	}
}
