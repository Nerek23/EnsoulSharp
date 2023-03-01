using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000355 RID: 853
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ashe")]
	public class DamageAshePassive : IPassiveDamage
	{
		// Token: 0x06001027 RID: 4135 RVA: 0x000448F5 File Offset: 0x00042AF5
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (0.1 + (double)(source.Crit / 100f * source.GetCritMultiplier(true))) * (double)source.TotalAttackDamage;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0004491E File Offset: 0x00042B1E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("ashepassiveslow");
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0004492B File Offset: 0x00042B2B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x0004492E File Offset: 0x00042B2E
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
