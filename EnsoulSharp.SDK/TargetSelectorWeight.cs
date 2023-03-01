using System;
using System.Collections.Generic;
using System.Linq;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200004F RID: 79
	internal class TargetSelectorWeight
	{
		// Token: 0x0600033F RID: 831 RVA: 0x00018ABE File Offset: 0x00016CBE
		public TargetSelectorWeight(TargetSelectorMode mode, TargetSelectorWeightEffect effect)
		{
			this.Mode = mode;
			this.Effect = effect;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00018AD4 File Offset: 0x00016CD4
		public void ComputeWeight(IEnumerable<AIHeroClient> heroes, float WeightValue, ref Dictionary<AIHeroClient, float> weightedTotals)
		{
			Dictionary<AIHeroClient, float> dictionary = new Dictionary<AIHeroClient, float>();
			foreach (AIHeroClient aiheroClient in heroes)
			{
				dictionary[aiheroClient] = this.WeightDefinition(aiheroClient);
			}
			float num = dictionary.Values.Sum();
			foreach (KeyValuePair<AIHeroClient, float> keyValuePair in dictionary)
			{
				if (num != 0f)
				{
					float num2 = keyValuePair.Value / num * 100f;
					if (this.Effect == TargetSelectorWeightEffect.LowerIsBetter)
					{
						num2 = 100f - num2;
					}
					float num3 = WeightValue * num2;
					Dictionary<AIHeroClient, float> dictionary2 = weightedTotals;
					AIHeroClient key = keyValuePair.Key;
					dictionary2[key] += num3;
				}
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00018BC4 File Offset: 0x00016DC4
		private float WeightDefinition(AIHeroClient target)
		{
			switch (this.Mode)
			{
			case TargetSelectorMode.LeastAttacks:
				return (float)((int)Math.Ceiling((double)target.Health / GameObjects.Player.GetAutoAttackDamage(target, true, false)));
			case TargetSelectorMode.LeastSpells:
				return (float)((int)((double)target.Health / GameObjects.Player.CalculateMagicDamage(target, 100.0)));
			case TargetSelectorMode.Closest:
				return target.DistanceToPlayer();
			case TargetSelectorMode.NearMouse:
				return target.DistanceToCursor();
			case TargetSelectorMode.MostAD:
				return target.TotalAttackDamage;
			case TargetSelectorMode.MostAP:
				return target.TotalMagicalDamage;
			case TargetSelectorMode.LowestHealth:
				return target.Health;
			case TargetSelectorMode.MostPriority:
				return (float)TargetSelector.GetPriority(target);
			default:
				return 0f;
			}
		}

		// Token: 0x040001DD RID: 477
		public TargetSelectorWeightEffect Effect;

		// Token: 0x040001DE RID: 478
		public TargetSelectorMode Mode;
	}
}
