using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000387 RID: 903
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Zeri")]
	public class DamageZeriPassive : IPassiveDamage
	{
		// Token: 0x0600113A RID: 4410 RVA: 0x00046420 File Offset: 0x00044620
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			int num = source.Level - 1;
			double num2 = 0.7025 + 0.0175 * (double)num;
			if (source.HasBuff("zeriqpassiveready"))
			{
				double num3 = 90.0 + 6.470588235294118 * (double)num * num2 + 0.9 * (double)source.TotalMagicalDamage;
				double num4 = DamageZeriPassive.passivePercents[Math.Min(num, 17)] * (double)target.MaxHealth / 100.0;
				return num3 + num4;
			}
			double num5 = 10.0 + 0.8823529411764706 * (double)num * num2 + 0.03 * (double)source.TotalMagicalDamage;
			if (target.Type == GameObjectType.AIMinionClient && (double)(target.Health - 10f) < source.CalculateMagicDamage(target, num5 * 6.0))
			{
				return (double)target.MaxHealth;
			}
			return num5;
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x00046506 File Offset: 0x00044706
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x00046509 File Offset: 0x00044709
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0004650C File Offset: 0x0004470C
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000895 RID: 2197
		private static readonly double[] passivePercents = new double[]
		{
			0.01,
			0.0159,
			0.021,
			0.0287,
			0.0354,
			0.0425,
			0.0499,
			0.0576,
			0.0655,
			0.0737,
			0.0823,
			0.0911,
			0.1002,
			0.1096,
			0.1192,
			0.1292,
			0.1395,
			0.15,
			0.15
		};
	}
}
