using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A8 RID: 936
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "MonkeyKing")]
	public class DamageMonkeyKingPassive : IPassiveDamage
	{
		// Token: 0x060011F7 RID: 4599 RVA: 0x00047804 File Offset: 0x00045A04
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageMonkeyKingPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.45 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x0004785A File Offset: 0x00045A5A
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("MonkeyKingDoubleAttack");
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x00047867 File Offset: 0x00045A67
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x0004786A File Offset: 0x00045A6A
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008B0 RID: 2224
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
