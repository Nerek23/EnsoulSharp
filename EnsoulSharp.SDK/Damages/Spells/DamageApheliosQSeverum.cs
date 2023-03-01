using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012F RID: 303
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.Q, 1)]
	public class DamageApheliosQSeverum : DamageSpell
	{
		// Token: 0x0600099C RID: 2460 RVA: 0x000393DE File Offset: 0x000375DE
		public DamageApheliosQSeverum()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000393FB File Offset: 0x000375FB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosQSeverum.damages[Math.Min(source.Level - 1, 12)] + DamageApheliosQSeverum.damagePercents[Math.Min(source.Level - 1, 12)] * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400061A RID: 1562
		private static readonly double[] damages = new double[]
		{
			10.0,
			10.0,
			13.33,
			13.33,
			16.67,
			16.67,
			20.0,
			20.0,
			23.33,
			23.33,
			26.67,
			26.67,
			30.0
		};

		// Token: 0x0400061B RID: 1563
		private static readonly double[] damagePercents = new double[]
		{
			0.21,
			0.21,
			0.225,
			0.225,
			0.24,
			0.24,
			0.255,
			0.255,
			0.27,
			0.27,
			0.285,
			0.285,
			0.3
		};
	}
}
