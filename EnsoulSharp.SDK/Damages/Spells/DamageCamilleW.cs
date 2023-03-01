using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000149 RID: 329
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.W, 0)]
	public class DamageCamilleW : DamageSpell
	{
		// Token: 0x060009E9 RID: 2537 RVA: 0x00039BE4 File Offset: 0x00037DE4
		public DamageCamilleW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00039BFA File Offset: 0x00037DFA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleW.damages[level] + 0.6 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000635 RID: 1589
		private static readonly double[] damages = new double[]
		{
			70.0,
			100.0,
			130.0,
			160.0,
			190.0
		};
	}
}
