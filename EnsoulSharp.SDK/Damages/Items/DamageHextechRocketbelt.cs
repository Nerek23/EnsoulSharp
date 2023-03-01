using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FB RID: 1019
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.HextechRocketbelt)]
	public class DamageHextechRocketbelt : DamageItem
	{
		// Token: 0x06001375 RID: 4981 RVA: 0x00049EB7 File Offset: 0x000480B7
		public DamageHextechRocketbelt()
		{
			base.ItemId = ItemId.Hextech_Rocketbelt;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00049ED1 File Offset: 0x000480D1
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 125.0 + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00049EEE File Offset: 0x000480EE
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
