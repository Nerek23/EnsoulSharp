using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AA RID: 426
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Illaoi", SpellSlot.Q, 0)]
	public class DamageIllaoiQ : DamageSpell
	{
		// Token: 0x06000B1D RID: 2845 RVA: 0x0003BC31 File Offset: 0x00039E31
		public DamageIllaoiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0003BC47 File Offset: 0x00039E47
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (double)(10 * source.Level) + 1.2 * (double)source.TotalAttackDamage;
		}
	}
}
