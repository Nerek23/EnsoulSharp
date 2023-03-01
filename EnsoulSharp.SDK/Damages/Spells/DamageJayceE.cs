using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001BD RID: 445
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jayce", SpellSlot.E, 0)]
	public class DamageJayceE : DamageSpell
	{
		// Token: 0x06000B55 RID: 2901 RVA: 0x0003C208 File Offset: 0x0003A408
		public DamageJayceE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0003C220 File Offset: 0x0003A420
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageJayceE.damages[level] * (double)target.MaxHealth + (double)(1f * source.GetBonusPhysicalDamage());
			if (!target.IsJungle())
			{
				return num;
			}
			return Math.Min(DamageJayceE.maxdamages[level], num);
		}

		// Token: 0x040006BA RID: 1722
		private static readonly double[] damages = new double[]
		{
			0.08,
			0.108,
			0.136,
			0.164,
			0.192,
			0.22
		};

		// Token: 0x040006BB RID: 1723
		private static readonly double[] maxdamages = new double[]
		{
			200.0,
			300.0,
			400.0,
			500.0,
			600.0,
			700.0
		};
	}
}
