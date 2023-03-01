using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000391 RID: 913
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Fizz")]
	public class DamageFizzPassiveA : IPassiveDamage
	{
		// Token: 0x06001174 RID: 4468 RVA: 0x00046A64 File Offset: 0x00044C64
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("fizzonhitbuff"))
			{
				BuffInstance buff = target.GetBuff("fizzonhitbuff");
				if (buff.Caster != null && buff.Caster.Compare(source))
				{
					SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
					if (spell != null && spell.Level > 0)
					{
						return DamageFizzPassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.35 * (double)source.TotalMagicalDamage;
					}
				}
			}
			return 0.0;
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x00046AEF File Offset: 0x00044CEF
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("fizzonhitbuff");
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x00046AFC File Offset: 0x00044CFC
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x00046AFF File Offset: 0x00044CFF
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400089E RID: 2206
		private static readonly double[] damages = new double[]
		{
			10.0,
			15.0,
			20.0,
			25.0,
			30.0
		};
	}
}
