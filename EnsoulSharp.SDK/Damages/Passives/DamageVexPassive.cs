using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000366 RID: 870
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Vex")]
	public class DamageVexPassive : IPassiveDamage
	{
		// Token: 0x06001086 RID: 4230 RVA: 0x00045376 File Offset: 0x00043576
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(30 + 150 / (17 * Math.Max(source.Level - 1, 1)));
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x00045393 File Offset: 0x00043593
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("vexpgloom");
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x000453A0 File Offset: 0x000435A0
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x000453A3 File Offset: 0x000435A3
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
