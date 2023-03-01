using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BC RID: 956
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Sona")]
	public class DamageSonaPassive : IPassiveDamage
	{
		// Token: 0x06001267 RID: 4711 RVA: 0x00048483 File Offset: 0x00046683
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageSonaPassive.damages[Math.Min(17, Math.Max(0, source.Level - 1))] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x000484B2 File Offset: 0x000466B2
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("sonapassiveattack");
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x000484BF File Offset: 0x000466BF
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x000484C2 File Offset: 0x000466C2
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008C2 RID: 2242
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0,
			70.0,
			80.0,
			90.0,
			105.0,
			120.0,
			135.0,
			150.0,
			165.0,
			180.0,
			195.0,
			210.0,
			225.0,
			240.0
		};
	}
}
