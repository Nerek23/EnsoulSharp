using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000350 RID: 848
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Akshan")]
	public class DamageAkshanPassive : IPassiveDamage
	{
		// Token: 0x0600100C RID: 4108 RVA: 0x0004473A File Offset: 0x0004293A
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageAkshanPassive.damages[Math.Min(source.Level - 1, 17)];
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x00044751 File Offset: 0x00042951
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("AkshanPassiveDebuff") == 2;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00044761 File Offset: 0x00042961
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00044764 File Offset: 0x00042964
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000872 RID: 2162
		private static readonly double[] damages = new double[]
		{
			10.0,
			15.0,
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
			105.0,
			120.0,
			135.0,
			150.0,
			165.0
		};
	}
}
