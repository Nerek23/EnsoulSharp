using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000232 RID: 562
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MissFortune", SpellSlot.Q, 1)]
	public class DamageMissFortuneQ1 : DamageSpell
	{
		// Token: 0x06000CB1 RID: 3249 RVA: 0x0003E8EE File Offset: 0x0003CAEE
		public DamageMissFortuneQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0003E90B File Offset: 0x0003CB0B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMissFortuneQ1.damages[level] + (double)(2f * source.TotalAttackDamage) + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000738 RID: 1848
		private static readonly double[] damages = new double[]
		{
			40.0,
			90.0,
			140.0,
			190.0,
			240.0
		};
	}
}
