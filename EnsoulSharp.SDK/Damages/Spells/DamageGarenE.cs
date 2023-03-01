using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018E RID: 398
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Garen", SpellSlot.E, 0)]
	public class DamageGarenE : DamageSpell
	{
		// Token: 0x06000AC2 RID: 2754 RVA: 0x0003B358 File Offset: 0x00039558
		public DamageGarenE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0003B36E File Offset: 0x0003956E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGarenE.damages[level] + DamageGarenE.damagePercents[Math.Min(source.Level - 1, 17)] + DamageGarenE.totaldamagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000689 RID: 1673
		private static readonly double[] damages = new double[]
		{
			4.0,
			8.0,
			12.0,
			16.0,
			20.0
		};

		// Token: 0x0400068A RID: 1674
		private static readonly double[] damagePercents = new double[]
		{
			0.0,
			0.8,
			1.6,
			2.4,
			3.2,
			4.0,
			4.8,
			5.6,
			6.4,
			6.6,
			6.8,
			7.0,
			7.2,
			7.4,
			7.6,
			7.8,
			8.0,
			8.2
		};

		// Token: 0x0400068B RID: 1675
		private static readonly double[] totaldamagePercents = new double[]
		{
			0.32,
			0.34,
			0.36,
			0.38,
			0.4
		};
	}
}
