using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000146 RID: 326
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.Q, 1)]
	public class DamageCamilleQ1 : DamageSpell
	{
		// Token: 0x060009E0 RID: 2528 RVA: 0x00039AFD File Offset: 0x00037CFD
		public DamageCamilleQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00039B1A File Offset: 0x00037D1A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleQ1.damages[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000632 RID: 1586
		private static readonly double[] damages = new double[]
		{
			0.4,
			0.5,
			0.6,
			0.7,
			0.8
		};
	}
}
