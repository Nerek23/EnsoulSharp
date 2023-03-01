using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000388 RID: 904
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Zoe")]
	public class DamageZoePassiveA : IPassiveDamage
	{
		// Token: 0x06001140 RID: 4416 RVA: 0x00046530 File Offset: 0x00044730
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageZoePassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.4 * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x00046586 File Offset: 0x00044786
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("zoeesleepstun");
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x00046593 File Offset: 0x00044793
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00046596 File Offset: 0x00044796
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000896 RID: 2198
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
