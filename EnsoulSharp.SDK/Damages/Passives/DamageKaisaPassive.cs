using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000373 RID: 883
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kaisa")]
	public class DamageKaisaPassive : IPassiveDamage
	{
		// Token: 0x060010CD RID: 4301 RVA: 0x000459FC File Offset: 0x00043BFC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			double num = DamageKaisaPassive.FirstDamage[Math.Min(source.Level, 18)];
			int buffCount = target.GetBuffCount("kaisapassivemarker");
			if (buffCount > 0)
			{
				num += DamageKaisaPassive.SecondDamage[Math.Min(source.Level, 18)] * (double)buffCount;
			}
			return num + DamageKaisaPassive.ThridDamage[Math.Min(buffCount - 1, 5)] * (double)source.TotalMagicalDamage;
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x00045A61 File Offset: 0x00043C61
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("kaisapassivemarker");
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x00045A6E File Offset: 0x00043C6E
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x00045A71 File Offset: 0x00043C71
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000887 RID: 2183
		private static readonly double[] FirstDamage = new double[]
		{
			5.0,
			5.0,
			5.0,
			8.0,
			8.0,
			8.0,
			11.0,
			11.0,
			11.0,
			14.0,
			14.0,
			17.0,
			17.0,
			17.0,
			20.0,
			20.0,
			20.0,
			23.0,
			23.0,
			23.0
		};

		// Token: 0x04000888 RID: 2184
		private static readonly double[] SecondDamage = new double[]
		{
			1.0,
			1.0,
			1.0,
			1.0,
			3.75,
			3.75,
			3.75,
			3.75,
			6.5,
			6.5,
			6.5,
			6.5,
			9.25,
			9.25,
			9.25,
			12.0,
			12.0,
			12.0,
			12.0,
			12.0
		};

		// Token: 0x04000889 RID: 2185
		private static readonly double[] ThridDamage = new double[]
		{
			0.0,
			0.15,
			0.175,
			0.2,
			0.225,
			0.25
		};
	}
}
