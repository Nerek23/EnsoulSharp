using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000386 RID: 902
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Zac")]
	public class DamageZacPassive : IPassiveDamage
	{
		// Token: 0x06001135 RID: 4405 RVA: 0x000463D1 File Offset: 0x000445D1
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.TotalAttackDamage * (source.GetCritMultiplier(false) - 1f));
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x000463E8 File Offset: 0x000445E8
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return Math.Abs(source.Crit - 1f) < float.Epsilon && !source.HasBuff("zacqempowered");
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x00046412 File Offset: 0x00044612
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x00046415 File Offset: 0x00044615
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
