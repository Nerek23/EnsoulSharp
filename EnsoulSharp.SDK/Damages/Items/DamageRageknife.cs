using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003ED RID: 1005
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Rageknife)]
	public class DamageRageknife : DamageItem
	{
		// Token: 0x0600134B RID: 4939 RVA: 0x000499E6 File Offset: 0x00047BE6
		public DamageRageknife()
		{
			base.ItemId = ItemId.Rageknife;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x00049A00 File Offset: 0x00047C00
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.Crit * 100f) * 1.75;
		}
	}
}
