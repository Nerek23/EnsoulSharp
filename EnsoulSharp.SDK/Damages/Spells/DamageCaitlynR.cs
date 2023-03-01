using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014D RID: 333
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Caitlyn", SpellSlot.R, 0)]
	public class DamageCaitlynR : DamageSpell
	{
		// Token: 0x060009F5 RID: 2549 RVA: 0x00039D30 File Offset: 0x00037F30
		public DamageCaitlynR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00039D46 File Offset: 0x00037F46
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCaitlynR.damages[level] + (double)(2f * source.GetBonusAaDamage());
		}

		// Token: 0x0400063B RID: 1595
		private static readonly double[] damages = new double[]
		{
			300.0,
			525.0,
			750.0
		};
	}
}
