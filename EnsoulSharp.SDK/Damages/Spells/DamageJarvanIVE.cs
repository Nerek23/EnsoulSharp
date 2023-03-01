using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B6 RID: 438
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("JarvanIV", SpellSlot.E, 0)]
	public class DamageJarvanIVE : DamageSpell
	{
		// Token: 0x06000B40 RID: 2880 RVA: 0x0003C005 File Offset: 0x0003A205
		public DamageJarvanIVE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0003C01B File Offset: 0x0003A21B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJarvanIVE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B3 RID: 1715
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
