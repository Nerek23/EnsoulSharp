using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028E RID: 654
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Samira", SpellSlot.W, 0)]
	public class DamageSamiraW : DamageSpell
	{
		// Token: 0x06000DC3 RID: 3523 RVA: 0x000405FE File Offset: 0x0003E7FE
		public DamageSamiraW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00040614 File Offset: 0x0003E814
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSamiraW.damages[level] + (double)(0.8f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000799 RID: 1945
		private static readonly double[] damages = new double[]
		{
			20.0,
			35.0,
			50.0,
			65.0,
			80.0
		};
	}
}
