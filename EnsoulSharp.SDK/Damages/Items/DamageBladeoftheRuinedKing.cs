using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Items
{
	// Token: 0x020003EF RID: 1007
	[Export(typeof(IDamageItem))]
	[ExportMetadata("Item", DamageItems.BladeoftheRuinedKing)]
	public class DamageBladeoftheRuinedKing : DamageItem
	{
		// Token: 0x0600134F RID: 4943 RVA: 0x00049A3E File Offset: 0x00047C3E
		public DamageBladeoftheRuinedKing()
		{
			base.ItemId = ItemId.Blade_of_The_Ruined_King;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x00049A58 File Offset: 0x00047C58
		public override double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double val = (source.IsMelee ? 0.1 : 0.06) * (double)target.Health;
			double num = Math.Max(15.0, val);
			if (target.IsMinion() || target.IsJungle())
			{
				return Math.Min(60.0, num);
			}
			return num;
		}
	}
}
