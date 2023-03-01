using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037B RID: 891
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Leona")]
	public class DamageLeonaPassiveA : IPassiveDamage
	{
		// Token: 0x060010F9 RID: 4345 RVA: 0x00045E60 File Offset: 0x00044060
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.R);
			if (spell != null && spell.Level > 0)
			{
				return DamageLeonaPassiveA.damages[Math.Min(spell.Level - 1, 2)] + 0.15 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x00045EB6 File Offset: 0x000440B6
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("leonarattackbuff");
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x00045EC3 File Offset: 0x000440C3
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x00045EC6 File Offset: 0x000440C6
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400088F RID: 2191
		private static readonly double[] damages = new double[]
		{
			30.0,
			40.0,
			50.0
		};
	}
}
