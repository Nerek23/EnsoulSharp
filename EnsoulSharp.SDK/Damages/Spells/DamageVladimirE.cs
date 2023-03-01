using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031B RID: 795
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vladimir", SpellSlot.E, 0)]
	public class DamageVladimirE : DamageSpell
	{
		// Token: 0x06000F6A RID: 3946 RVA: 0x00043642 File Offset: 0x00041842
		public DamageVladimirE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00043658 File Offset: 0x00041858
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVladimirE.damages[level] + 0.35 * (double)source.TotalMagicalDamage + 0.015 * (double)source.MaxHealth;
		}

		// Token: 0x0400083B RID: 2107
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0
		};
	}
}
