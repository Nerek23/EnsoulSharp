using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000130 RID: 304
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.Q, 0)]
	public class DamageApheliosQCalibrum : DamageSpell
	{
		// Token: 0x0600099F RID: 2463 RVA: 0x00039460 File Offset: 0x00037660
		public DamageApheliosQCalibrum()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00039478 File Offset: 0x00037678
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosQCalibrum.damages[Math.Min(source.Level - 1, 12)] + DamageApheliosQCalibrum.damagePercents[Math.Min(source.Level - 1, 12)] * (double)source.GetBonusPhysicalDamage() + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400061C RID: 1564
		private static readonly double[] damages = new double[]
		{
			60.0,
			60.0,
			76.67,
			76.67,
			93.33,
			93.33,
			110.0,
			110.0,
			126.67,
			126.67,
			143.33,
			143.33,
			160.0
		};

		// Token: 0x0400061D RID: 1565
		private static readonly double[] damagePercents = new double[]
		{
			0.42,
			0.42,
			0.45,
			0.45,
			0.48,
			0.48,
			0.51,
			0.51,
			0.54,
			0.54,
			0.57,
			0.57,
			0.6
		};
	}
}
