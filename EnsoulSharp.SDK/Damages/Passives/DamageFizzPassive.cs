using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000390 RID: 912
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Fizz")]
	public class DamageFizzPassive : IPassiveDamage
	{
		// Token: 0x0600116E RID: 4462 RVA: 0x000469D8 File Offset: 0x00044BD8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageFizzPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x00046A2E File Offset: 0x00044C2E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("FizzW");
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x00046A3B File Offset: 0x00044C3B
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x00046A3E File Offset: 0x00044C3E
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400089D RID: 2205
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
