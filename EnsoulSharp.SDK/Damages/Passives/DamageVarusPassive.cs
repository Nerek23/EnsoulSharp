using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C6 RID: 966
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Varus")]
	public class DamageVarusPassive : IPassiveDamage
	{
		// Token: 0x0600129F RID: 4767 RVA: 0x00048A30 File Offset: 0x00046C30
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageVarusPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x00048A86 File Offset: 0x00046C86
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x00048A89 File Offset: 0x00046C89
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x00048A8C File Offset: 0x00046C8C
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008CB RID: 2251
		private static readonly double[] damages = new double[]
		{
			7.0,
			12.0,
			17.0,
			22.0,
			27.0
		};
	}
}
