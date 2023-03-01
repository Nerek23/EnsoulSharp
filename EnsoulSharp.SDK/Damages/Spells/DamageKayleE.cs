using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DE RID: 478
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayle", SpellSlot.E, 0)]
	public class DamageKayleE : DamageSpell
	{
		// Token: 0x06000BB7 RID: 2999 RVA: 0x0003CE5C File Offset: 0x0003B05C
		public DamageKayleE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0003CE72 File Offset: 0x0003B072
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (0.08 + 0.01 * (double)source.TotalMagicalDamage / 50.0) * (double)(target.MaxHealth - target.Health);
		}
	}
}
