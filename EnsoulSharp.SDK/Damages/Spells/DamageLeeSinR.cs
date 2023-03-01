using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000206 RID: 518
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("LeeSin", SpellSlot.R, 0)]
	public class DamageLeeSinR : DamageSpell
	{
		// Token: 0x06000C2D RID: 3117 RVA: 0x0003DB36 File Offset: 0x0003BD36
		public DamageLeeSinR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0003DB4C File Offset: 0x0003BD4C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeeSinR.damages[level] + (double)(2f * source.GetBonusAaDamage());
		}

		// Token: 0x0400070A RID: 1802
		private static readonly double[] damages = new double[]
		{
			175.0,
			400.0,
			625.0
		};
	}
}
