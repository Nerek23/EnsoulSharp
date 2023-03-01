using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E4 RID: 996
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Typhoon)]
	public class DamageTyphoon : DamageItem
	{
		// Token: 0x0600132F RID: 4911 RVA: 0x000497A1 File Offset: 0x000479A1
		public DamageTyphoon()
		{
			base.ItemId = ItemId.Typhoon;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001330 RID: 4912 RVA: 0x000497BB File Offset: 0x000479BB
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageTyphoon.damage[Math.Min(source.Level - 1, 17)];
		}

		// Token: 0x06001331 RID: 4913 RVA: 0x000497D2 File Offset: 0x000479D2
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}

		// Token: 0x04000905 RID: 2309
		private static readonly double[] damage = new double[]
		{
			180.0,
			180.0,
			180.0,
			180.0,
			180.0,
			180.0,
			180.0,
			180.0,
			180.0,
			195.0,
			210.0,
			225.0,
			240.0,
			255.0,
			270.0,
			285.0,
			300.0,
			315.0
		};
	}
}
