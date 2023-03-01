using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CF RID: 975
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "XinZhao")]
	public class DamageXinZhaoPassive : IPassiveDamage
	{
		// Token: 0x060012D3 RID: 4819 RVA: 0x00048F74 File Offset: 0x00047174
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.Level < 16)
			{
				return ((source.Level >= 11) ? 0.45 : ((source.Level >= 6) ? 0.3 : 0.15)) * (double)source.TotalAttackDamage;
			}
			return 0.6;
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x00048FCF File Offset: 0x000471CF
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.GetBuffCount("XinZhaoPTracker") == 3;
		}

		// Token: 0x060012D5 RID: 4821 RVA: 0x00048FDF File Offset: 0x000471DF
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012D6 RID: 4822 RVA: 0x00048FE2 File Offset: 0x000471E2
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
