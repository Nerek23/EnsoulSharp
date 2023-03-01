using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BA RID: 442
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jax", SpellSlot.Q, 0)]
	public class DamageJaxQ : DamageSpell
	{
		// Token: 0x06000B4C RID: 2892 RVA: 0x0003C13B File Offset: 0x0003A33B
		public DamageJaxQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0003C151 File Offset: 0x0003A351
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJaxQ.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x040006B7 RID: 1719
		private static readonly double[] damages = new double[]
		{
			65.0,
			105.0,
			145.0,
			185.0,
			225.0
		};
	}
}
