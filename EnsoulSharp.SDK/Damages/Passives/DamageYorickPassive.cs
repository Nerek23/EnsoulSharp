using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D1 RID: 977
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Yorick")]
	public class DamageYorickPassive : IPassiveDamage
	{
		// Token: 0x060012DD RID: 4829 RVA: 0x00049034 File Offset: 0x00047234
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageYorickPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.4 * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x0004908A File Offset: 0x0004728A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("yorickqbuff");
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x00049097 File Offset: 0x00047297
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x0004909A File Offset: 0x0004729A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008D3 RID: 2259
		private static readonly double[] damages = new double[]
		{
			30.0,
			55.0,
			80.0,
			105.0,
			130.0
		};
	}
}
