using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000158 RID: 344
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.R, 0)]
	public class DamageCorkiR : DamageSpell
	{
		// Token: 0x06000A16 RID: 2582 RVA: 0x0003A122 File Offset: 0x00038322
		public DamageCorkiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0003A138 File Offset: 0x00038338
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiR.damages[level] + DamageCorkiR.damagePercents[level] * (double)source.GetTotalAaDamage() + 0.12 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000646 RID: 1606
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0
		};

		// Token: 0x04000647 RID: 1607
		private static readonly double[] damagePercents = new double[]
		{
			0.15,
			0.45,
			0.75
		};
	}
}
