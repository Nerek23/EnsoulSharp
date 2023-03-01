using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000169 RID: 361
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ekko", SpellSlot.R, 0)]
	public class DamageEkkoR : DamageSpell
	{
		// Token: 0x06000A53 RID: 2643 RVA: 0x0003A753 File Offset: 0x00038953
		public DamageEkkoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0003A769 File Offset: 0x00038969
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEkkoR.damages[level] + 1.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000661 RID: 1633
		private static readonly double[] damages = new double[]
		{
			200.0,
			350.0,
			500.0
		};
	}
}
