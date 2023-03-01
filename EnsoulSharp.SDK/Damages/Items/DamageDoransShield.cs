using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000406 RID: 1030
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DoransShield)]
	public class DamageDoransShield : DamageItem
	{
		// Token: 0x06001395 RID: 5013 RVA: 0x0004A190 File Offset: 0x00048390
		public DamageDoransShield()
		{
			base.ItemId = ItemId.Dorans_Shield;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0004A1AA File Offset: 0x000483AA
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 5.0;
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x0004A1B5 File Offset: 0x000483B5
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.IsMinion();
		}
	}
}
