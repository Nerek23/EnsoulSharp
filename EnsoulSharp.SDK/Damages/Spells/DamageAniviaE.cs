using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000124 RID: 292
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Anivia", SpellSlot.E, 0)]
	public class DamageAniviaE : DamageSpell
	{
		// Token: 0x0600097B RID: 2427 RVA: 0x00038F9D File Offset: 0x0003719D
		public DamageAniviaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00038FB3 File Offset: 0x000371B3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageAniviaE.damages[level] + 0.6 * (double)source.TotalMagicalDamage) * (double)(target.HasBuff("chilled") ? 2 : 1);
		}

		// Token: 0x0400060C RID: 1548
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
