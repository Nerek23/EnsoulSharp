using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A4 RID: 932
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Lucian")]
	public class DamageLucianPassive : IPassiveDamage
	{
		// Token: 0x060011E2 RID: 4578 RVA: 0x0004764C File Offset: 0x0004584C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = (source.Level < 6) ? 0.3 : ((source.Level < 11) ? 0.4 : ((source.Level < 16) ? 0.5 : 0.6));
			if (target.Type == GameObjectType.AIMinionClient)
			{
				num = 1.0;
			}
			return (double)source.TotalAttackDamage * num;
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x000476BD File Offset: 0x000458BD
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("lucianpassivebuff");
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x000476CA File Offset: 0x000458CA
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x000476CD File Offset: 0x000458CD
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
