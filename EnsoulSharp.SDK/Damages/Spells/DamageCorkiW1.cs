using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200015B RID: 347
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.W, 1)]
	public class DamageCorkiW1 : DamageSpell
	{
		// Token: 0x06000A1F RID: 2591 RVA: 0x0003A250 File Offset: 0x00038450
		public DamageCorkiW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0003A26D File Offset: 0x0003846D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiW1.damages[Math.Min(source.Level - 1, 17)] + (double)(10f * source.GetBonusPhysicalDamage()) + 1.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400064B RID: 1611
		private static readonly double[] damages = new double[]
		{
			150.0,
			150.0,
			150.0,
			150.0,
			150.0,
			150.0,
			150.0,
			175.0,
			200.0,
			225.0,
			250.0,
			275.0,
			300.0,
			325.0,
			350.0,
			400.0,
			450.0,
			500.0
		};
	}
}
