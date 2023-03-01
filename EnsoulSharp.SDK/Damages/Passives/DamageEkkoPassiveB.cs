using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000369 RID: 873
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ekko")]
	public class DamageEkkoPassiveB : IPassiveDamage
	{
		// Token: 0x06001096 RID: 4246 RVA: 0x000454C0 File Offset: 0x000436C0
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.E);
			if (spell != null && spell.Level > 0)
			{
				return DamageEkkoPassiveB.damages[Math.Min(spell.Level - 1, 4)] + 0.4 * (double)source.TotalMagicalDamage;
			}
			return 0.0;
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x00045516 File Offset: 0x00043716
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("ekkoeattackbuff");
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x00045523 File Offset: 0x00043723
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00045526 File Offset: 0x00043726
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x04000881 RID: 2177
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
