using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038E RID: 910
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ekko")]
	public class DamageEkkoPassive : IPassiveDamage
	{
		// Token: 0x06001163 RID: 4451 RVA: 0x00046860 File Offset: 0x00044A60
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = DamageEkkoPassive.damages[Math.Min(17, Math.Max(0, source.Level - 1))] + 0.9 * (double)source.TotalMagicalDamage;
			if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
			{
				num *= 2.5;
			}
			return num;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x000468BE File Offset: 0x00044ABE
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("EkkoStacks") == 2;
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x000468CE File Offset: 0x00044ACE
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x000468D1 File Offset: 0x00044AD1
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400089C RID: 2204
		private static readonly double[] damages = new double[]
		{
			30.0,
			40.0,
			50.0,
			60.0,
			70.0,
			80.0,
			85.0,
			90.0,
			95.0,
			100.0,
			105.0,
			110.0,
			115.0,
			120.0,
			125.0,
			130.0,
			135.0,
			140.0
		};
	}
}
