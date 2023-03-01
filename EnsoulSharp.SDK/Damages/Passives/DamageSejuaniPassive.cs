using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B6 RID: 950
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Sejuani")]
	public class DamageSejuaniPassive : IPassiveDamage
	{
		// Token: 0x06001245 RID: 4677 RVA: 0x00047F94 File Offset: 0x00046194
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double result = 0.0;
			GameObjectType type = target.Type;
			if (type != GameObjectType.AIHeroClient)
			{
				if (type == GameObjectType.AIMinionClient)
				{
					result = 300.0;
				}
			}
			else if (source.Level < 7)
			{
				result = 0.1 * (double)target.MaxHealth;
			}
			else if (source.Level < 14)
			{
				result = 0.15 * (double)target.MaxHealth;
			}
			else
			{
				result = 0.2 * (double)target.MaxHealth;
			}
			return result;
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x00048016 File Offset: 0x00046216
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("sejuanistun");
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x00048023 File Offset: 0x00046223
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x00048026 File Offset: 0x00046226
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
