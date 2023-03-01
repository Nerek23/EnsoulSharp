using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000363 RID: 867
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Samira")]
	public class DamageSamiraPassive : IPassiveDamage
	{
		// Token: 0x06001075 RID: 4213 RVA: 0x0004521F File Offset: 0x0004341F
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(((float)(1 + source.Level) + 0.1f * source.GetBonusPhysicalDamage()) * ((source.HealthPercent + 100f) / 100f));
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0004524B File Offset: 0x0004344B
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.Distance(source) < 200f + target.BoundingRadius;
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x00045262 File Offset: 0x00043462
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00045265 File Offset: 0x00043465
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
