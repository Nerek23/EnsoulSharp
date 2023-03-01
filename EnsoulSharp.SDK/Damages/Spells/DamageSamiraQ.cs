using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028C RID: 652
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Samira", SpellSlot.Q, 0)]
	public class DamageSamiraQ : DamageSpell
	{
		// Token: 0x06000DBD RID: 3517 RVA: 0x00040558 File Offset: 0x0003E758
		public DamageSamiraQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x0004056E File Offset: 0x0003E76E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSamiraQ.damages[level] + DamageSamiraQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000796 RID: 1942
		private static readonly double[] damages = new double[]
		{
			0.0,
			5.0,
			10.0,
			15.0,
			20.0
		};

		// Token: 0x04000797 RID: 1943
		private static readonly double[] damagePercents = new double[]
		{
			0.28,
			0.95,
			1.05,
			1.15,
			1.25
		};
	}
}
