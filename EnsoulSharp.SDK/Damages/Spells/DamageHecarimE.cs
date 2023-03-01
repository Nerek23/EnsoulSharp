using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A0 RID: 416
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Hecarim", SpellSlot.E, 0)]
	public class DamageHecarimE : DamageSpell
	{
		// Token: 0x06000AF8 RID: 2808 RVA: 0x0003B998 File Offset: 0x00039B98
		public DamageHecarimE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0003B9AE File Offset: 0x00039BAE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHecarimE.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006A0 RID: 1696
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0
		};
	}
}
