using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003AB RID: 939
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Nautilus")]
	public class DamageNautilusPassiveA : IPassiveDamage
	{
		// Token: 0x06001208 RID: 4616 RVA: 0x00047940 File Offset: 0x00045B40
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageNautilusPassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.2 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x00047996 File Offset: 0x00045B96
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("nautiluspiercinggazeshield");
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x000479A3 File Offset: 0x00045BA3
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x000479A6 File Offset: 0x00045BA6
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008B2 RID: 2226
		private static readonly double[] damages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};
	}
}
