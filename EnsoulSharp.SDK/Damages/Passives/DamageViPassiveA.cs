using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003CB RID: 971
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Vi")]
	public class DamageViPassiveA : IPassiveDamage
	{
		// Token: 0x060012BD RID: 4797 RVA: 0x00048D60 File Offset: 0x00046F60
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return (DamageViPassiveA.damages[spell.Level - 1] + 1.1 * (double)source.TotalAttackDamage + 0.9 * (double)source.TotalMagicalDamage) * (double)source.GetCritMultiplier(false);
			}
			return 0.0;
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x00048DCB File Offset: 0x00046FCB
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ViE");
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x00048DD8 File Offset: 0x00046FD8
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x00048DDB File Offset: 0x00046FDB
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008D1 RID: 2257
		private static readonly double[] damages = new double[]
		{
			10.0,
			30.0,
			50.0,
			70.0,
			90.0
		};
	}
}
