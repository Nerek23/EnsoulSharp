using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000384 RID: 900
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Urgot")]
	public class DamageUrgotPassive : IPassiveDamage
	{
		// Token: 0x0600112A RID: 4394 RVA: 0x00046303 File Offset: 0x00044503
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			return (double)(source.TotalAttackDamage * (source.GetCritMultiplier(false) - 1f));
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x0004631A File Offset: 0x0004451A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.Spellbook.GetSpell(SpellSlot.W).Name == "UrgotWCancel";
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x00046337 File Offset: 0x00044537
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x0004633A File Offset: 0x0004453A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
