using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028D RID: 653
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Samira", SpellSlot.R, 0)]
	public class DamageSamiraR : DamageSpell
	{
		// Token: 0x06000DC0 RID: 3520 RVA: 0x000405B5 File Offset: 0x0003E7B5
		public DamageSamiraR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x000405CB File Offset: 0x0003E7CB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSamiraR.damage[level] + 0.5 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000798 RID: 1944
		private static readonly double[] damage = new double[]
		{
			5.0,
			15.0,
			25.0
		};
	}
}
