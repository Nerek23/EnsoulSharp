using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021E RID: 542
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lulu", SpellSlot.E, 0)]
	public class DamageLuluE : DamageSpell
	{
		// Token: 0x06000C75 RID: 3189 RVA: 0x0003E2AA File Offset: 0x0003C4AA
		public DamageLuluE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x0003E2C0 File Offset: 0x0003C4C0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLuluE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000723 RID: 1827
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
