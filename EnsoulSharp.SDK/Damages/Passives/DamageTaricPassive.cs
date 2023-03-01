using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BF RID: 959
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Taric")]
	public class DamageTaricPassive : IPassiveDamage
	{
		// Token: 0x06001277 RID: 4727 RVA: 0x00048555 File Offset: 0x00046755
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(21 + 4 * (source.Level - 1)) + 0.15 * (double)source.BonusArmor;
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00048577 File Offset: 0x00046777
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("TaricPassiveAttack");
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00048584 File Offset: 0x00046784
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00048587 File Offset: 0x00046787
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
