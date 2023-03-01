using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000352 RID: 850
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Aphelios")]
	public class DamageApheliosPassiveB : IPassiveDamage
	{
		// Token: 0x06001017 RID: 4119 RVA: 0x000447B4 File Offset: 0x000429B4
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			int buffCount = source.GetBuffCount("aphelioscrescendumorbitmanager");
			return (1.0 + DamageApheliosPassiveB.damages[Math.Min(buffCount, 20)]) * (double)source.TotalAttackDamage;
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x000447ED File Offset: 0x000429ED
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("aphelioscrescendumorbitmanager");
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x000447FA File Offset: 0x000429FA
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x000447FD File Offset: 0x000429FD
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000873 RID: 2163
		private static readonly double[] damages = new double[]
		{
			0.0,
			0.15,
			0.285,
			0.405,
			0.51,
			0.6,
			0.675,
			0.735,
			0.785,
			0.385,
			0.885,
			0.935,
			0.985,
			1.035,
			1.085,
			1.135,
			1.185,
			1.235,
			1.285,
			1.335,
			1.385
		};
	}
}
