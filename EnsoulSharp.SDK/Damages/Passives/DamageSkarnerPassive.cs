using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003BB RID: 955
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Skarner")]
	public class DamageSkarnerPassive : IPassiveDamage
	{
		// Token: 0x06001261 RID: 4705 RVA: 0x0004840C File Offset: 0x0004660C
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageSkarnerPassive.damages[Math.Min(spell.Level - 1, 4)];
			}
			return 0.0;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00048450 File Offset: 0x00046650
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("skarnerpassivebuff");
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0004845D File Offset: 0x0004665D
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00048460 File Offset: 0x00046660
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x040008C1 RID: 2241
		private static readonly double[] damages = new double[]
		{
			30.0,
			50.0,
			70.0,
			90.0,
			110.0
		};
	}
}
