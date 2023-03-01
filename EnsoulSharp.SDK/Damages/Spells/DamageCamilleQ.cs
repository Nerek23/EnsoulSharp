using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000147 RID: 327
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.Q, 0)]
	public class DamageCamilleQ : DamageSpell
	{
		// Token: 0x060009E3 RID: 2531 RVA: 0x00039B43 File Offset: 0x00037D43
		public DamageCamilleQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00039B59 File Offset: 0x00037D59
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleQ.damages[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000633 RID: 1587
		private static readonly double[] damages = new double[]
		{
			0.2,
			0.25,
			0.3,
			0.35,
			0.4
		};
	}
}
