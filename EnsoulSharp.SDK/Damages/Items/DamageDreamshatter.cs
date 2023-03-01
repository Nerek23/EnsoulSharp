using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E1 RID: 993
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.Dreamshatter)]
	public class DamageDreamshatter : DamageItem
	{
		// Token: 0x06001326 RID: 4902 RVA: 0x000496E3 File Offset: 0x000478E3
		public DamageDreamshatter()
		{
			base.ItemId = ItemId.Dreamshatter;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001327 RID: 4903 RVA: 0x000496FD File Offset: 0x000478FD
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 1.75 * (double)source.BaseAttackDamage;
		}

		// Token: 0x06001328 RID: 4904 RVA: 0x00049710 File Offset: 0x00047910
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
