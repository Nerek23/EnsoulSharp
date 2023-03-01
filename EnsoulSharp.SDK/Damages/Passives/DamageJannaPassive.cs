using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000371 RID: 881
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Janna")]
	public class DamageJannaPassive : IPassiveDamage
	{
		// Token: 0x060010C2 RID: 4290 RVA: 0x0004592D File Offset: 0x00043B2D
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return ((source.Level >= 10) ? 0.35 : 0.25) * (double)(source.MoveSpeed - source.BaseMoveSpeed);
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0004595C File Offset: 0x00043B5C
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0004595F File Offset: 0x00043B5F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x00045962 File Offset: 0x00043B62
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
