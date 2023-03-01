using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000381 RID: 897
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Rammus")]
	public class DamageRammusPassive : IPassiveDamage
	{
		// Token: 0x0600111A RID: 4378 RVA: 0x000461CE File Offset: 0x000443CE
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 10.0;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x000461D9 File Offset: 0x000443D9
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x000461DC File Offset: 0x000443DC
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x000461DF File Offset: 0x000443DF
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
