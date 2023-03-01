using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000180 RID: 384
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiora", SpellSlot.Q, 0)]
	public class DamageFioraQ : DamageSpell
	{
		// Token: 0x06000A98 RID: 2712 RVA: 0x0003AF36 File Offset: 0x00039136
		public DamageFioraQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0003AF4C File Offset: 0x0003914C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFioraQ.damages[level] + DamageFioraQ.damagePercents[level] * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400067A RID: 1658
		private static readonly double[] damages = new double[]
		{
			70.0,
			80.0,
			90.0,
			100.0,
			110.0
		};

		// Token: 0x0400067B RID: 1659
		private static readonly double[] damagePercents = new double[]
		{
			0.9,
			0.95,
			1.0,
			1.05,
			1.1
		};
	}
}
