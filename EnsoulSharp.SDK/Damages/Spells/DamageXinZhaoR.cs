using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000333 RID: 819
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("XinZhao", SpellSlot.R, 0)]
	public class DamageXinZhaoR : DamageSpell
	{
		// Token: 0x06000FB2 RID: 4018 RVA: 0x00043DE0 File Offset: 0x00041FE0
		public DamageXinZhaoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x00043DF6 File Offset: 0x00041FF6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXinZhaoR.damages[level] + (double)(1f * source.GetBonusAaDamage()) + 1.1 * (double)source.TotalMagicalDamage + 0.15 * (double)target.Health;
		}

		// Token: 0x04000855 RID: 2133
		private static readonly double[] damages = new double[]
		{
			75.0,
			175.0,
			275.0
		};
	}
}
