using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C3 RID: 963
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "TwistedFate")]
	public class DamageTwistedFatePassive : IPassiveDamage
	{
		// Token: 0x0600128D RID: 4749 RVA: 0x000487B0 File Offset: 0x000469B0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				if (source.HasBuff("bluecardpreattack"))
				{
					return DamageTwistedFatePassive.bluedamages[Math.Min(spell.Level - 1, 4)] + 0.9 * (double)source.TotalMagicalDamage;
				}
				if (source.HasBuff("redcardpreattack"))
				{
					return DamageTwistedFatePassive.reddamages[Math.Min(spell.Level - 1, 4)] + 0.6 * (double)source.TotalMagicalDamage;
				}
				if (source.HasBuff("goldcardpreattack"))
				{
					return DamageTwistedFatePassive.golddamages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.TotalMagicalDamage;
				}
			}
			return 0.0;
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x00048881 File Offset: 0x00046A81
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("bluecardpreattack") || source.HasBuff("redcardpreattack") || source.HasBuff("goldcardpreattack");
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x000488AA File Offset: 0x00046AAA
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x000488AD File Offset: 0x00046AAD
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008C6 RID: 2246
		private static readonly double[] bluedamages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};

		// Token: 0x040008C7 RID: 2247
		private static readonly double[] reddamages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0
		};

		// Token: 0x040008C8 RID: 2248
		private static readonly double[] golddamages = new double[]
		{
			15.0,
			22.5,
			30.0,
			37.5,
			45.0
		};
	}
}
