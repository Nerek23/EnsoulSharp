using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A3 RID: 419
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Hecarim", SpellSlot.W, 0)]
	public class DamageHecarimW : DamageSpell
	{
		// Token: 0x06000B01 RID: 2817 RVA: 0x0003BA92 File Offset: 0x00039C92
		public DamageHecarimW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0003BAA8 File Offset: 0x00039CA8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHecarimW.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006A3 RID: 1699
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};
	}
}
