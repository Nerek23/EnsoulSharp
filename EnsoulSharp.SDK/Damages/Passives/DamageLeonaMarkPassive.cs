using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D8 RID: 984
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageLeonaMarkPassive : IPassiveDamage
	{
		// Token: 0x06001304 RID: 4868 RVA: 0x00049427 File Offset: 0x00047627
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(18 + 7 * source.Level);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x00049435 File Offset: 0x00047635
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("LeonaSunlight") && !target.GetBuff("LeonaSunlight").Caster.Compare(source);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0004945F File Offset: 0x0004765F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x00049462 File Offset: 0x00047662
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
