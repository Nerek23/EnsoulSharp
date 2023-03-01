using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200034F RID: 847
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Akali")]
	public class DamageAkaliPassive : IPassiveDamage
	{
		// Token: 0x06001007 RID: 4103 RVA: 0x000446F5 File Offset: 0x000428F5
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.Level == 1)
			{
				return 35.0;
			}
			return (double)(35 + 147 / (17 * (source.Level - 1)));
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0004471F File Offset: 0x0004291F
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("akalipweapon");
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x0004472C File Offset: 0x0004292C
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0004472F File Offset: 0x0004292F
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
