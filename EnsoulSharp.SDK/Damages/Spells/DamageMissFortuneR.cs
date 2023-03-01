using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000233 RID: 563
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MissFortune", SpellSlot.R, 0)]
	public class DamageMissFortuneR : DamageSpell
	{
		// Token: 0x06000CB4 RID: 3252 RVA: 0x0003E94C File Offset: 0x0003CB4C
		public DamageMissFortuneR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0003E962 File Offset: 0x0003CB62
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 0.75 * (double)source.GetTotalAaDamage() + 0.25 * (double)source.TotalMagicalDamage;
		}
	}
}
