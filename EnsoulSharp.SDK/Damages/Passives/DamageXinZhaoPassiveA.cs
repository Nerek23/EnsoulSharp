using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x02000385 RID: 901
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "XinZhao")]
	public class DamageXinZhaoPassiveA : IPassiveDamage
	{
		// Token: 0x0600112F RID: 4399 RVA: 0x00046348 File Offset: 0x00044548
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.Q);
			if (spell != null && spell.Level > 0)
			{
				return DamageXinZhaoPassiveA.damages[Math.Min(spell.Level - 1, 4)] + 0.4 * (double)source.GetBonusPhysicalDamage();
			}
			return 0.0;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0004639E File Offset: 0x0004459E
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("XinZhaoQ");
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x000463AB File Offset: 0x000445AB
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x000463AE File Offset: 0x000445AE
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x04000894 RID: 2196
		private static readonly double[] damages = new double[]
		{
			16.0,
			25.0,
			34.0,
			43.0,
			52.0
		};
	}
}
