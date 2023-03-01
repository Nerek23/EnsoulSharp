using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000216 RID: 534
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leona", SpellSlot.W, 0)]
	public class DamageLeonaW : DamageSpell
	{
		// Token: 0x06000C5D RID: 3165 RVA: 0x0003E03C File Offset: 0x0003C23C
		public DamageLeonaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0003E052 File Offset: 0x0003C252
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeonaW.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400071A RID: 1818
		private static readonly double[] damages = new double[]
		{
			45.0,
			80.0,
			115.0,
			150.0,
			185.0
		};
	}
}
