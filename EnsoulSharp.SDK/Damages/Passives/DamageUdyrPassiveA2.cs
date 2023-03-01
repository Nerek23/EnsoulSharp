using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000364 RID: 868
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Udyr")]
	public class DamageUdyrPassiveA2 : IPassiveDamage
	{
		// Token: 0x0600107A RID: 4218 RVA: 0x00045270 File Offset: 0x00043470
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return (DamageUdyrPassiveA2.damages[Math.Min(spell.Level - 1, 5)] + 0.01 * (double)source.GetBonusPhysicalDamage() * 0.04) * (double)target.MaxHealth;
			}
			return 0.0;
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x000452D8 File Offset: 0x000434D8
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("UdyrQActivation");
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x000452E5 File Offset: 0x000434E5
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x000452E8 File Offset: 0x000434E8
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x0400087D RID: 2173
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.042,
			0.054,
			0.066,
			0.078,
			0.09
		};
	}
}
