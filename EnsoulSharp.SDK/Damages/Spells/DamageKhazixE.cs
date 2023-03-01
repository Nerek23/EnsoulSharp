using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F2 RID: 498
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Khazix", SpellSlot.E, 0)]
	public class DamageKhazixE : DamageSpell
	{
		// Token: 0x06000BF1 RID: 3057 RVA: 0x0003D4C8 File Offset: 0x0003B6C8
		public DamageKhazixE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0003D4DE File Offset: 0x0003B6DE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKhazixE.damages[level] + 0.2 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006F6 RID: 1782
		private static readonly double[] damages = new double[]
		{
			65.0,
			100.0,
			135.0,
			170.0,
			205.0
		};
	}
}
