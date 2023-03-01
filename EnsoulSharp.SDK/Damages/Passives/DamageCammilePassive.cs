using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035C RID: 860
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Camille")]
	public class DamageCammilePassive : IPassiveDamage
	{
		// Token: 0x0600104E RID: 4174 RVA: 0x00044CC8 File Offset: 0x00042EC8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageCammilePassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x00044D14 File Offset: 0x00042F14
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("CamilleQ");
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x00044D21 File Offset: 0x00042F21
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00044D24 File Offset: 0x00042F24
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000879 RID: 2169
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
