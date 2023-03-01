using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E8 RID: 1000
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.FrozenFist)]
	public class DamageFrozenFist : DamageItem
	{
		// Token: 0x0600133C RID: 4924 RVA: 0x000498B0 File Offset: 0x00047AB0
		public DamageFrozenFist()
		{
			base.ItemId = ItemId.Frozen_Fist;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x000498CA File Offset: 0x00047ACA
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.BaseAttackDamage;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x000498D3 File Offset: 0x00047AD3
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.InventoryItems.Find((InventorySlot x) => x.Id == base.ItemId && x.SpellSlot.IsReady(0)) != null;
		}
	}
}
