using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AA RID: 938
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Nautilus")]
	public class DamageNautilusPassive : IPassiveDamage
	{
		// Token: 0x06001203 RID: 4611 RVA: 0x00047914 File Offset: 0x00045B14
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(2 + 6 * source.Level);
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00047921 File Offset: 0x00045B21
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return !target.HasBuff("nautiluspassivecheck");
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00047931 File Offset: 0x00045B31
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00047934 File Offset: 0x00045B34
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
