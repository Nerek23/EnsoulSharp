using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025A RID: 602
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ornn", SpellSlot.E, 0)]
	public class DamageOrnnE : DamageSpell
	{
		// Token: 0x06000D28 RID: 3368 RVA: 0x0003F58C File Offset: 0x0003D78C
		public DamageOrnnE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0003F5A2 File Offset: 0x0003D7A2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOrnnE.damages[level] + 0.4 * (double)source.BonusArmor + 0.4 * (double)source.BonusSpellBlock;
		}

		// Token: 0x04000761 RID: 1889
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
