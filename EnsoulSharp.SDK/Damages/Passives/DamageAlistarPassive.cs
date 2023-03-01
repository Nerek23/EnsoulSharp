using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000351 RID: 849
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Alistar")]
	public class DamageAlistarPassive : IPassiveDamage
	{
		// Token: 0x06001012 RID: 4114 RVA: 0x00044788 File Offset: 0x00042988
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(20 + 15 * (source.Level - 1));
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00044799 File Offset: 0x00042999
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("alistareattack");
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x000447A6 File Offset: 0x000429A6
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x000447A9 File Offset: 0x000429A9
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
