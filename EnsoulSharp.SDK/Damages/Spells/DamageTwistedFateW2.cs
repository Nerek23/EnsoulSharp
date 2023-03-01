using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F1 RID: 753
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TwistedFate", SpellSlot.W, 2)]
	public class DamageTwistedFateW2 : DamageSpell
	{
		// Token: 0x06000EEC RID: 3820 RVA: 0x00042803 File Offset: 0x00040A03
		public DamageTwistedFateW2()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 2;
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00042820 File Offset: 0x00040A20
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTwistedFateW2.damages[level] + (double)(1f * source.TotalAttackDamage) + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400080B RID: 2059
		private static readonly double[] damages = new double[]
		{
			15.0,
			22.5,
			30.0,
			37.5,
			45.0
		};
	}
}
