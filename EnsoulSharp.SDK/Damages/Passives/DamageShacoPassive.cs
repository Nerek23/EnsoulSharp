using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003B7 RID: 951
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Shaco")]
	public class DamageShacoPassive : IPassiveDamage
	{
		// Token: 0x0600124A RID: 4682 RVA: 0x00048034 File Offset: 0x00046234
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageShacoPassive.damages[Math.Min(spell.Level - 1, 4)] + 0.4 * (double)source.GetBonusPhysicalDamage() + 0.3 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x0004809C File Offset: 0x0004629C
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("Deceive");
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x000480A9 File Offset: 0x000462A9
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x000480AC File Offset: 0x000462AC
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008BC RID: 2236
		private static readonly double[] damages = new double[]
		{
			10.0,
			20.0,
			30.0,
			40.0,
			50.0
		};
	}
}
