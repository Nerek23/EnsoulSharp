using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000339 RID: 825
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zeri", SpellSlot.R, 0)]
	public class DamageZeriR : DamageSpell
	{
		// Token: 0x06000FC4 RID: 4036 RVA: 0x00043FDA File Offset: 0x000421DA
		public DamageZeriR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x00043FF0 File Offset: 0x000421F0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZeriR.damage[level] + (double)source.GetBonusAaDamage() + 1.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400085B RID: 2139
		private static readonly double[] damage = new double[]
		{
			175.0,
			275.0,
			375.0
		};
	}
}
