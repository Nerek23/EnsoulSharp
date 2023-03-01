using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000354 RID: 852
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Aphelios")]
	public class DamageApheliosPassive : IPassiveDamage
	{
		// Token: 0x06001022 RID: 4130 RVA: 0x000448B8 File Offset: 0x00042AB8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return 1.1 * (double)source.TotalAttackDamage;
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x000448CB File Offset: 0x00042ACB
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.Spellbook.GetSpell(SpellSlot.Q).TooltipVars[2] == 3f;
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x000448E7 File Offset: 0x00042AE7
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x000448EA File Offset: 0x00042AEA
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
