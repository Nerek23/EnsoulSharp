using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000256 RID: 598
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Orianna", SpellSlot.E, 0)]
	public class DamageOriannaE : DamageSpell
	{
		// Token: 0x06000D1C RID: 3356 RVA: 0x0003F468 File Offset: 0x0003D668
		public DamageOriannaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0003F47E File Offset: 0x0003D67E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOriannaE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400075D RID: 1885
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0,
			150.0,
			180.0
		};
	}
}
