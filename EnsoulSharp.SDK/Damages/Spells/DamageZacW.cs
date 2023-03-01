using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000342 RID: 834
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zac", SpellSlot.W, 0)]
	public class DamageZacW : DamageSpell
	{
		// Token: 0x06000FDF RID: 4063 RVA: 0x000442D8 File Offset: 0x000424D8
		public DamageZacW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x000442EE File Offset: 0x000424EE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageZacW.damages[level] + DamageZacW.damagePercents[level] * (double)target.MaxHealth) * (double)(1f + target.TotalMagicalDamage / 100f * 0.04f);
		}

		// Token: 0x04000866 RID: 2150
		private static readonly double[] damages = new double[]
		{
			35.0,
			50.0,
			65.0,
			80.0,
			95.0
		};

		// Token: 0x04000867 RID: 2151
		private static readonly double[] damagePercents = new double[]
		{
			0.04,
			0.05,
			0.06,
			0.07,
			0.08
		};
	}
}
