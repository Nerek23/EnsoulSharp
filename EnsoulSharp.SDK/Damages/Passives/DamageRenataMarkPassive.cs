using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D3 RID: 979
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageRenataMarkPassive : IPassiveDamage
	{
		// Token: 0x060012E9 RID: 4841 RVA: 0x00049148 File Offset: 0x00047348
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("RenataPassiveDebuff"))
			{
				AIHeroClient aiheroClient = target.GetBuff("RenataPassiveDebuff").Caster as AIHeroClient;
				if (aiheroClient != null && !aiheroClient.Compare(source))
				{
					return (0.01 + 0.0025 * (double)Math.Min(source.Level - 1, 17) + 0.01 * (double)source.TotalAttackDamage / 100.0) * (double)target.MaxHealth;
				}
			}
			return 0.0;
		}

		// Token: 0x060012EA RID: 4842 RVA: 0x000491DC File Offset: 0x000473DC
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("RenataPassiveDebuff");
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x000491E9 File Offset: 0x000473E9
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x000491EC File Offset: 0x000473EC
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
