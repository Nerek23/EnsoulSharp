using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200037C RID: 892
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "MasterYi")]
	public class DamageMasterYiPassiveA : IPassiveDamage
	{
		// Token: 0x060010FF RID: 4351 RVA: 0x00045EEC File Offset: 0x000440EC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageMasterYiPassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x00045F42 File Offset: 0x00044142
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("wujustylesuperchargedvisual");
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x00045F4F File Offset: 0x0004414F
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x00045F52 File Offset: 0x00044152
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x04000890 RID: 2192
		private static readonly double[] damages = new double[]
		{
			30.0,
			35.0,
			40.0,
			45.0,
			50.0
		};
	}
}
