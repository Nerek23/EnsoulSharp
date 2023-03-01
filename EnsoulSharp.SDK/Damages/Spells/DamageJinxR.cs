using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C8 RID: 456
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jinx", SpellSlot.R, 0)]
	public class DamageJinxR : DamageSpell
	{
		// Token: 0x06000B75 RID: 2933 RVA: 0x0003C5C4 File Offset: 0x0003A7C4
		public DamageJinxR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x0003C5DA File Offset: 0x0003A7DA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJinxR.damages[level] + DamageJinxR.damagePercents[level] * (double)(target.MaxHealth - target.Health) + 0.15 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006C6 RID: 1734
		private static readonly double[] damages = new double[]
		{
			300.0,
			450.0,
			600.0
		};

		// Token: 0x040006C7 RID: 1735
		private static readonly double[] damagePercents = new double[]
		{
			0.25,
			0.3,
			0.35
		};
	}
}
