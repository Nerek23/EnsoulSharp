using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012C RID: 300
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.Q, 4)]
	public class DamageApheliosQCrescendum : DamageSpell
	{
		// Token: 0x06000993 RID: 2451 RVA: 0x000391FF File Offset: 0x000373FF
		public DamageApheliosQCrescendum()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 4;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0003921C File Offset: 0x0003741C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosQCrescendum.damages[Math.Min(source.Level - 1, 12)] + DamageApheliosQCrescendum.damagePercents[Math.Min(source.Level - 1, 12)] * (double)source.GetBonusPhysicalDamage() + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000614 RID: 1556
		private static readonly double[] damages = new double[]
		{
			31.0,
			31.0,
			42.5,
			42.5,
			54.0,
			54.0,
			65.5,
			65.5,
			77.0,
			77.0,
			88.5,
			88.5,
			100.0
		};

		// Token: 0x04000615 RID: 1557
		private static readonly double[] damagePercents = new double[]
		{
			0.4,
			0.4,
			0.4333,
			0.4333,
			0.4667,
			0.4667,
			0.5,
			0.5,
			0.5333,
			0.5333,
			0.5337,
			0.5337,
			0.6
		};
	}
}
