using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x02000081 RID: 129
	public static class Mec
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x00023E44 File Offset: 0x00022044
		public static void FindMinimalBoundingCircle(List<Vector2> points, out Vector2 center, out float radius)
		{
			List<Vector2> list = Mec.MakeConvexHull(points);
			Vector2 vector = points[0];
			float num = float.MaxValue;
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					Vector2 vector2 = new Vector2((list[i].X + list[j].X) / 2f, (list[i].Y + list[j].Y) / 2f);
					float num2 = vector2.X - list[i].X;
					float num3 = vector2.Y - list[i].Y;
					float num4 = num2 * num2 + num3 * num3;
					if (num4 < num && Mec.CircleEnclosesPoints(vector2, num4, points, i, j, -1))
					{
						vector = vector2;
						num = num4;
					}
				}
			}
			for (int k = 0; k < list.Count - 2; k++)
			{
				for (int l = k + 1; l < list.Count - 1; l++)
				{
					for (int m = l + 1; m < list.Count; m++)
					{
						Vector2 vector3;
						float num5;
						Mec.FindCircle(list[k], list[l], list[m], out vector3, out num5);
						if (num5 < num && Mec.CircleEnclosesPoints(vector3, num5, points, k, l, m))
						{
							vector = vector3;
							num = num5;
						}
					}
				}
			}
			center = vector;
			if (num == 3.4028235E+38f)
			{
				radius = 0f;
				return;
			}
			radius = (float)Math.Sqrt((double)num);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00023FE4 File Offset: 0x000221E4
		public static MecCircle GetMec(List<Vector2> points)
		{
			Vector2 center;
			float radius;
			Mec.FindMinimalBoundingCircle(Mec.MakeConvexHull(points), out center, out radius);
			return new MecCircle(center, radius);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00024008 File Offset: 0x00022208
		public static List<Vector2> MakeConvexHull(List<Vector2> points)
		{
			points = Mec.HullCull(points);
			Vector2[] best_pt = new Vector2[]
			{
				points[0]
			};
			IEnumerable<Vector2> source = points;
			Func<Vector2, bool> <>9__0;
			Func<Vector2, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((Vector2 pt) => pt.Y < best_pt[0].Y || (pt.Y == best_pt[0].Y && pt.X < best_pt[0].X)));
			}
			foreach (Vector2 vector in source.Where(predicate))
			{
				best_pt[0] = vector;
			}
			List<Vector2> list = new List<Vector2>
			{
				best_pt[0]
			};
			points.Remove(best_pt[0]);
			float num = 0f;
			while (points.Count != 0)
			{
				float x = list[list.Count - 1].X;
				float y = list[list.Count - 1].Y;
				best_pt[0] = points[0];
				float num2 = 3600f;
				foreach (Vector2 vector2 in points)
				{
					float num3 = Mec.AngleValue(x, y, vector2.X, vector2.Y);
					if (num3 >= num && num2 > num3)
					{
						num2 = num3;
						best_pt[0] = vector2;
					}
				}
				float num4 = Mec.AngleValue(x, y, list[0].X, list[0].Y);
				if (num4 >= num && num2 >= num4)
				{
					break;
				}
				list.Add(best_pt[0]);
				points.Remove(best_pt[0]);
				num = num2;
			}
			return list;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000241F0 File Offset: 0x000223F0
		private static float AngleValue(float x1, float y1, float x2, float y2)
		{
			float num = x2 - x1;
			float num2 = Math.Abs(num);
			float num3 = y2 - y1;
			float num4 = Math.Abs(num3);
			float num5;
			if (num2 + num4 == 0f)
			{
				num5 = 40f;
			}
			else
			{
				num5 = num3 / (num2 + num4);
			}
			if (num < 0f)
			{
				num5 = 2f - num5;
			}
			else if (num3 < 0f)
			{
				num5 = 4f + num5;
			}
			return num5 * 90f;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00024254 File Offset: 0x00022454
		private static bool CircleEnclosesPoints(Vector2 center, float radius2, IEnumerable<Vector2> points, int skip1, int skip2, int skip3)
		{
			return (from point in points.Where((Vector2 t, int i) => i != skip1 && i != skip2 && i != skip3)
			let dx = center.X - point.X
			let dy = center.Y - point.Y
			select dx * dx + dy * dy).All((float test_radius2) => test_radius2 <= radius2);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000242F8 File Offset: 0x000224F8
		private static void FindCircle(Vector2 a, Vector2 b, Vector2 c, out Vector2 center, out float radius2)
		{
			float num = (b.X + a.X) / 2f;
			float num2 = (b.Y + a.Y) / 2f;
			float num3 = b.X - a.X;
			float num4 = -(b.Y - a.Y);
			float num5 = (c.X + b.X) / 2f;
			float num6 = (c.Y + b.Y) / 2f;
			float num7 = c.X - b.X;
			float num8 = -(c.Y - b.Y);
			float num9 = (num2 * num4 * num8 + num5 * num4 * num7 - num * num3 * num8 - num6 * num4 * num8) / (num4 * num7 - num3 * num8);
			float num10 = (num9 - num) * num3 / num4 + num2;
			center = new Vector2(num9, num10);
			float num11 = num9 - a.X;
			float num12 = num10 - a.Y;
			radius2 = num11 * num11 + num12 * num12;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000243FC File Offset: 0x000225FC
		private static RectangleF GetMinMaxBox(List<Vector2> points)
		{
			Vector2 vector = new Vector2(0f, 0f);
			Vector2 vector2 = vector;
			Vector2 vector3 = vector;
			Vector2 vector4 = vector;
			Mec.GetMinMaxCorners(points, ref vector, ref vector2, ref vector3, ref vector4);
			float x = vector.X;
			float y = vector.Y;
			float x2 = vector2.X;
			if (y < vector2.Y)
			{
				y = vector2.Y;
			}
			if (x2 > vector4.X)
			{
				x2 = vector4.X;
			}
			float y2 = vector4.Y;
			if (x < vector3.X)
			{
				x = vector3.X;
			}
			if (y2 > vector3.Y)
			{
				y2 = vector3.Y;
			}
			return Mec.MinMaxBox = new RectangleF(x, y, x2 - x, y2 - y);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000244B0 File Offset: 0x000226B0
		private static void GetMinMaxCorners(List<Vector2> points, ref Vector2 ul, ref Vector2 ur, ref Vector2 ll, ref Vector2 lr)
		{
			ul = points[0];
			ur = ul;
			ll = ul;
			lr = ul;
			foreach (Vector2 vector in points)
			{
				if (-vector.X - vector.Y > -ul.X - ul.Y)
				{
					ul = vector;
				}
				if (vector.X - vector.Y > ur.X - ur.Y)
				{
					ur = vector;
				}
				if (-vector.X + vector.Y > -ll.X + ll.Y)
				{
					ll = vector;
				}
				if (vector.X + vector.Y > lr.X + lr.Y)
				{
					lr = vector;
				}
			}
			Mec.MinMaxCorners = new Vector2[]
			{
				ul,
				ur,
				lr,
				ll
			};
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00024604 File Offset: 0x00022804
		private static List<Vector2> HullCull(List<Vector2> points)
		{
			RectangleF culling_box = Mec.GetMinMaxBox(points);
			List<Vector2> list = (from pt in points
			where pt.X <= culling_box.Left || pt.X >= culling_box.Right || pt.Y <= culling_box.Top || pt.Y >= culling_box.Bottom
			select pt).ToList<Vector2>();
			Mec.NonCulledPoints = new Vector2[list.Count];
			list.CopyTo(Mec.NonCulledPoints);
			return list;
		}

		// Token: 0x040002AF RID: 687
		public static RectangleF MinMaxBox;

		// Token: 0x040002B0 RID: 688
		public static Vector2[] MinMaxCorners;

		// Token: 0x040002B1 RID: 689
		public static Vector2[] NonCulledPoints;
	}
}
