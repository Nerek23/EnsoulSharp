using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B5 RID: 693
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sion", SpellSlot.E, 0)]
	public class DamageSionE : DamageSpell
	{
		// Token: 0x06000E38 RID: 3640 RVA: 0x000413ED File Offset: 0x0003F5ED
		public DamageSionE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x00041403 File Offset: 0x0003F603
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSionE.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007C8 RID: 1992
		private static readonly double[] damages = new double[]
		{
			65.0,
			100.0,
			135.0,
			170.0,
			205.0
		};
	}
}
