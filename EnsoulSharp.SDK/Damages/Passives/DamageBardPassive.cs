using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000357 RID: 855
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Bard")]
	public class DamageBardPassive : IPassiveDamage
	{
		// Token: 0x06001032 RID: 4146 RVA: 0x000449BC File Offset: 0x00042BBC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell((SpellSlot)63);
			if (spell != null && spell.Ammo > 0)
			{
				return (double)(35 + 14 * (spell.Ammo / 5)) + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x00044A0E File Offset: 0x00042C0E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.GetBuffCount("bardpspiritammocount") > 0;
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x00044A1E File Offset: 0x00042C1E
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x00044A21 File Offset: 0x00042C21
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
