using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033A RID: 826
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zeri", SpellSlot.Q, 0)]
	public class DamageZeriQ : DamageSpell
	{
		// Token: 0x06000FC7 RID: 4039 RVA: 0x0004402B File Offset: 0x0004222B
		public DamageZeriQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00044041 File Offset: 0x00042241
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZeriQ.damage[level] + DamageZeriQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x0400085C RID: 2140
		private static readonly double[] damage = new double[]
		{
			15.0,
			17.0,
			19.0,
			21.0,
			23.0
		};

		// Token: 0x0400085D RID: 2141
		private static readonly double[] damagePercents = new double[]
		{
			1.04,
			1.08,
			1.12,
			1.16,
			1.2
		};
	}
}
