using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000317 RID: 791
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vi", SpellSlot.E, 0)]
	public class DamageViE : DamageSpell
	{
		// Token: 0x06000F5E RID: 3934 RVA: 0x000434FA File Offset: 0x000416FA
		public DamageViE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x00043510 File Offset: 0x00041710
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViE.damages[level] + 1.1 * (double)source.TotalAttackDamage + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000837 RID: 2103
		private static readonly double[] damages = new double[]
		{
			10.0,
			30.0,
			50.0,
			70.0,
			90.0
		};
	}
}
