using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F6 RID: 502
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kindred", SpellSlot.E, 0)]
	public class DamageKindredE : DamageSpell
	{
		// Token: 0x06000BFD RID: 3069 RVA: 0x0003D5EF File Offset: 0x0003B7EF
		public DamageKindredE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0003D605 File Offset: 0x0003B805
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKindredE.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006FA RID: 1786
		private static readonly double[] damages = new double[]
		{
			80.0,
			100.0,
			120.0,
			140.0,
			160.0
		};
	}
}
