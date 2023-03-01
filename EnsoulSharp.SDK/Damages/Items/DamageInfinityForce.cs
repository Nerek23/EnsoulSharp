using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E5 RID: 997
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.InfinityForce)]
	public class DamageInfinityForce : DamageItem
	{
		// Token: 0x06001333 RID: 4915 RVA: 0x000497F6 File Offset: 0x000479F6
		public DamageInfinityForce()
		{
			base.ItemId = ItemId.Infinity_Force;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00049810 File Offset: 0x00047A10
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(2f * source.BaseAttackDamage);
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x0004981F File Offset: 0x00047A1F
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("3078trinityforce");
		}
	}
}
