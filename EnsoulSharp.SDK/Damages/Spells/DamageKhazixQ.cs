using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F3 RID: 499
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Khazix", SpellSlot.Q, 0)]
	public class DamageKhazixQ : DamageSpell
	{
		// Token: 0x06000BF4 RID: 3060 RVA: 0x0003D511 File Offset: 0x0003B711
		public DamageKhazixQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0003D527 File Offset: 0x0003B727
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKhazixQ.damages[level] + 1.15 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006F7 RID: 1783
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
