using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E8 RID: 488
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.Q, 0)]
	public class DamageKaynQ : DamageSpell
	{
		// Token: 0x06000BD4 RID: 3028 RVA: 0x0003D18D File Offset: 0x0003B38D
		public DamageKaynQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0003D1A4 File Offset: 0x0003B3A4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageKaynQ.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
			if (target.Type != GameObjectType.AIHeroClient)
			{
				num += 40.0;
			}
			return num;
		}

		// Token: 0x040006EC RID: 1772
		private static readonly double[] damages = new double[]
		{
			75.0,
			95.0,
			115.0,
			135.0,
			155.0
		};
	}
}
