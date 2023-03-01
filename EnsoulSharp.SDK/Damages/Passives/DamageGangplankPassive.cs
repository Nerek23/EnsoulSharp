using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036B RID: 875
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Gangplank")]
	public class DamageGangplankPassive : IPassiveDamage
	{
		// Token: 0x060010A2 RID: 4258 RVA: 0x000455D8 File Offset: 0x000437D8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.Type == GameObjectType.AIMinionClient)
			{
				return 0.0;
			}
			float num = (float)(45 + 15 * Math.Min(18, source.Level)) + source.GetBonusPhysicalDamage();
			if (target.Type == GameObjectType.AITurretClient)
			{
				num *= 0.5f;
			}
			return (double)num;
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x00045627 File Offset: 0x00043827
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("gangplankpassiveattack");
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x00045634 File Offset: 0x00043834
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x00045637 File Offset: 0x00043837
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}
	}
}
