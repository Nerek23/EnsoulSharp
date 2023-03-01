using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B3 RID: 947
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Rengar")]
	public class DamageRengarPassive : IPassiveDamage
	{
		// Token: 0x06001235 RID: 4661 RVA: 0x00047D90 File Offset: 0x00045F90
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell == null || spell.Level <= 0)
			{
				return 0.0;
			}
			if (source.HasBuff("RengarQEmp"))
			{
				return DamageRengarPassive.maxdamages[Math.Min(spell.Level - 1, 4)] + DamageRengarPassive.maxdamagePercents[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return DamageRengarPassive.damages[Math.Min(source.Level - 1, 17)] + 0.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x00047E26 File Offset: 0x00046026
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("RengerQ") || source.HasBuff("RengarQEmp");
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x00047E42 File Offset: 0x00046042
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x00047E45 File Offset: 0x00046045
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008B9 RID: 2233
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0,
			105.0,
			120.0,
			135.0,
			150.0,
			160.0,
			170.0,
			180.0,
			190.0,
			200.0,
			210.0,
			220.0,
			230.0,
			240.0
		};

		// Token: 0x040008BA RID: 2234
		private static readonly double[] maxdamages = new double[]
		{
			30.0,
			60.0,
			90.0,
			120.0,
			150.0
		};

		// Token: 0x040008BB RID: 2235
		private static readonly double[] maxdamagePercents = new double[]
		{
			0.0,
			0.05,
			0.1,
			0.15,
			0.2
		};
	}
}
