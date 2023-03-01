using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000370 RID: 880
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Garen")]
	public class DamageGarenPassiveA : IPassiveDamage
	{
		// Token: 0x060010BD RID: 4285 RVA: 0x000458AC File Offset: 0x00043AAC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("garenpassiveenemytarget") && target.Type == GameObjectType.AIHeroClient)
			{
				BuffInstance buff = target.GetBuff("garenpassiveenemytarget");
				if (buff.Caster != null && buff.Caster.Compare(source))
				{
					return 0.01 * (double)target.MaxHealth;
				}
			}
			return 0.0;
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x00045912 File Offset: 0x00043B12
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("garenpassiveenemytarget");
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x0004591F File Offset: 0x00043B1F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x00045922 File Offset: 0x00043B22
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}
	}
}
