using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035B RID: 859
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Camille")]
	public class DamageCamillePassiveA : IPassiveDamage
	{
		// Token: 0x06001048 RID: 4168 RVA: 0x00044C00 File Offset: 0x00042E00
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return (1.0 - Math.Min(1.0, 0.36 + 0.04 * (double)source.Level - 1.0)) * 2.0 * DamageCamillePassiveA.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x00044C94 File Offset: 0x00042E94
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("CamilleQ2");
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x00044CA1 File Offset: 0x00042EA1
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x00044CA4 File Offset: 0x00042EA4
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000878 RID: 2168
		private static readonly double[] damages = new double[]
		{
			0.2,
			0.25,
			0.3,
			0.35,
			0.4
		};
	}
}
