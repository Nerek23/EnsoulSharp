using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CC RID: 972
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Volibear")]
	public class DamageVolibearPassive : IPassiveDamage
	{
		// Token: 0x060012C3 RID: 4803 RVA: 0x00048E00 File Offset: 0x00047000
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageVolibearPassive.damages[Math.Min(spell.Level - 1, 4)] + (double)(1.2f * source.GetBonusPhysicalDamage());
			}
			return 0.0;
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x00048E52 File Offset: 0x00047052
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("VolibearQ");
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x00048E5F File Offset: 0x0004705F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012C6 RID: 4806 RVA: 0x00048E62 File Offset: 0x00047062
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008D2 RID: 2258
		private static readonly double[] damages = new double[]
		{
			20.0,
			40.0,
			60.0,
			80.0,
			100.0
		};
	}
}
