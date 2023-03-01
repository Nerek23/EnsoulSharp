using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000368 RID: 872
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Draven")]
	public class DamageDravenPassive : IPassiveDamage
	{
		// Token: 0x06001090 RID: 4240 RVA: 0x00045414 File Offset: 0x00043614
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageDravenPassive.damages[Math.Min(spell.Level - 1, 4)] + DamageDravenPassive.damagePercents[Math.Min(spell.Level - 1, 4)] * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x00045475 File Offset: 0x00043675
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("DravenSpinningAttack");
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x00045482 File Offset: 0x00043682
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x00045485 File Offset: 0x00043685
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400087F RID: 2175
		private static readonly double[] damages = new double[]
		{
			40.0,
			45.0,
			50.0,
			55.0,
			60.0
		};

		// Token: 0x04000880 RID: 2176
		private static readonly double[] damagePercents = new double[]
		{
			0.7,
			0.8,
			0.9,
			1.0,
			1.1
		};
	}
}
