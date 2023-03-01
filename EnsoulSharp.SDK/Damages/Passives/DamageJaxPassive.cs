using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000399 RID: 921
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Jax")]
	public class DamageJaxPassive : IPassiveDamage
	{
		// Token: 0x060011A2 RID: 4514 RVA: 0x00046F14 File Offset: 0x00045114
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageJaxPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.6 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x00046F6A File Offset: 0x0004516A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("JaxEmpowerTwo");
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x00046F77 File Offset: 0x00045177
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x00046F7A File Offset: 0x0004517A
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008A5 RID: 2213
		private static readonly double[] damages = new double[]
		{
			50.0,
			85.0,
			120.0,
			155.0,
			190.0
		};
	}
}
