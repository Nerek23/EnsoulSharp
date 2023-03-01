using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018B RID: 395
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Galio", SpellSlot.R, 0)]
	public class DamageGalioR : DamageSpell
	{
		// Token: 0x06000AB9 RID: 2745 RVA: 0x0003B281 File Offset: 0x00039481
		public DamageGalioR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0003B297 File Offset: 0x00039497
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGalioR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000686 RID: 1670
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
