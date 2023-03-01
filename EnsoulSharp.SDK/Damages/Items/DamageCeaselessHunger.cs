using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E2 RID: 994
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.CeaselessHunger)]
	public class DamageCeaselessHunger : DamageItem
	{
		// Token: 0x06001329 RID: 4905 RVA: 0x0004971B File Offset: 0x0004791B
		public DamageCeaselessHunger()
		{
			base.ItemId = ItemId.Ceaseless_Hunger;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x00049735 File Offset: 0x00047935
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 1.75 * (double)source.BaseAttackDamage;
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x00049748 File Offset: 0x00047948
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
