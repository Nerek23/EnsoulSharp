using System;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000408 RID: 1032
	public interface IDamageItem
	{
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600139B RID: 5019
		DamageType DamageType { get; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600139C RID: 5020
		ItemId ItemId { get; }

		// Token: 0x0600139D RID: 5021
		double GetDamage(AIHeroClient source, AIBaseClient target);

		// Token: 0x0600139E RID: 5022
		double GetPassiveDamage(AIHeroClient source, AIBaseClient target);

		// Token: 0x0600139F RID: 5023
		bool IsActive(AIHeroClient source, AIBaseClient target);
	}
}
