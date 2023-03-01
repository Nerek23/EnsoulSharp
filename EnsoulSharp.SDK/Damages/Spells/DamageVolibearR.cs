using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000322 RID: 802
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Volibear", SpellSlot.R, 0)]
	public class DamageVolibearR : DamageSpell
	{
		// Token: 0x06000F7F RID: 3967 RVA: 0x0004388A File Offset: 0x00041A8A
		public DamageVolibearR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x000438A0 File Offset: 0x00041AA0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVolibearR.damages[level] + (double)(2.5f * source.GetBonusAaDamage()) + (double)(1.25f * source.TotalMagicalDamage);
		}

		// Token: 0x04000843 RID: 2115
		private static readonly double[] damages = new double[]
		{
			300.0,
			500.0,
			700.0
		};
	}
}
