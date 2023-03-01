using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B1 RID: 433
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ivern", SpellSlot.E, 0)]
	public class DamageIvernE : DamageSpell
	{
		// Token: 0x06000B31 RID: 2865 RVA: 0x0003BE66 File Offset: 0x0003A066
		public DamageIvernE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0003BE7C File Offset: 0x0003A07C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIvernE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006AE RID: 1710
		private static readonly double[] damages = new double[]
		{
			70.0,
			90.0,
			110.0,
			130.0,
			150.0
		};
	}
}
