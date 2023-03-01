using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039B RID: 923
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Jhin")]
	public class DamageJhinPassive : IPassiveDamage
	{
		// Token: 0x060011AE RID: 4526 RVA: 0x00047020 File Offset: 0x00045220
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return ((source.Level < 6) ? 0.15 : ((source.Level < 11) ? 0.2 : 0.25)) * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0004706E File Offset: 0x0004526E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("JhinPassiveAttackBuff");
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0004707B File Offset: 0x0004527B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0004707E File Offset: 0x0004527E
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
