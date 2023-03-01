using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010E RID: 270
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aatrox", SpellSlot.Q, 2)]
	public class DamageAatroxQ2 : DamageSpell
	{
		// Token: 0x06000939 RID: 2361 RVA: 0x000387E3 File Offset: 0x000369E3
		public DamageAatroxQ2()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 2;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00038800 File Offset: 0x00036A00
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAatroxQ2.damages[level] + DamageAatroxQ2.damagePercents[level] * (double)source.TotalAttackDamage;
			if (target.IsMinion())
			{
				return 0.44999998807907104 * num;
			}
			return num;
		}

		// Token: 0x040005F2 RID: 1522
		private static readonly double[] damages = new double[]
		{
			15.0,
			45.0,
			75.0,
			105.0,
			135.0
		};

		// Token: 0x040005F3 RID: 1523
		private static readonly double[] damagePercents = new double[]
		{
			0.825,
			0.9,
			0.975,
			1.05,
			1.125
		};
	}
}
