using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace EnsoulSharp.SDK.Damages.Passives
{
	// Token: 0x0200035F RID: 863
	[Export(typeof(IPassiveDamage))]
	[ExportMetadata("ChampionName", "Caitlyn")]
	public class DamageCaitlynPassive : IPassiveDamage
	{
		// Token: 0x0600105E RID: 4190 RVA: 0x00044DBC File Offset: 0x00042FBC
		public double GetDamage(AIHeroClient source, AIBaseClient target)
		{
			if (source.HasBuff("caitlynpassivedriver"))
			{
				float num = 1f;
				float num2 = source.Crit;
				if (target.Type == GameObjectType.AIHeroClient)
				{
					if (source.Level >= 13)
					{
						num = 1.2f;
					}
					else if (source.Level >= 7)
					{
						num = 0.9f;
					}
					else
					{
						num = 0.6f;
					}
				}
				else if (target.Type == GameObjectType.AITurretClient)
				{
					num2 = Math.Min(num2, 0.4f);
				}
				return (double)((num + num2 * 1.2f * 1.25f) * source.TotalAttackDamage);
			}
			HashSet<EffectEmitter> source2;
			if (GameObjects.CaitlynHeadshotBeams.TryGetValue(target.NetworkId, out source2))
			{
				if (source2.Any((EffectEmitter effectEmitter) => effectEmitter.IsValid && !effectEmitter.IsDead))
				{
					float num3 = 1f;
					double num4 = 0.0;
					float num5 = source.Crit;
					if (target.Type == GameObjectType.AIHeroClient)
					{
						if (source.Level >= 13)
						{
							num3 = 1.1f;
						}
						else if (source.Level >= 7)
						{
							num3 = 0.85f;
						}
						else
						{
							num3 = 0.6f;
						}
						if (DamageCaitlynPassive.IsWBuffActive(source, target))
						{
							int level = source.Spellbook.GetSpell(SpellSlot.W).Level;
							if (level > 0)
							{
								num4 += DamageCaitlynPassive.damages[Math.Min(level - 1, 4)] + DamageCaitlynPassive.damagePercents[Math.Min(level - 1, 4)] * (double)source.GetBonusPhysicalDamage();
							}
						}
					}
					else if (target.Type == GameObjectType.AITurretClient)
					{
						num5 = Math.Min(num5, 0.4f);
					}
					return (double)((num3 + num5 * 1.25f) * source.TotalAttackDamage) + num4;
				}
			}
			return 0.0;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x00044F58 File Offset: 0x00043158
		private static bool IsWBuffActive(AIHeroClient source, AIBaseClient target)
		{
			BuffInstance buff = target.GetBuff("CaitlynWSnare");
			return buff != null && buff.IsValid && buff.IsActive && buff.Caster != null && buff.Caster.Compare(source);
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x00044FA3 File Offset: 0x000431A3
		public bool IsActive(AIHeroClient source, AIBaseClient target)
		{
			return source.HasBuff("caitlynpassivedriver") || target.HasBuff("CaitlynWSnare") || target.HasBuff("CaitlynEMissile");
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x00044FCC File Offset: 0x000431CC
		public bool OverwriteAttackDamage()
		{
			return false;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x00044FCF File Offset: 0x000431CF
		public DamageType GetDamageType()
		{
			return DamageType.Physical;
		}

		// Token: 0x0400087A RID: 2170
		private static readonly double[] damages = new double[]
		{
			40.0,
			85.0,
			130.0,
			175.0,
			220.0
		};

		// Token: 0x0400087B RID: 2171
		private static readonly double[] damagePercents = new double[]
		{
			0.4000000059604645,
			0.5,
			0.6000000238418579,
			0.699999988079071,
			0.800000011920929
		};
	}
}
