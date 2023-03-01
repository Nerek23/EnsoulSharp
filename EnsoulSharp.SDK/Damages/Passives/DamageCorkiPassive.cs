using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038A RID: 906
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Corki")]
	public class DamageCorkiPassive : IPassiveDamage
	{
		// Token: 0x0600114C RID: 4428 RVA: 0x0004661C File Offset: 0x0004481C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double result = 0.8 * (double)source.TotalAttackDamage;
			if (Math.Abs(source.Crit - 1f) < 1E-45f)
			{
				result = 0.8 * (double)source.TotalAttackDamage * (double)source.GetCritMultiplier(false);
			}
			return result;
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x0004666F File Offset: 0x0004486F
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x00046672 File Offset: 0x00044872
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00046675 File Offset: 0x00044875
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
