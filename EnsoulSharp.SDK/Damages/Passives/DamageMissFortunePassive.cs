using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037D RID: 893
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "MissFortune")]
	public class DamageMissFortunePassive : IPassiveDamage
	{
		// Token: 0x06001105 RID: 4357 RVA: 0x00045F78 File Offset: 0x00044178
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.HasBuff("missfortunepassive"))
			{
				return 0.0;
			}
			double num = (double)source.TotalAttackDamage * ((source.Level < 4) ? 0.25 : ((source.Level < 7) ? 0.3 : ((source.Level < 9) ? 0.35 : ((source.Level < 11) ? 0.4 : ((source.Level < 13) ? 0.45 : 5.0)))));
			if (target.Type == GameObjectType.AIMinionClient)
			{
				return num;
			}
			return num * 2.0;
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0004602B File Offset: 0x0004422B
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x0004602E File Offset: 0x0004422E
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x00046031 File Offset: 0x00044231
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
