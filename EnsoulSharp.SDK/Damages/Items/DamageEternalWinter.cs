using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E0 RID: 992
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.EternalWinter)]
	public class DamageEternalWinter : DamageItem
	{
		// Token: 0x06001323 RID: 4899 RVA: 0x000496A1 File Offset: 0x000478A1
		public DamageEternalWinter()
		{
			base.ItemId = ItemId.Eternal_Winter;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001324 RID: 4900 RVA: 0x000496BB File Offset: 0x000478BB
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 100.0 + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x000496D8 File Offset: 0x000478D8
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
