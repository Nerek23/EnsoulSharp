using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BE RID: 958
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Talon")]
	public class DamageTalonPassive : IPassiveDamage
	{
		// Token: 0x06001272 RID: 4722 RVA: 0x00048518 File Offset: 0x00046718
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)((float)(65 + 10 * (source.Level - 1)) + 2f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x00048537 File Offset: 0x00046737
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("TalonPassiveStack") == 3;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00048547 File Offset: 0x00046747
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x0004854A File Offset: 0x0004674A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
