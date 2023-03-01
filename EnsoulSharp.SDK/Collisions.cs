using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000024 RID: 36
	public static class Collisions
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000A36C File Offset: 0x0000856C
		internal static void Attach()
		{
			if (GameObjects.EnemyHeroes.Any((AIHeroClient x) => x.CharacterName == "Yasuo"))
			{
				Collisions.YasuoInGame = true;
			}
			if (GameObjects.EnemyHeroes.Any((AIHeroClient x) => x.CharacterName == "Samira"))
			{
				Collisions.SamiraInGame = true;
			}
			if (!Collisions.YasuoInGame)
			{
				return;
			}
			GameObject.OnCreate += Collisions.OnCreate;
			GameObject.OnDelete += Collisions.OnDelete;
			AIBaseClient.OnDoCast += Collisions.OnDoCast;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000A418 File Offset: 0x00008618
		public static List<AIBaseClient> GetCollision(List<Vector3> positions, PredictionInput input)
		{
			HashSet<AIBaseClient> hashSet = new HashSet<AIBaseClient>();
			Func<AIHeroClient, bool> <>9__0;
			Func<AIMinionClient, bool> <>9__1;
			Func<AIMinionClient, bool> <>9__2;
			Func<AITurretClient, bool> <>9__3;
			Func<BarracksDampenerClient, bool> <>9__4;
			foreach (Vector3 vector in positions)
			{
				if (vector.IsValid())
				{
					if (input.CollisionObjects.Contains(CollisionObjects.Heroes))
					{
						IEnumerable<AIHeroClient> enemyHeroes = GameObjects.EnemyHeroes;
						Func<AIHeroClient, bool> predicate;
						if ((predicate = <>9__0) == null)
						{
							predicate = (<>9__0 = ((AIHeroClient hero) => hero != null && hero.IsValid && hero.IsValidTarget(Math.Min(input.Range + input.Radius + 100f, 2000f), true, input.RangeCheckFrom) && !hero.Compare(input.Unit)));
						}
						foreach (AIHeroClient aiheroClient in enemyHeroes.Where(predicate).ToList<AIHeroClient>())
						{
							if (aiheroClient != null && aiheroClient.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
							{
								input.Unit = aiheroClient;
								Vector2 segmentEnd = Prediction.GetPrediction(input, false, false).UnitPosition.ToVector2();
								float num = input.Radius + aiheroClient.BoundingRadius + 50f;
								ProjectionInfo projectionInfo = vector.ToVector2().ProjectOn(input.From.ToVector2(), segmentEnd);
								if (projectionInfo.IsOnSegment && (projectionInfo.SegmentPoint.Distance(vector.ToVector2()) <= num || projectionInfo.LinePoint.Distance(vector.ToVector2()) <= num))
								{
									hashSet.Add(aiheroClient);
								}
							}
						}
					}
					if (input.CollisionObjects.Contains(CollisionObjects.Minions))
					{
						IEnumerable<AIMinionClient> enemyMinions = GameObjects.EnemyMinions;
						Func<AIMinionClient, bool> predicate2;
						if ((predicate2 = <>9__1) == null)
						{
							predicate2 = (<>9__1 = ((AIMinionClient x) => x != null && x.IsValid && x.IsValidTarget(Math.Min(input.Range + input.Radius + 100f, 2000f), true, input.RangeCheckFrom) && !x.Compare(input.Unit)));
						}
						foreach (AIMinionClient aiminionClient in enemyMinions.Where(predicate2).ToList<AIMinionClient>())
						{
							if (aiminionClient != null && aiminionClient.IsValid && aiminionClient.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
							{
								float num2 = aiminionClient.ServerPosition.Distance(input.From);
								float num3 = aiminionClient.BoundingRadius + input.Unit.BoundingRadius;
								if (!Collisions.WillDead(input, aiminionClient, num2))
								{
									if (num2 < num3 || aiminionClient.ServerPosition.Distance(vector) < num3 || aiminionClient.ServerPosition.Distance(input.Unit.ServerPosition) < num3)
									{
										hashSet.Add(aiminionClient);
									}
									else
									{
										Vector3 vector2 = aiminionClient.ServerPosition;
										int num4 = 15;
										if (aiminionClient.IsMoving)
										{
											vector2 = Prediction.GetPrediction(new PredictionInput
											{
												Collision = false,
												Speed = input.Speed,
												Delay = input.Delay,
												Range = input.Range,
												From = input.From,
												Radius = input.Radius,
												Unit = aiminionClient,
												Type = input.Type
											}).CastPosition;
											num4 = 50 + (int)input.Radius;
										}
										if ((double)vector2.ToVector2().DistanceSquared(input.From.ToVector2(), vector.ToVector2(), true) <= Math.Pow((double)(input.Radius + (float)num4 + aiminionClient.BoundingRadius), 2.0))
										{
											hashSet.Add(aiminionClient);
										}
									}
								}
							}
						}
						IEnumerable<AIMinionClient> jungle = GameObjects.Jungle;
						Func<AIMinionClient, bool> predicate3;
						if ((predicate3 = <>9__2) == null)
						{
							predicate3 = (<>9__2 = ((AIMinionClient x) => x != null && x.IsValid && x.IsValidTarget(Math.Min(input.Range + input.Radius + 100f, 2000f), true, input.RangeCheckFrom) && !x.Compare(input.Unit)));
						}
						foreach (AIMinionClient aiminionClient2 in jungle.Where(predicate3).ToList<AIMinionClient>())
						{
							if (aiminionClient2 != null && aiminionClient2.IsValid && aiminionClient2.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
							{
								float num5 = aiminionClient2.ServerPosition.Distance(input.From);
								float num6 = aiminionClient2.BoundingRadius + input.Unit.BoundingRadius;
								if (!Collisions.WillDead(input, aiminionClient2, num5))
								{
									if (num5 < num6 || aiminionClient2.ServerPosition.Distance(vector) < num6 || aiminionClient2.ServerPosition.Distance(input.Unit.ServerPosition) < num6)
									{
										hashSet.Add(aiminionClient2);
									}
									else
									{
										Vector3 vector3 = aiminionClient2.ServerPosition;
										int num7 = 20;
										if (aiminionClient2.IsMoving)
										{
											vector3 = Prediction.GetPrediction(new PredictionInput
											{
												Collision = false,
												Speed = input.Speed,
												Delay = input.Delay,
												Range = input.Range,
												From = input.From,
												Radius = input.Radius,
												Unit = aiminionClient2,
												Type = input.Type
											}).CastPosition;
											num7 = 50 + (int)input.Radius;
										}
										if ((double)vector3.ToVector2().DistanceSquared(input.From.ToVector2(), vector.ToVector2(), true) <= Math.Pow((double)(input.Radius + (float)num7 + aiminionClient2.BoundingRadius), 2.0))
										{
											hashSet.Add(aiminionClient2);
										}
									}
								}
							}
						}
					}
					if (input.CollisionObjects.Contains(CollisionObjects.Building))
					{
						IEnumerable<AITurretClient> enemyTurrets = GameObjects.EnemyTurrets;
						Func<AITurretClient, bool> predicate4;
						if ((predicate4 = <>9__3) == null)
						{
							predicate4 = (<>9__3 = ((AITurretClient x) => x.IsValidTarget(Math.Min(input.Range + input.Radius + 100f, 2000f), true, input.RangeCheckFrom) && !x.Compare(input.Unit)));
						}
						foreach (AITurretClient aiturretClient in enemyTurrets.Where(predicate4).ToList<AITurretClient>())
						{
							float num8 = input.Radius + aiturretClient.BoundingRadius + 50f;
							ProjectionInfo projectionInfo2 = vector.ToVector2().ProjectOn(input.From.ToVector2(), aiturretClient.Position.ToVector2());
							if (projectionInfo2.IsOnSegment && (projectionInfo2.SegmentPoint.Distance(vector.ToVector2()) <= num8 || projectionInfo2.LinePoint.Distance(vector.ToVector2()) <= num8))
							{
								hashSet.Add(aiturretClient);
							}
						}
						IEnumerable<BarracksDampenerClient> enemyInhibitors = GameObjects.EnemyInhibitors;
						Func<BarracksDampenerClient, bool> predicate5;
						if ((predicate5 = <>9__4) == null)
						{
							predicate5 = (<>9__4 = ((BarracksDampenerClient x) => x.IsValidTarget(Math.Min(input.Range + input.Radius + 100f, 2000f), true, input.RangeCheckFrom) && !x.Compare(input.Unit)));
						}
						foreach (BarracksDampenerClient barracksDampenerClient in enemyInhibitors.Where(predicate5).ToList<BarracksDampenerClient>())
						{
							float num9 = input.Radius + barracksDampenerClient.BoundingRadius + 50f;
							ProjectionInfo projectionInfo3 = vector.ToVector2().ProjectOn(input.From.ToVector2(), barracksDampenerClient.Position.ToVector2());
							if (projectionInfo3.IsOnSegment && (projectionInfo3.SegmentPoint.Distance(vector.ToVector2()) <= num9 || projectionInfo3.LinePoint.Distance(vector.ToVector2()) <= num9))
							{
								hashSet.Add(GameObjects.Player);
							}
						}
					}
					if (input.CollisionObjects.Contains(CollisionObjects.Walls))
					{
						float num10 = vector.Distance(input.From) / 10f;
						for (int i = 0; i < 9; i++)
						{
							Vector2 vector4 = input.From.ToVector2().Extend(vector.ToVector2(), num10 * (float)i);
							if (NavMesh.GetCollisionFlags(vector4.X, vector4.Y).HasFlag(CollisionFlags.Wall))
							{
								hashSet.Add(GameObjects.Player);
							}
						}
					}
					if (input.CollisionObjects.Contains(CollisionObjects.YasuoWall))
					{
						if (Collisions.YasuoInGame && Variables.GameTimeTickCount - Collisions._wallCastT <= 4000)
						{
							foreach (EffectEmitter effectEmitter in (from x in Collisions.Windwalls
							where x != null && x.IsValid
							select x).ToList<EffectEmitter>())
							{
								if (effectEmitter != null && effectEmitter.IsValid && !effectEmitter.IsDead)
								{
									int windWallLevel = Collisions.GetWindWallLevel(effectEmitter);
									float num11 = 350f + 50f * (float)windWallLevel;
									Vector2 value = new Vector2(effectEmitter.Orientation.M11, effectEmitter.Orientation.M13);
									Vector2 vector5 = effectEmitter.Position.ToVector2() + num11 / 2f * value;
									Vector2 lineSegment1End = vector5 - num11 * value;
									if (vector5.Intersection(lineSegment1End, vector.ToVector2(), input.From.ToVector2()).Intersects)
									{
										hashSet.Add(GameObjects.Player);
									}
								}
							}
						}
						if (Collisions.SamiraInGame)
						{
							foreach (AIHeroClient aiheroClient2 in (from x in GameObjects.EnemyHeroes
							where x.IsValidTarget(float.MaxValue, true, default(Vector3)) && x.CharacterName == "Samira"
							select x).ToList<AIHeroClient>())
							{
								if (aiheroClient2 != null && aiheroClient2.IsValidTarget(3.4028235E+38f, true, default(Vector3)) && aiheroClient2.HasBuff("SamiraW"))
								{
									float num12 = 325f + input.Radius;
									if (aiheroClient2.ServerPosition.Distance(input.From) <= num12)
									{
										hashSet.Add(GameObjects.Player);
									}
									else if (vector.Distance(aiheroClient2.ServerPosition) <= num12)
									{
										hashSet.Add(GameObjects.Player);
									}
									else
									{
										ProjectionInfo projectionInfo4 = vector.ToVector2().ProjectOn(input.From.ToVector2(), aiheroClient2.ServerPosition.ToVector2());
										if (projectionInfo4.IsOnSegment && (projectionInfo4.SegmentPoint.Distance(vector.ToVector2()) <= num12 || projectionInfo4.LinePoint.Distance(vector.ToVector2()) <= num12))
										{
											hashSet.Add(GameObjects.Player);
										}
									}
								}
							}
						}
					}
				}
			}
			return hashSet.ToList<AIBaseClient>();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000B010 File Offset: 0x00009210
		public static bool IsCollision(List<Vector3> positions, PredictionInput input)
		{
			return Collisions.GetCollision(positions, input).Any<AIBaseClient>();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000B01E File Offset: 0x0000921E
		public static bool HasYasuoWindWallCollision(Vector3 start, Vector3 end)
		{
			return Collisions.HasYasuoWindWallCollision(start, end, 50f);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000B02C File Offset: 0x0000922C
		public static bool HasYasuoWindWallCollision(Vector3 start, Vector3 end, float extraRadius)
		{
			if (Collisions.SamiraInGame)
			{
				foreach (AIHeroClient aiheroClient in (from x in GameObjects.EnemyHeroes
				where x.IsValidTarget(float.MaxValue, true, default(Vector3)) && x.CharacterName == "Samira"
				select x).ToList<AIHeroClient>())
				{
					if (aiheroClient != null && aiheroClient.IsValidTarget(3.4028235E+38f, true, default(Vector3)) && aiheroClient.HasBuff("SamiraW"))
					{
						float num = 325f + extraRadius;
						if (aiheroClient.ServerPosition.Distance(start) <= num)
						{
							return true;
						}
						if (end.Distance(aiheroClient.ServerPosition) <= num)
						{
							return true;
						}
						ProjectionInfo projectionInfo = end.ToVector2().ProjectOn(start.ToVector2(), aiheroClient.ServerPosition.ToVector2());
						if (projectionInfo.IsOnSegment && (projectionInfo.SegmentPoint.Distance(end.ToVector2()) <= num || projectionInfo.LinePoint.Distance(end.ToVector2()) <= num))
						{
							return true;
						}
					}
				}
			}
			if (Collisions.YasuoInGame)
			{
				if (Variables.GameTimeTickCount - Collisions._wallCastT > 4000)
				{
					return false;
				}
				foreach (EffectEmitter effectEmitter in Collisions.Windwalls.ToList<EffectEmitter>())
				{
					if (effectEmitter != null && effectEmitter.IsValid)
					{
						int windWallLevel = Collisions.GetWindWallLevel(effectEmitter);
						float num2 = 250f + 50f * (float)windWallLevel + extraRadius;
						Vector2 value = new Vector2(effectEmitter.Orientation.M11, effectEmitter.Orientation.M13);
						Vector2 vector = effectEmitter.Position.ToVector2() + num2 / 2f * value;
						Vector2 lineSegment1End = vector - num2 * value;
						if (vector.Intersection(lineSegment1End, end.ToVector2(), start.ToVector2()).Intersects)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000B284 File Offset: 0x00009484
		private static bool WillDead(PredictionInput input, AIBaseClient minion, float distance)
		{
			if (minion == null || !minion.IsValid)
			{
				return false;
			}
			float num = distance / input.Speed + input.Delay;
			if (Math.Abs(input.Speed - 3.4028235E+38f) < 1E-45f)
			{
				num = input.Delay;
			}
			int time = (int)(num * 1000f) - Game.Ping;
			return HealthPrediction.GetPrediction(minion, time, 0, HealthPredictionType.Default) <= 0f;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000B2F8 File Offset: 0x000094F8
		private static void OnCreate(GameObject sender, EventArgs args)
		{
			if (!Collisions.YasuoInGame)
			{
				return;
			}
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.EffectEmitter)
			{
				return;
			}
			if (Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall2", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall3", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall4", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall5", RegexOptions.IgnoreCase))
			{
				Collisions.Windwalls.Add(sender as EffectEmitter);
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000B398 File Offset: 0x00009598
		private static void OnDelete(GameObject sender, EventArgs args)
		{
			if (!Collisions.YasuoInGame)
			{
				return;
			}
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.EffectEmitter)
			{
				return;
			}
			if (Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall2", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall3", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall4", RegexOptions.IgnoreCase) || Regex.IsMatch(sender.Name, "Yasuo_.+_w_windwall5", RegexOptions.IgnoreCase))
			{
				Collisions.Windwalls.Remove(sender as EffectEmitter);
			}
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000B43C File Offset: 0x0000963C
		private static int GetWindWallLevel(EffectEmitter effectEmitter)
		{
			if (!Collisions.YasuoInGame)
			{
				return -5;
			}
			if (effectEmitter == null || !effectEmitter.IsValid)
			{
				return -5;
			}
			if (Regex.IsMatch(effectEmitter.Name, "Yasuo_.+_w_windwall2", RegexOptions.IgnoreCase))
			{
				return 2;
			}
			if (Regex.IsMatch(effectEmitter.Name, "Yasuo_.+_w_windwall3", RegexOptions.IgnoreCase))
			{
				return 3;
			}
			if (Regex.IsMatch(effectEmitter.Name, "Yasuo_.+_w_windwall4", RegexOptions.IgnoreCase))
			{
				return 4;
			}
			if (!Regex.IsMatch(effectEmitter.Name, "Yasuo_.+_w_windwall5", RegexOptions.IgnoreCase))
			{
				return 1;
			}
			return 5;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000B4BC File Offset: 0x000096BC
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (!Collisions.YasuoInGame)
			{
				return;
			}
			if (sender == null || !sender.IsValid || sender.Type != GameObjectType.AIHeroClient || !sender.IsEnemy)
			{
				return;
			}
			if (sender.CharacterName != "Yasuo" || args.Slot != SpellSlot.W)
			{
				return;
			}
			Collisions._wallCastT = Variables.GameTimeTickCount;
		}

		// Token: 0x040000B2 RID: 178
		private static int _wallCastT;

		// Token: 0x040000B3 RID: 179
		private static bool YasuoInGame;

		// Token: 0x040000B4 RID: 180
		private static bool SamiraInGame;

		// Token: 0x040000B5 RID: 181
		private static readonly List<EffectEmitter> Windwalls = new List<EffectEmitter>();
	}
}
