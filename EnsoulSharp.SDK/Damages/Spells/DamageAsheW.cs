using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000133 RID: 307
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ashe", SpellSlot.W, 0)]
	public class DamageAsheW : DamageSpell
	{
		// Token: 0x060009A8 RID: 2472 RVA: 0x00039592 File Offset: 0x00037792
		public DamageAsheW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x000395A8 File Offset: 0x000377A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAsheW.damages[level] + (double)(1f * source.TotalAttackDamage);
		}

		// Token: 0x04000620 RID: 1568
		private static readonly double[] damages = new double[]
		{
			20.0,
			35.0,
			50.0,
			65.0,
			80.0
		};
	}
}
