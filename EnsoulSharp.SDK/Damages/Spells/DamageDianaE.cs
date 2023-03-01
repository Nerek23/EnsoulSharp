using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000162 RID: 354
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Diana", SpellSlot.E, 0)]
	public class DamageDianaE : DamageSpell
	{
		// Token: 0x06000A3E RID: 2622 RVA: 0x0003A4AD File Offset: 0x000386AD
		public DamageDianaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0003A4C3 File Offset: 0x000386C3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDianaE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000656 RID: 1622
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
