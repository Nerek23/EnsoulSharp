using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200034A RID: 842
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zilean", SpellSlot.Q, 0)]
	public class DamageZileanQ : DamageSpell
	{
		// Token: 0x06000FF6 RID: 4086 RVA: 0x0004452A File Offset: 0x0004272A
		public DamageZileanQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00044540 File Offset: 0x00042740
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZileanQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086E RID: 2158
		private static readonly double[] damages = new double[]
		{
			75.0,
			115.0,
			165.0,
			230.0,
			300.0
		};
	}
}
