using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003C5 RID: 965
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Udyr")]
	public class DamageUdyrPassive : IPassiveDamage
	{
		// Token: 0x06001299 RID: 4761 RVA: 0x00048994 File Offset: 0x00046B94
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageUdyrPassive.damages[Math.Min(spell.Level - 1, 5)] + 0.25 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x000489EA File Offset: 0x00046BEA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("UdyrQ") && source.GetBuffCount("UdyrQ") > 0;
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00048A09 File Offset: 0x00046C09
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00048A0C File Offset: 0x00046C0C
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008CA RID: 2250
		private static readonly double[] damages = new double[]
		{
			5.0,
			11.0,
			17.0,
			23.0,
			29.0,
			35.0
		};
	}
}
