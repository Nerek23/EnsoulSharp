using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038C RID: 908
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Diana")]
	public class DamageDianaPassive : IPassiveDamage
	{
		// Token: 0x06001157 RID: 4439 RVA: 0x00046700 File Offset: 0x00044900
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = DamageDianaPassive.damages[Math.Min(source.Level - 1, 17)] + 0.5 * (double)source.TotalMagicalDamage;
			if (!target.IsJungle())
			{
				return num;
			}
			return num * 3.0;
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x0004674A File Offset: 0x0004494A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("dianaarcready");
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x00046757 File Offset: 0x00044957
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0004675A File Offset: 0x0004495A
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000899 RID: 2201
		private static readonly double[] damages = new double[]
		{
			20.0,
			25.0,
			30.0,
			35.0,
			40.0,
			45.0,
			55.0,
			65.0,
			75.0,
			85.0,
			95.0,
			110.0,
			125.0,
			140.0,
			155.0,
			170.0,
			195.0,
			220.0
		};
	}
}
