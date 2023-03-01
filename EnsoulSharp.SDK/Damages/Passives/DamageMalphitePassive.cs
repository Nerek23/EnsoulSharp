using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A6 RID: 934
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Malphite")]
	public class DamageMalphitePassive : IPassiveDamage
	{
		// Token: 0x060011EC RID: 4588 RVA: 0x00047730 File Offset: 0x00045930
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageMalphitePassive.damages[Math.Min(spell.Level - 1, 4)] + 0.2 * (double)source.TotalMagicalDamage + 0.15 * (double)source.Armor;
			}
			return 0.0;
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x00047798 File Offset: 0x00045998
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("MalphiteCleave");
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x000477A5 File Offset: 0x000459A5
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x000477A8 File Offset: 0x000459A8
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008AF RID: 2223
		private static readonly double[] damages = new double[]
		{
			15.0,
			25.0,
			35.0,
			45.0,
			55.0
		};
	}
}
