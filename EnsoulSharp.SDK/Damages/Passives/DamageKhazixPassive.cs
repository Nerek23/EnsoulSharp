using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037A RID: 890
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Khazix")]
	public class DamageKhazixPassive : IPassiveDamage
	{
		// Token: 0x060010F4 RID: 4340 RVA: 0x00045E16 File Offset: 0x00044016
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(6 + 8 * (source.Level - 1)) + 0.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x00045E37 File Offset: 0x00044037
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("KhazixPDamage") && target.Type == GameObjectType.AIHeroClient;
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x00045E51 File Offset: 0x00044051
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010F7 RID: 4343 RVA: 0x00045E54 File Offset: 0x00044054
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
