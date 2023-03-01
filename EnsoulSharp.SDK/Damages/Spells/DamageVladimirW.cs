using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031F RID: 799
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vladimir", SpellSlot.W, 0)]
	public class DamageVladimirW : DamageSpell
	{
		// Token: 0x06000F76 RID: 3958 RVA: 0x0004377F File Offset: 0x0004197F
		public DamageVladimirW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x00043795 File Offset: 0x00041995
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVladimirW.damages[level] + 0.025 * (double)source.BonusHealth;
		}

		// Token: 0x0400083F RID: 2111
		private static readonly double[] damages = new double[]
		{
			20.0,
			33.75,
			47.5,
			61.25,
			75.0
		};
	}
}
