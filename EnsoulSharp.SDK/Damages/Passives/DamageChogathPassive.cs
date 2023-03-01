using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000360 RID: 864
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Chogath")]
	public class DamageChogathPassive : IPassiveDamage
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x00045008 File Offset: 0x00043208
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageChogathPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.TotalMagicalDamage + (0.03 + ((source.GetBuffCount("Feast") > 0) ? ((double)source.GetBuffCount("Feast") * 0.05) : 0.0)) * (double)target.MaxHealth;
			}
			return 0.0;
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x000450A0 File Offset: 0x000432A0
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("VorpalSpikes");
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x000450AD File Offset: 0x000432AD
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x000450B0 File Offset: 0x000432B0
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400087C RID: 2172
		private static readonly double[] damages = new double[]
		{
			22.0,
			34.0,
			46.0,
			58.0,
			70.0
		};
	}
}
