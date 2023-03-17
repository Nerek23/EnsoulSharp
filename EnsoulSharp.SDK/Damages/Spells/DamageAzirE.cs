using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000136 RID: 310
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Azir", SpellSlot.E, 0)]
	public class DamageAzirE : DamageSpell
	{
		// Token: 0x060009B1 RID: 2481 RVA: 0x0003966F File Offset: 0x0003786F
		public DamageAzirE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00039685 File Offset: 0x00037885
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAzirE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000623 RID: 1571
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
