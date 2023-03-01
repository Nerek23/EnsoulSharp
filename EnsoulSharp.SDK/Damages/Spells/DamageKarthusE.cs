using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D3 RID: 467
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karthus", SpellSlot.E, 0)]
	public class DamageKarthusE : DamageSpell
	{
		// Token: 0x06000B96 RID: 2966 RVA: 0x0003CA19 File Offset: 0x0003AC19
		public DamageKarthusE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0003CA2F File Offset: 0x0003AC2F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarthusE.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D6 RID: 1750
		private static readonly double[] damages = new double[]
		{
			30.0,
			50.0,
			70.0,
			90.0,
			110.0
		};
	}
}
