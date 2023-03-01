using System;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003DA RID: 986
	public interface IPassiveDamage
	{
		// Token: 0x0600130F RID: 4879
		double GetDamage(AIHeroClient source, AIBaseClient target);

		// Token: 0x06001310 RID: 4880
		bool IsActive(AIHeroClient source, AIBaseClient target);

		// Token: 0x06001311 RID: 4881
		bool OverwriteAttackDamage();

		// Token: 0x06001312 RID: 4882
		DamageType GetDamageType();
	}
}
