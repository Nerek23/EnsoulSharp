using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B1 RID: 945
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "RekSai")]
	public class DamageRekSaiPassive : IPassiveDamage
	{
		// Token: 0x06001229 RID: 4649 RVA: 0x00047C2C File Offset: 0x00045E2C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageRekSaiPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00047C82 File Offset: 0x00045E82
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("RekSaiQ");
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00047C8F File Offset: 0x00045E8F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x00047C92 File Offset: 0x00045E92
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008B6 RID: 2230
		private static readonly double[] damages = new double[]
		{
			20.0,
			25.0,
			30.0,
			35.0,
			40.0
		};
	}
}
