using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000336 RID: 822
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yasuo", SpellSlot.R, 0)]
	public class DamageYasuoR : DamageSpell
	{
		// Token: 0x06000FBB RID: 4027 RVA: 0x00043EED File Offset: 0x000420ED
		public DamageYasuoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x00043F03 File Offset: 0x00042103
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYasuoR.damages[level] + 1.5 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000858 RID: 2136
		private static readonly double[] damages = new double[]
		{
			200.0,
			350.0,
			500.0
		};
	}
}
