using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B2 RID: 946
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Renekton")]
	public class DamageRenektonPassive : IPassiveDamage
	{
		// Token: 0x0600122F RID: 4655 RVA: 0x00047CB8 File Offset: 0x00045EB8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				double result = DamageRenektonPassive.damages[Math.Min(spell.Level - 1, 4)] + 1.25 * (double)source.TotalAttackDamage;
				if (source.Mana >= 50f)
				{
					result = DamageRenektonPassive.maxdamages[Math.Min(spell.Level - 1, 4)] + 0.5 * (double)source.TotalAttackDamage;
				}
				return result;
			}
			return 0.0;
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x00047D44 File Offset: 0x00045F44
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("RenektonPreExecute");
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00047D51 File Offset: 0x00045F51
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x00047D54 File Offset: 0x00045F54
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008B7 RID: 2231
		private static readonly double[] damages = new double[]
		{
			15.0,
			45.0,
			75.0,
			105.0,
			135.0
		};

		// Token: 0x040008B8 RID: 2232
		private static readonly double[] maxdamages = new double[]
		{
			10.0,
			30.0,
			50.0,
			70.0,
			90.0
		};
	}
}
