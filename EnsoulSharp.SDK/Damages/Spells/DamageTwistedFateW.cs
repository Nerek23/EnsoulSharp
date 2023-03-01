using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002EF RID: 751
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TwistedFate", SpellSlot.W, 0)]
	public class DamageTwistedFateW : DamageSpell
	{
		// Token: 0x06000EE6 RID: 3814 RVA: 0x0004274E File Offset: 0x0004094E
		public DamageTwistedFateW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x00042764 File Offset: 0x00040964
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTwistedFateW.damages[level] + (double)(1f * source.TotalAttackDamage) + 1.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000809 RID: 2057
		private static readonly double[] damages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};
	}
}
