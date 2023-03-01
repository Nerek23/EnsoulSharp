using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200004B RID: 75
	internal class PredictionSDK : IPrediction
	{
		// Token: 0x06000321 RID: 801 RVA: 0x000165DC File Offset: 0x000147DC
		public PredictionOutput GetPrediction(PredictionInput input)
		{
			return this.GetPrediction(input, true, true);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000165E8 File Offset: 0x000147E8
		public PredictionOutput GetPrediction(PredictionInput input, bool ft, bool checkCollision)
		{
			PredictionOutput predictionOutput = null;
			if (input == null)
			{
				throw new Exception("PredictionInput cant be null!");
			}
			if (input.Unit == null || !input.Unit.IsValidTarget(3.4028235E+38f, false, default(Vector3)))
			{
				return new PredictionOutput
				{
					Input = input
				};
			}
			if (input.Unit.Type == GameObjectType.AIHeroClient && input.Unit.CharacterName == "Yuumi" && GameObjects.Heroes.Any((AIHeroClient x) => x.IsValidTarget(float.MaxValue, false, default(Vector3)) && x.Team == input.Unit.Team && x.HasBuff("YuumiWAlly") && x.Distance(input.Unit) <= 50f))
			{
				return new PredictionOutput
				{
					Input = input
				};
			}
			if (ft)
			{
				input.Delay += (float)Game.Ping / 2000f + 0.06f;
				if (input.Aoe)
				{
					return AoEPrediction.GetPrediction(input);
				}
			}
			if (Math.Abs(input.Range - 3.4028235E+38f) > 1E-45f && (double)input.Unit.DistanceSquared(input.RangeCheckFrom) > Math.Pow((double)input.Range * 1.5, 2.0))
			{
				return new PredictionOutput
				{
					Input = input
				};
			}
			if (input.Unit.Type == GameObjectType.AIHeroClient)
			{
				if (input.Unit.IsDashing())
				{
					predictionOutput = PredictionSDK.GetDashingPrediction(input);
				}
				else
				{
					double num = PredictionSDK.UnitIsImmobileUntil(input.Unit);
					if (num >= 0.0)
					{
						predictionOutput = PredictionSDK.GetImmobilePrediction(input, num);
					}
				}
			}
			if (predictionOutput == null)
			{
				predictionOutput = PredictionSDK.GetPositionOnPath(input, input.Unit.GetWaypoints(), input.Unit.MoveSpeed, true);
			}
			if (Math.Abs(input.Range - 3.4028235E+38f) > 1E-45f)
			{
				if (predictionOutput.Hitchance >= HitChance.High && (double)input.RangeCheckFrom.DistanceSquared(input.Unit.ServerPosition) > Math.Pow((double)(input.Range + input.RealRadius * 3f / 4f), 2.0))
				{
					predictionOutput.Hitchance = HitChance.Medium;
				}
				if ((double)input.RangeCheckFrom.DistanceSquared(predictionOutput.UnitPosition) > Math.Pow((double)(input.Range + ((input.Type == SpellType.Circle) ? input.RealRadius : 0f)), 2.0))
				{
					predictionOutput.Hitchance = HitChance.OutOfRange;
				}
			}
			if (checkCollision && input.Collision && predictionOutput.Hitchance > HitChance.None)
			{
				List<AIBaseClient> collision = Collisions.GetCollision(new List<Vector3>
				{
					predictionOutput.CastPosition
				}, input);
				if ((float)collision.Count > input.MaxCollisionCount)
				{
					collision.RemoveAll((AIBaseClient x) => x == null || !x.IsValid || x.Compare(input.Unit));
					predictionOutput.CollisionObjects = collision;
					predictionOutput.OriginHitchance = predictionOutput.Hitchance;
					predictionOutput.Hitchance = HitChance.Collision;
					return predictionOutput;
				}
			}
			return predictionOutput;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00016954 File Offset: 0x00014B54
		private static PredictionOutput GetDashingPrediction(PredictionInput input)
		{
			AntiGapcloser.GapcloserArgs gapcloserInfo = input.Unit.GetGapcloserInfo();
			PredictionOutput predictionOutput = new PredictionOutput
			{
				Input = input
			};
			if (gapcloserInfo != null && gapcloserInfo.SpellName != "NullDash")
			{
				Vector2 vector = gapcloserInfo.EndPosition.ToVector2();
				PredictionOutput positionOnPath = PredictionSDK.GetPositionOnPath(input, new List<Vector2>
				{
					input.Unit.ServerPosition.ToVector2(),
					vector
				}, gapcloserInfo.Speed, false);
				if (positionOnPath.Hitchance >= HitChance.High && positionOnPath.UnitPosition.ToVector2().Distance(input.Unit.ServerPosition.ToVector2(), vector, true) < 200f)
				{
					positionOnPath.CastPosition = positionOnPath.UnitPosition;
					positionOnPath.Hitchance = HitChance.Dash;
					return positionOnPath;
				}
				if (gapcloserInfo.StartPosition.Distance(gapcloserInfo.EndPosition) > 200f && input.Delay / 2f + input.From.ToVector2().Distance(vector) / input.Speed - 0.25f <= input.Unit.Distance(vector) / gapcloserInfo.Speed + input.RealRadius / input.Unit.MoveSpeed)
				{
					return new PredictionOutput
					{
						CastPosition = vector.ToVector3(0f),
						UnitPosition = vector.ToVector3(0f),
						Hitchance = HitChance.Dash
					};
				}
				predictionOutput.CastPosition = gapcloserInfo.EndPosition;
				predictionOutput.UnitPosition = gapcloserInfo.EndPosition;
			}
			else
			{
				input.Delay += 0.1f;
				Dash.DashArgs dashInfo = input.Unit.GetDashInfo();
				Vector2 vector2 = dashInfo.Path.Last<Vector2>();
				PredictionOutput positionOnPath2 = PredictionSDK.GetPositionOnPath(input, new List<Vector2>
				{
					dashInfo.StartPos,
					vector2
				}, dashInfo.Speed, false);
				if (positionOnPath2.Hitchance >= HitChance.High && positionOnPath2.UnitPosition.ToVector2().Distance(input.Unit.ServerPosition.ToVector2(), vector2, true) < 200f)
				{
					positionOnPath2.CastPosition = positionOnPath2.UnitPosition;
					positionOnPath2.Hitchance = HitChance.Dash;
					return positionOnPath2;
				}
				if (dashInfo.StartPos.Distance(dashInfo.EndPos) > 200f && input.Delay / 2f + input.From.ToVector2().Distance(vector2) / input.Speed - 0.25f <= input.Unit.Distance(vector2) / dashInfo.Speed + input.RealRadius / input.Unit.MoveSpeed)
				{
					return new PredictionOutput
					{
						CastPosition = vector2.ToVector3(0f),
						UnitPosition = vector2.ToVector3(0f),
						Hitchance = HitChance.Dash
					};
				}
				predictionOutput.CastPosition = vector2.ToVector3(0f);
				predictionOutput.UnitPosition = vector2.ToVector3(0f);
			}
			return predictionOutput;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00016C40 File Offset: 0x00014E40
		private static PredictionOutput GetImmobilePrediction(PredictionInput input, double remainingImmobileT)
		{
			Vector3 serverPosition = input.Unit.ServerPosition;
			float num = input.Delay + input.Unit.Distance(input.From) / input.Speed;
			if ((double)num <= remainingImmobileT + (double)(input.RealRadius / input.Unit.MoveSpeed))
			{
				return new PredictionOutput
				{
					CastPosition = serverPosition,
					UnitPosition = serverPosition,
					Hitchance = HitChance.Immobile
				};
			}
			if ((double)(num - 0.2f) <= remainingImmobileT + (double)(input.RealRadius / input.Unit.MoveSpeed))
			{
				return new PredictionOutput
				{
					CastPosition = serverPosition,
					UnitPosition = serverPosition,
					Hitchance = HitChance.VeryHigh
				};
			}
			return new PredictionOutput
			{
				Input = input,
				CastPosition = serverPosition,
				UnitPosition = serverPosition,
				Hitchance = HitChance.Medium
			};
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00016D08 File Offset: 0x00014F08
		private static double UnitIsImmobileUntil(AIBaseClient unit)
		{
			return (from buff in unit.Buffs
			where buff.IsValid && buff.IsActive && Game.Time <= buff.EndTime && (buff.Type == BuffType.Charm || buff.Type == BuffType.Knockup || buff.Type == BuffType.Stun || buff.Type == BuffType.Suppression || buff.Type == BuffType.Snare || buff.Type == BuffType.Fear || buff.Type == BuffType.Taunt || buff.Type == BuffType.Knockback || buff.Type == BuffType.Asleep)
			select buff).Aggregate(0.0, (double current, BuffInstance buff) => Math.Max(current, (double)buff.EndTime)) - (double)Game.Time;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00016D74 File Offset: 0x00014F74
		private static PredictionOutput GetPositionOnPath(PredictionInput input, List<Vector2> path, float speed = -1f, bool needToFixSpeed = false)
		{
			if (needToFixSpeed && (double)input.Unit.DistanceSquared(input.From) < Math.Pow(250.0, 2.0))
			{
				speed *= 1.5f;
			}
			speed = ((Math.Abs(speed - -1f) < float.Epsilon) ? input.Unit.MoveSpeed : speed);
			Vector3 serverPosition = input.Unit.ServerPosition;
			if (path.Count <= 1 || (input.Unit.IsWindingUp && !input.Unit.IsDashing()))
			{
				return new PredictionOutput
				{
					Input = input,
					UnitPosition = serverPosition,
					CastPosition = serverPosition,
					Hitchance = HitChance.VeryHigh
				};
			}
			float pathLength = path.GetPathLength();
			if (path.Count == 2 && pathLength < 5f && (input.Unit.CharacterName == "PracticeTool_TargetDummy" || input.Unit.IsMinion() || input.Unit.IsJungle()))
			{
				return new PredictionOutput
				{
					Input = input,
					UnitPosition = input.Unit.ServerPosition,
					CastPosition = input.Unit.ServerPosition,
					Hitchance = HitChance.VeryHigh
				};
			}
			if (pathLength >= input.Delay * speed - input.RealRadius && Math.Abs(input.Speed - 3.4028235E+38f) < 1E-45f)
			{
				float num = input.Delay * speed - input.RealRadius;
				for (int i = 0; i < path.Count - 1; i++)
				{
					Vector2 vector = path[i];
					Vector2 vector2 = path[i + 1];
					float num2 = vector.Distance(vector2);
					if (num2 >= num)
					{
						Vector2 value = (vector2 - vector).Normalized();
						Vector2 vector3 = vector + value * num;
						Vector2 vector4 = vector + value * ((i == path.Count - 2) ? Math.Min(num + input.RealRadius, num2) : (num + input.RealRadius));
						return new PredictionOutput
						{
							Input = input,
							CastPosition = vector3.ToVector3(0f).SetZ(null),
							UnitPosition = vector4.ToVector3(0f).SetZ(null),
							Hitchance = PredictionSDK.GetHitchance(input.Unit)
						};
					}
					num -= num2;
				}
			}
			if (pathLength >= input.Delay * speed - input.RealRadius && Math.Abs(input.Speed - 3.4028235E+38f) > 1E-45f)
			{
				float distance = input.Delay * speed - input.RealRadius;
				if ((input.Type == SpellType.Line || input.Type == SpellType.Cone) && (double)input.From.DistanceSquared(serverPosition) < Math.Pow(200.0, 2.0))
				{
					distance = input.Delay * speed;
				}
				path = path.CutPath(distance);
				float num3 = 0f;
				int j = 0;
				while (j < path.Count - 1)
				{
					Vector2 vector5 = path[j];
					Vector2 vector6 = path[j + 1];
					float num4 = vector5.Distance(vector6) / speed;
					Vector2 value2 = (vector6 - vector5).Normalized();
					vector5 -= speed * num3 * value2;
					MovementCollisionInfo movementCollisionInfo = vector5.VectorMovementCollision(vector6, speed, input.From.ToVector2(), input.Speed, num3);
					float collisionTime = movementCollisionInfo.CollisionTime;
					Vector2 collisionPosition = movementCollisionInfo.CollisionPosition;
					if (collisionPosition.IsValid() && collisionTime >= num3 && collisionTime <= num3 + num4)
					{
						if (collisionPosition.DistanceSquared(vector6) >= 20f)
						{
							Vector2 vector7 = collisionPosition - input.RealRadius * value2;
							return new PredictionOutput
							{
								Input = input,
								CastPosition = collisionPosition.ToVector3(0f).SetZ(null),
								UnitPosition = vector7.ToVector3(0f).SetZ(null),
								Hitchance = PredictionSDK.GetHitchance(input.Unit)
							};
						}
						break;
					}
					else
					{
						num3 += num4;
						j++;
					}
				}
			}
			Vector2 vector8 = path.LastOrDefault<Vector2>();
			return new PredictionOutput
			{
				Input = input,
				CastPosition = vector8.ToVector3(0f).SetZ(null),
				UnitPosition = vector8.ToVector3(0f).SetZ(null),
				Hitchance = HitChance.Medium
			};
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0001721A File Offset: 0x0001541A
		private static HitChance GetHitchance(AIBaseClient unit)
		{
			if (unit.Type != GameObjectType.AIHeroClient)
			{
				return HitChance.VeryHigh;
			}
			if (StoredPaths.GetCurrentPath(unit).Time >= 0.1)
			{
				return HitChance.High;
			}
			return HitChance.VeryHigh;
		}
	}
}
