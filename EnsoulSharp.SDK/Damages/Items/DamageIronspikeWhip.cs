using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E9 RID: 1001
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.IronspikeWhip)]
	public class DamageIronspikeWhip : DamageItem
	{
		// Token: 0x06001340 RID: 4928 RVA: 0x0004990D File Offset: 0x00047B0D
		public DamageIronspikeWhip()
		{
			base.ItemId = ItemId.Ironspike_Whip;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x00049927 File Offset: 0x00047B27
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00049930 File Offset: 0x00047B30
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
