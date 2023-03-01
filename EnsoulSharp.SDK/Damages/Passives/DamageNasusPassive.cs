using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A9 RID: 937
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Nasus")]
	public class DamageNasusPassive : IPassiveDamage
	{
		// Token: 0x060011FD RID: 4605 RVA: 0x00047890 File Offset: 0x00045A90
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageNasusPassive.damages[Math.Min(spell.Level - 1, 4)] + (double)source.GetBuffCount("NausuQ");
			}
			return 0.0;
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x000478E1 File Offset: 0x00045AE1
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("NasusQ");
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x000478EE File Offset: 0x00045AEE
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x000478F1 File Offset: 0x00045AF1
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008B1 RID: 2225
		private static readonly double[] damages = new double[]
		{
			30.0,
			50.0,
			70.0,
			90.0,
			110.0
		};
	}
}
