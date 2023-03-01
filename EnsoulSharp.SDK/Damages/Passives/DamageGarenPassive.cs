using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000392 RID: 914
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Garen")]
	public class DamageGarenPassive : IPassiveDamage
	{
		// Token: 0x0600117A RID: 4474 RVA: 0x00046B24 File Offset: 0x00044D24
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageGarenPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x00046B7A File Offset: 0x00044D7A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("GarenQ");
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x00046B87 File Offset: 0x00044D87
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x00046B8A File Offset: 0x00044D8A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400089F RID: 2207
		private static readonly double[] damages = new double[]
		{
			30.0,
			60.0,
			90.0,
			120.0,
			150.0
		};
	}
}
