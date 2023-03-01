using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000144 RID: 324
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.E, 0)]
	public class DamageCamilleE : DamageSpell
	{
		// Token: 0x060009DA RID: 2522 RVA: 0x00039A6E File Offset: 0x00037C6E
		public DamageCamilleE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00039A84 File Offset: 0x00037C84
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleE.damages[level] + 0.9 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000630 RID: 1584
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
