using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000142 RID: 322
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Braum", SpellSlot.Q, 0)]
	public class DamageBraumQ : DamageSpell
	{
		// Token: 0x060009D4 RID: 2516 RVA: 0x000399DC File Offset: 0x00037BDC
		public DamageBraumQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000399F2 File Offset: 0x00037BF2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBraumQ.damages[level] + 0.025 * (double)source.MaxHealth;
		}

		// Token: 0x0400062E RID: 1582
		private static readonly double[] damages = new double[]
		{
			75.0,
			125.0,
			175.0,
			225.0,
			275.0
		};
	}
}
