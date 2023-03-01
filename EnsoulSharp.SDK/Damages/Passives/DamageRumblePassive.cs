using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B5 RID: 949
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Rumble")]
	public class DamageRumblePassive : IPassiveDamage
	{
		// Token: 0x06001240 RID: 4672 RVA: 0x00047F57 File Offset: 0x00046157
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(20 + 5 * (source.Level - 1)) + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x00047F79 File Offset: 0x00046179
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("rumbleoverheat");
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x00047F86 File Offset: 0x00046186
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x00047F89 File Offset: 0x00046189
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
