using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200015A RID: 346
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.W, 0)]
	public class DamageCorkiW : DamageSpell
	{
		// Token: 0x06000A1C RID: 2588 RVA: 0x0003A207 File Offset: 0x00038407
		public DamageCorkiW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0003A21D File Offset: 0x0003841D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiW.damages[level] + 0.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400064A RID: 1610
		private static readonly double[] damages = new double[]
		{
			150.0,
			225.0,
			300.0,
			375.0,
			450.0
		};
	}
}
