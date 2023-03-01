using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AD RID: 941
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Nocturne")]
	public class DamageNocturnePassive : IPassiveDamage
	{
		// Token: 0x06001214 RID: 4628 RVA: 0x00047ACC File Offset: 0x00045CCC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = 0.2 * (double)source.TotalAttackDamage;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return 0.5 * num;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00047B01 File Offset: 0x00045D01
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("nocturneumbrablades");
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00047B0E File Offset: 0x00045D0E
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00047B11 File Offset: 0x00045D11
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
