using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000251 RID: 593
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nunu", SpellSlot.W, 0)]
	public class DamageNunuW : DamageSpell
	{
		// Token: 0x06000D0D RID: 3341 RVA: 0x0003F2BB File Offset: 0x0003D4BB
		public DamageNunuW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0003F2D1 File Offset: 0x0003D4D1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNunuW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000757 RID: 1879
		private static readonly double[] damages = new double[]
		{
			12.0,
			15.0,
			18.0,
			21.0,
			24.0
		};
	}
}
