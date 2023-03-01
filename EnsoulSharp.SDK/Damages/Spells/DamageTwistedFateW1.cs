using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F0 RID: 752
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TwistedFate", SpellSlot.W, 1)]
	public class DamageTwistedFateW1 : DamageSpell
	{
		// Token: 0x06000EE9 RID: 3817 RVA: 0x000427A5 File Offset: 0x000409A5
		public DamageTwistedFateW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x000427C2 File Offset: 0x000409C2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTwistedFateW1.damages[level] + (double)(1f * source.TotalAttackDamage) + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400080A RID: 2058
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
