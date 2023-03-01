using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000402 RID: 1026
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.TitanicHydra)]
	public class DamageTitanicHydra : DamageItem
	{
		// Token: 0x0600138A RID: 5002 RVA: 0x0004A083 File Offset: 0x00048283
		public DamageTitanicHydra()
		{
			base.ItemId = ItemId.Titanic_Hydra;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x0004A0A0 File Offset: 0x000482A0
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (source.IsMelee ? 5.0 : 3.75) + (source.IsMelee ? 0.015 : 0.0125) * (double)source.MaxHealth;
		}
	}
}
