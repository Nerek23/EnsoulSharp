using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F0 RID: 1008
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DeadMansPlate)]
	public class DamageDeadMansPlate : DamageItem
	{
		// Token: 0x06001351 RID: 4945 RVA: 0x00049ABB File Offset: 0x00047CBB
		public DamageDeadMansPlate()
		{
			base.ItemId = ItemId.Dead_Mans_Plate;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x00049AD8 File Offset: 0x00047CD8
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = (double)source.InventoryItems.Find((InventorySlot x) => x.Id == base.ItemId).SpellCharges;
			return num * 0.4 + num * 0.01 * (double)source.BaseAttackDamage;
		}
	}
}
