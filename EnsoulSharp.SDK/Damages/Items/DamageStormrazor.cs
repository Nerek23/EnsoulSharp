using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000403 RID: 1027
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Stormrazor)]
	public class DamageStormrazor : DamageItem
	{
		// Token: 0x0600138C RID: 5004 RVA: 0x0004A0EE File Offset: 0x000482EE
		public DamageStormrazor()
		{
			base.ItemId = ItemId.Stormrazor;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0004A108 File Offset: 0x00048308
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 120.0;
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x0004A113 File Offset: 0x00048313
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("itemstatikshankcharge") && source.GetBuffCount("itemstatikshankcharge") == 100;
		}
	}
}
