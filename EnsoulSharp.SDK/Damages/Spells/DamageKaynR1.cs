using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E9 RID: 489
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.R, 1)]
	public class DamageKaynR1 : DamageSpell
	{
		// Token: 0x06000BD7 RID: 3031 RVA: 0x0003D1F9 File Offset: 0x0003B3F9
		public DamageKaynR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0003D216 File Offset: 0x0003B416
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (0.1 + 0.13 * (double)source.GetBonusAaDamage() / 100.0) * (double)target.MaxHealth;
		}
	}
}
