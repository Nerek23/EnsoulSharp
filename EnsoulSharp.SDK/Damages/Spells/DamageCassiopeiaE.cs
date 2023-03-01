using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014E RID: 334
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Cassiopeia", SpellSlot.E, 0)]
	public class DamageCassiopeiaE : DamageSpell
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x00039D75 File Offset: 0x00037F75
		public DamageCassiopeiaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00039D8C File Offset: 0x00037F8C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = (double)(48 + 4 * source.Level) + 0.1 * (double)source.TotalMagicalDamage;
			if (target.HasBuffOfType(BuffType.Poison))
			{
				return num + DamageCassiopeiaE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
			}
			return num;
		}

		// Token: 0x0400063C RID: 1596
		private static readonly double[] damages = new double[]
		{
			20.0,
			40.0,
			60.0,
			80.0,
			100.0
		};
	}
}
