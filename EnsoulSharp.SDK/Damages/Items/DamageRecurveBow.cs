using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003EE RID: 1006
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.RecurveBow)]
	public class DamageRecurveBow : DamageItem
	{
		// Token: 0x0600134D RID: 4941 RVA: 0x00049A19 File Offset: 0x00047C19
		public DamageRecurveBow()
		{
			base.ItemId = ItemId.Recurve_Bow;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00049A33 File Offset: 0x00047C33
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 15.0;
		}
	}
}
