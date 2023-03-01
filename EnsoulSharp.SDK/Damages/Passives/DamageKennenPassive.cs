using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A1 RID: 929
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kennen")]
	public class DamageKennenPassive : IPassiveDamage
	{
		// Token: 0x060011D0 RID: 4560 RVA: 0x00047460 File Offset: 0x00045660
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageKennenPassive.damages[Math.Min(spell.Level - 1, 4)] + DamageKennenPassive.damagePercents[Math.Min(spell.Level - 1, 4)] * (double)source.GetBonusPhysicalDamage() + 0.35 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x000474D3 File Offset: 0x000456D3
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("kennendoublestrikelive");
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x000474E0 File Offset: 0x000456E0
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x000474E3 File Offset: 0x000456E3
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008AB RID: 2219
		private static readonly double[] damages = new double[]
		{
			35.0,
			45.0,
			55.0,
			65.0,
			75.0
		};

		// Token: 0x040008AC RID: 2220
		private static readonly double[] damagePercents = new double[]
		{
			0.8,
			0.9,
			1.0,
			1.1,
			1.2
		};
	}
}
