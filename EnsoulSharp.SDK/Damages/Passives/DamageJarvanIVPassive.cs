using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000398 RID: 920
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "JarvanIV")]
	public class DamageJarvanIVPassive : IPassiveDamage
	{
		// Token: 0x0600119D RID: 4509 RVA: 0x00046E90 File Offset: 0x00045090
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.Type != GameObjectType.AIHeroClient && target.Type != GameObjectType.AIMinionClient)
			{
				return 0.0;
			}
			double result = (double)target.Health * 0.08;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				result = Math.Min((double)target.Health * 0.08, 400.0);
			}
			return result;
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x00046EF5 File Offset: 0x000450F5
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return !target.HasBuff("jarvanivmartialcadencecheck");
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x00046F05 File Offset: 0x00045105
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x00046F08 File Offset: 0x00045108
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
