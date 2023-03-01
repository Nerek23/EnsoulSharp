using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000271 RID: 625
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Quinn", SpellSlot.Q, 0)]
	public class DamageQuinnQ : DamageSpell
	{
		// Token: 0x06000D6D RID: 3437 RVA: 0x0003FCB9 File Offset: 0x0003DEB9
		public DamageQuinnQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x0003FCCF File Offset: 0x0003DECF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQuinnQ.damages[level] + DamageQuinnQ.damagePercents[level] * (double)source.TotalAttackDamage + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000779 RID: 1913
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};

		// Token: 0x0400077A RID: 1914
		private static readonly double[] damagePercents = new double[]
		{
			0.8,
			0.9,
			1.0,
			1.1,
			1.2
		};
	}
}
