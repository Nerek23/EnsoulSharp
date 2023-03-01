using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C0 RID: 960
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Teemo")]
	public class DamageTeemoPassive : IPassiveDamage
	{
		// Token: 0x0600127C RID: 4732 RVA: 0x00048594 File Offset: 0x00046794
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageTeemoPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x000485EA File Offset: 0x000467EA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return true;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x000485ED File Offset: 0x000467ED
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x000485F0 File Offset: 0x000467F0
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008C3 RID: 2243
		private static readonly double[] damages = new double[]
		{
			14.0,
			25.0,
			36.0,
			47.0,
			58.0
		};
	}
}
