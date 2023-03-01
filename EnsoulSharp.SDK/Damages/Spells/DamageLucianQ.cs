using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021B RID: 539
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lucian", SpellSlot.Q, 0)]
	public class DamageLucianQ : DamageSpell
	{
		// Token: 0x06000C6C RID: 3180 RVA: 0x0003E1A9 File Offset: 0x0003C3A9
		public DamageLucianQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x0003E1BF File Offset: 0x0003C3BF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLucianQ.damages[level] + DamageLucianQ.damagePercents[level] * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400071F RID: 1823
		private static readonly double[] damages = new double[]
		{
			95.0,
			125.0,
			155.0,
			185.0,
			215.0
		};

		// Token: 0x04000720 RID: 1824
		private static readonly double[] damagePercents = new double[]
		{
			0.6,
			0.75,
			0.9,
			1.05,
			1.2
		};
	}
}
