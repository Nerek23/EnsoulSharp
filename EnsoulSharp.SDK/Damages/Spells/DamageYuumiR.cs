using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032A RID: 810
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yuumi", SpellSlot.R, 0)]
	public class DamageYuumiR : DamageSpell
	{
		// Token: 0x06000F97 RID: 3991 RVA: 0x00043B14 File Offset: 0x00041D14
		public DamageYuumiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x00043B2A File Offset: 0x00041D2A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYuumiR.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400084C RID: 2124
		private static readonly double[] damages = new double[]
		{
			75.0,
			100.0,
			125.0
		};
	}
}
