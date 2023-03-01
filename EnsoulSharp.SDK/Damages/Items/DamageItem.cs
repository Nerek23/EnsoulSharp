using System;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003DC RID: 988
	public class DamageItem : IDamageItem
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x00049537 File Offset: 0x00047737
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x0004953F File Offset: 0x0004773F
		public DamageType DamageType { get; protected set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x00049548 File Offset: 0x00047748
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x00049550 File Offset: 0x00047750
		public ItemId ItemId { get; protected set; }

		// Token: 0x06001318 RID: 4888 RVA: 0x00049559 File Offset: 0x00047759
		public virtual double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x00049564 File Offset: 0x00047764
		public virtual double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return this.GetDamage(source, target);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x0004956E File Offset: 0x0004776E
		public virtual bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}
	}
}
