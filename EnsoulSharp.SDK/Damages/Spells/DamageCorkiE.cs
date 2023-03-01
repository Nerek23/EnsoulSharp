using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000156 RID: 342
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.E, 0)]
	public class DamageCorkiE : DamageSpell
	{
		// Token: 0x06000A10 RID: 2576 RVA: 0x0003A07E File Offset: 0x0003827E
		public DamageCorkiE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0003A094 File Offset: 0x00038294
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiE.damages[level] + 0.15 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000644 RID: 1604
		private static readonly double[] damages = new double[]
		{
			7.5,
			10.625,
			13.75,
			16.875,
			20.0
		};
	}
}
