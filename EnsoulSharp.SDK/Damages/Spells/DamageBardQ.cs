using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013A RID: 314
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Bard", SpellSlot.Q, 0)]
	public class DamageBardQ : DamageSpell
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x000397A2 File Offset: 0x000379A2
		public DamageBardQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x000397B8 File Offset: 0x000379B8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBardQ.damages[level] + 0.65 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000627 RID: 1575
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
