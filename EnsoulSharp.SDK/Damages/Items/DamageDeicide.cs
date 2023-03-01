using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003DE RID: 990
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Deicide)]
	public class DamageDeicide : DamageItem
	{
		// Token: 0x0600131C RID: 4892 RVA: 0x00049579 File Offset: 0x00047779
		public DamageDeicide()
		{
			base.ItemId = ItemId.Deicide;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x00049594 File Offset: 0x00047794
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double val = (source.IsMelee ? 0.12 : 0.09) * (double)target.MaxHealth;
			double val2 = 1.5 * (double)source.BaseAttackDamage;
			double num = Math.Max(val, val2);
			if (!target.IsJungle())
			{
				return num;
			}
			return Math.Min(2.5 * (double)source.BaseAttackDamage, num);
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x000495FF File Offset: 0x000477FF
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("6632buff");
		}
	}
}
