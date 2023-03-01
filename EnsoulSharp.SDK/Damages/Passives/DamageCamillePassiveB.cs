using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035A RID: 858
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Camille")]
	public class DamageCamillePassiveB : IPassiveDamage
	{
		// Token: 0x06001042 RID: 4162 RVA: 0x00044B40 File Offset: 0x00042D40
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return Math.Min(1.0, 0.36 + 0.04 * (double)source.Level - 1.0) * 2.0 * DamageCamillePassiveB.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x00044BCA File Offset: 0x00042DCA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("CamilleQ2");
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00044BD7 File Offset: 0x00042DD7
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x00044BDA File Offset: 0x00042DDA
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x04000877 RID: 2167
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
