using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000372 RID: 882
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ivern")]
	public class DamageIvernPassive : IPassiveDamage
	{
		// Token: 0x060010C7 RID: 4295 RVA: 0x00045970 File Offset: 0x00043B70
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				return DamageIvernPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000459C6 File Offset: 0x00043BC6
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ivernwpassive");
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x000459D3 File Offset: 0x00043BD3
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x000459D6 File Offset: 0x00043BD6
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000886 RID: 2182
		private static readonly double[] damages = new double[]
		{
			30.0,
			37.5,
			45.0,
			52.5,
			60.0
		};
	}
}
