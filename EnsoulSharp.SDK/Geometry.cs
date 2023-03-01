using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EnsoulSharp.SDK.Clipper;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200003D RID: 61
	public static class Geometry
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x00011C8B File Offset: 0x0000FE8B
		public static bool Close(float a, float b, float eps)
		{
			if (Math.Abs(eps) < 1E-45f)
			{
				eps = 1E-09f;
			}
			return Math.Abs(a - b) <= eps;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00011CAF File Offset: 0x0000FEAF
		public static float DegreeToRadian(double angle)
		{
			return (float)(3.141592653589793 * angle / 180.0);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00011CC8 File Offset: 0x0000FEC8
		public static Vector2 CenterOfPolygone(this Geometry.Polygon p)
		{
			float num = 0f;
			float num2 = 0f;
			int count = p.Points.Count;
			foreach (Vector2 vector in p.Points)
			{
				num += vector.X;
				num2 += vector.Y;
			}
			return new Vector2(num / (float)count, num2 / (float)count);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00011D50 File Offset: 0x0000FF50
		public static List<List<IntPoint>> ClipPolygons(List<Geometry.Polygon> polygons)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>(polygons.Count);
			List<List<IntPoint>> list2 = new List<List<IntPoint>>(polygons.Count);
			foreach (Geometry.Polygon polygon in polygons)
			{
				list.Add(polygon.ToClipperPath());
				list2.Add(polygon.ToClipperPath());
			}
			List<List<IntPoint>> list3 = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(list, PolyType.ptClip, true);
			clipper.AddPaths(list2, PolyType.ptClip, true);
			clipper.Execute(ClipType.ctUnion, list3, PolyFillType.pftPositive, PolyFillType.pftEvenOdd);
			return list3;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00011DF8 File Offset: 0x0000FFF8
		public static List<Geometry.Polygon> JoinPolygons(this List<Geometry.Polygon> sList)
		{
			List<List<IntPoint>> ppg = Geometry.ClipPolygons(sList);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(ppg, PolyType.ptClip, true);
			clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
			return list.ToPolygons();
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00011E34 File Offset: 0x00010034
		public static List<Geometry.Polygon> JoinPolygons(this List<Geometry.Polygon> sList, ClipType cType, PolyType pType = PolyType.ptClip, PolyFillType pFType1 = PolyFillType.pftNonZero, PolyFillType pFType2 = PolyFillType.pftNonZero)
		{
			List<List<IntPoint>> ppg = Geometry.ClipPolygons(sList);
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(ppg, pType, true);
			clipper.Execute(cType, list, pFType1, pFType2);
			return list.ToPolygons();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00011E70 File Offset: 0x00010070
		public static Geometry.Polygon MovePolygone(this Geometry.Polygon polygon, Vector2 moveTo)
		{
			Geometry.Polygon polygon2 = new Geometry.Polygon();
			polygon2.Add(moveTo);
			int count = polygon.Points.Count;
			Vector2 vector = polygon.Points[0];
			for (int i = 1; i < count; i++)
			{
				Vector2 vector2 = polygon.Points[i];
				polygon2.Add(new Vector2(moveTo.X + (vector2.X - vector.X), moveTo.Y + (vector2.Y - vector.Y)));
			}
			return polygon2;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00011EF3 File Offset: 0x000100F3
		public static float RadianToDegree(double angle)
		{
			return (float)(angle * 57.29577951308232);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00011F04 File Offset: 0x00010104
		public static Geometry.Polygon RotatePolygon(this Geometry.Polygon polygon, Vector2 around, float angle)
		{
			Geometry.Polygon polygon2 = new Geometry.Polygon();
			IEnumerable<Vector2> points = polygon.Points;
			Func<Vector2, Vector2> <>9__0;
			Func<Vector2, Vector2> selector;
			if ((selector = <>9__0) == null)
			{
				selector = (<>9__0 = ((Vector2 poinit) => poinit.RotateAroundPoint(around, angle)));
			}
			foreach (Vector2 point in points.Select(selector))
			{
				polygon2.Add(point);
			}
			return polygon2;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00011F94 File Offset: 0x00010194
		public static Geometry.Polygon RotatePolygon(this Geometry.Polygon polygon, Vector2 around, Vector2 direction)
		{
			float num = around.X - direction.X;
			float num2 = (float)Math.Atan2((double)(around.Y - direction.Y), (double)num);
			return polygon.RotatePolygon(around, num2 - Geometry.DegreeToRadian(90.0));
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00011FE0 File Offset: 0x000101E0
		public static Geometry.Polygon ToPolygon(this List<IntPoint> v)
		{
			Geometry.Polygon polygon = new Geometry.Polygon();
			foreach (IntPoint intPoint in v)
			{
				polygon.Add(new Vector2((float)intPoint.X, (float)intPoint.Y));
			}
			return polygon;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00012048 File Offset: 0x00010248
		public static List<Geometry.Polygon> ToPolygons(this List<List<IntPoint>> v)
		{
			return (from path in v
			select path.ToPolygon()).ToList<Geometry.Polygon>();
		}

		// Token: 0x02000488 RID: 1160
		public class Arc : Geometry.Polygon
		{
			// Token: 0x06001568 RID: 5480 RVA: 0x0004C731 File Offset: 0x0004A931
			public Arc(Vector3 start, Vector3 direction, float angle, float radius, int quality = 20) : this(start.ToVector2(), direction.ToVector2(), angle, radius, quality)
			{
			}

			// Token: 0x06001569 RID: 5481 RVA: 0x0004C74A File Offset: 0x0004A94A
			public Arc(Vector2 start, Vector2 end, float angle, float radius, int quality = 20)
			{
				this.StartPos = start;
				this.EndPos = (end - start).Normalized();
				this.Angle = angle;
				this.Radius = radius;
				this._quality = quality;
				this.UpdatePolygon(0);
			}

			// Token: 0x0600156A RID: 5482 RVA: 0x0004C78C File Offset: 0x0004A98C
			public void UpdatePolygon(int offset = 0)
			{
				this.Points.Clear();
				float num = (this.Radius + (float)offset) / (float)Math.Cos(6.283185307179586 / (double)this._quality);
				Vector2 vector = this.EndPos.Rotated(-this.Angle * 0.5f);
				for (int i = 0; i <= this._quality; i++)
				{
					Vector2 vector2 = vector.Rotated((float)i * this.Angle / (float)this._quality).Normalized();
					this.Points.Add(new Vector2(this.StartPos.X + num * vector2.X, this.StartPos.Y + num * vector2.Y));
				}
			}

			// Token: 0x04000BC2 RID: 3010
			private readonly int _quality;

			// Token: 0x04000BC3 RID: 3011
			public float Angle;

			// Token: 0x04000BC4 RID: 3012
			public Vector2 EndPos;

			// Token: 0x04000BC5 RID: 3013
			public float Radius;

			// Token: 0x04000BC6 RID: 3014
			public Vector2 StartPos;
		}

		// Token: 0x02000489 RID: 1161
		public class Circle : Geometry.Polygon
		{
			// Token: 0x0600156B RID: 5483 RVA: 0x0004C845 File Offset: 0x0004AA45
			public Circle(Vector3 center, float radius, int quality = 20) : this(center.ToVector2(), radius, quality)
			{
			}

			// Token: 0x0600156C RID: 5484 RVA: 0x0004C855 File Offset: 0x0004AA55
			public Circle(Vector2 center, float radius, int quality = 20)
			{
				this.Center = center;
				this.Radius = radius;
				this._quality = quality;
				this.UpdatePolygon(0, -1f);
			}

			// Token: 0x0600156D RID: 5485 RVA: 0x0004C880 File Offset: 0x0004AA80
			public void UpdatePolygon(int offset = 0, float overrideWidth = -1f)
			{
				this.Points.Clear();
				float num = (overrideWidth > 0f) ? overrideWidth : (((float)offset + this.Radius) / (float)Math.Cos(6.283185307179586 / (double)this._quality));
				for (int i = 1; i <= this._quality; i++)
				{
					double num2 = (double)(i * 2) * 3.141592653589793 / (double)this._quality;
					Vector2 item = new Vector2(this.Center.X + num * (float)Math.Cos(num2), this.Center.Y + num * (float)Math.Sin(num2));
					this.Points.Add(item);
				}
			}

			// Token: 0x04000BC7 RID: 3015
			private readonly int _quality;

			// Token: 0x04000BC8 RID: 3016
			public Vector2 Center;

			// Token: 0x04000BC9 RID: 3017
			public float Radius;
		}

		// Token: 0x0200048A RID: 1162
		public class Line : Geometry.Polygon
		{
			// Token: 0x0600156E RID: 5486 RVA: 0x0004C92A File Offset: 0x0004AB2A
			public Line(Vector3 start, Vector3 end, float length = -1f) : this(start.ToVector2(), end.ToVector2(), length)
			{
			}

			// Token: 0x0600156F RID: 5487 RVA: 0x0004C93F File Offset: 0x0004AB3F
			public Line(Vector2 start, Vector2 end, float length = -1f)
			{
				this.LineStart = start;
				this.LineEnd = end;
				if (length > 0f)
				{
					this.Length = length;
				}
				this.UpdatePolygon();
			}

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x06001570 RID: 5488 RVA: 0x0004C96A File Offset: 0x0004AB6A
			// (set) Token: 0x06001571 RID: 5489 RVA: 0x0004C97D File Offset: 0x0004AB7D
			public float Length
			{
				get
				{
					return this.LineStart.Distance(this.LineEnd);
				}
				set
				{
					this.LineEnd = (this.LineEnd - this.LineStart).Normalized() * value + this.LineStart;
				}
			}

			// Token: 0x06001572 RID: 5490 RVA: 0x0004C9AC File Offset: 0x0004ABAC
			public void UpdatePolygon()
			{
				this.Points.Clear();
				this.Points.Add(this.LineStart);
				this.Points.Add(this.LineEnd);
			}

			// Token: 0x04000BCA RID: 3018
			public Vector2 LineEnd;

			// Token: 0x04000BCB RID: 3019
			public Vector2 LineStart;
		}

		// Token: 0x0200048B RID: 1163
		public class Polygon
		{
			// Token: 0x06001573 RID: 5491 RVA: 0x0004C9DB File Offset: 0x0004ABDB
			public void Add(Vector2 point)
			{
				this.Points.Add(point);
			}

			// Token: 0x06001574 RID: 5492 RVA: 0x0004C9E9 File Offset: 0x0004ABE9
			public void Add(Vector3 point)
			{
				this.Points.Add(point.ToVector2());
			}

			// Token: 0x06001575 RID: 5493 RVA: 0x0004C9FC File Offset: 0x0004ABFC
			public void Add(Geometry.Polygon polygon)
			{
				foreach (Vector2 item in polygon.Points)
				{
					this.Points.Add(item);
				}
			}

			// Token: 0x06001576 RID: 5494 RVA: 0x0004CA54 File Offset: 0x0004AC54
			public virtual void Draw(System.Drawing.Color color, int width = 1)
			{
				for (int i = 0; i <= this.Points.Count - 1; i++)
				{
					int index = (this.Points.Count - 1 == i) ? 0 : (i + 1);
					Vector2 vector = Drawing.WorldToScreen(this.Points[i].ToVector3(0f));
					Vector2 vector2 = Drawing.WorldToScreen(this.Points[index].ToVector3(0f));
					if (vector.IsValid() && vector2.IsValid())
					{
						Drawing.DrawLine(vector[0], vector[1], vector2[0], vector2[1], (float)width, color);
					}
				}
			}

			// Token: 0x06001577 RID: 5495 RVA: 0x0004CB06 File Offset: 0x0004AD06
			public bool IsInside(Vector2 point)
			{
				return !this.IsOutside(point);
			}

			// Token: 0x06001578 RID: 5496 RVA: 0x0004CB12 File Offset: 0x0004AD12
			public bool IsInside(Vector3 point)
			{
				return !this.IsOutside(point.ToVector2());
			}

			// Token: 0x06001579 RID: 5497 RVA: 0x0004CB23 File Offset: 0x0004AD23
			public bool IsInside(GameObject point)
			{
				return !this.IsOutside(point.Position.ToVector2());
			}

			// Token: 0x0600157A RID: 5498 RVA: 0x0004CB39 File Offset: 0x0004AD39
			public bool IsOutside(Vector2 point)
			{
				return Clipper.PointInPolygon(new IntPoint((double)point.X, (double)point.Y), this.ToClipperPath()) != 1;
			}

			// Token: 0x0600157B RID: 5499 RVA: 0x0004CB60 File Offset: 0x0004AD60
			public List<IntPoint> ToClipperPath()
			{
				List<IntPoint> list = new List<IntPoint>(this.Points.Count);
				list.AddRange(from point in this.Points
				select new IntPoint((double)point.X, (double)point.Y));
				return list;
			}

			// Token: 0x04000BCC RID: 3020
			public List<Vector2> Points = new List<Vector2>();
		}

		// Token: 0x0200048C RID: 1164
		public class Rectangle : Geometry.Polygon
		{
			// Token: 0x0600157D RID: 5501 RVA: 0x0004CBC0 File Offset: 0x0004ADC0
			public Rectangle(Vector3 start, Vector3 end, float width) : this(start.ToVector2(), end.ToVector2(), width)
			{
			}

			// Token: 0x0600157E RID: 5502 RVA: 0x0004CBD5 File Offset: 0x0004ADD5
			public Rectangle(Vector2 start, Vector2 end, float width)
			{
				this.Start = start;
				this.End = end;
				this.Width = width;
				this.UpdatePolygon(0, -1f);
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x0600157F RID: 5503 RVA: 0x0004CBFE File Offset: 0x0004ADFE
			public Vector2 Direction
			{
				get
				{
					return (this.End - this.Start).Normalized();
				}
			}

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x06001580 RID: 5504 RVA: 0x0004CC16 File Offset: 0x0004AE16
			public Vector2 Perpendicular
			{
				get
				{
					return this.Direction.Perpendicular(0);
				}
			}

			// Token: 0x06001581 RID: 5505 RVA: 0x0004CC24 File Offset: 0x0004AE24
			public void UpdatePolygon(int offset = 0, float overrideWidth = -1f)
			{
				this.Points.Clear();
				this.Points.Add(this.Start + ((overrideWidth > 0f) ? overrideWidth : (this.Width + (float)offset)) * this.Perpendicular - (float)offset * this.Direction);
				this.Points.Add(this.Start - ((overrideWidth > 0f) ? overrideWidth : (this.Width + (float)offset)) * this.Perpendicular - (float)offset * this.Direction);
				this.Points.Add(this.End - ((overrideWidth > 0f) ? overrideWidth : (this.Width + (float)offset)) * this.Perpendicular + (float)offset * this.Direction);
				this.Points.Add(this.End + ((overrideWidth > 0f) ? overrideWidth : (this.Width + (float)offset)) * this.Perpendicular + (float)offset * this.Direction);
			}

			// Token: 0x04000BCD RID: 3021
			public Vector2 End;

			// Token: 0x04000BCE RID: 3022
			public Vector2 Start;

			// Token: 0x04000BCF RID: 3023
			public float Width;
		}

		// Token: 0x0200048D RID: 1165
		public class Ring : Geometry.Polygon
		{
			// Token: 0x06001582 RID: 5506 RVA: 0x0004CD58 File Offset: 0x0004AF58
			public Ring(Vector3 center, float innerRadius, float outerRadius, int quality = 20) : this(center.ToVector2(), innerRadius, outerRadius, quality)
			{
			}

			// Token: 0x06001583 RID: 5507 RVA: 0x0004CD6A File Offset: 0x0004AF6A
			public Ring(Vector2 center, float innerRadius, float outerRadius, int quality = 20)
			{
				this.Center = center;
				this.InnerRadius = innerRadius;
				this.OuterRadius = outerRadius;
				this._quality = quality;
				this.UpdatePolygon(0);
			}

			// Token: 0x06001584 RID: 5508 RVA: 0x0004CD98 File Offset: 0x0004AF98
			public void UpdatePolygon(int offset = 0)
			{
				this.Points.Clear();
				float num = ((float)offset + this.InnerRadius + this.OuterRadius) / (float)Math.Cos(6.283185307179586 / (double)this._quality);
				float num2 = this.InnerRadius - this.OuterRadius - (float)offset;
				for (int i = 0; i <= this._quality; i++)
				{
					double num3 = (double)(i * 2) * 3.141592653589793 / (double)this._quality;
					Vector2 item = new Vector2(this.Center.X - num * (float)Math.Cos(num3), this.Center.Y - num * (float)Math.Sin(num3));
					this.Points.Add(item);
				}
				for (int j = 0; j <= this._quality; j++)
				{
					double num4 = (double)(j * 2) * 3.141592653589793 / (double)this._quality;
					Vector2 item2 = new Vector2(this.Center.X + num2 * (float)Math.Cos(num4), this.Center.Y - num2 * (float)Math.Sin(num4));
					this.Points.Add(item2);
				}
			}

			// Token: 0x04000BD0 RID: 3024
			private readonly int _quality;

			// Token: 0x04000BD1 RID: 3025
			public Vector2 Center;

			// Token: 0x04000BD2 RID: 3026
			public float InnerRadius;

			// Token: 0x04000BD3 RID: 3027
			public float OuterRadius;
		}

		// Token: 0x0200048E RID: 1166
		public class Sector : Geometry.Polygon
		{
			// Token: 0x06001585 RID: 5509 RVA: 0x0004CEBE File Offset: 0x0004B0BE
			public Sector(Vector3 center, Vector3 endPosition, float angle, float radius, int quality = 20) : this(center.ToVector2(), endPosition.ToVector2(), angle, radius, quality)
			{
			}

			// Token: 0x06001586 RID: 5510 RVA: 0x0004CED7 File Offset: 0x0004B0D7
			public Sector(Vector2 center, Vector2 endPosition, float angle, float radius, int quality = 20)
			{
				this.Center = center;
				this.Direction = (endPosition - center).Normalized();
				this.Angle = angle;
				this.Radius = radius;
				this._quality = quality;
				this.UpdatePolygon(0);
			}

			// Token: 0x06001587 RID: 5511 RVA: 0x0004CF18 File Offset: 0x0004B118
			public Vector2 RotateLineFromPoint(Vector2 point1, Vector2 point2, float value, bool radian = true)
			{
				double num = (!radian) ? ((double)value * 3.141592653589793 / 180.0) : ((double)value);
				Vector2 vector = Vector2.Subtract(point2, point1);
				return Vector2.Add(new Vector2
				{
					X = (float)((double)vector.X * Math.Cos(num) - (double)vector.Y * Math.Sin(num)),
					Y = (float)((double)vector.X * Math.Sin(num) + (double)vector.Y * Math.Cos(num))
				}, point1);
			}

			// Token: 0x06001588 RID: 5512 RVA: 0x0004CFA8 File Offset: 0x0004B1A8
			public void UpdatePolygon(int offset = 0)
			{
				this.Points.Clear();
				float num = (this.Radius + (float)offset) / (float)Math.Cos(6.283185307179586 / (double)this._quality);
				this.Points.Add(this.Center);
				Vector2 vector = this.Direction.Rotated(-this.Angle * 0.5f);
				for (int i = 0; i <= this._quality; i++)
				{
					Vector2 vector2 = vector.Rotated((float)i * this.Angle / (float)this._quality).Normalized();
					this.Points.Add(new Vector2(this.Center.X + num * vector2.X, this.Center.Y + num * vector2.Y));
				}
			}

			// Token: 0x04000BD4 RID: 3028
			private readonly int _quality;

			// Token: 0x04000BD5 RID: 3029
			public float Angle;

			// Token: 0x04000BD6 RID: 3030
			public Vector2 Center;

			// Token: 0x04000BD7 RID: 3031
			public Vector2 Direction;

			// Token: 0x04000BD8 RID: 3032
			public float Radius;
		}
	}
}
