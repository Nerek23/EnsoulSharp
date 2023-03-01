using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000356 RID: 854
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ashe")]
	public class DamageAshePassiveA : IPassiveDamage
	{
		// Token: 0x0600102C RID: 4140 RVA: 0x0004493C File Offset: 0x00042B3C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageAshePassiveA.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x00044988 File Offset: 0x00042B88
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("AsheQAttack");
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x00044995 File Offset: 0x00042B95
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00044998 File Offset: 0x00042B98
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000874 RID: 2164
		private static readonly double[] damages = new double[]
		{
			0.05,
			0.1,
			0.115,
			0.2,
			0.25
		};
	}
}
