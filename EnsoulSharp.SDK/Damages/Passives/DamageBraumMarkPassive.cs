using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D6 RID: 982
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageBraumMarkPassive : IPassiveDamage
	{
		// Token: 0x060012F9 RID: 4857 RVA: 0x00049317 File Offset: 0x00047517
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(16 + 10 * source.Level);
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00049326 File Offset: 0x00047526
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("BraumMark") == 3;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00049336 File Offset: 0x00047536
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00049339 File Offset: 0x00047539
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
