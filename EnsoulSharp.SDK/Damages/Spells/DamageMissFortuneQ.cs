using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000231 RID: 561
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MissFortune", SpellSlot.Q, 0)]
	public class DamageMissFortuneQ : DamageSpell
	{
		// Token: 0x06000CAE RID: 3246 RVA: 0x0003E89D File Offset: 0x0003CA9D
		public DamageMissFortuneQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x0003E8B3 File Offset: 0x0003CAB3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMissFortuneQ.damages[level] + (double)source.TotalAttackDamage + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000737 RID: 1847
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
