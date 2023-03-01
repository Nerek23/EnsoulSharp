using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x02000400 RID: 1024
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Stridebreaker)]
	public class DamageStridebreaker : DamageItem
	{
		// Token: 0x06001384 RID: 4996 RVA: 0x0004A001 File Offset: 0x00048201
		public DamageStridebreaker()
		{
			base.ItemId = ItemId.Stridebreaker;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x0004A01B File Offset: 0x0004821B
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 1.75 * (double)source.BaseAttackDamage;
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0004A02E File Offset: 0x0004822E
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
