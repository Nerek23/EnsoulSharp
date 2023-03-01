using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C1 RID: 449
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jhin", SpellSlot.E, 0)]
	public class DamageJhinE : DamageSpell
	{
		// Token: 0x06000B61 RID: 2913 RVA: 0x0003C36E File Offset: 0x0003A56E
		public DamageJhinE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0003C384 File Offset: 0x0003A584
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJhinE.damages[level] + 1.2 * (double)source.TotalAttackDamage + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x040006BF RID: 1727
		private static readonly double[] damages = new double[]
		{
			20.0,
			80.0,
			140.0,
			200.0,
			260.0
		};
	}
}
