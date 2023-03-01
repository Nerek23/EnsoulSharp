using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036E RID: 878
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Galio")]
	public class DamageGalioPassive : IPassiveDamage
	{
		// Token: 0x060010B3 RID: 4275 RVA: 0x000457B3 File Offset: 0x000439B3
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.HasBuff("galiopassivebuff"))
			{
				return 0.0;
			}
			return (double)source.TotalAttackDamage;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x000457D3 File Offset: 0x000439D3
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.GetSpell(SpellSlot.W).Level > 0;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x000457E4 File Offset: 0x000439E4
		public bool OverwriteAttackDamage()
		{
			return true;
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x000457E7 File Offset: 0x000439E7
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}
	}
}
