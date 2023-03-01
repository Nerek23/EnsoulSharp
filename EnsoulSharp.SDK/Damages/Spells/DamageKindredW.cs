using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F8 RID: 504
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kindred", SpellSlot.W, 0)]
	public class DamageKindredW : DamageSpell
	{
		// Token: 0x06000C03 RID: 3075 RVA: 0x0003D681 File Offset: 0x0003B881
		public DamageKindredW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0003D697 File Offset: 0x0003B897
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKindredW.damages[level] + 0.2 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006FC RID: 1788
		private static readonly double[] damages = new double[]
		{
			25.0,
			30.0,
			35.0,
			40.0,
			45.0
		};
	}
}
