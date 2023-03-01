using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000255 RID: 597
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Olaf", SpellSlot.Q, 0)]
	public class DamageOlafQ : DamageSpell
	{
		// Token: 0x06000D19 RID: 3353 RVA: 0x0003F423 File Offset: 0x0003D623
		public DamageOlafQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0003F439 File Offset: 0x0003D639
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOlafQ.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x0400075C RID: 1884
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};
	}
}
