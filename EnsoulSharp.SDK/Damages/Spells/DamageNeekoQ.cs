using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000210 RID: 528
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Neeko", SpellSlot.Q, 0)]
	public class DamageNeekoQ : DamageSpell
	{
		// Token: 0x06000C4B RID: 3147 RVA: 0x0003DE86 File Offset: 0x0003C086
		public DamageNeekoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0003DE9C File Offset: 0x0003C09C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNeekoQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000714 RID: 1812
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
