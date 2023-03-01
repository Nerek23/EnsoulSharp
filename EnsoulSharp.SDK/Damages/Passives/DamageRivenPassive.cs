using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B4 RID: 948
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Riven")]
	public class DamageRivenPassive : IPassiveDamage
	{
		// Token: 0x0600123B RID: 4667 RVA: 0x00047EA0 File Offset: 0x000460A0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = (double)source.TotalAttackDamage;
			if (source.Level >= 18)
			{
				num *= 0.6;
			}
			else if (source.Level >= 15)
			{
				num *= 0.54;
			}
			else if (source.Level >= 12)
			{
				num *= 0.48;
			}
			else if (source.Level >= 9)
			{
				num *= 0.42;
			}
			else if (source.Level >= 6)
			{
				num *= 0.6;
			}
			else
			{
				num *= 0.3;
			}
			return num;
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x00047F39 File Offset: 0x00046139
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.GetBuffCount("RivenPassiveAABoost") > 0;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x00047F49 File Offset: 0x00046149
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00047F4C File Offset: 0x0004614C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
