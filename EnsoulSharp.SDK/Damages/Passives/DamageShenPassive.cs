using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B8 RID: 952
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Shen")]
	public class DamageShenPassive : IPassiveDamage
	{
		// Token: 0x06001250 RID: 4688 RVA: 0x000480D0 File Offset: 0x000462D0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell == null || spell.Level <= 0)
			{
				return 0.0;
			}
			int num = (source.Level >= 16) ? 40 : ((source.Level >= 13) ? 34 : ((source.Level >= 10) ? 28 : ((source.Level >= 7) ? 22 : ((source.Level >= 4) ? 16 : 10))));
			double val = DamageShenPassive.maxDamage[Math.Min(spell.Level - 1, 4)];
			if (source.HasBuff("shenqbuffstrong"))
			{
				double num2 = (DamageShenPassive.heroDamage[Math.Min(spell.Level - 1, 4)] + 0.02 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
				if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
				{
					return Math.Min(val, (double)num + num2);
				}
				return (double)num + num2;
			}
			else
			{
				double num3 = (DamageShenPassive.minionDamage[Math.Min(spell.Level - 1, 4)] + 0.015 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
				if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
				{
					return Math.Min(val, (double)num + num3);
				}
				return (double)num + num3;
			}
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x0004822F File Offset: 0x0004642F
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("shenqbuffweak") || source.HasBuff("shenqbuffstrong");
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x0004824B File Offset: 0x0004644B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x0004824E File Offset: 0x0004644E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008BD RID: 2237
		private static readonly double[] maxDamage = new double[]
		{
			75.0,
			100.0,
			125.0,
			150.0,
			175.0
		};

		// Token: 0x040008BE RID: 2238
		private static readonly double[] heroDamage = new double[]
		{
			0.04,
			0.045,
			0.05,
			0.055,
			0.06
		};

		// Token: 0x040008BF RID: 2239
		private static readonly double[] minionDamage = new double[]
		{
			0.02,
			0.025,
			0.03,
			0.035,
			0.04
		};
	}
}
