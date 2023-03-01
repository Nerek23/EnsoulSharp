using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000195 RID: 405
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.R, 0)]
	public class DamageGnarR : DamageSpell
	{
		// Token: 0x06000AD7 RID: 2775 RVA: 0x0003B5CF File Offset: 0x000397CF
		public DamageGnarR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0003B5E5 File Offset: 0x000397E5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarR.damages[level] + 0.5 * (double)source.GetBonusAaDamage() + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000693 RID: 1683
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
