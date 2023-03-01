using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000014 RID: 20
	public static class Vector2Extensions
	{
		// Token: 0x0600008E RID: 142 RVA: 0x00006270 File Offset: 0x00004470
		public static float AngleBetween(this Vector2 vector2, Vector2 toVector2)
		{
			float num = vector2.Polar() - toVector2.Polar();
			if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			return num;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000062AC File Offset: 0x000044AC
		public static float AngleBetween(this Vector2 vector2, Vector3 toVector3)
		{
			return vector2.AngleBetween(toVector3.ToVector2());
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000062BC File Offset: 0x000044BC
		public static Vector2[] CircleCircleIntersection(this Vector2 center1, Vector2 center2, float radius1, float radius2)
		{
			float num = center1.Distance(center2);
			if (num > radius1 + radius2 || num <= Math.Abs(radius1 - radius2))
			{
				return new Vector2[0];
			}
			float scale = (float)(Math.Pow((double)radius1, 2.0) - Math.Pow((double)radius2, 2.0) + Math.Pow((double)num, 2.0)) / (2f * num);
			float scale2 = (float)Math.Sqrt(Math.Pow((double)radius1, 2.0) - Math.Pow((double)num, 2.0));
			Vector2 vector = (center2 - center1).Normalized();
			Vector2 left = center1 + scale * vector;
			Vector2 vector2 = left + scale2 * vector.Perpendicular(0);
			Vector2 vector3 = left - scale2 * vector.Perpendicular(0);
			return new Vector2[]
			{
				vector2,
				vector3
			};
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000063A8 File Offset: 0x000045A8
		public static Vector2 Closest(this Vector2 vector2, IEnumerable<Vector2> array)
		{
			Vector2 result = Vector2.Zero;
			float num = float.MaxValue;
			foreach (Vector2 vector3 in array)
			{
				float num2 = vector2.Distance(vector3);
				if (num2 < num)
				{
					num = num2;
					result = vector3;
				}
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000640C File Offset: 0x0000460C
		public static Vector3 Closest(this Vector2 vector2, IEnumerable<Vector3> array)
		{
			Vector3 result = Vector3.Zero;
			float num = float.MaxValue;
			foreach (Vector3 vector3 in array)
			{
				float num2 = vector2.Distance(vector3);
				if (num2 < num)
				{
					num = num2;
					result = vector3;
				}
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00006470 File Offset: 0x00004670
		public static int CountAllyHeroesInRange(this Vector2 vector2, float range, AIBaseClient originalUnit = null)
		{
			return (from h in GameObjects.AllyHeroes
			where h.IsValidTarget(range, false, vector2.ToVector3(0f)) && !h.Compare(originalUnit)
			select h).ToList<AIHeroClient>().Count;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000064B8 File Offset: 0x000046B8
		public static int CountEnemyHeroesInRange(this Vector2 vector2, float range, AIBaseClient originalUnit = null)
		{
			return (from h in GameObjects.EnemyHeroes
			where h.IsValidTarget(range, true, vector2.ToVector3(0f)) && !h.Compare(originalUnit)
			select h).ToList<AIHeroClient>().Count;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006500 File Offset: 0x00004700
		public static float CrossProduct(this Vector2 self, Vector2 other)
		{
			return other.Y * self.X - other.X * self.Y;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006520 File Offset: 0x00004720
		public static List<Vector2> CutPath(this List<Vector2> path, float distance)
		{
			List<Vector2> list = new List<Vector2>();
			float num = distance;
			if (distance < 0f)
			{
				path[0] = path[0] + distance * (path[1] - path[0]).Normalized();
				return path;
			}
			for (int i = 0; i < path.Count - 1; i++)
			{
				float num2 = path[i].Distance(path[i + 1]);
				if (num2 > num)
				{
					list.Add(path[i] + num * (path[i + 1] - path[i]).Normalized());
					for (int j = i + 1; j < path.Count; j++)
					{
						list.Add(path[j]);
					}
					break;
				}
				num -= num2;
			}
			if (list.Count <= 0)
			{
				return new List<Vector2>
				{
					path.LastOrDefault<Vector2>()
				};
			}
			return list;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00006619 File Offset: 0x00004819
		public static float Distance(this Vector2 vector2, GameObject obj)
		{
			return Vector2.Distance(vector2, obj.Position.ToVector2());
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000662C File Offset: 0x0000482C
		public static float Distance(this Vector2 vector2, Vector2 toVector2)
		{
			return Vector2.Distance(vector2, toVector2);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00006635 File Offset: 0x00004835
		public static float Distance(this Vector2 vector2, Vector3 toVector3)
		{
			return Vector2.Distance(vector2, toVector3.ToVector2());
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006644 File Offset: 0x00004844
		public static float Distance(this Vector2 point, Vector2 segmentStart, Vector2 segmentEnd, bool onlyIfOnSegment = false)
		{
			ProjectionInfo projectionInfo = point.ProjectOn(segmentStart, segmentEnd);
			if (!projectionInfo.IsOnSegment && onlyIfOnSegment)
			{
				return float.MaxValue;
			}
			return Vector2.Distance(projectionInfo.SegmentPoint, point);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006677 File Offset: 0x00004877
		public static float DistanceSquared(this Vector2 vector2, GameObject obj)
		{
			return Vector2.DistanceSquared(vector2, obj.Position.ToVector2());
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000668A File Offset: 0x0000488A
		public static float DistanceSquared(this Vector2 vector2, Vector2 toVector2)
		{
			return Vector2.DistanceSquared(vector2, toVector2);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006693 File Offset: 0x00004893
		public static float DistanceSquared(this Vector2 vector2, Vector3 toVector3)
		{
			return Vector2.DistanceSquared(vector2, toVector3.ToVector2());
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000066A4 File Offset: 0x000048A4
		public static float DistanceSquared(this Vector2 point, Vector2 segmentStart, Vector2 segmentEnd, bool onlyIfOnSegment = false)
		{
			ProjectionInfo projectionInfo = point.ProjectOn(segmentStart, segmentEnd);
			if (!projectionInfo.IsOnSegment && onlyIfOnSegment)
			{
				return float.MaxValue;
			}
			return Vector2.DistanceSquared(projectionInfo.SegmentPoint, point);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000066D7 File Offset: 0x000048D7
		public static float DistanceToCursor(this Vector2 vector2)
		{
			return Game.CursorPos.ToVector2().Distance(vector2);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000066E9 File Offset: 0x000048E9
		public static float DistanceToPlayer(this Vector2 vector2)
		{
			return GameObjects.Player.Position.Distance(vector2);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000066FC File Offset: 0x000048FC
		public static Vector2 Extend(this Vector2 vector2, Vector2 toVector2, float distance)
		{
			Vector2 right = distance * (toVector2 - vector2).Normalized();
			return vector2 + right;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00006724 File Offset: 0x00004924
		public static Vector2 Extend(this Vector2 vector2, Vector3 toVector3, float distance)
		{
			Vector2 right = distance * (toVector3.ToVector2() - vector2).Normalized();
			return vector2 + right;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006750 File Offset: 0x00004950
		public static float GetPathLength(this List<Vector2> path)
		{
			float num = 0f;
			for (int i = 0; i < path.Count - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006790 File Offset: 0x00004990
		public static List<Vector2> GetWaypoints(this AIBaseClient unit)
		{
			List<Vector2> list = new List<Vector2>();
			if (unit.IsVisible)
			{
				list.Add(unit.ServerPosition.ToVector2());
				Vector3[] path = unit.Path;
				if (path.Length != 0)
				{
					Vector2 vector = path[0].ToVector2();
					if (vector.DistanceSquared(list[0]) > 40f)
					{
						list.Add(vector);
					}
					for (int i = 1; i < path.Length; i++)
					{
						list.Add(path[i].ToVector2());
					}
				}
			}
			return list;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006810 File Offset: 0x00004A10
		public static bool InRange(this Vector2 from, Vector2 checkPosition, float range, bool squared = false)
		{
			if (squared)
			{
				return (double)from.DistanceSquared(checkPosition) <= Math.Pow((double)range, 2.0);
			}
			return from.Distance(checkPosition) <= range;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006840 File Offset: 0x00004A40
		public static bool InRange<T>(this Vector2 from, T target, float range, bool squared = false) where T : GameObject
		{
			return from.InRange(target.Position.ToVector2(), range, squared);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000685C File Offset: 0x00004A5C
		public static IntersectionResult Intersection(this Vector2 lineSegment1Start, Vector2 lineSegment1End, Vector2 lineSegment2Start, Vector2 lineSegment2End)
		{
			double num = (double)(lineSegment1Start.Y - lineSegment2Start.Y);
			double num2 = (double)(lineSegment2End.X - lineSegment2Start.X);
			double num3 = (double)(lineSegment1Start.X - lineSegment2Start.X);
			double num4 = (double)(lineSegment2End.Y - lineSegment2Start.Y);
			double num5 = (double)(lineSegment1End.X - lineSegment1Start.X);
			double num6 = (double)(lineSegment1End.Y - lineSegment1Start.Y);
			double num7 = num5 * num4 - num6 * num2;
			double num8 = num * num2 - num3 * num4;
			if (Math.Abs(num7) < 1.401298464324817E-45)
			{
				if (Math.Abs(num8) >= 1.401298464324817E-45)
				{
					return default(IntersectionResult);
				}
				if (lineSegment1Start.X >= lineSegment2Start.X && lineSegment1Start.X <= lineSegment2End.X)
				{
					return new IntersectionResult(true, lineSegment1Start);
				}
				if (lineSegment2Start.X >= lineSegment1Start.X && lineSegment2Start.X <= lineSegment1End.X)
				{
					return new IntersectionResult(true, lineSegment2Start);
				}
				return default(IntersectionResult);
			}
			else
			{
				double num9 = num8 / num7;
				if (num9 < 0.0 || num9 > 1.0)
				{
					return default(IntersectionResult);
				}
				double num10 = (num * num5 - num3 * num6) / num7;
				if (num10 < 0.0 || num10 > 1.0)
				{
					return default(IntersectionResult);
				}
				return new IntersectionResult(true, new Vector2((float)((double)lineSegment1Start.X + num9 * num5), (float)((double)lineSegment1Start.Y + num9 * num6)));
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000069E1 File Offset: 0x00004BE1
		public static bool IsBuilding(this Vector2 vector2)
		{
			return NavMesh.GetCollisionFlags(vector2.X, vector2.Y).HasFlag(CollisionFlags.Building);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006A05 File Offset: 0x00004C05
		public static bool IsOnMiniMap(this Vector2 vector2, float radius = 0f)
		{
			return vector2.X + radius > Library.GameCache.WindowsValue.MiniMapWidth && vector2.Y + radius > Library.GameCache.WindowsValue.MiniMapHeight;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006A3C File Offset: 0x00004C3C
		public static bool IsOnScreen(this Vector2 vector2, float radius = 0f)
		{
			return vector2.X + radius >= 0f && vector2.X - radius <= (float)Library.GameCache.WindowsValue.WindowsWidth && vector2.Y + radius >= 0f && vector2.Y - radius <= (float)Library.GameCache.WindowsValue.WindowsHeight;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006AA0 File Offset: 0x00004CA0
		public static bool IsOrthogonal(this Vector2 vector2, Vector2 toVector2)
		{
			return Math.Abs(vector2.X * toVector2.X + vector2.Y * toVector2.Y) < float.Epsilon;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006AC9 File Offset: 0x00004CC9
		public static bool IsOrthogonal(this Vector2 vector2, Vector3 toVector3)
		{
			return vector2.IsOrthogonal(toVector3.ToVector2());
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00006AD8 File Offset: 0x00004CD8
		public static bool IsUnderAllyTurret(this Vector2 position, float extraRange = 0f)
		{
			return GameObjects.AllyTurrets.Any((AITurretClient turret) => turret != null && turret.IsValid && !turret.IsDead && turret.Health > 1f && turret.Position.ToVector2().Distance(position) < 950f + extraRange);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00006B10 File Offset: 0x00004D10
		public static bool IsUnderEnemyTurret(this Vector2 position, float extraRange = 0f)
		{
			return GameObjects.EnemyTurrets.Any((AITurretClient turret) => turret != null && turret.IsValid && !turret.IsDead && turret.Health > 1f && turret.Position.ToVector2().Distance(position) < 950f + extraRange);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00006B47 File Offset: 0x00004D47
		public static bool IsUnderRectangle(this Vector2 point, float x, float y, float width, float height)
		{
			return point.X > x && point.X < x + width && point.Y > y && point.Y < y + height;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00006B74 File Offset: 0x00004D74
		public static bool IsValid(this Vector2 vector2)
		{
			return vector2 != Vector2.Zero;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006B81 File Offset: 0x00004D81
		public static bool IsWall(this Vector2 vector2)
		{
			return vector2.ToVector3(0f).IsWall();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006B93 File Offset: 0x00004D93
		public static float Magnitude(this Vector2 vector2)
		{
			return (float)Math.Sqrt(Math.Pow((double)vector2.X, 2.0) + Math.Pow((double)vector2.Y, 2.0));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00006BC6 File Offset: 0x00004DC6
		public static Vector2 Normalized(this Vector2 vector2)
		{
			vector2.Normalize();
			return vector2;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006BD0 File Offset: 0x00004DD0
		public static float PathLength(this List<Vector2> path)
		{
			float num = 0f;
			for (int i = 0; i < path.Count - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006C10 File Offset: 0x00004E10
		public static float PathLength(this Vector2[] path)
		{
			float num = 0f;
			for (int i = 0; i < path.Length - 1; i++)
			{
				num += path[i].Distance(path[i + 1]);
			}
			return num;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006C4C File Offset: 0x00004E4C
		public static Vector2 Perpendicular(this Vector2 vector2, int offset = 0)
		{
			if (offset != 0)
			{
				return new Vector2(vector2.Y, -vector2.X);
			}
			return new Vector2(-vector2.Y, vector2.X);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006C78 File Offset: 0x00004E78
		public static float Polar(this Vector2 vector2)
		{
			if (Math.Abs(vector2.X - 0f) <= 1E-09f)
			{
				return (float)((vector2.Y > 0f) ? 90 : ((vector2.Y < 0f) ? 270 : 0));
			}
			float num = (float)(Math.Atan((double)(vector2.Y / vector2.X)) * 57.29577951308232);
			if (vector2.X < 0f)
			{
				num += 180f;
			}
			if (num < 0f)
			{
				num += 360f;
			}
			return num;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006D0C File Offset: 0x00004F0C
		public static Vector2 PositionAfter(this List<Vector2> self, int t, int s, int delay = 0)
		{
			int num = Math.Max(0, t - delay) * s / 1000;
			for (int i = 0; i <= self.Count - 2; i++)
			{
				Vector2 vector = self[i];
				Vector2 vector2 = self[i + 1];
				int num2 = (int)vector2.Distance(vector);
				if (num2 > num)
				{
					return vector + (float)num * (vector2 - vector).Normalized();
				}
				num -= num2;
			}
			return self[self.Count - 1];
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006D8C File Offset: 0x00004F8C
		public static ProjectionInfo ProjectOn(this Vector2 point, Vector2 segmentStart, Vector2 segmentEnd)
		{
			float x = point.X;
			float y = point.Y;
			float x2 = segmentStart.X;
			float y2 = segmentStart.Y;
			float x3 = segmentEnd.X;
			float y3 = segmentEnd.Y;
			float num = ((x - x2) * (x3 - x2) + (y - y2) * (y3 - y2)) / ((float)Math.Pow((double)(x3 - x2), 2.0) + (float)Math.Pow((double)(y3 - y2), 2.0));
			Vector2 vector = new Vector2(x2 + num * (x3 - x2), y2 + num * (y3 - y2));
			float num2;
			if (num < 0f)
			{
				num2 = 0f;
			}
			else if (num > 1f)
			{
				num2 = 1f;
			}
			else
			{
				num2 = num;
			}
			bool flag = num2.CompareTo(num) == 0;
			Vector2 segmentPoint = flag ? vector : new Vector2(x2 + num2 * (x3 - x2), y2 + num2 * (y3 - y2));
			return new ProjectionInfo(flag, segmentPoint, vector);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00006E74 File Offset: 0x00005074
		public static Vector2 Rotated(this Vector2 vector2, float angle)
		{
			double num = Math.Cos((double)angle);
			double num2 = Math.Sin((double)angle);
			return new Vector2((float)((double)vector2.X * num - (double)vector2.Y * num2), (float)((double)vector2.Y * num + (double)vector2.X * num2));
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006EC0 File Offset: 0x000050C0
		public static Vector2 RotateAroundPoint(this Vector2 rotated, Vector2 around, float angle)
		{
			double num = Math.Sin((double)angle);
			double num2 = Math.Cos((double)angle);
			float num3 = (float)(num2 * (double)(rotated.X - around.X) - num * (double)(rotated.Y - around.Y) + (double)around.X);
			double num4 = num * (double)(rotated.X - around.X) + num2 * (double)(rotated.Y - around.Y) + (double)around.Y;
			return new Vector2(num3, (float)num4);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006F38 File Offset: 0x00005138
		public static Vector3 ToVector3(this Vector2 vector2, float z = 0f)
		{
			float z2 = (z == 0f) ? NavMesh.GetHeightForPosition(vector2.X, vector2.Y) : z;
			return new Vector3(vector2.X, vector2.Y, z2);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006F74 File Offset: 0x00005174
		public static List<Vector3> ToVector3(this List<Vector2> path)
		{
			return (from point in path
			select point.ToVector3(0f)).ToList<Vector3>();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006FA0 File Offset: 0x000051A0
		public static MovementCollisionInfo VectorMovementCollision(this Vector2 pointStartA, Vector2 pointEndA, float pointVelocityA, Vector2 pointB, float pointVelocityB, float delay = 0f)
		{
			return new Vector2[]
			{
				pointStartA,
				pointEndA
			}.VectorMovementCollision(pointVelocityA, pointB, pointVelocityB, delay);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006FC4 File Offset: 0x000051C4
		public static MovementCollisionInfo VectorMovementCollision(this Vector2[] pointA, float pointVelocityA, Vector2 pointB, float pointVelocityB, float delay = 0f)
		{
			if (pointA.Length < 1)
			{
				return default(MovementCollisionInfo);
			}
			float x = pointA[0].X;
			float y = pointA[0].Y;
			float x2 = pointA[1].X;
			float y2 = pointA[1].Y;
			float x3 = pointB.X;
			float y3 = pointB.Y;
			float num = x2 - x;
			float num2 = y2 - y;
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			float num4 = float.NaN;
			float num5 = (Math.Abs(num3) > float.Epsilon) ? (pointVelocityA * num / num3) : 0f;
			float num6 = (Math.Abs(num3) > float.Epsilon) ? (pointVelocityA * num2 / num3) : 0f;
			float num7 = x3 - x;
			float num8 = y3 - y;
			float num9 = num7 * num7 + num8 * num8;
			if (num3 > 0f)
			{
				if (Math.Abs(pointVelocityA - 3.4028235E+38f) < 1E-45f)
				{
					float num10 = num3 / pointVelocityA;
					num4 = ((pointVelocityB * num10 >= 0f) ? num10 : float.NaN);
				}
				else if (Math.Abs(pointVelocityB - 3.4028235E+38f) < 1E-45f)
				{
					num4 = 0f;
				}
				else
				{
					float num11 = num5 * num5 + num6 * num6 - pointVelocityB * pointVelocityB;
					float num12 = -num7 * num5 - num8 * num6;
					if (Math.Abs(num11) < 1E-45f)
					{
						if (Math.Abs(num12) < 1E-45f)
						{
							num4 = ((Math.Abs(num9) < float.Epsilon) ? 0f : float.NaN);
						}
						else
						{
							float num13 = -num9 / (2f * num12);
							num4 = ((pointVelocityB * num13 >= 0f) ? num13 : float.NaN);
						}
					}
					else
					{
						float num14 = num12 * num12 - num11 * num9;
						if (num14 >= 0f)
						{
							float num15 = (float)Math.Sqrt((double)num14);
							float num16 = (-num15 - num12) / num11;
							num4 = ((pointVelocityB * num16 >= 0f) ? num16 : float.NaN);
							num16 = (num15 - num12) / num11;
							float num17 = (pointVelocityB * num16 >= 0f) ? num16 : float.NaN;
							if (!float.IsNaN(num17) && !float.IsNaN(num4))
							{
								if (num4 >= delay && num17 >= delay)
								{
									num4 = Math.Min(num4, num17);
								}
								else if (num17 >= delay)
								{
									num4 = num17;
								}
							}
						}
					}
				}
			}
			else if (Math.Abs(num3) < 1E-45f)
			{
				num4 = 0f;
			}
			return new MovementCollisionInfo(num4, (!float.IsNaN(num4)) ? new Vector2(x + num5 * num4, y + num6 * num4) : default(Vector2));
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000725B File Offset: 0x0000545B
		public static RawVector2 ToRawVector2(this Vector2 vector)
		{
			return new RawVector2(vector.X, vector.Y);
		}
	}
}
