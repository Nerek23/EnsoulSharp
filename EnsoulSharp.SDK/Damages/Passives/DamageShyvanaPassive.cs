using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B9 RID: 953
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Shyvana")]
	public class DamageShyvanaPassive : IPassiveDamage
	{
		// Token: 0x06001256 RID: 4694 RVA: 0x000482AC File Offset: 0x000464AC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell == null || spell.Level <= 0)
			{
				return 0.0;
			}
			if (source.HasBuff("ShyvanaDoubleAttackDragon"))
			{
				return DamageShyvanaPassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
			}
			return DamageShyvanaPassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage * 2.0 + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00048350 File Offset: 0x00046550
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ShyvanaDoubleAttack") || source.HasBuff("ShyvanaDoubleAttackDragon");
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x0004836C File Offset: 0x0004656C
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x0004836F File Offset: 0x0004656F
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008C0 RID: 2240
		private static readonly double[] damages = new double[]
		{
			0.2,
			0.35,
			0.5,
			0.65,
			0.8
		};
	}
}
