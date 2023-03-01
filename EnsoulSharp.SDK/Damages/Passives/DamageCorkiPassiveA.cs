using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000367 RID: 871
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Corki")]
	public class DamageCorkiPassiveA : IPassiveDamage
	{
		// Token: 0x0600108B RID: 4235 RVA: 0x000453B0 File Offset: 0x000435B0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (Math.Abs(source.Crit - 1f) < 1E-45f)
			{
				return 0.2 * (double)source.GetCritMultiplier(false) * (double)source.TotalAttackDamage;
			}
			return 0.2 * (double)source.TotalAttackDamage;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00045401 File Offset: 0x00043601
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x00045404 File Offset: 0x00043604
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x00045407 File Offset: 0x00043607
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
