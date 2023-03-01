using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000047 RID: 71
	public class FarmPrediction
	{
		// Token: 0x0600030D RID: 781 RVA: 0x000158A8 File Offset: 0x00013AA8
		public static FarmLocation GetBestCircularFarmLocation(List<Vector2> minionPositions, float width, float range, int useMecMax = 9)
		{
			Vector2 position = default(Vector2);
			int num = 0;
			Vector2 toVector = GameObjects.Player.ServerPosition.ToVector2();
			range *= range;
			if (minionPositions.Count == 0)
			{
				return new FarmLocation(position, num);
			}
			if (minionPositions.Count <= useMecMax)
			{
				using (IEnumerator<List<Vector2>> enumerator = minionPositions.GetCombinations().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						List<Vector2> list = enumerator.Current;
						if (list.Count > 0)
						{
							MecCircle mec = Mec.GetMec(list);
							if (mec.Radius <= width && mec.Center.DistanceSquared(toVector) <= range)
							{
								num = list.Count;
								return new FarmLocation(mec.Center, num);
							}
						}
					}
					goto IL_13D;
				}
			}
			using (List<Vector2>.Enumerator enumerator2 = minionPositions.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					Vector2 pos = enumerator2.Current;
					if (pos.DistanceSquared(toVector) <= range)
					{
						int num2 = minionPositions.Count((Vector2 pos2) => pos.DistanceSquared(pos2) <= width * width);
						if (num2 >= num)
						{
							position = pos;
							num = num2;
						}
					}
				}
			}
			IL_13D:
			return new FarmLocation(position, num);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00015A18 File Offset: 0x00013C18
		public static FarmLocation GetBestLineFarmLocation(List<Vector2> minions, float width, float range)
		{
			Vector2 position = default(Vector2);
			int num = 0;
			Vector2 startPos = GameObjects.Player.ServerPosition.ToVector2();
			List<Vector2> list = new List<Vector2>();
			list.AddRange(minions);
			int count = minions.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++)
				{
					if (minions[j] != minions[i])
					{
						list.Add((minions[j] + minions[i]) / 2f);
					}
				}
			}
			foreach (Vector2 vector in list)
			{
				if (vector.DistanceSquared(startPos) <= range * range)
				{
					Vector2 endPos = startPos + range * (vector - startPos).Normalized();
					int num2 = minions.Count((Vector2 pos2) => pos2.DistanceSquared(startPos, endPos, true) <= width * width);
					if (num2 >= num)
					{
						position = endPos;
						num = num2;
					}
				}
			}
			return new FarmLocation(position, num);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00015B8C File Offset: 0x00013D8C
		public static List<Vector2> GetMinionsPredictedPositions(IEnumerable<AIBaseClient> minions, float delay, float width, float speed, Vector3 from, float range, bool collision, SpellType stype, Vector3 rangeCheckFrom = default(Vector3))
		{
			from = (from.ToVector2().IsValid() ? from : GameObjects.Player.ServerPosition);
			List<Vector2> list = new List<Vector2>();
			foreach (AIBaseClient unit in from x in minions
			where x != null && x.IsValid && x.IsValidTarget(float.MaxValue, true, default(Vector3))
			select x)
			{
				PredictionOutput prediction = Prediction.GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = width,
					Speed = speed,
					From = from,
					Range = range,
					Collision = collision,
					Type = stype,
					RangeCheckFrom = rangeCheckFrom
				});
				if (prediction.Hitchance >= HitChance.High)
				{
					list.Add(prediction.UnitPosition.ToVector2());
				}
			}
			return list;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00015C80 File Offset: 0x00013E80
		public static List<Vector2> GetMinionsPredictedPositions(IEnumerable<AIMinionClient> minions, float delay, float width, float speed, Vector3 from, float range, bool collision, SpellType stype, Vector3 rangeCheckFrom = default(Vector3))
		{
			from = (from.ToVector2().IsValid() ? from : GameObjects.Player.ServerPosition);
			List<Vector2> list = new List<Vector2>();
			foreach (AIMinionClient unit in from x in minions
			where x != null && x.IsValid && x.IsValidTarget(float.MaxValue, true, default(Vector3))
			select x)
			{
				PredictionOutput prediction = Prediction.GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = width,
					Speed = speed,
					From = from,
					Range = range,
					Collision = collision,
					Type = stype,
					RangeCheckFrom = rangeCheckFrom
				});
				if (prediction.Hitchance >= HitChance.High)
				{
					list.Add(prediction.UnitPosition.ToVector2());
				}
			}
			return list;
		}
	}
}
