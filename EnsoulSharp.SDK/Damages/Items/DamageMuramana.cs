using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F2 RID: 1010
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Muramana)]
	public class DamageMuramana : DamageItem
	{
		// Token: 0x06001357 RID: 4951 RVA: 0x00049B74 File Offset: 0x00047D74
		public DamageMuramana()
		{
			base.ItemId = ItemId.Muramana;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x00049B8E File Offset: 0x00047D8E
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (source.IsMelee ? 0.035 : 0.027) * (double)source.MaxMana + 0.06 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x00049BC6 File Offset: 0x00047DC6
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.015 * (double)source.MaxMana;
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x00049BD9 File Offset: 0x00047DD9
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.Type == GameObjectType.AIHeroClient;
		}
	}
}
