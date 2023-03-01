using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000125 RID: 293
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Anivia", SpellSlot.Q, 1)]
	public class DamageAniviaQ1 : DamageSpell
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x00038FF9 File Offset: 0x000371F9
		public DamageAniviaQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00039016 File Offset: 0x00037216
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAniviaQ1.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400060D RID: 1549
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
