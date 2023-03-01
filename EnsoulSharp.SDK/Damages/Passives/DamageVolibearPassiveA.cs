using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CD RID: 973
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Volibear")]
	public class DamageVolibearPassiveA : IPassiveDamage
	{
		// Token: 0x060012C9 RID: 4809 RVA: 0x00048E88 File Offset: 0x00047088
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.Level <= 3)
			{
				return (double)(10f + 1f * (float)source.Level + 0.4f * source.TotalMagicalDamage);
			}
			if (source.Level <= 6)
			{
				return (double)(10f + 2f * (float)source.Level + 0.4f * source.TotalMagicalDamage);
			}
			if (source.Level <= 13)
			{
				return (double)(10f + 3f * (float)source.Level + 0.4f * source.TotalMagicalDamage);
			}
			return (double)(10f + 4f * (float)source.Level + 0.4f * source.TotalMagicalDamage);
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x00048F38 File Offset: 0x00047138
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("volibearrapplicator");
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x00048F45 File Offset: 0x00047145
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x00048F48 File Offset: 0x00047148
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
