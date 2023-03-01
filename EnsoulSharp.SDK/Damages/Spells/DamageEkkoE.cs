using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016A RID: 362
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ekko", SpellSlot.E, 0)]
	public class DamageEkkoE : DamageSpell
	{
		// Token: 0x06000A56 RID: 2646 RVA: 0x0003A79C File Offset: 0x0003899C
		public DamageEkkoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0003A7B2 File Offset: 0x000389B2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEkkoE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000662 RID: 1634
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
