using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200034E RID: 846
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Aatrox")]
	public class DamageAatroxPassive : IPassiveDamage
	{
		// Token: 0x06001002 RID: 4098 RVA: 0x00044650 File Offset: 0x00042850
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double result = (double)target.MaxHealth * (0.08 + 0.0047 * (double)Math.Max(0, source.Level - 1));
			if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
			{
				result = Math.Min(100.0, (double)target.MaxHealth * (0.05 + 0.0047 * (double)Math.Max(0, source.Level - 1)));
			}
			return result;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x000446DA File Offset: 0x000428DA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("aatroxpassiveready");
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x000446E7 File Offset: 0x000428E7
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x000446EA File Offset: 0x000428EA
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
