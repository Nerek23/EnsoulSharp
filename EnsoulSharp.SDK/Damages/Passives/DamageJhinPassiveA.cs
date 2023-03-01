using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039C RID: 924
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Jhin")]
	public class DamageJhinPassiveA : IPassiveDamage
	{
		// Token: 0x060011B3 RID: 4531 RVA: 0x0004708C File Offset: 0x0004528C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)source.TotalAttackDamage + Math.Round((DamageJhinPassiveA.damages[Math.Min(source.Level - 1, 17)] + Math.Round((double)(source.Crit * 100f / 10f * 3f)) + Math.Round((double)((source.AttackSpeedMod - 1f) * 100f / 10f)) * 2.5) / 100.0 * (double)source.TotalAttackDamage) * 0.5;
		}

		// Token: 0x060011B4 RID: 4532 RVA: 0x0004711F File Offset: 0x0004531F
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return Math.Abs(source.Crit - 1f) < float.Epsilon;
		}

		// Token: 0x060011B5 RID: 4533 RVA: 0x00047139 File Offset: 0x00045339
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011B6 RID: 4534 RVA: 0x0004713C File Offset: 0x0004533C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008A7 RID: 2215
		private static readonly double[] damages = new double[]
		{
			4.0,
			5.0,
			6.0,
			7.0,
			8.0,
			9.0,
			10.0,
			11.0,
			12.0,
			14.0,
			16.0,
			20.0,
			24.0,
			28.0,
			32.0,
			36.0,
			40.0,
			44.0
		};
	}
}
