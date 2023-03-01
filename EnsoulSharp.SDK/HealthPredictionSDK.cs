using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000048 RID: 72
	internal class HealthPredictionSDK : IHealthPrediction, IDisposable
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00015D7C File Offset: 0x00013F7C
		public HealthPredictionSDK()
		{
			if (HealthPredictionSDK._initialize)
			{
				return;
			}
			HealthPredictionSDK._initialize = true;
			Game.OnUpdate += HealthPredictionSDK.OnUpdate;
			AIBaseClient.OnDoCast += HealthPredictionSDK.OnDoCast;
			Spellbook.OnStopCast += HealthPredictionSDK.OnStopCast;
			GameObject.OnDelete += HealthPredictionSDK.OnDelete;
			AIBaseClient.OnProcessSpellCast += HealthPredictionSDK.OnProcessSpellCast;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00015DF4 File Offset: 0x00013FF4
		public AIBaseClient GetAggroTurret(AIMinionClient minion)
		{
			if (minion == null || !minion.IsValid)
			{
				return null;
			}
			PredictedDamage predictedDamage = HealthPredictionSDK.ActiveAttacks.Values.FirstOrDefault((PredictedDamage m) => m.Source != null && m.Source.IsValid && m.Source.Type == GameObjectType.AITurretClient && m.Target.Compare(minion));
			if (predictedDamage == null)
			{
				return null;
			}
			return predictedDamage.Source;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00015E51 File Offset: 0x00014051
		public float GetPrediction(AIBaseClient unit, int time, int delay = 70, HealthPredictionType type = HealthPredictionType.Default)
		{
			if (type != HealthPredictionType.Simulated)
			{
				return HealthPredictionSDK.GetPredictionDefault(unit, time, delay);
			}
			return HealthPredictionSDK.GetPredictionSimulated(unit, time);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x00015E68 File Offset: 0x00014068
		public bool HasMinionAggro(AIMinionClient minion)
		{
			return minion != null && minion.IsValid && HealthPredictionSDK.ActiveAttacks.Values.Any((PredictedDamage m) => m.Source != null && m.Source.IsValid && m.Source.Type == GameObjectType.AIMinionClient && m.Target.Compare(minion));
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00015EBC File Offset: 0x000140BC
		public bool HasTurretAggro(AIMinionClient minion)
		{
			return minion != null && minion.IsValid && HealthPredictionSDK.ActiveAttacks.Values.Any((PredictedDamage m) => m.Source != null && m.Source.IsValid && m.Source.Type == GameObjectType.AITurretClient && m.Target.Compare(minion));
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00015F10 File Offset: 0x00014110
		public int TurretAggroStartTick(AIMinionClient minion)
		{
			if (minion == null || !minion.IsValid)
			{
				return 0;
			}
			PredictedDamage predictedDamage = HealthPredictionSDK.ActiveAttacks.Values.FirstOrDefault((PredictedDamage m) => m.Source != null && m.Source.IsValid && m.Source.Type == GameObjectType.AITurretClient && m.Target.Compare(minion));
			if (predictedDamage == null)
			{
				return 0;
			}
			return predictedDamage.StartTick;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00015F70 File Offset: 0x00014170
		private static float GetPredictionDefault(AIBaseClient unit, int time, int delay = 70)
		{
			float num = 0f;
			IEnumerable<PredictedDamage> values = HealthPredictionSDK.ActiveAttacks.Values;
			Func<PredictedDamage, bool> <>9__0;
			Func<PredictedDamage, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((PredictedDamage i) => i.Target.Compare(unit) && !i.Processed && i.Source != null && i.Source.IsValid && !i.Source.IsDead));
			}
			foreach (PredictedDamage predictedDamage in values.Where(predicate))
			{
				float num2 = 0f;
				if ((float)predictedDamage.StartTick + predictedDamage.Delay + 1000f * (predictedDamage.Source.IsMelee ? 0f : (Math.Max(0f, unit.Distance(predictedDamage.Source) - predictedDamage.TargetBoundingRadius) / (float)predictedDamage.ProjectileSpeed)) + (float)delay < (float)(Variables.GameTimeTickCount + time))
				{
					num2 = predictedDamage.Damage;
				}
				num += num2;
			}
			return unit.Health - num;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00016080 File Offset: 0x00014280
		private static float GetPredictionSimulated(AIBaseClient unit, int time)
		{
			float num = 0f;
			IEnumerable<PredictedDamage> values = HealthPredictionSDK.ActiveAttacks.Values;
			Func<PredictedDamage, bool> <>9__0;
			Func<PredictedDamage, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((PredictedDamage i) => i.Target.Compare(unit) && i.Source != null && i.Source.IsValid && !i.Source.IsDead));
			}
			foreach (PredictedDamage predictedDamage in values.Where(predicate))
			{
				int num2 = 0;
				if ((float)(Variables.GameTimeTickCount - 100) <= (float)predictedDamage.StartTick + predictedDamage.AnimationTime)
				{
					int num3 = predictedDamage.StartTick;
					int num4 = Variables.GameTimeTickCount + time;
					do
					{
						float num5 = predictedDamage.Delay / 1000f + (predictedDamage.Source.IsMelee ? 0f : (Math.Max(0f, unit.Distance(predictedDamage.Source) - predictedDamage.TargetBoundingRadius) / (float)predictedDamage.ProjectileSpeed));
						if (num3 >= Variables.GameTimeTickCount && (float)num3 + num5 < (float)num4)
						{
							num2++;
						}
						num3 += (int)predictedDamage.AnimationTime;
					}
					while (num3 < num4);
				}
				num += (float)num2 * predictedDamage.Damage;
			}
			return unit.Health - num;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000161D8 File Offset: 0x000143D8
		private static void OnDelete(GameObject sender, EventArgs args)
		{
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.MissileClient)
			{
				return;
			}
			MissileClient missileClient = sender as MissileClient;
			if (missileClient != null && missileClient.SpellCaster != null && missileClient.SpellCaster.IsValid)
			{
				int networkId = missileClient.SpellCaster.NetworkId;
				if (HealthPredictionSDK.ActiveAttacks.ContainsKey(networkId))
				{
					HealthPredictionSDK.ActiveAttacks[networkId].Processed = true;
				}
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00016258 File Offset: 0x00014458
		private static void OnUpdate(EventArgs args)
		{
			(from pair in HealthPredictionSDK.ActiveAttacks.ToList<KeyValuePair<int, PredictedDamage>>()
			where pair.Value.StartTick < Variables.GameTimeTickCount - 3000
			select pair).ToList<KeyValuePair<int, PredictedDamage>>().ForEach(delegate(KeyValuePair<int, PredictedDamage> pair)
			{
				HealthPredictionSDK.ActiveAttacks.Remove(pair.Key);
			});
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000162BC File Offset: 0x000144BC
		private static void OnProcessSpellCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender == null || !sender.IsValid || !sender.IsAlly || !sender.IsMelee)
			{
				return;
			}
			if (!HealthPredictionSDK.ActiveAttacks.ContainsKey(sender.NetworkId))
			{
				return;
			}
			HealthPredictionSDK.ActiveAttacks[sender.NetworkId].Processed = true;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00016314 File Offset: 0x00014514
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender == null || !sender.IsValid || !sender.IsAlly)
			{
				return;
			}
			if (sender.Type != GameObjectType.AIMinionClient && sender.Type != GameObjectType.AITurretClient)
			{
				return;
			}
			if (!sender.IsValidTarget(3000f, false, default(Vector3)))
			{
				return;
			}
			if (!Orbwalker.IsAutoAttack(args.SData.Name))
			{
				return;
			}
			if (args.Target == null || !args.Target.IsValid)
			{
				return;
			}
			AIMinionClient aiminionClient = args.Target as AIMinionClient;
			if (aiminionClient == null || !aiminionClient.IsValid || aiminionClient.IsDead)
			{
				return;
			}
			PredictedDamage predictedDamage = new PredictedDamage
			{
				StartTick = Variables.GameTimeTickCount - Game.Ping / 2,
				ProjectileSpeed = (sender.IsMelee() ? int.MaxValue : ((int)args.SData.MissileSpeed)),
				AnimationTime = sender.AttackDelay * 1000f - (float)((sender.Type == GameObjectType.AITurretClient) ? 70 : 0),
				TargetBoundingRadius = sender.BoundingRadius,
				Damage = (float)sender.GetAutoAttackDamage(aiminionClient, true, false),
				Delay = sender.AttackCastDelay * 1000f,
				Processed = false,
				Source = sender,
				SourceNetworkId = sender.NetworkId,
				Target = aiminionClient,
				TargetNetworkId = aiminionClient.NetworkId
			};
			if (HealthPredictionSDK.ActiveAttacks.ContainsKey(predictedDamage.SourceNetworkId))
			{
				HealthPredictionSDK.ActiveAttacks.Remove(predictedDamage.SourceNetworkId);
			}
			HealthPredictionSDK.ActiveAttacks.Add(predictedDamage.SourceNetworkId, predictedDamage);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000164A8 File Offset: 0x000146A8
		private static void OnStopCast(Spellbook sender, SpellbookStopCastEventArgs args)
		{
			if (sender == null)
			{
				return;
			}
			if (sender.Owner == null || !sender.Owner.IsValid || !sender.Owner.IsAlly)
			{
				return;
			}
			if (!args.KeepAnimationPlaying || !args.DestroyMissile)
			{
				return;
			}
			if (sender.Owner.IsMelee)
			{
				HealthPredictionSDK.ActiveAttacks.Remove(sender.Owner.NetworkId);
			}
			if (HealthPredictionSDK.ActiveAttacks.ContainsKey(sender.Owner.NetworkId))
			{
				HealthPredictionSDK.ActiveAttacks.Remove(sender.Owner.NetworkId);
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00016544 File Offset: 0x00014744
		public void Dispose()
		{
			if (!HealthPredictionSDK._initialize)
			{
				return;
			}
			HealthPredictionSDK._initialize = false;
			Logging.Write(false, true, "Dispose")(LogLevel.Info, "SDK HealthPrediction Dispose", Array.Empty<object>());
			Game.OnUpdate -= HealthPredictionSDK.OnUpdate;
			AIBaseClient.OnDoCast -= HealthPredictionSDK.OnDoCast;
			Spellbook.OnStopCast -= HealthPredictionSDK.OnStopCast;
			GameObject.OnDelete -= HealthPredictionSDK.OnDelete;
			AIBaseClient.OnProcessSpellCast -= HealthPredictionSDK.OnProcessSpellCast;
		}

		// Token: 0x040001B2 RID: 434
		private static bool _initialize;

		// Token: 0x040001B3 RID: 435
		private static readonly Dictionary<int, PredictedDamage> ActiveAttacks = new Dictionary<int, PredictedDamage>();
	}
}
