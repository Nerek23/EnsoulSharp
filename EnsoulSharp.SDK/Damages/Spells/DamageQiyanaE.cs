using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025E RID: 606
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Qiyana", SpellSlot.E, 0)]
	public class DamageQiyanaE : DamageSpell
	{
		// Token: 0x06000D34 RID: 3380 RVA: 0x0003F6B0 File Offset: 0x0003D8B0
		public DamageQiyanaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x0003F6C6 File Offset: 0x0003D8C6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQiyanaE.damages[level] + 0.7 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000765 RID: 1893
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
