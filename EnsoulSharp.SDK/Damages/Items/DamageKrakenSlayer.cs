using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FC RID: 1020
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.KrakenSlayer)]
	public class DamageKrakenSlayer : DamageItem
	{
		// Token: 0x06001378 RID: 4984 RVA: 0x00049EF9 File Offset: 0x000480F9
		public DamageKrakenSlayer()
		{
			base.ItemId = ItemId.Kraken_Slayer;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x00049F13 File Offset: 0x00048113
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(60f + 0.45f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00049F28 File Offset: 0x00048128
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("6672buff") && source.GetBuffCount("6672buff") == 2;
		}
	}
}
