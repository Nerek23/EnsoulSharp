using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FA RID: 1018
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Goredrinker)]
	public class DamageGoredrinker : DamageItem
	{
		// Token: 0x06001372 RID: 4978 RVA: 0x00049E7F File Offset: 0x0004807F
		public DamageGoredrinker()
		{
			base.ItemId = ItemId.Goredrinker;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x00049E99 File Offset: 0x00048099
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 1.75 * (double)source.BaseAttackDamage;
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x00049EAC File Offset: 0x000480AC
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
