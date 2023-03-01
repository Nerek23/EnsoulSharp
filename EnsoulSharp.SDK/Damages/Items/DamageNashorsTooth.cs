using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F4 RID: 1012
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.NashorsTooth)]
	public class DamageNashorsTooth : DamageItem
	{
		// Token: 0x0600135E RID: 4958 RVA: 0x00049C27 File Offset: 0x00047E27
		public DamageNashorsTooth()
		{
			base.ItemId = ItemId.Nashors_Tooth;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x00049C41 File Offset: 0x00047E41
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 15.0 + 0.2 * (double)source.TotalMagicalDamage;
		}
	}
}
