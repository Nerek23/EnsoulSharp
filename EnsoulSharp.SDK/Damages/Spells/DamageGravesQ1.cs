using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019D RID: 413
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Graves", SpellSlot.Q, 1)]
	public class DamageGravesQ1 : DamageSpell
	{
		// Token: 0x06000AEF RID: 2799 RVA: 0x0003B8A2 File Offset: 0x00039AA2
		public DamageGravesQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0003B8BF File Offset: 0x00039ABF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGravesQ1.damages[level] + DamageGravesQ1.damagePercents[level] * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400069C RID: 1692
		private static readonly double[] damages = new double[]
		{
			85.0,
			120.0,
			155.0,
			190.0,
			225.0
		};

		// Token: 0x0400069D RID: 1693
		private static readonly double[] damagePercents = new double[]
		{
			0.4,
			0.7,
			1.0,
			1.3,
			1.6
		};
	}
}
