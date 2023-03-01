using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000389 RID: 905
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Zoe")]
	public class DamageZoePassive : IPassiveDamage
	{
		// Token: 0x06001146 RID: 4422 RVA: 0x000465B9 File Offset: 0x000447B9
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return DamageZoePassive.damages[Math.Min(17, Math.Max(0, source.Level - 1))] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000465E8 File Offset: 0x000447E8
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("zoepassivesheenbuff");
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x000465F5 File Offset: 0x000447F5
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x000465F8 File Offset: 0x000447F8
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000897 RID: 2199
		private static readonly double[] damages = new double[]
		{
			16.0,
			20.0,
			24.0,
			28.0,
			32.0,
			36.0,
			42.0,
			48.0,
			54.0,
			60.0,
			66.0,
			74.0,
			82.0,
			90.0,
			100.0,
			110.0,
			120.0,
			130.0
		};
	}
}
