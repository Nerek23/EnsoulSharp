using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000138 RID: 312
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Azir", SpellSlot.R, 0)]
	public class DamageAzirR : DamageSpell
	{
		// Token: 0x060009B7 RID: 2487 RVA: 0x00039701 File Offset: 0x00037901
		public DamageAzirR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x00039717 File Offset: 0x00037917
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAzirR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000625 RID: 1573
		private static readonly double[] damages = new double[]
		{
			200.0,
			400.0,
			600.0
		};
	}
}
