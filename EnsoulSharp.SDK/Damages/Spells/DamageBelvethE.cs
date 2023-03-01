using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F0 RID: 240
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Belveth", SpellSlot.E, 0)]
	public class DamageBelvethE : DamageSpell
	{
		// Token: 0x060008E0 RID: 2272 RVA: 0x00037CDA File Offset: 0x00035EDA
		public DamageBelvethE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00037CF0 File Offset: 0x00035EF0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBelvethE.damages[level] + 0.06 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040005D0 RID: 1488
		private static readonly double[] damages = new double[]
		{
			8.0,
			10.0,
			12.0,
			14.0,
			16.0
		};
	}
}
