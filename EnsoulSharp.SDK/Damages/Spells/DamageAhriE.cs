using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000112 RID: 274
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ahri", SpellSlot.E, 0)]
	public class DamageAhriE : DamageSpell
	{
		// Token: 0x06000945 RID: 2373 RVA: 0x000389B9 File Offset: 0x00036BB9
		public DamageAhriE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000389CF File Offset: 0x00036BCF
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAhriE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005F9 RID: 1529
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
