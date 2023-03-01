using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022C RID: 556
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Maokai", SpellSlot.R, 0)]
	public class DamageMaokaiR : DamageSpell
	{
		// Token: 0x06000C9F RID: 3231 RVA: 0x0003E734 File Offset: 0x0003C934
		public DamageMaokaiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x0003E74A File Offset: 0x0003C94A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMaokaiR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000732 RID: 1842
		private static readonly double[] damages = new double[]
		{
			150.0,
			225.0,
			300.0
		};
	}
}
