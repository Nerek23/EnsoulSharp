using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FF RID: 511
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.E, 1)]
	public class DamageLeblancE1 : DamageSpell
	{
		// Token: 0x06000C18 RID: 3096 RVA: 0x0003D8D0 File Offset: 0x0003BAD0
		public DamageLeblancE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0003D8ED File Offset: 0x0003BAED
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancE1.damages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000703 RID: 1795
		private static readonly double[] damages = new double[]
		{
			70.0,
			140.0,
			210.0
		};
	}
}
