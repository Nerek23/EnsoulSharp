using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200012E RID: 302
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.Q, 2)]
	public class DamageApheliosQGravitum : DamageSpell
	{
		// Token: 0x06000999 RID: 2457 RVA: 0x0003933E File Offset: 0x0003753E
		public DamageApheliosQGravitum()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 2;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0003935C File Offset: 0x0003755C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosQGravitum.damages[Math.Min(source.Level - 1, 12)] + DamageApheliosQGravitum.damagePercents[Math.Min(source.Level - 1, 12)] * (double)source.GetBonusPhysicalDamage() + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000618 RID: 1560
		private static readonly double[] damages = new double[]
		{
			50.0,
			50.0,
			60.0,
			60.0,
			70.0,
			70.0,
			80.0,
			80.0,
			90.0,
			90.0,
			100.0,
			100.0,
			110.0
		};

		// Token: 0x04000619 RID: 1561
		private static readonly double[] damagePercents = new double[]
		{
			0.26,
			0.26,
			0.275,
			0.275,
			0.29,
			0.29,
			0.305,
			0.305,
			0.32,
			0.32,
			0.335,
			0.335,
			0.35
		};
	}
}
