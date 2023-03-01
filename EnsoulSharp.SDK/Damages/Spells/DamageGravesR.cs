using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019E RID: 414
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Graves", SpellSlot.R, 0)]
	public class DamageGravesR : DamageSpell
	{
		// Token: 0x06000AF2 RID: 2802 RVA: 0x0003B906 File Offset: 0x00039B06
		public DamageGravesR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0003B91C File Offset: 0x00039B1C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGravesR.damages[level] + 1.5 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x0400069E RID: 1694
		private static readonly double[] damages = new double[]
		{
			275.0,
			425.0,
			575.0
		};
	}
}
