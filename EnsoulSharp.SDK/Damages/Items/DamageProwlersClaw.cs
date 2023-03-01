using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003FD RID: 1021
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.ProwlersClaw)]
	public class DamageProwlersClaw : DamageItem
	{
		// Token: 0x0600137B RID: 4987 RVA: 0x00049F47 File Offset: 0x00048147
		public DamageProwlersClaw()
		{
			base.ItemId = ItemId.Prowlers_Claw;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00049F61 File Offset: 0x00048161
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 75.0 + 0.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00049F7E File Offset: 0x0004817E
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
