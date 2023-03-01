using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016C RID: 364
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ekko", SpellSlot.Q, 1)]
	public class DamageEkkoQ1 : DamageSpell
	{
		// Token: 0x06000A5C RID: 2652 RVA: 0x0003A82E File Offset: 0x00038A2E
		public DamageEkkoQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0003A84B File Offset: 0x00038A4B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEkkoQ1.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000664 RID: 1636
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};
	}
}
