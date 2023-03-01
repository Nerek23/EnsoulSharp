using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003EC RID: 1004
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.GuinsoosRageblade)]
	public class DamageGuinsoosRageblade : DamageItem
	{
		// Token: 0x06001349 RID: 4937 RVA: 0x000499B7 File Offset: 0x00047BB7
		public DamageGuinsoosRageblade()
		{
			base.ItemId = ItemId.Guinsoos_Rageblade;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000499D1 File Offset: 0x00047BD1
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.Crit * 100f * 2f);
		}
	}
}
