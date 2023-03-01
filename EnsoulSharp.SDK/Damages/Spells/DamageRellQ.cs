using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010B RID: 267
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.Q, 0)]
	public class DamageRellQ : DamageSpell
	{
		// Token: 0x06000930 RID: 2352 RVA: 0x00038701 File Offset: 0x00036901
		public DamageRellQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00038717 File Offset: 0x00036917
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005EF RID: 1519
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
