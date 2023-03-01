using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C7 RID: 455
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jinx", SpellSlot.Q, 0)]
	public class DamageJinxQ : DamageSpell
	{
		// Token: 0x06000B73 RID: 2931 RVA: 0x0003C59B File Offset: 0x0003A79B
		public DamageJinxQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0003C5B1 File Offset: 0x0003A7B1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 0.1 * (double)source.TotalAttackDamage;
		}
	}
}
