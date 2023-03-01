using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001B RID: 27
	public static class IncomingDamagePrediction
	{
		// Token: 0x06000128 RID: 296 RVA: 0x00007DC8 File Offset: 0x00005FC8
		static IncomingDamagePrediction()
		{
			if (IncomingDamagePrediction._initialize)
			{
				return;
			}
			IncomingDamagePrediction._initialize = true;
			GameObject.OnCreate += IncomingDamagePrediction.OnCreate;
			GameObject.OnDelete += IncomingDamagePrediction.OnDelete;
			AIBaseClient.OnDoCast += IncomingDamagePrediction.OnDoCast;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007E2C File Offset: 0x0000602C
		private static void OnCreate(GameObject sender, EventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			MissileClient missileClient = sender as MissileClient;
			if (missileClient == null || !missileClient.IsValid)
			{
				return;
			}
			AIBaseClient spellCaster = missileClient.SpellCaster;
			if (spellCaster == null || !spellCaster.IsValid || spellCaster.Type != GameObjectType.AIHeroClient)
			{
				return;
			}
			if (missileClient.Target != null)
			{
				if (missileClient.Target.IsValid && missileClient.Target.Type == GameObjectType.AIHeroClient)
				{
					IncomingDamagePrediction.MissileList.Add(missileClient);
					return;
				}
			}
			else
			{
				IncomingDamagePrediction.MissileList.Add(missileClient);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007EC8 File Offset: 0x000060C8
		private static void OnDelete(GameObject sender, EventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			MissileClient missile = sender as MissileClient;
			if (missile == null || !missile.IsValid)
			{
				return;
			}
			IncomingDamagePrediction.MissileList.RemoveAll((MissileClient x) => x.Compare(missile));
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00007F2C File Offset: 0x0000612C
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.AIHeroClient || args.SData == null)
			{
				return;
			}
			AIHeroClient fromHero = sender as AIHeroClient;
			if (args.Target != null && args.Target.IsValid)
			{
				AIHeroClient aiheroClient = args.Target as AIHeroClient;
				if (aiheroClient != null && aiheroClient.IsValid && !aiheroClient.IsDead && aiheroClient.Team != fromHero.Team)
				{
					if (Orbwalker.IsAutoAttack(args.SData.Name))
					{
						IncomingDamagePrediction.ActiveDamages.Add(new PredictedDamage
						{
							StartTick = Variables.GameTimeTickCount,
							AnimationTime = args.CastTime * 1000f,
							Delay = args.TotalTime * 1000f,
							ProjectileSpeed = (fromHero.IsMelee() ? int.MaxValue : ((int)args.SData.MissileSpeed)),
							Damage = (float)fromHero.GetAutoAttackDamage(aiheroClient, true, false),
							TargetBoundingRadius = aiheroClient.BoundingRadius,
							Source = fromHero,
							SourceNetworkId = fromHero.NetworkId,
							Target = aiheroClient,
							TargetNetworkId = aiheroClient.NetworkId
						});
						return;
					}
					if (args.SData.TargetingType == SpellDataTargetType.Target || args.SData.TargetingType == SpellDataTargetType.TargetOrLocation)
					{
						IncomingDamagePrediction.ActiveDamages.Add(new PredictedDamage
						{
							StartTick = Variables.GameTimeTickCount,
							AnimationTime = args.CastTime * 1000f,
							Delay = args.TotalTime * 1000f,
							ProjectileSpeed = (fromHero.IsMelee() ? int.MaxValue : ((int)args.SData.MissileSpeed)),
							Damage = (float)fromHero.GetSpellDamageFromName(aiheroClient, args.SData.Name, 0),
							TargetBoundingRadius = aiheroClient.BoundingRadius,
							Source = fromHero,
							SourceNetworkId = fromHero.NetworkId,
							Target = aiheroClient,
							TargetNetworkId = aiheroClient.NetworkId,
							IsSkillshot = true
						});
						return;
					}
				}
			}
			else
			{
				IEnumerable<AIHeroClient> heroes = GameObjects.Heroes;
				Func<AIHeroClient, bool> <>9__0;
				Func<AIHeroClient, bool> predicate;
				if ((predicate = <>9__0) == null)
				{
					predicate = (<>9__0 = ((AIHeroClient x) => x != null && x.IsValid && !x.IsDead && x.IsVisible && x.Team != fromHero.Team && x.Distance(fromHero) < 2000f));
				}
				foreach (AIHeroClient aiheroClient2 in heroes.Where(predicate))
				{
					if ((aiheroClient2.HasBuffOfType(BuffType.Slow) || aiheroClient2.IsWindingUp || !aiheroClient2.CanMove) && IncomingDamagePrediction.WillHit(aiheroClient2, args.Start, args.To, args.SData.LineWidth, args.SData.CastRadius))
					{
						IncomingDamagePrediction.ActiveDamages.Add(new PredictedDamage
						{
							StartTick = Variables.GameTimeTickCount,
							AnimationTime = args.CastTime * 1000f,
							Delay = args.TotalTime * 1000f,
							ProjectileSpeed = (fromHero.IsMelee() ? int.MaxValue : ((int)args.SData.MissileSpeed)),
							Damage = (float)fromHero.GetSpellDamageFromName(aiheroClient2, args.SData.Name, 0),
							TargetBoundingRadius = aiheroClient2.BoundingRadius,
							Source = fromHero,
							SourceNetworkId = fromHero.NetworkId,
							Target = aiheroClient2,
							TargetNetworkId = aiheroClient2.NetworkId,
							IsSkillshot = true
						});
					}
				}
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000830C File Offset: 0x0000650C
		public static bool WillHit(AIHeroClient target, Vector3 startPosition, Vector3 endPosition, float lineWidth = 0f, float castRadius = 0f)
		{
			Vector2 vector = target.ServerPosition.ToVector2();
			float boundingRadius = target.BoundingRadius;
			if (lineWidth > 0f)
			{
				double num = Math.Pow((double)(lineWidth + boundingRadius), 2.0);
				if ((double)vector.DistanceSquared(endPosition.ToVector2(), startPosition.ToVector2(), true) <= num)
				{
					return true;
				}
			}
			else if (castRadius > 0f)
			{
				double num2 = Math.Pow((double)(castRadius + boundingRadius), 2.0);
				if ((double)vector.DistanceSquared(endPosition.ToVector2()) <= num2)
				{
					return true;
				}
			}
			else
			{
				double num3 = Math.Pow((double)(50f + boundingRadius), 2.0);
				if ((double)vector.DistanceSquared(endPosition.ToVector2()) <= num3)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000098 RID: 152
		private static readonly bool _initialize;

		// Token: 0x04000099 RID: 153
		public static List<MissileClient> MissileList = new List<MissileClient>();

		// Token: 0x0400009A RID: 154
		public static List<PredictedDamage> ActiveDamages = new List<PredictedDamage>();
	}
}
