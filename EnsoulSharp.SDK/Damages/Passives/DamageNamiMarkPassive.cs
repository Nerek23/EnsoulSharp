using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D9 RID: 985
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageNamiMarkPassive : IPassiveDamage
	{
		// Token: 0x06001309 RID: 4873 RVA: 0x00049470 File Offset: 0x00047670
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("NamiE"))
			{
				AIHeroClient aiheroClient = target.GetBuff("NamiE").Caster as AIHeroClient;
				if (aiheroClient != null && aiheroClient.Compare(source))
				{
					SpellDataInst spell = aiheroClient.Spellbook.GetSpell(SpellSlot.E);
					if (spell != null && spell.Level > 0)
					{
						double amount = DamageNamiMarkPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.2 * (double)aiheroClient.TotalMagicalDamage;
						return aiheroClient.CalculateMagicDamage(target, amount);
					}
				}
			}
			return 0.0;
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x00049504 File Offset: 0x00047704
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("NamiE");
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x00049511 File Offset: 0x00047711
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x00049514 File Offset: 0x00047714
		public DamageType GetDamageType()
		{
			return DamageType.True;
		}

		// Token: 0x040008D7 RID: 2263
		private static readonly double[] damages = new double[]
		{
			25.0,
			40.0,
			55.0,
			70.0,
			85.0
		};
	}
}
