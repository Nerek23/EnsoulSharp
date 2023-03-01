using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000365 RID: 869
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Udyr")]
	public class DamageUdyrPassiveA : IPassiveDamage
	{
		// Token: 0x06001080 RID: 4224 RVA: 0x0004530B File Offset: 0x0004350B
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (DamageUdyrPassiveA.damages[Math.Min(source.Level - 1, 17)] + 0.006 * (double)(source.TotalMagicalDamage / 100f)) * (double)target.MaxHealth;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00045342 File Offset: 0x00043542
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("UdyrQ2Activation");
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0004534F File Offset: 0x0004354F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00045352 File Offset: 0x00043552
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400087E RID: 2174
		private static readonly double[] damages = new double[]
		{
			0.015,
			0.0159,
			0.0168,
			0.0176,
			0.0185,
			0.0194,
			0.0203,
			0.0212,
			0.0221,
			0.0229,
			0.0238,
			0.0247,
			0.0256,
			0.0265,
			0.0274,
			0.0282,
			0.0291,
			0.03
		};
	}
}
