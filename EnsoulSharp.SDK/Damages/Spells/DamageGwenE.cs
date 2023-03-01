using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F9 RID: 249
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.E, 0)]
	public class DamageGwenE : DamageSpell
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x00038052 File Offset: 0x00036252
		public DamageGwenE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00038068 File Offset: 0x00036268
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenE.damages[level] + 0.08 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005DA RID: 1498
		private static readonly double[] damages = new double[]
		{
			10.0,
			15.0,
			20.0,
			25.0,
			30.0
		};
	}
}
