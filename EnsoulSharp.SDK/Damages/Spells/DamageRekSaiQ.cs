using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027A RID: 634
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.Q, 0)]
	public class DamageRekSaiQ : DamageSpell
	{
		// Token: 0x06000D87 RID: 3463 RVA: 0x0003FF65 File Offset: 0x0003E165
		public DamageRekSaiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x0003FF7B File Offset: 0x0003E17B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiQ.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000782 RID: 1922
		private static readonly double[] damages = new double[]
		{
			21.0,
			27.0,
			33.0,
			39.0,
			45.0
		};
	}
}
