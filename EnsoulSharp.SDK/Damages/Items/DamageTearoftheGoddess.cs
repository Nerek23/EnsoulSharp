using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000405 RID: 1029
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.TearoftheGoddess)]
	public class DamageTearoftheGoddess : DamageItem
	{
		// Token: 0x06001392 RID: 5010 RVA: 0x0004A163 File Offset: 0x00048363
		public DamageTearoftheGoddess()
		{
			base.ItemId = ItemId.Tear_of_the_Goddess;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0004A17D File Offset: 0x0004837D
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 5.0;
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x0004A188 File Offset: 0x00048388
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.IsMinion();
		}
	}
}
