using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B2 RID: 434
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ivern", SpellSlot.Q, 0)]
	public class DamageIvernQ : DamageSpell
	{
		// Token: 0x06000B34 RID: 2868 RVA: 0x0003BEAF File Offset: 0x0003A0AF
		public DamageIvernQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0003BEC5 File Offset: 0x0003A0C5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIvernQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006AF RID: 1711
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
