using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035E RID: 862
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Braum")]
	public class DamageBraumPassive : IPassiveDamage
	{
		// Token: 0x06001059 RID: 4185 RVA: 0x00044D87 File Offset: 0x00042F87
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.2 * (double)(16 + 10 * source.Level);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x00044DA0 File Offset: 0x00042FA0
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("braummarkstunreduction");
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00044DAD File Offset: 0x00042FAD
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00044DB0 File Offset: 0x00042FB0
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
