using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000359 RID: 857
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Blitzcrank")]
	public class DamageBlitzcrankPassiveA : IPassiveDamage
	{
		// Token: 0x0600103D RID: 4157 RVA: 0x00044AE8 File Offset: 0x00042CE8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = (double)target.MaxHealth * 0.01;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				num += (double)(60 + 7 * (source.Level - 1));
			}
			return num;
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00044B22 File Offset: 0x00042D22
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("Overdrive");
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00044B2F File Offset: 0x00042D2F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00044B32 File Offset: 0x00042D32
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
