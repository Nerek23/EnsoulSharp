using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000375 RID: 885
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kalista")]
	public class DamageKalistaPassiveA : IPassiveDamage
	{
		// Token: 0x060010D8 RID: 4312 RVA: 0x00045B53 File Offset: 0x00043D53
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.9 * (double)source.TotalAttackDamage;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x00045B66 File Offset: 0x00043D66
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x00045B69 File Offset: 0x00043D69
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00045B6C File Offset: 0x00043D6C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
