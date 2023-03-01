using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A5 RID: 421
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Heimerdinger", SpellSlot.E, 1)]
	public class DamageHeimerdingerE1 : DamageSpell
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x0003BB24 File Offset: 0x00039D24
		public DamageHeimerdingerE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0003BB41 File Offset: 0x00039D41
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHeimerdingerE1.damages[source.Spellbook.GetSpell(SpellSlot.R).Level - 1] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006A5 RID: 1701
		private static readonly double[] damages = new double[]
		{
			100.0,
			200.0,
			300.0
		};
	}
}
