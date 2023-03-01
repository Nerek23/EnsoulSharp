using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FE RID: 1022
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Everfrost)]
	public class DamageEverfrost : DamageItem
	{
		// Token: 0x0600137E RID: 4990 RVA: 0x00049F89 File Offset: 0x00048189
		public DamageEverfrost()
		{
			base.ItemId = ItemId.Everfrost;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00049FA3 File Offset: 0x000481A3
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 100.0 + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00049FC0 File Offset: 0x000481C0
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
