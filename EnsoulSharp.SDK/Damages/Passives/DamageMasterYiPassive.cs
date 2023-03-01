using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A7 RID: 935
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "MasterYi")]
	public class DamageMasterYiPassive : IPassiveDamage
	{
		// Token: 0x060011F2 RID: 4594 RVA: 0x000477CB File Offset: 0x000459CB
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.5 * (double)source.TotalAttackDamage * (double)source.GetCritMultiplier(true);
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x000477E7 File Offset: 0x000459E7
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("doublestrike");
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x000477F4 File Offset: 0x000459F4
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x000477F7 File Offset: 0x000459F7
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
