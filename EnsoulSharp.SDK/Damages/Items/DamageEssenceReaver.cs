using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F1 RID: 1009
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.EssenceReaver)]
	public class DamageEssenceReaver : DamageItem
	{
		// Token: 0x06001354 RID: 4948 RVA: 0x00049B32 File Offset: 0x00047D32
		public DamageEssenceReaver()
		{
			base.ItemId = ItemId.Essence_Reaver;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x00049B4C File Offset: 0x00047D4C
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.BaseAttackDamage + 0.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001356 RID: 4950 RVA: 0x00049B67 File Offset: 0x00047D67
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("3508buff");
		}
	}
}
