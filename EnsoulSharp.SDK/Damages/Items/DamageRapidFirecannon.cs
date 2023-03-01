using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F5 RID: 1013
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.RapidFirecannon)]
	public class DamageRapidFirecannon : DamageItem
	{
		// Token: 0x06001360 RID: 4960 RVA: 0x00049C5E File Offset: 0x00047E5E
		public DamageRapidFirecannon()
		{
			base.ItemId = ItemId.Rapid_Firecannon;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x00049C78 File Offset: 0x00047E78
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 120.0;
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x00049C83 File Offset: 0x00047E83
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("itemstatikshankcharge") && source.GetBuffCount("itemstatikshankcharge") == 100;
		}
	}
}
