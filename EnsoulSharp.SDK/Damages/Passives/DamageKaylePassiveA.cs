using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000377 RID: 887
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kayle")]
	public class DamageKaylePassiveA : IPassiveDamage
	{
		// Token: 0x060010E3 RID: 4323 RVA: 0x00045C5C File Offset: 0x00043E5C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageKaylePassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.1 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x00045CC4 File Offset: 0x00043EC4
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.Level >= 16;
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00045CD3 File Offset: 0x00043ED3
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x00045CD6 File Offset: 0x00043ED6
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400088C RID: 2188
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
