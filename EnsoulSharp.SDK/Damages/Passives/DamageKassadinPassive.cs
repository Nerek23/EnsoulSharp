using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200039F RID: 927
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Kassadin")]
	public class DamageKassadinPassive : IPassiveDamage
	{
		// Token: 0x060011C4 RID: 4548 RVA: 0x0004729C File Offset: 0x0004549C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return 20.0 + 0.1 * (double)source.TotalMagicalDamage + (source.HasBuff("NetherBlade") ? (DamageKassadinPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.8 * (double)source.TotalMagicalDamage) : 0.0);
			}
			return 0.0;
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x00047326 File Offset: 0x00045526
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.GetSpell(SpellSlot.W).Level > 0;
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x00047337 File Offset: 0x00045537
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0004733A File Offset: 0x0004553A
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008A9 RID: 2217
		private static readonly double[] damages = new double[]
		{
			70.0,
			95.0,
			120.0,
			145.0,
			170.0
		};
	}
}
