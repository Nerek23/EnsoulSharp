using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014F RID: 335
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Cassiopeia", SpellSlot.Q, 0)]
	public class DamageCassiopeiaQ : DamageSpell
	{
		// Token: 0x060009FB RID: 2555 RVA: 0x00039DF7 File Offset: 0x00037FF7
		public DamageCassiopeiaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00039E0D File Offset: 0x0003800D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCassiopeiaQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400063D RID: 1597
		private static readonly double[] damages = new double[]
		{
			75.0,
			110.0,
			145.0,
			180.0,
			215.0
		};
	}
}
