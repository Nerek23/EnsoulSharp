using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000207 RID: 519
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.E, 0)]
	public class DamageLilliaE : DamageSpell
	{
		// Token: 0x06000C30 RID: 3120 RVA: 0x0003DB7B File Offset: 0x0003BD7B
		public DamageLilliaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0003DB91 File Offset: 0x0003BD91
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLilliaE.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400070B RID: 1803
		private static readonly double[] damages = new double[]
		{
			70.0,
			95.0,
			120.0,
			145.0,
			170.0
		};
	}
}
