using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003EB RID: 1003
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Noonquiver)]
	public class DamageNoonquiver : DamageItem
	{
		// Token: 0x06001346 RID: 4934 RVA: 0x00049980 File Offset: 0x00047B80
		public DamageNoonquiver()
		{
			base.ItemId = ItemId.Noonquiver;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x0004999A File Offset: 0x00047B9A
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 20.0;
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000499A5 File Offset: 0x00047BA5
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.IsMinion() || target.IsJungle();
		}
	}
}
