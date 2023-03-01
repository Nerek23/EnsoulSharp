using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035D RID: 861
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Blitzcrank")]
	public class DamageBlitzcrankPassive : IPassiveDamage
	{
		// Token: 0x06001054 RID: 4180 RVA: 0x00044D47 File Offset: 0x00042F47
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.75 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00044D6C File Offset: 0x00042F6C
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("PowerFist");
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00044D79 File Offset: 0x00042F79
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x00044D7C File Offset: 0x00042F7C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
