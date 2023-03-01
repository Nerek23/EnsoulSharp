using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F8 RID: 1016
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.IcebornGauntlet)]
	public class DamageIcebornGauntlet : DamageItem
	{
		// Token: 0x0600136A RID: 4970 RVA: 0x00049DCD File Offset: 0x00047FCD
		public DamageIcebornGauntlet()
		{
			base.ItemId = ItemId.Iceborn_Gauntlet;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x00049DE7 File Offset: 0x00047FE7
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.BaseAttackDamage;
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x00049DF0 File Offset: 0x00047FF0
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.InventoryItems.Find((InventorySlot x) => x.Id == base.ItemId && x.SpellSlot.IsReady(0)) != null;
		}
	}
}
