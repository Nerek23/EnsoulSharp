using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000110 RID: 272
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aatrox", SpellSlot.Q, 0)]
	public class DamageAatroxQ : DamageSpell
	{
		// Token: 0x0600093F RID: 2367 RVA: 0x000388F0 File Offset: 0x00036AF0
		public DamageAatroxQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00038908 File Offset: 0x00036B08
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAatroxQ.damages[level] + DamageAatroxQ.damagePercents[level] * (double)source.GetTotalAaDamage();
			if (target.IsMinion())
			{
				return 0.44999998807907104 * num;
			}
			return num;
		}

		// Token: 0x040005F6 RID: 1526
		private static readonly double[] damages = new double[]
		{
			10.0,
			30.0,
			50.0,
			70.0,
			90.0
		};

		// Token: 0x040005F7 RID: 1527
		private static readonly double[] damagePercents = new double[]
		{
			0.55,
			0.6,
			0.65,
			0.7,
			0.75
		};
	}
}
