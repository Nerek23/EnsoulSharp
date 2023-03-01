using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000362 RID: 866
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Renata")]
	public class DamageRenataPassive : IPassiveDamage
	{
		// Token: 0x06001070 RID: 4208 RVA: 0x000451AC File Offset: 0x000433AC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (0.01 + 0.0025 * (double)Math.Min(source.Level - 1, 17) + 0.01 * (double)source.TotalAttackDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x00045201 File Offset: 0x00043401
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return !target.HasBuff("RenataPassiveDebuff");
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x00045211 File Offset: 0x00043411
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00045214 File Offset: 0x00043414
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
