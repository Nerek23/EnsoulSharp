using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000248 RID: 584
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nidalee", SpellSlot.E, 0)]
	public class DamageNidaleeE : DamageSpell
	{
		// Token: 0x06000CF2 RID: 3314 RVA: 0x0003EF5B File Offset: 0x0003D15B
		public DamageNidaleeE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x0003EF74 File Offset: 0x0003D174
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			int num = source.Spellbook.GetSpell(SpellSlot.R).Level;
			if (num == 0)
			{
				num = 1;
			}
			return DamageNidaleeE.damages[num - 1] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400074D RID: 1869
		private static readonly double[] damages = new double[]
		{
			80.0,
			140.0,
			200.0,
			260.0
		};
	}
}
