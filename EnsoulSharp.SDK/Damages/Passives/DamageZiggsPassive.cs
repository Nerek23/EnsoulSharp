using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D2 RID: 978
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ziggs")]
	public class DamageZiggsPassive : IPassiveDamage
	{
		// Token: 0x060012E3 RID: 4835 RVA: 0x000490C0 File Offset: 0x000472C0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(0.5f * source.TotalMagicalDamage) + DamageZiggsPassive.damages[Math.Min(17, Math.Max(0, source.Level - 1))] * ((target.Type == GameObjectType.AITurretClient) ? 2.5 : 1.0);
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x00049114 File Offset: 0x00047314
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ZiggsShortFuse");
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x00049121 File Offset: 0x00047321
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x00049124 File Offset: 0x00047324
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008D4 RID: 2260
		private static readonly double[] damages = new double[]
		{
			20.0,
			24.0,
			28.0,
			32.0,
			36.0,
			40.0,
			48.0,
			56.0,
			64.0,
			72.0,
			80.0,
			88.0,
			100.0,
			112.0,
			124.0,
			136.0,
			148.0,
			160.0
		};
	}
}
