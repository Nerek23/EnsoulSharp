using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CD RID: 717
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Swain", SpellSlot.Q, 0)]
	public class DamageSwainQ : DamageSpell
	{
		// Token: 0x06000E80 RID: 3712 RVA: 0x00041BCD File Offset: 0x0003FDCD
		public DamageSwainQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x00041BE3 File Offset: 0x0003FDE3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSwainQ.damages[level] + 0.38 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E4 RID: 2020
		private static readonly double[] damages = new double[]
		{
			60.0,
			80.0,
			110.0,
			120.0,
			140.0
		};
	}
}
