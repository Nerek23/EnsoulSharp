using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038B RID: 907
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Darius")]
	public class DamageDariusPassive : IPassiveDamage
	{
		// Token: 0x06001151 RID: 4433 RVA: 0x00046680 File Offset: 0x00044880
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageDariusPassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x000466CC File Offset: 0x000448CC
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("DariusNoxianTacticsONH");
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x000466D9 File Offset: 0x000448D9
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x000466DC File Offset: 0x000448DC
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000898 RID: 2200
		private static readonly double[] damages = new double[]
		{
			0.4,
			0.45,
			0.5,
			0.55,
			0.6
		};
	}
}
