using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003A3 RID: 931
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Leona")]
	public class DamageLeonaPassive : IPassiveDamage
	{
		// Token: 0x060011DC RID: 4572 RVA: 0x000475C0 File Offset: 0x000457C0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageLeonaPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x00047616 File Offset: 0x00045816
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("LeonaShieldOfDaybreak");
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x00047623 File Offset: 0x00045823
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x00047626 File Offset: 0x00045826
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008AE RID: 2222
		private static readonly double[] damages = new double[]
		{
			10.0,
			35.0,
			60.0,
			85.0,
			110.0
		};
	}
}
