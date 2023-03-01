using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000166 RID: 358
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Draven", SpellSlot.Q, 0)]
	public class DamageDravenQ : DamageSpell
	{
		// Token: 0x06000A4A RID: 2634 RVA: 0x0003A5D1 File Offset: 0x000387D1
		public DamageDravenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0003A5E7 File Offset: 0x000387E7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDravenQ.damages[level] + DamageDravenQ.damagePercents[level] * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400065A RID: 1626
		private static readonly double[] damages = new double[]
		{
			40.0,
			45.0,
			50.0,
			55.0,
			60.0
		};

		// Token: 0x0400065B RID: 1627
		private static readonly double[] damagePercents = new double[]
		{
			0.7,
			0.8,
			0.9,
			1.0,
			1.1
		};
	}
}
