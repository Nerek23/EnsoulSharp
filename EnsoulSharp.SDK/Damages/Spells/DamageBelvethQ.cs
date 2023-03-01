using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F1 RID: 241
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Belveth", SpellSlot.Q, 0)]
	public class DamageBelvethQ : DamageSpell
	{
		// Token: 0x060008E3 RID: 2275 RVA: 0x00037D23 File Offset: 0x00035F23
		public DamageBelvethQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00037D3C File Offset: 0x00035F3C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageBelvethQ.damages[level] + 1.1 * (double)source.TotalAttackDamage;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				if (target.IsMinion())
				{
					num *= DamageBelvethQ.miniondamages[level];
				}
				else if (target.IsJungle())
				{
					num *= 1.2;
				}
			}
			return num;
		}

		// Token: 0x040005D1 RID: 1489
		private static readonly double[] damages = new double[]
		{
			10.0,
			15.0,
			20.0,
			25.0,
			30.0
		};

		// Token: 0x040005D2 RID: 1490
		private static readonly double[] miniondamages = new double[]
		{
			0.6,
			0.7,
			0.8,
			0.9,
			1.0
		};
	}
}
