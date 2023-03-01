using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000376 RID: 886
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kayle")]
	public class DamageKaylePassiveB : IPassiveDamage
	{
		// Token: 0x060010DD RID: 4317 RVA: 0x00045B78 File Offset: 0x00043D78
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageKaylePassiveB.damages[Math.Min(spell.Level - 1, 4)] + 0.1 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage + (DamageKaylePassiveB.damagePercents[Math.Min(spell.Level - 1, 4)] + (double)(source.TotalMagicalDamage / 100f)) * (double)(target.MaxHealth - target.Health);
			}
			return 0.0;
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x00045C12 File Offset: 0x00043E12
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("KayleE");
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x00045C1F File Offset: 0x00043E1F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x00045C22 File Offset: 0x00043E22
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400088A RID: 2186
		private static readonly double[] damages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};

		// Token: 0x0400088B RID: 2187
		private static readonly double[] damagePercents = new double[]
		{
			0.08,
			0.1,
			0.12,
			0.14,
			0.16
		};
	}
}
