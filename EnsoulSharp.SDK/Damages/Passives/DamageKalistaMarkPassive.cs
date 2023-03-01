using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x020003D7 RID: 983
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "AllChampions")]
	public class DamageKalistaMarkPassive : IPassiveDamage
	{
		// Token: 0x060012FE RID: 4862 RVA: 0x00049344 File Offset: 0x00047544
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (target.HasBuff("kalistacoopstrikemarkbuff"))
			{
				AIHeroClient aiheroClient = target.GetBuff("kalistacoopstrikemarkbuff").Caster as AIHeroClient;
				if (aiheroClient != null && aiheroClient.Compare(source))
				{
					SpellDataInst spell = aiheroClient.Spellbook.GetSpell(SpellSlot.W);
					if (spell != null && spell.Level > 0)
					{
						double result = DamageKalistaMarkPassive.damage[Math.Min(spell.Level - 1, 4)] * (double)target.MaxHealth;
						if (target.Type == GameObjectType.AIMinionClient && target.Health < 125f)
						{
							return (double)target.MaxHealth;
						}
						return result;
					}
				}
			}
			return 0.0;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x000493E5 File Offset: 0x000475E5
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return target.HasBuff("kalistacoopstrikemarkbuff") && source.HasBuff("kalistacoopstrikeally");
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x00049401 File Offset: 0x00047601
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x00049404 File Offset: 0x00047604
		public DamageType GetDamageType()
		{
			return DamageType.Magical;
		}

		// Token: 0x040008D6 RID: 2262
		private static readonly double[] damage = new double[]
		{
			0.05,
			0.075,
			0.1,
			0.125,
			0.15
		};
	}
}
