using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B0 RID: 944
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Quinn")]
	public class DamageQuinnPassive : IPassiveDamage
	{
		// Token: 0x06001224 RID: 4644 RVA: 0x00047BDC File Offset: 0x00045DDC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(10 + 5 * source.Level) + (0.14 + 0.02 * (double)source.Level) * (double)source.TotalAttackDamage;
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x00047C0E File Offset: 0x00045E0E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("quinnw");
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x00047C1B File Offset: 0x00045E1B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x00047C1E File Offset: 0x00045E1E
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
