using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000151 RID: 337
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Cassiopeia", SpellSlot.W, 0)]
	public class DamageCassiopeiaW : DamageSpell
	{
		// Token: 0x06000A01 RID: 2561 RVA: 0x00039E89 File Offset: 0x00038089
		public DamageCassiopeiaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00039E9F File Offset: 0x0003809F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCassiopeiaW.damages[level] + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400063F RID: 1599
		private static readonly double[] damages = new double[]
		{
			20.0,
			25.0,
			30.0,
			35.0,
			40.0
		};
	}
}
