using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003EA RID: 1002
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.KircheisShard)]
	public class DamageKircheisShard : DamageItem
	{
		// Token: 0x06001343 RID: 4931 RVA: 0x0004993B File Offset: 0x00047B3B
		public DamageKircheisShard()
		{
			base.ItemId = ItemId.Kircheis_Shard;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x00049955 File Offset: 0x00047B55
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 80.0;
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x00049960 File Offset: 0x00047B60
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("itemstatikshankcharge") && source.GetBuffCount("itemstatikshankcharge") == 100;
		}
	}
}
