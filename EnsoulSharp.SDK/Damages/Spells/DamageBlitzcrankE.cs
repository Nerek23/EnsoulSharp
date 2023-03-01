using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200013B RID: 315
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Blitzcrank", SpellSlot.E, 0)]
	public class DamageBlitzcrankE : DamageSpell
	{
		// Token: 0x060009C0 RID: 2496 RVA: 0x000397EB File Offset: 0x000379EB
		public DamageBlitzcrankE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00039801 File Offset: 0x00037A01
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 1.75 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
		}
	}
}
