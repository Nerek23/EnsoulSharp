using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000220 RID: 544
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lux", SpellSlot.E, 0)]
	public class DamageLuxE : DamageSpell
	{
		// Token: 0x06000C7B RID: 3195 RVA: 0x0003E33C File Offset: 0x0003C53C
		public DamageLuxE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x0003E352 File Offset: 0x0003C552
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLuxE.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000725 RID: 1829
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};
	}
}
