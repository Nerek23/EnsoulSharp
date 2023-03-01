using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CE RID: 974
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Warwick")]
	public class DamageWarwickPassive : IPassiveDamage
	{
		// Token: 0x060012CE RID: 4814 RVA: 0x00048F53 File Offset: 0x00047153
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(8 + 2 * source.Level);
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x00048F60 File Offset: 0x00047160
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x00048F63 File Offset: 0x00047163
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x00048F66 File Offset: 0x00047166
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
