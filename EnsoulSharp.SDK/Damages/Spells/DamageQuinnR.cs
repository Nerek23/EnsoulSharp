using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000272 RID: 626
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Quinn", SpellSlot.R, 0)]
	public class DamageQuinnR : DamageSpell
	{
		// Token: 0x06000D70 RID: 3440 RVA: 0x0003FD28 File Offset: 0x0003DF28
		public DamageQuinnR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x0003FD3E File Offset: 0x0003DF3E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 0.7 * (double)source.TotalMagicalDamage + 0.02 * (double)source.MaxHealth;
		}
	}
}
