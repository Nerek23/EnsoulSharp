using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AF RID: 943
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Poppy")]
	public class DamagePoppyPassive : IPassiveDamage
	{
		// Token: 0x0600121F RID: 4639 RVA: 0x00047B7C File Offset: 0x00045D7C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double result = 20.0;
			if (source.Level > 1)
			{
				result = 20.0 + 9.411764705882353 * (double)Math.Max(0, source.Level - 1);
			}
			return result;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00047BC1 File Offset: 0x00045DC1
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("PoppyPassiveBuff");
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x00047BCE File Offset: 0x00045DCE
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00047BD1 File Offset: 0x00045DD1
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
