using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CA RID: 970
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Vi")]
	public class DamageViPassive : IPassiveDamage
	{
		// Token: 0x060012B7 RID: 4791 RVA: 0x00048C98 File Offset: 0x00046E98
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				double num = (DamageViPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.01 * (double)source.GetBonusPhysicalDamage() / 35.0) * (double)target.MaxHealth;
				if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
				{
					num = Math.Max(300.0, num);
				}
				return num;
			}
			return 0.0;
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00048D28 File Offset: 0x00046F28
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.GetBuffCount("viwproc") == 2;
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x00048D38 File Offset: 0x00046F38
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x00048D3B File Offset: 0x00046F3B
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008D0 RID: 2256
		private static readonly double[] damages = new double[]
		{
			0.04,
			0.055,
			0.07,
			0.085,
			0.1
		};
	}
}
