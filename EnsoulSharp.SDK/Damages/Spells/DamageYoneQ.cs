using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000327 RID: 807
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yone", SpellSlot.Q, 0)]
	public class DamageYoneQ : DamageSpell
	{
		// Token: 0x06000F8E RID: 3982 RVA: 0x00043A39 File Offset: 0x00041C39
		public DamageYoneQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x00043A4F File Offset: 0x00041C4F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYoneQ.damage[level] + 1.05 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000849 RID: 2121
		private static readonly double[] damage = new double[]
		{
			20.0,
			40.0,
			60.0,
			80.0,
			100.0
		};
	}
}
