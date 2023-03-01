using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000361 RID: 865
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Gwen")]
	public class DamageGwenPassive : IPassiveDamage
	{
		// Token: 0x0600106B RID: 4203 RVA: 0x000450D4 File Offset: 0x000432D4
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			float num = (0.01f + source.TotalMagicalDamage / 100f * 0.008f) * target.MaxHealth;
			if (target as AIHeroClient != null)
			{
				return (double)num;
			}
			AIMinionClient aiminionClient = target as AIMinionClient;
			if (aiminionClient != null)
			{
				if (aiminionClient.IsMinion())
				{
					if (aiminionClient.HealthPercent >= 40f)
					{
						return (double)num;
					}
					return (double)(num + 8f + ((source.Level > 1) ? (22f / (17f * ((float)source.Level - 1f))) : 0f));
				}
				else if (aiminionClient.IsJungle())
				{
					return (double)Math.Min(10f + 0.25f * source.TotalMagicalDamage, num);
				}
			}
			return 0.0;
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x00045198 File Offset: 0x00043398
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0004519B File Offset: 0x0004339B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x0004519E File Offset: 0x0004339E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
