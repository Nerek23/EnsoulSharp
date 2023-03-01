using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F9 RID: 1017
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Galeforce)]
	public class DamageGaleforce : DamageItem
	{
		// Token: 0x0600136E RID: 4974 RVA: 0x00049E2A File Offset: 0x0004802A
		public DamageGaleforce()
		{
			base.ItemId = ItemId.Galeforce;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x00049E44 File Offset: 0x00048044
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageGaleforce.damage[Math.Min(source.Level - 1, 17)];
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x00049E5B File Offset: 0x0004805B
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}

		// Token: 0x04000906 RID: 2310
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
