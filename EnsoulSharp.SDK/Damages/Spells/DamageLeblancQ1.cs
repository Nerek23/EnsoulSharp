using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000201 RID: 513
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.Q, 1)]
	public class DamageLeblancQ1 : DamageSpell
	{
		// Token: 0x06000C1E RID: 3102 RVA: 0x0003D994 File Offset: 0x0003BB94
		public DamageLeblancQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0003D9B1 File Offset: 0x0003BBB1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancQ1.damages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000705 RID: 1797
		private static readonly double[] damages = new double[]
		{
			70.0,
			140.0,
			210.0
		};
	}
}
