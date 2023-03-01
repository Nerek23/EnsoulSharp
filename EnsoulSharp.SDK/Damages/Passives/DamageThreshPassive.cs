using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C1 RID: 961
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Thresh")]
	public class DamageThreshPassive : IPassiveDamage
	{
		// Token: 0x06001282 RID: 4738 RVA: 0x00048614 File Offset: 0x00046814
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				double num = (double)((float)source.GetBuffCount("threshpassivesoulsgain") * 1.5f + (0.5f + 0.3f * (float)spell.Level) * source.TotalAttackDamage);
				if (source.HasBuff("threshepassive3"))
				{
					num *= 0.7;
				}
				else if (source.HasBuff("threshepassive2"))
				{
					num *= 0.4;
				}
				else if (source.HasBuff("threshepassive1"))
				{
					num *= 0.1;
				}
				return num;
			}
			return 0.0;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x000486C9 File Offset: 0x000468C9
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.Buffs.Any((BuffInstance x) => x.Name.Contains("threshpassive"));
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x000486F5 File Offset: 0x000468F5
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x000486F8 File Offset: 0x000468F8
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
