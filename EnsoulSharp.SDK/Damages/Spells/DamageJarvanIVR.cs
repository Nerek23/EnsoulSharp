using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B8 RID: 440
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("JarvanIV", SpellSlot.R, 0)]
	public class DamageJarvanIVR : DamageSpell
	{
		// Token: 0x06000B46 RID: 2886 RVA: 0x0003C097 File Offset: 0x0003A297
		public DamageJarvanIVR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0003C0AD File Offset: 0x0003A2AD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJarvanIVR.damages[level] + 1.8 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006B5 RID: 1717
		private static readonly double[] damages = new double[]
		{
			200.0,
			325.0,
			450.0
		};
	}
}
