using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000270 RID: 624
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Quinn", SpellSlot.E, 0)]
	public class DamageQuinnE : DamageSpell
	{
		// Token: 0x06000D6A RID: 3434 RVA: 0x0003FC70 File Offset: 0x0003DE70
		public DamageQuinnE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x0003FC86 File Offset: 0x0003DE86
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQuinnE.damages[level] + 0.2 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000778 RID: 1912
		private static readonly double[] damages = new double[]
		{
			40.0,
			70.0,
			100.0,
			130.0,
			160.0
		};
	}
}
