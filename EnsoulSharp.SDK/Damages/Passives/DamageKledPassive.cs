using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000379 RID: 889
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kled")]
	public class DamageKledPassive : IPassiveDamage
	{
		// Token: 0x060010EF RID: 4335 RVA: 0x00045DCB File Offset: 0x00043FCB
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.8 * (double)source.TotalAttackDamage;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x00045DDE File Offset: 0x00043FDE
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.Spellbook.GetSpell(SpellSlot.Q).Name == "KledRiderQ" && target.Type == GameObjectType.AIHeroClient;
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x00045E08 File Offset: 0x00044008
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x00045E0B File Offset: 0x0004400B
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
