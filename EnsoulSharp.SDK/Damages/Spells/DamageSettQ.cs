using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000290 RID: 656
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sett", SpellSlot.Q, 0)]
	public class DamageSettQ : DamageSpell
	{
		// Token: 0x06000DC9 RID: 3529 RVA: 0x0004068C File Offset: 0x0003E88C
		public DamageSettQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000406A2 File Offset: 0x0003E8A2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSettQ.damages[level] + (DamageSettQ.damagePercents[level] + 0.01 * (double)source.TotalAttackDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x0400079B RID: 1947
		private static readonly double[] damages = new double[]
		{
			10.0,
			20.0,
			30.0,
			40.0,
			50.0
		};

		// Token: 0x0400079C RID: 1948
		private static readonly double[] damagePercents = new double[]
		{
			0.01,
			0.02,
			0.03,
			0.04,
			0.05
		};
	}
}
