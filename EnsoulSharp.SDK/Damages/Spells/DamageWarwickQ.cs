using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000324 RID: 804
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Warwick", SpellSlot.Q, 0)]
	public class DamageWarwickQ : DamageSpell
	{
		// Token: 0x06000F85 RID: 3973 RVA: 0x00043934 File Offset: 0x00041B34
		public DamageWarwickQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x0004394A File Offset: 0x00041B4A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 1.2 * (double)source.TotalAttackDamage + (double)(1f * source.TotalMagicalDamage) + DamageWarwickQ.damages[level] * (double)target.MaxHealth;
		}

		// Token: 0x04000845 RID: 2117
		private static readonly double[] damages = new double[]
		{
			0.06,
			0.07,
			0.08,
			0.09,
			0.1
		};
	}
}
