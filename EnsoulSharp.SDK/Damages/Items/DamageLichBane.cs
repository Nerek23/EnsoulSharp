using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003F3 RID: 1011
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.LichBane)]
	public class DamageLichBane : DamageItem
	{
		// Token: 0x0600135B RID: 4955 RVA: 0x00049BE4 File Offset: 0x00047DE4
		public DamageLichBane()
		{
			base.ItemId = ItemId.Lich_Bane;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00049BFE File Offset: 0x00047DFE
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(0.75f * source.BaseAttackDamage + 0.5f * source.TotalMagicalDamage);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00049C1A File Offset: 0x00047E1A
		public override bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("lichbane");
		}
	}
}
