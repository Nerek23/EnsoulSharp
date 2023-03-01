using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C7 RID: 967
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Vayne")]
	public class DamageVaynePassive : IPassiveDamage
	{
		// Token: 0x060012A5 RID: 4773 RVA: 0x00048AB0 File Offset: 0x00046CB0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageVaynePassive.damages[Math.Min(spell.Level - 1, 4)] * (double)source.TotalAttackDamage;
			}
			return 0.0;
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x00048AFC File Offset: 0x00046CFC
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("vaynetumblebonus");
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x00048B09 File Offset: 0x00046D09
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x00048B0C File Offset: 0x00046D0C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008CC RID: 2252
		private static readonly double[] damages = new double[]
		{
			0.6,
			0.65,
			0.7,
			0.75,
			0.8
		};
	}
}
