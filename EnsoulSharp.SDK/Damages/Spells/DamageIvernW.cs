using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B3 RID: 435
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ivern", SpellSlot.W, 0)]
	public class DamageIvernW : DamageSpell
	{
		// Token: 0x06000B37 RID: 2871 RVA: 0x0003BEF8 File Offset: 0x0003A0F8
		public DamageIvernW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0003BF0E File Offset: 0x0003A10E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIvernW.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B0 RID: 1712
		private static readonly double[] damages = new double[]
		{
			30.0,
			37.5,
			45.0,
			52.5,
			60.0
		};
	}
}
