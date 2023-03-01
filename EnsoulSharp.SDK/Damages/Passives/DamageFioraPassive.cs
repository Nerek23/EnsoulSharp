using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200036C RID: 876
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Fiora")]
	public class DamageFioraPassive : IPassiveDamage
	{
		// Token: 0x060010A7 RID: 4263 RVA: 0x00045644 File Offset: 0x00043844
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return (double)source.GetCritMultiplier(false) + DamageFioraPassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x00045699 File Offset: 0x00043899
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("fiorae2");
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x000456A6 File Offset: 0x000438A6
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x000456A9 File Offset: 0x000438A9
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000883 RID: 2179
		private static readonly double[] damages = new double[]
		{
			-0.4,
			-0.3,
			-0.2,
			-0.1,
			0.0
		};
	}
}
