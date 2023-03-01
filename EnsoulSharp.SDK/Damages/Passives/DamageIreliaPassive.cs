using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000397 RID: 919
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Irelia")]
	public class DamageIreliaPassive : IPassiveDamage
	{
		// Token: 0x06001198 RID: 4504 RVA: 0x00046E3B File Offset: 0x0004503B
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 15.0 + 3.0 * (double)Math.Max(0, source.Level - 1) + 0.25 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x00046E72 File Offset: 0x00045072
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ireliapassivestacksmax");
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x00046E7F File Offset: 0x0004507F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x00046E82 File Offset: 0x00045082
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
