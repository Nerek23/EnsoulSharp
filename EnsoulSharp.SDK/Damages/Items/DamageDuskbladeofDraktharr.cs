using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F7 RID: 1015
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DuskbladeofDraktharr)]
	public class DamageDuskbladeofDraktharr : DamageItem
	{
		// Token: 0x06001366 RID: 4966 RVA: 0x00049D38 File Offset: 0x00047F38
		public DamageDuskbladeofDraktharr()
		{
			base.ItemId = ItemId.Duskblade_of_Draktharr;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x00049D52 File Offset: 0x00047F52
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.IsMelee ? 75 : 55) + (source.IsMelee ? 0.3 : 0.25) * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x00049D88 File Offset: 0x00047F88
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.Type == GameObjectType.AIHeroClient && source.InventoryItems.Find((InventorySlot x) => x.Id == base.ItemId && x.SpellSlot.IsReady(0)) != null;
		}
	}
}
