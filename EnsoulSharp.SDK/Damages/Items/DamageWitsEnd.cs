using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000401 RID: 1025
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.WitsEnd)]
	public class DamageWitsEnd : DamageItem
	{
		// Token: 0x06001387 RID: 4999 RVA: 0x0004A039 File Offset: 0x00048239
		public DamageWitsEnd()
		{
			base.ItemId = ItemId.Wits_End;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x0004A053 File Offset: 0x00048253
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageWitsEnd.damage[Math.Min(source.Level - 1, 17)];
		}

		// Token: 0x04000907 RID: 2311
		private static readonly double[] damage = new double[]
		{
			15.0,
			15.0,
			15.0,
			15.0,
			15.0,
			15.0,
			15.0,
			15.0,
			25.0,
			35.0,
			45.0,
			55.0,
			65.0,
			75.0,
			76.25,
			77.5,
			78.75,
			80.0
		};
	}
}
