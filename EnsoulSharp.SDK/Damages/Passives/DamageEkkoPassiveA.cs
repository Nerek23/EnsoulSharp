using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200038F RID: 911
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Ekko")]
	public class DamageEkkoPassiveA : IPassiveDamage
	{
		// Token: 0x06001169 RID: 4457 RVA: 0x000468F8 File Offset: 0x00044AF8
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			SpellDataInst spell = source.Spellbook.GetSpell(SpellSlot.W);
			if (spell != null && spell.Level > 0)
			{
				double result = 0.0;
				GameObjectType type = target.Type;
				if (type != GameObjectType.AIHeroClient)
				{
					if (type == GameObjectType.AIMinionClient)
					{
						result = Math.Min(Math.Max(0.03 + 0.03 * (double)(source.TotalMagicalDamage / 100f), 15.0), 150.0);
					}
				}
				else
				{
					result = Math.Max(0.03 + 0.03 * (double)(source.TotalMagicalDamage / 100f), 15.0);
				}
				return result;
			}
			return 0.0;
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x000469BA File Offset: 0x00044BBA
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HealthPercent < 30f;
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x000469C9 File Offset: 0x00044BC9
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x000469CC File Offset: 0x00044BCC
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}
	}
}
