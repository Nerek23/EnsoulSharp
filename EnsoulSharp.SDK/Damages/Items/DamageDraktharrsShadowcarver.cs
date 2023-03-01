using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003DF RID: 991
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DraktharrsShadowcarver)]
	public class DamageDraktharrsShadowcarver : DamageItem
	{
		// Token: 0x0600131F RID: 4895 RVA: 0x0004960C File Offset: 0x0004780C
		public DamageDraktharrsShadowcarver()
		{
			base.ItemId = ItemId.Draktharrs_Shadowcarver;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x00049626 File Offset: 0x00047826
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.IsMelee ? 75 : 55) + (source.IsMelee ? 0.3 : 0.25) * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x0004965C File Offset: 0x0004785C
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.Type == GameObjectType.AIHeroClient && source.InventoryItems.Find((InventorySlot x) => x.Id == base.ItemId && x.SpellSlot.IsReady(0)) != null;
		}
	}
}
