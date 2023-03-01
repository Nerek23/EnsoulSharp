using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000141 RID: 321
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Brand", SpellSlot.W, 0)]
	public class DamageBrandW : DamageSpell
	{
		// Token: 0x060009D1 RID: 2513 RVA: 0x00039993 File Offset: 0x00037B93
		public DamageBrandW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x000399A9 File Offset: 0x00037BA9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBrandW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400062D RID: 1581
		private static readonly double[] damages = new double[]
		{
			75.0,
			120.0,
			165.0,
			210.0,
			255.0
		};
	}
}
