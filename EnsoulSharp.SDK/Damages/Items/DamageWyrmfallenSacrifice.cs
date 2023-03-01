using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E3 RID: 995
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.WyrmfallenSacrifice)]
	public class DamageWyrmfallenSacrifice : DamageItem
	{
		// Token: 0x0600132C RID: 4908 RVA: 0x00049753 File Offset: 0x00047953
		public DamageWyrmfallenSacrifice()
		{
			base.ItemId = ItemId.Wyrmfallen_Sacrifice;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x0004976D File Offset: 0x0004796D
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(60f + 0.45f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x0600132E RID: 4910 RVA: 0x00049782 File Offset: 0x00047982
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("6672buff") && source.GetBuffCount("6672buff") == 2;
		}
	}
}
