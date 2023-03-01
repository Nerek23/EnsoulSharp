using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F6 RID: 1014
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.DivineSunderer)]
	public class DamageDivineSunderer : DamageItem
	{
		// Token: 0x06001363 RID: 4963 RVA: 0x00049CA3 File Offset: 0x00047EA3
		public DamageDivineSunderer()
		{
			base.ItemId = ItemId.Divine_Sunderer;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x00049CC0 File Offset: 0x00047EC0
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

		// Token: 0x06001365 RID: 4965 RVA: 0x00049D2B File Offset: 0x00047F2B
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("6632buff");
		}
	}
}
