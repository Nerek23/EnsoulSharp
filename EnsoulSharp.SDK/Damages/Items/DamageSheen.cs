using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000404 RID: 1028
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Sheen)]
	public class DamageSheen : DamageItem
	{
		// Token: 0x0600138F RID: 5007 RVA: 0x0004A133 File Offset: 0x00048333
		public DamageSheen()
		{
			base.ItemId = ItemId.Sheen;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x0004A14D File Offset: 0x0004834D
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0004A156 File Offset: 0x00048356
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("sheen");
		}
	}
}
