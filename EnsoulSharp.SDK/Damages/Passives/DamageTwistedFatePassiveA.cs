using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C4 RID: 964
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "TwistedFate")]
	public class DamageTwistedFatePassiveA : IPassiveDamage
	{
		// Token: 0x06001293 RID: 4755 RVA: 0x00048908 File Offset: 0x00046B08
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageTwistedFatePassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x0004895E File Offset: 0x00046B5E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("cardmasterstackparticle");
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x0004896B File Offset: 0x00046B6B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x0004896E File Offset: 0x00046B6E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008C9 RID: 2249
		private static readonly double[] damages = new double[]
		{
			65.0,
			90.0,
			115.0,
			140.0,
			165.0
		};
	}
}
