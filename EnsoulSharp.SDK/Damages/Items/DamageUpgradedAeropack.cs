using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E6 RID: 998
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.UpgradedAeropack)]
	public class DamageUpgradedAeropack : DamageItem
	{
		// Token: 0x06001336 RID: 4918 RVA: 0x0004982C File Offset: 0x00047A2C
		public DamageUpgradedAeropack()
		{
			base.ItemId = ItemId.Upgraded_Aeropack;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x00049846 File Offset: 0x00047A46
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 125.0 + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x00049863 File Offset: 0x00047A63
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
