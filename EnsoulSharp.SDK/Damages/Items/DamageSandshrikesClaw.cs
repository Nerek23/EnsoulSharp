using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003E7 RID: 999
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.SandshrikesClaw)]
	public class DamageSandshrikesClaw : DamageItem
	{
		// Token: 0x06001339 RID: 4921 RVA: 0x0004986E File Offset: 0x00047A6E
		public DamageSandshrikesClaw()
		{
			base.ItemId = ItemId.Sandshrikes_Claw;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600133A RID: 4922 RVA: 0x00049888 File Offset: 0x00047A88
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 75.0 + 0.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0600133B RID: 4923 RVA: 0x000498A5 File Offset: 0x00047AA5
		public override double GetPassiveDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.0;
		}
	}
}
