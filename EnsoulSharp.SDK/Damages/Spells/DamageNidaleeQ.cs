using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000249 RID: 585
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nidalee", SpellSlot.Q, 0)]
	public class DamageNidaleeQ : DamageSpell
	{
		// Token: 0x06000CF5 RID: 3317 RVA: 0x0003EFCB File Offset: 0x0003D1CB
		public DamageNidaleeQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x0003EFE1 File Offset: 0x0003D1E1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNidaleeQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400074E RID: 1870
		private static readonly double[] damages = new double[]
		{
			70.0,
			90.0,
			110.0,
			130.0,
			150.0
		};
	}
}
