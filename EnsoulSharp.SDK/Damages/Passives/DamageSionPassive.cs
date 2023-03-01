using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BA RID: 954
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Sion")]
	public class DamageSionPassive : IPassiveDamage
	{
		// Token: 0x0600125C RID: 4700 RVA: 0x00048394 File Offset: 0x00046594
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double result = 0.0;
			GameObjectType type = target.Type;
			if (type != GameObjectType.AIHeroClient)
			{
				if (type == GameObjectType.AIMinionClient)
				{
					result = Math.Min(75.0, 0.1 * (double)target.MaxHealth);
				}
			}
			else
			{
				result = 0.1 * (double)target.MaxHealth;
			}
			return result;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x000483EF File Offset: 0x000465EF
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("sionpassivezombie");
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x000483FC File Offset: 0x000465FC
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000483FF File Offset: 0x000465FF
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
