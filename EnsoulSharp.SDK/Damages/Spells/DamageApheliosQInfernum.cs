using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012D RID: 301
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.Q, 3)]
	public class DamageApheliosQInfernum : DamageSpell
	{
		// Token: 0x06000996 RID: 2454 RVA: 0x0003929E File Offset: 0x0003749E
		public DamageApheliosQInfernum()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 3;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x000392BC File Offset: 0x000374BC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosQInfernum.damages[Math.Min(source.Level - 1, 12)] + DamageApheliosQInfernum.damagePercents[Math.Min(source.Level - 1, 12)] * (double)source.GetBonusPhysicalDamage() + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000616 RID: 1558
		private static readonly double[] damages = new double[]
		{
			25.0,
			25.0,
			31.67,
			31.67,
			38.33,
			38.33,
			45.0,
			45.0,
			51.67,
			51.67,
			58.33,
			58.33,
			65.0
		};

		// Token: 0x04000617 RID: 1559
		private static readonly double[] damagePercents = new double[]
		{
			0.56,
			0.56,
			0.6,
			0.6,
			0.64,
			0.64,
			0.68,
			0.68,
			0.72,
			0.72,
			0.76,
			0.76,
			0.8
		};
	}
}
