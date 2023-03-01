using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AC RID: 940
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Nidalee")]
	public class DamageNidaleePassive : IPassiveDamage
	{
		// Token: 0x0600120E RID: 4622 RVA: 0x000479CC File Offset: 0x00045BCC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.R);
			if (spell != null && spell.Level > 0)
			{
				double result = DamageNidaleePassive.damages[Math.Min(spell.Level - 1, 3)] + 0.75 * (double)source.TotalAttackDamage + 0.4 * (double)source.TotalMagicalDamage;
				if (target.HasBuff("NidaleePassiveHunted"))
				{
					result = DamageNidaleePassive.passivedamages[Math.Min(spell.Level - 1, 3)] + 1.05 * (double)source.TotalAttackDamage + 0.56 * (double)source.TotalMagicalDamage;
				}
				return result;
			}
			return 0.0;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00047A82 File Offset: 0x00045C82
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("Takedown");
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x00047A8F File Offset: 0x00045C8F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00047A92 File Offset: 0x00045C92
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008B3 RID: 2227
		private static readonly double[] damages = new double[]
		{
			5.0,
			30.0,
			55.0,
			80.0
		};

		// Token: 0x040008B4 RID: 2228
		private static readonly double[] passivedamages = new double[]
		{
			7.0,
			42.0,
			77.0,
			112.0
		};
	}
}
