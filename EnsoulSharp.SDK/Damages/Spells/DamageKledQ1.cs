using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E4 RID: 484
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kled", SpellSlot.Q, 1)]
	public class DamageKledQ1 : DamageSpell
	{
		// Token: 0x06000BC8 RID: 3016 RVA: 0x0003D03C File Offset: 0x0003B23C
		public DamageKledQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0003D059 File Offset: 0x0003B259
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledQ1.damages[level] + 1.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006E7 RID: 1767
		private static readonly double[] damages = new double[]
		{
			60.0,
			110.0,
			160.0,
			210.0,
			260.0
		};
	}
}
