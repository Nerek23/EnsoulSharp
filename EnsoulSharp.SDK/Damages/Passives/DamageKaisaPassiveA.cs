using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000374 RID: 884
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kaisa")]
	public class DamageKaisaPassiveA : IPassiveDamage
	{
		// Token: 0x060010D3 RID: 4307 RVA: 0x00045AD0 File Offset: 0x00043CD0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = (0.15 + (double)(source.TotalMagicalDamage / 100f) * 0.06) * (double)(target.MaxHealth - target.Health);
			if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
			{
				num = Math.Min(400.0, num);
			}
			return num;
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00045B35 File Offset: 0x00043D35
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("kaisapassivemarker") == 4;
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x00045B45 File Offset: 0x00043D45
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x00045B48 File Offset: 0x00043D48
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
