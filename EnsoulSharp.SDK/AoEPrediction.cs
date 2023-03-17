using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001C RID: 28
	public static class AoEPrediction
	{
		// Token: 0x0600012D RID: 301 RVA: 0x000083BC File Offset: 0x000065BC
		internal static PredictionOutput GetPrediction(PredictionInput input)
		{
			switch (input.Type)
			{
			case SpellType.Line:
				return AoEPrediction.GetLinePrediction(input);
			case SpellType.Circle:
				return AoEPrediction.GetCirclePrediction(input);
			case SpellType.Cone:
				return AoEPrediction.GetConePrediction(input);
			default:
				return new PredictionOutput();
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008400 File Offset: 0x00006600
		public static PredictionOutput GetCirclePrediction(PredictionInput input)
		{
			AIHeroClient aiheroClient = input.Unit as AIHeroClient;
			if (aiheroClient == null)
			{
				return new PredictionOutput();
			}
			PredictionOutput prediction = Prediction.GetPrediction(input, false, true);
			List<AoEPrediction.PossibleTarget> list = new List<AoEPrediction.PossibleTarget>
			{
				new AoEPrediction.PossibleTarget
				{
					Position = prediction.UnitPosition.ToVector2(),
					Unit = aiheroClient
				}
			};
			if (prediction.Hitchance >= HitChance.Medium)
			{
				list.AddRange(AoEPrediction.GetPossibleTargets(input));
			}
			while (list.Count > 1)
			{
				MecCircle mec = Mec.GetMec((from h in list
				select h.Position).ToList<Vector2>());
				if (mec.Radius <= input.RealRadius - 10f && (double)Vector2.DistanceSquared(mec.Center, input.RangeCheckFrom.ToVector2()) < Math.Pow((double)input.Range, 2.0))
				{
					PredictionOutput predictionOutput = new PredictionOutput();
					predictionOutput.AoeTargetsHit = (from h in list
					select h.Unit).ToList<AIHeroClient>();
					predictionOutput.CastPosition = mec.Center.ToVector3(0f).SetZ(null);
					predictionOutput.UnitPosition = prediction.UnitPosition.SetZ(null);
					predictionOutput.Hitchance = prediction.Hitchance;
					predictionOutput.Input = input;
					return predictionOutput;
				}
				float num = -1f;
				int index = 1;
				for (int i = 1; i < list.Count; i++)
				{
					float num2 = Vector2.DistanceSquared(list[i].Position, list[0].Position);
					if (num2 > num || num.CompareTo(-1f) == 0)
					{
						index = i;
						num = num2;
					}
				}
				list.RemoveAt(index);
			}
			return prediction;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000085E8 File Offset: 0x000067E8
		public static PredictionOutput GetConePrediction(PredictionInput input)
		{
			AIHeroClient aiheroClient = input.Unit as AIHeroClient;
			if (aiheroClient == null)
			{
				return new PredictionOutput();
			}
			PredictionOutput prediction = Prediction.GetPrediction(input, false, true);
			List<AoEPrediction.PossibleTarget> list = new List<AoEPrediction.PossibleTarget>
			{
				new AoEPrediction.PossibleTarget
				{
					Position = prediction.UnitPosition.ToVector2(),
					Unit = aiheroClient
				}
			};
			if (prediction.Hitchance >= HitChance.Medium)
			{
				list.AddRange(AoEPrediction.GetPossibleTargets(input));
			}
			if (list.Count > 1)
			{
				List<Vector2> list2 = new List<Vector2>();
				foreach (AoEPrediction.PossibleTarget possibleTarget in list)
				{
					possibleTarget.Position -= input.From.ToVector2();
				}
				for (int i = 0; i < list.Count; i++)
				{
					for (int j = 0; j < list.Count; j++)
					{
						if (i != j)
						{
							Vector2 item = (list[i].Position + list[j].Position) * 0.5f;
							if (!list2.Contains(item))
							{
								list2.Add(item);
							}
						}
					}
				}
				int num = -1;
				List<AIHeroClient> aoeTargetsHit = new List<AIHeroClient>();
				Vector2 vector = default(Vector2);
				foreach (Vector2 vector2 in list2)
				{
					Tuple<int, List<AIHeroClient>> coneHits = AoEPrediction.GetConeHits(vector2, (double)input.Range, input.RealRadius, list);
					if (coneHits.Item1 > num)
					{
						vector = vector2;
						aoeTargetsHit = coneHits.Item2;
						num = coneHits.Item1;
					}
				}
				vector += input.From.ToVector2();
				if (num > 1 && (double)input.From.ToVector2().DistanceSquared(vector) > Math.Pow(50.0, 2.0))
				{
					return new PredictionOutput
					{
						Hitchance = prediction.Hitchance,
						AoeTargetsHit = aoeTargetsHit,
						UnitPosition = prediction.UnitPosition.SetZ(null),
						CastPosition = vector.ToVector3(0f).SetZ(null),
						Input = input
					};
				}
			}
			return prediction;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00008854 File Offset: 0x00006A54
		public static PredictionOutput GetLinePrediction(PredictionInput input)
		{
			AIHeroClient aiheroClient = input.Unit as AIHeroClient;
			if (aiheroClient == null)
			{
				return new PredictionOutput();
			}
			PredictionOutput prediction = Prediction.GetPrediction(input, false, true);
			List<AoEPrediction.PossibleTarget> list = new List<AoEPrediction.PossibleTarget>
			{
				new AoEPrediction.PossibleTarget
				{
					Position = prediction.UnitPosition.ToVector2(),
					Unit = aiheroClient
				}
			};
			if (prediction.Hitchance >= HitChance.Medium)
			{
				list.AddRange(AoEPrediction.GetPossibleTargets(input));
			}
			if (list.Count > 1)
			{
				List<Vector2> list2 = new List<Vector2>();
				foreach (AoEPrediction.PossibleTarget possibleTarget in list)
				{
					IEnumerable<Vector2> lineCandidates = AoEPrediction.GetLineCandidates(input.From.ToVector2(), possibleTarget.Position, input.Range, list[0].Position);
					list2.AddRange(lineCandidates);
				}
				int num = -1;
				Vector2 vector = default(Vector2);
				List<AoEPrediction.PossibleTarget> list3 = new List<AoEPrediction.PossibleTarget>();
				foreach (Vector2 vector2 in list2)
				{
					if ((double)list[0].Position.DistanceSquared(input.From.ToVector2(), vector2, true) <= Math.Pow((double)input.RealRadius, 2.0))
					{
						Tuple<int, List<AoEPrediction.PossibleTarget>> lineHits = AoEPrediction.GetLineHits(input.From.ToVector2(), vector2, (double)input.RealRadius, list);
						if (lineHits.Item1 >= num)
						{
							num = lineHits.Item1;
							vector = vector2;
							list3 = lineHits.Item2;
						}
					}
				}
				if (num > 1)
				{
					float num2 = -1f;
					Vector2 left = default(Vector2);
					Vector2 right = default(Vector2);
					List<Vector2> list4 = (from t in list
					select t.Position).ToList<Vector2>();
					for (int i = 0; i < list3.Count; i++)
					{
						for (int j = 0; j < list3.Count; j++)
						{
							Vector2 segmentStart = input.From.ToVector2();
							Vector2 segmentEnd = vector;
							ProjectionInfo projectionInfo = list4[i].ProjectOn(segmentStart, segmentEnd);
							ProjectionInfo projectionInfo2 = list4[j].ProjectOn(segmentStart, segmentEnd);
							float num3 = Vector2.DistanceSquared(list3[i].Position, projectionInfo.LinePoint) + Vector2.DistanceSquared(list3[j].Position, projectionInfo2.LinePoint);
							if (num3 >= num2 && (projectionInfo.LinePoint - list4[i]).AngleBetween(projectionInfo2.LinePoint - list4[j]) > 90f)
							{
								num2 = num3;
								left = list4[i];
								right = list4[j];
							}
						}
					}
					PredictionOutput predictionOutput = new PredictionOutput();
					predictionOutput.Hitchance = prediction.Hitchance;
					predictionOutput.AoeTargetsHit = (from x in list3
					select x.Unit).ToList<AIHeroClient>();
					predictionOutput.UnitPosition = prediction.UnitPosition.SetZ(null);
					predictionOutput.CastPosition = ((left + right) * 0.5f).ToVector3(0f).SetZ(null);
					predictionOutput.Input = input;
					return predictionOutput;
				}
			}
			return prediction;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008BE8 File Offset: 0x00006DE8
		private static List<AoEPrediction.PossibleTarget> GetPossibleTargets(PredictionInput input)
		{
			List<AoEPrediction.PossibleTarget> list = new List<AoEPrediction.PossibleTarget>();
			AIBaseClient originalUnit = input.Unit;
			IEnumerable<AIHeroClient> enemyHeroes = GameObjects.EnemyHeroes;
			Func<AIHeroClient, bool> <>9__0;
			Func<AIHeroClient, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((AIHeroClient h) => h.IsValidTarget(input.Range + 200f + input.RealRadius, true, input.RangeCheckFrom) && !h.Compare(originalUnit)));
			}
			foreach (AIHeroClient unit in enemyHeroes.Where(predicate))
			{
				input.Unit = unit;
				PredictionOutput prediction = Prediction.GetPrediction(input, false, false);
				if (prediction.Hitchance >= HitChance.Medium)
				{
					list.Add(new AoEPrediction.PossibleTarget
					{
						Position = prediction.UnitPosition.ToVector2(),
						Unit = unit
					});
				}
			}
			return list;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008CC4 File Offset: 0x00006EC4
		private static Tuple<int, List<AIHeroClient>> GetConeHits(Vector2 end, double range, float angle, IEnumerable<AoEPrediction.PossibleTarget> targets)
		{
			int num = 0;
			List<AIHeroClient> list = new List<AIHeroClient>();
			foreach (AoEPrediction.PossibleTarget possibleTarget in targets)
			{
				Vector2 vector = end.Rotated(-angle / 2f);
				Vector2 other = vector.Rotated(angle);
				if ((double)possibleTarget.Position.DistanceSquared(default(Vector2)) < Math.Pow(range, 2.0) && vector.CrossProduct(possibleTarget.Position) > 0f && possibleTarget.Position.CrossProduct(other) > 0f)
				{
					num++;
					list.Add(possibleTarget.Unit);
				}
			}
			return new Tuple<int, List<AIHeroClient>>(num, list);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008D94 File Offset: 0x00006F94
		private static Tuple<int, List<AoEPrediction.PossibleTarget>> GetLineHits(Vector2 start, Vector2 end, double radius, IEnumerable<AoEPrediction.PossibleTarget> targets)
		{
			int num = 0;
			List<AoEPrediction.PossibleTarget> list = new List<AoEPrediction.PossibleTarget>();
			foreach (AoEPrediction.PossibleTarget possibleTarget in targets)
			{
				if ((double)possibleTarget.Position.DistanceSquared(start, end, true) < Math.Pow(radius, 2.0))
				{
					num++;
					list.Add(possibleTarget);
				}
			}
			return new Tuple<int, List<AoEPrediction.PossibleTarget>>(num, list);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00008E10 File Offset: 0x00007010
		private static IEnumerable<Vector2> GetLineCandidates(Vector2 from, Vector2 to, float range, Vector2 endPosition)
		{
			Vector2 segmentEnd = from.Extend(endPosition, range);
			ProjectionInfo projectionInfo = to.ProjectOn(from, segmentEnd);
			if (!projectionInfo.IsOnSegment)
			{
				return new Vector2[0];
			}
			return new Vector2[]
			{
				projectionInfo.SegmentPoint
			};
		}

		// Token: 0x0200043C RID: 1084
		internal class PossibleTarget
		{
			// Token: 0x04000B0F RID: 2831
			public Vector2 Position;

			// Token: 0x04000B10 RID: 2832
			public AIHeroClient Unit;
		}
	}
}
