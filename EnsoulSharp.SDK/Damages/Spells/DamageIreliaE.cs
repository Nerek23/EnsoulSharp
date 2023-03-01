using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AD RID: 429
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Irelia", SpellSlot.E, 0)]
	public class DamageIreliaE : DamageSpell
	{
		// Token: 0x06000B25 RID: 2853 RVA: 0x0003BD09 File Offset: 0x00039F09
		public DamageIreliaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0003BD1F File Offset: 0x00039F1F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIreliaE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006AA RID: 1706
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
