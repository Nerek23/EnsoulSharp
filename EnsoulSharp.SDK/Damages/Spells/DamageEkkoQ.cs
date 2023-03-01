using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200016B RID: 363
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ekko", SpellSlot.Q, 0)]
	public class DamageEkkoQ : DamageSpell
	{
		// Token: 0x06000A59 RID: 2649 RVA: 0x0003A7E5 File Offset: 0x000389E5
		public DamageEkkoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0003A7FB File Offset: 0x000389FB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEkkoQ.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000663 RID: 1635
		private static readonly double[] damages = new double[]
		{
			60.0,
			75.0,
			90.0,
			105.0,
			120.0
		};
	}
}
