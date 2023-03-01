using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D0 RID: 976
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Yasuo")]
	public class DamageYasuoPassive : IPassiveDamage
	{
		// Token: 0x060012D8 RID: 4824 RVA: 0x00048FED File Offset: 0x000471ED
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.9 * (double)source.GetCritMultiplier(false) * (double)source.TotalAttackDamage;
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x00049009 File Offset: 0x00047209
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return Math.Abs(source.Crit - 1f) < float.Epsilon;
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x00049023 File Offset: 0x00047223
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x00049026 File Offset: 0x00047226
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
