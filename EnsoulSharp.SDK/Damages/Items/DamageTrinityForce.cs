using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FF RID: 1023
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.TrinityForce)]
	public class DamageTrinityForce : DamageItem
	{
		// Token: 0x06001381 RID: 4993 RVA: 0x00049FCB File Offset: 0x000481CB
		public DamageTrinityForce()
		{
			base.ItemId = ItemId.Trinity_Force;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00049FE5 File Offset: 0x000481E5
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(2f * source.BaseAttackDamage);
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00049FF4 File Offset: 0x000481F4
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("3078trinityforce");
		}
	}
}
