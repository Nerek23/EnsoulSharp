using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000320 RID: 800
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Volibear", SpellSlot.E, 0)]
	public class DamageVolibearE : DamageSpell
	{
		// Token: 0x06000F79 RID: 3961 RVA: 0x000437C8 File Offset: 0x000419C8
		public DamageVolibearE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x000437DE File Offset: 0x000419DE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return Math.Min(DamageVolibearE.damages[level] + 0.8 * (double)source.TotalMagicalDamage + DamageVolibearE.damagePercents[level] * (double)target.MaxHealth, 750.0);
		}

		// Token: 0x04000840 RID: 2112
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};

		// Token: 0x04000841 RID: 2113
		private static readonly double[] damagePercents = new double[]
		{
			0.11,
			0.12,
			0.13,
			0.14,
			0.15
		};
	}
}
