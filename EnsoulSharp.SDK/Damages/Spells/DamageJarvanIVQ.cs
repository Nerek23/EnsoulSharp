using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B7 RID: 439
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("JarvanIV", SpellSlot.Q, 0)]
	public class DamageJarvanIVQ : DamageSpell
	{
		// Token: 0x06000B43 RID: 2883 RVA: 0x0003C04E File Offset: 0x0003A24E
		public DamageJarvanIVQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0003C064 File Offset: 0x0003A264
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJarvanIVQ.damages[level] + 1.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006B4 RID: 1716
		private static readonly double[] damages = new double[]
		{
			90.0,
			130.0,
			170.0,
			210.0,
			250.0
		};
	}
}
