using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D4 RID: 980
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageXayahMarkPassive : IPassiveDamage
	{
		// Token: 0x060012EE RID: 4846 RVA: 0x000491F7 File Offset: 0x000473F7
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.2 * (double)source.TotalAttackDamage;
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x0004920A File Offset: 0x0004740A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("XayahW") && (source.CharacterName == "Xayah" || source.CharacterName == "Rakan");
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x0004923F File Offset: 0x0004743F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x00049242 File Offset: 0x00047442
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
