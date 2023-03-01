using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000407 RID: 1031
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DoransRing)]
	public class DamageDoransRing : DamageItem
	{
		// Token: 0x06001398 RID: 5016 RVA: 0x0004A1BD File Offset: 0x000483BD
		public DamageDoransRing()
		{
			base.ItemId = ItemId.Dorans_Ring;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x0004A1D7 File Offset: 0x000483D7
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 5.0;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0004A1E2 File Offset: 0x000483E2
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.IsMinion();
		}
	}
}
