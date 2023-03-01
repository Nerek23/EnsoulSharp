using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000305 RID: 773
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xayah", SpellSlot.R, 0)]
	public class DamageXayahR : DamageSpell
	{
		// Token: 0x06000F28 RID: 3880 RVA: 0x00042F15 File Offset: 0x00041115
		public DamageXayahR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x00042F2B File Offset: 0x0004112B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXayahR.damages[level] + (double)(1f * source.GetBonusAaDamage());
		}

		// Token: 0x04000823 RID: 2083
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
