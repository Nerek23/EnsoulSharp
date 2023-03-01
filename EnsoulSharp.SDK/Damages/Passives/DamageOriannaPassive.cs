using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AE RID: 942
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Orianna")]
	public class DamageOriannaPassive : IPassiveDamage
	{
		// Token: 0x06001219 RID: 4633 RVA: 0x00047B1C File Offset: 0x00045D1C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 0.15 * (double)source.TotalMagicalDamage + DamageOriannaPassive.damages[Math.Min(17, source.Level - 1)];
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x00047B45 File Offset: 0x00045D45
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("orianaspellsword");
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00047B52 File Offset: 0x00045D52
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00047B55 File Offset: 0x00045D55
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008B5 RID: 2229
		private static readonly double[] damages = new double[]
		{
			10.0,
			10.0,
			10.0,
			18.0,
			18.0,
			18.0,
			26.0,
			26.0,
			26.0,
			34.0,
			34.0,
			34.0,
			42.0,
			42.0,
			42.0,
			50.0,
			50.0,
			50.0
		};
	}
}
