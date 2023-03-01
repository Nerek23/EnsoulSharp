using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000062 RID: 98
	public class ClipperOffset
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x0002129C File Offset: 0x0001F49C
		public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
		{
			this.MiterLimit = miterLimit;
			this.ArcTolerance = arcTolerance;
			this.m_lowest.X = -1L;
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x000212D5 File Offset: 0x0001F4D5
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x000212DD File Offset: 0x0001F4DD
		public double ArcTolerance { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x000212E6 File Offset: 0x0001F4E6
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x000212EE File Offset: 0x0001F4EE
		public double MiterLimit { get; set; }

		// Token: 0x0600044D RID: 1101 RVA: 0x000212F7 File Offset: 0x0001F4F7
		public void Clear()
		{
			this.m_polyNodes.Childs.Clear();
			this.m_lowest.X = -1L;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00021316 File Offset: 0x0001F516
		internal static long Round(double value)
		{
			if (value >= 0.0)
			{
				return (long)(value + 0.5);
			}
			return (long)(value - 0.5);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00021340 File Offset: 0x0001F540
		public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
		{
			int num = path.Count - 1;
			if (num < 0)
			{
				return;
			}
			PolyNode polyNode = new PolyNode
			{
				m_jointype = joinType,
				m_endtype = endType
			};
			if (endType != EndType.etClosedLine)
			{
				if (endType != EndType.etClosedPolygon)
				{
					goto IL_48;
				}
			}
			while (num > 0 && path[0] == path[num])
			{
				num--;
			}
			IL_48:
			polyNode.m_polygon.Capacity = num + 1;
			polyNode.m_polygon.Add(path[0]);
			int num2 = 0;
			int num3 = 0;
			for (int i = 1; i <= num; i++)
			{
				if (polyNode.m_polygon[num2] != path[i])
				{
					num2++;
					polyNode.m_polygon.Add(path[i]);
					if (path[i].Y > polyNode.m_polygon[num3].Y || (path[i].Y == polyNode.m_polygon[num3].Y && path[i].X < polyNode.m_polygon[num3].X))
					{
						num3 = num2;
					}
				}
			}
			if (endType == EndType.etClosedPolygon && num2 < 2)
			{
				return;
			}
			this.m_polyNodes.AddChild(polyNode);
			if (endType != EndType.etClosedPolygon)
			{
				return;
			}
			if (this.m_lowest.X < 0L)
			{
				this.m_lowest = new IntPoint((long)(this.m_polyNodes.ChildCount - 1), (long)num3);
				return;
			}
			IntPoint intPoint = this.m_polyNodes.Childs[(int)this.m_lowest.X].m_polygon[(int)this.m_lowest.Y];
			if (polyNode.m_polygon[num3].Y > intPoint.Y || (polyNode.m_polygon[num3].Y == intPoint.Y && polyNode.m_polygon[num3].X < intPoint.X))
			{
				this.m_lowest = new IntPoint((long)(this.m_polyNodes.ChildCount - 1), (long)num3);
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00021544 File Offset: 0x0001F744
		public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
		{
			foreach (List<IntPoint> path in paths)
			{
				this.AddPath(path, joinType, endType);
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00021594 File Offset: 0x0001F794
		private void FixOrientations()
		{
			if (this.m_lowest.X >= 0L && !Clipper.Orientation(this.m_polyNodes.Childs[(int)this.m_lowest.X].m_polygon))
			{
				for (int i = 0; i < this.m_polyNodes.ChildCount; i++)
				{
					PolyNode polyNode = this.m_polyNodes.Childs[i];
					if (polyNode.m_endtype == EndType.etClosedPolygon || (polyNode.m_endtype == EndType.etClosedLine && Clipper.Orientation(polyNode.m_polygon)))
					{
						polyNode.m_polygon.Reverse();
					}
				}
				return;
			}
			for (int j = 0; j < this.m_polyNodes.ChildCount; j++)
			{
				PolyNode polyNode2 = this.m_polyNodes.Childs[j];
				if (polyNode2.m_endtype == EndType.etClosedLine && !Clipper.Orientation(polyNode2.m_polygon))
				{
					polyNode2.m_polygon.Reverse();
				}
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00021674 File Offset: 0x0001F874
		internal static DoublePoint GetUnitNormal(IntPoint pt1, IntPoint pt2)
		{
			double num = (double)(pt2.X - pt1.X);
			double num2 = (double)(pt2.Y - pt1.Y);
			if (num == 0.0 && num2 == 0.0)
			{
				return default(DoublePoint);
			}
			double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
			num *= num3;
			num2 *= num3;
			return new DoublePoint(num2, -num);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000216E8 File Offset: 0x0001F8E8
		private void DoOffset(double delta)
		{
			this.m_destPolys = new List<List<IntPoint>>();
			this.m_delta = delta;
			if (ClipperBase.Near_zero(delta))
			{
				this.m_destPolys.Capacity = this.m_polyNodes.ChildCount;
				for (int i = 0; i < this.m_polyNodes.ChildCount; i++)
				{
					PolyNode polyNode = this.m_polyNodes.Childs[i];
					if (polyNode.m_endtype == EndType.etClosedPolygon)
					{
						this.m_destPolys.Add(polyNode.m_polygon);
					}
				}
				return;
			}
			if (this.MiterLimit > 2.0)
			{
				this.m_miterLim = 2.0 / (this.MiterLimit * this.MiterLimit);
			}
			else
			{
				this.m_miterLim = 0.5;
			}
			double num;
			if (this.ArcTolerance <= 0.0)
			{
				num = 0.25;
			}
			else if (this.ArcTolerance > Math.Abs(delta) * 0.25)
			{
				num = Math.Abs(delta) * 0.25;
			}
			else
			{
				num = this.ArcTolerance;
			}
			double num2 = 3.141592653589793 / Math.Acos(1.0 - num / Math.Abs(delta));
			this.m_sin = Math.Sin(6.283185307179586 / num2);
			this.m_cos = Math.Cos(6.283185307179586 / num2);
			this.m_StepsPerRad = num2 / 6.283185307179586;
			if (delta < 0.0)
			{
				this.m_sin = -this.m_sin;
			}
			this.m_destPolys.Capacity = this.m_polyNodes.ChildCount * 2;
			for (int j = 0; j < this.m_polyNodes.ChildCount; j++)
			{
				PolyNode polyNode2 = this.m_polyNodes.Childs[j];
				this.m_srcPoly = polyNode2.m_polygon;
				int count = this.m_srcPoly.Count;
				if (count != 0 && (delta > 0.0 || (count >= 3 && polyNode2.m_endtype == EndType.etClosedPolygon)))
				{
					this.m_destPoly = new List<IntPoint>();
					if (count == 1)
					{
						if (polyNode2.m_jointype == JoinType.jtRound)
						{
							double num3 = 1.0;
							double num4 = 0.0;
							int num5 = 1;
							while ((double)num5 <= num2)
							{
								this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[0].X + num3 * delta), ClipperOffset.Round((double)this.m_srcPoly[0].Y + num4 * delta)));
								double num6 = num3;
								num3 = num3 * this.m_cos - this.m_sin * num4;
								num4 = num6 * this.m_sin + num4 * this.m_cos;
								num5++;
							}
						}
						else
						{
							double num7 = -1.0;
							double num8 = -1.0;
							for (int k = 0; k < 4; k++)
							{
								this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[0].X + num7 * delta), ClipperOffset.Round((double)this.m_srcPoly[0].Y + num8 * delta)));
								if (num7 < 0.0)
								{
									num7 = 1.0;
								}
								else if (num8 < 0.0)
								{
									num8 = 1.0;
								}
								else
								{
									num7 = -1.0;
								}
							}
						}
						this.m_destPolys.Add(this.m_destPoly);
					}
					else
					{
						this.m_normals.Clear();
						this.m_normals.Capacity = count;
						for (int l = 0; l < count - 1; l++)
						{
							this.m_normals.Add(ClipperOffset.GetUnitNormal(this.m_srcPoly[l], this.m_srcPoly[l + 1]));
						}
						if (polyNode2.m_endtype == EndType.etClosedLine || polyNode2.m_endtype == EndType.etClosedPolygon)
						{
							this.m_normals.Add(ClipperOffset.GetUnitNormal(this.m_srcPoly[count - 1], this.m_srcPoly[0]));
						}
						else
						{
							this.m_normals.Add(new DoublePoint(this.m_normals[count - 2]));
						}
						EndType endtype = polyNode2.m_endtype;
						if (endtype != EndType.etClosedPolygon)
						{
							if (endtype != EndType.etClosedLine)
							{
								int num9 = 0;
								for (int m = 1; m < count - 1; m++)
								{
									this.OffsetPoint(m, ref num9, polyNode2.m_jointype);
								}
								if (polyNode2.m_endtype == EndType.etOpenButt)
								{
									int index = count - 1;
									IntPoint item = new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[index].X + this.m_normals[index].X * delta), ClipperOffset.Round((double)this.m_srcPoly[index].Y + this.m_normals[index].Y * delta));
									this.m_destPoly.Add(item);
									item = new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[index].X - this.m_normals[index].X * delta), ClipperOffset.Round((double)this.m_srcPoly[index].Y - this.m_normals[index].Y * delta));
									this.m_destPoly.Add(item);
								}
								else
								{
									int num10 = count - 1;
									num9 = count - 2;
									this.m_sinA = 0.0;
									this.m_normals[num10] = new DoublePoint(-this.m_normals[num10].X, -this.m_normals[num10].Y);
									if (polyNode2.m_endtype == EndType.etOpenSquare)
									{
										this.DoSquare(num10, num9);
									}
									else
									{
										this.DoRound(num10, num9);
									}
								}
								for (int n = count - 1; n > 0; n--)
								{
									this.m_normals[n] = new DoublePoint(-this.m_normals[n - 1].X, -this.m_normals[n - 1].Y);
								}
								this.m_normals[0] = new DoublePoint(-this.m_normals[1].X, -this.m_normals[1].Y);
								num9 = count - 1;
								for (int num11 = num9 - 1; num11 > 0; num11--)
								{
									this.OffsetPoint(num11, ref num9, polyNode2.m_jointype);
								}
								if (polyNode2.m_endtype == EndType.etOpenButt)
								{
									IntPoint item = new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[0].X - this.m_normals[0].X * delta), ClipperOffset.Round((double)this.m_srcPoly[0].Y - this.m_normals[0].Y * delta));
									this.m_destPoly.Add(item);
									item = new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[0].X + this.m_normals[0].X * delta), ClipperOffset.Round((double)this.m_srcPoly[0].Y + this.m_normals[0].Y * delta));
									this.m_destPoly.Add(item);
								}
								else
								{
									this.m_sinA = 0.0;
									if (polyNode2.m_endtype == EndType.etOpenSquare)
									{
										this.DoSquare(0, 1);
									}
									else
									{
										this.DoRound(0, 1);
									}
								}
								this.m_destPolys.Add(this.m_destPoly);
							}
							else
							{
								int num12 = count - 1;
								for (int num13 = 0; num13 < count; num13++)
								{
									this.OffsetPoint(num13, ref num12, polyNode2.m_jointype);
								}
								this.m_destPolys.Add(this.m_destPoly);
								this.m_destPoly = new List<IntPoint>();
								DoublePoint doublePoint = this.m_normals[count - 1];
								for (int num14 = count - 1; num14 > 0; num14--)
								{
									this.m_normals[num14] = new DoublePoint(-this.m_normals[num14 - 1].X, -this.m_normals[num14 - 1].Y);
								}
								this.m_normals[0] = new DoublePoint(-doublePoint.X, -doublePoint.Y);
								num12 = 0;
								for (int num15 = count - 1; num15 >= 0; num15--)
								{
									this.OffsetPoint(num15, ref num12, polyNode2.m_jointype);
								}
								this.m_destPolys.Add(this.m_destPoly);
							}
						}
						else
						{
							int num16 = count - 1;
							for (int num17 = 0; num17 < count; num17++)
							{
								this.OffsetPoint(num17, ref num16, polyNode2.m_jointype);
							}
							this.m_destPolys.Add(this.m_destPoly);
						}
					}
				}
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00021FE8 File Offset: 0x000201E8
		public void Execute(ref List<List<IntPoint>> solution, double delta)
		{
			solution.Clear();
			this.FixOrientations();
			this.DoOffset(delta);
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(this.m_destPolys, PolyType.ptSubject, true);
			if (delta > 0.0)
			{
				clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
				return;
			}
			IntRect bounds = ClipperBase.GetBounds(this.m_destPolys);
			List<IntPoint> pg = new List<IntPoint>(4)
			{
				new IntPoint(bounds.left - 10L, bounds.bottom + 10L),
				new IntPoint(bounds.right + 10L, bounds.bottom + 10L),
				new IntPoint(bounds.right + 10L, bounds.top - 10L),
				new IntPoint(bounds.left - 10L, bounds.top - 10L)
			};
			clipper.AddPath(pg, PolyType.ptSubject, true);
			clipper.ReverseSolution = true;
			clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (solution.Count > 0)
			{
				solution.RemoveAt(0);
			}
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000220F8 File Offset: 0x000202F8
		public void Execute(ref PolyTree solution, double delta)
		{
			solution.Clear();
			this.FixOrientations();
			this.DoOffset(delta);
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(this.m_destPolys, PolyType.ptSubject, true);
			if (delta > 0.0)
			{
				clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
				return;
			}
			IntRect bounds = ClipperBase.GetBounds(this.m_destPolys);
			List<IntPoint> pg = new List<IntPoint>(4)
			{
				new IntPoint(bounds.left - 10L, bounds.bottom + 10L),
				new IntPoint(bounds.right + 10L, bounds.bottom + 10L),
				new IntPoint(bounds.right + 10L, bounds.top - 10L),
				new IntPoint(bounds.left - 10L, bounds.top - 10L)
			};
			clipper.AddPath(pg, PolyType.ptSubject, true);
			clipper.ReverseSolution = true;
			clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (solution.ChildCount == 1 && solution.Childs[0].ChildCount > 0)
			{
				PolyNode polyNode = solution.Childs[0];
				solution.Childs.Capacity = polyNode.ChildCount;
				solution.Childs[0] = polyNode.Childs[0];
				solution.Childs[0].m_Parent = solution;
				for (int i = 1; i < polyNode.ChildCount; i++)
				{
					solution.AddChild(polyNode.Childs[i]);
				}
				return;
			}
			solution.Clear();
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00022294 File Offset: 0x00020494
		private void OffsetPoint(int j, ref int k, JoinType jointype)
		{
			this.m_sinA = this.m_normals[k].X * this.m_normals[j].Y - this.m_normals[j].X * this.m_normals[k].Y;
			if (Math.Abs(this.m_sinA * this.m_delta) < 1.0)
			{
				if (this.m_normals[k].X * this.m_normals[j].X + this.m_normals[j].Y * this.m_normals[k].Y > 0.0)
				{
					this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_normals[k].X * this.m_delta), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_normals[k].Y * this.m_delta)));
					return;
				}
			}
			else if (this.m_sinA > 1.0)
			{
				this.m_sinA = 1.0;
			}
			else if (this.m_sinA < -1.0)
			{
				this.m_sinA = -1.0;
			}
			if (this.m_sinA * this.m_delta < 0.0)
			{
				this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_normals[k].X * this.m_delta), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_normals[k].Y * this.m_delta)));
				this.m_destPoly.Add(this.m_srcPoly[j]);
				this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_normals[j].X * this.m_delta), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_normals[j].Y * this.m_delta)));
			}
			else
			{
				switch (jointype)
				{
				case JoinType.jtSquare:
					this.DoSquare(j, k);
					break;
				case JoinType.jtRound:
					this.DoRound(j, k);
					break;
				case JoinType.jtMiter:
				{
					double num = 1.0 + (this.m_normals[j].X * this.m_normals[k].X + this.m_normals[j].Y * this.m_normals[k].Y);
					if (num >= this.m_miterLim)
					{
						this.DoMiter(j, k, num);
					}
					else
					{
						this.DoSquare(j, k);
					}
					break;
				}
				}
			}
			k = j;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000225D8 File Offset: 0x000207D8
		internal void DoSquare(int j, int k)
		{
			double num = Math.Tan(Math.Atan2(this.m_sinA, this.m_normals[k].X * this.m_normals[j].X + this.m_normals[k].Y * this.m_normals[j].Y) / 4.0);
			this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_delta * (this.m_normals[k].X - this.m_normals[k].Y * num)), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_delta * (this.m_normals[k].Y + this.m_normals[k].X * num))));
			this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_delta * (this.m_normals[j].X + this.m_normals[j].Y * num)), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_delta * (this.m_normals[j].Y - this.m_normals[j].X * num))));
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00022778 File Offset: 0x00020978
		internal void DoMiter(int j, int k, double r)
		{
			double num = this.m_delta / r;
			this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + (this.m_normals[k].X + this.m_normals[j].X) * num), ClipperOffset.Round((double)this.m_srcPoly[j].Y + (this.m_normals[k].Y + this.m_normals[j].Y) * num)));
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00022818 File Offset: 0x00020A18
		internal void DoRound(int j, int k)
		{
			double value = Math.Atan2(this.m_sinA, this.m_normals[k].X * this.m_normals[j].X + this.m_normals[k].Y * this.m_normals[j].Y);
			int num = Math.Max((int)ClipperOffset.Round(this.m_StepsPerRad * Math.Abs(value)), 1);
			double num2 = this.m_normals[k].X;
			double num3 = this.m_normals[k].Y;
			for (int i = 0; i < num; i++)
			{
				this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + num2 * this.m_delta), ClipperOffset.Round((double)this.m_srcPoly[j].Y + num3 * this.m_delta)));
				double num4 = num2;
				num2 = num2 * this.m_cos - this.m_sin * num3;
				num3 = num4 * this.m_sin + num3 * this.m_cos;
			}
			this.m_destPoly.Add(new IntPoint(ClipperOffset.Round((double)this.m_srcPoly[j].X + this.m_normals[j].X * this.m_delta), ClipperOffset.Round((double)this.m_srcPoly[j].Y + this.m_normals[j].Y * this.m_delta)));
		}

		// Token: 0x04000222 RID: 546
		private const double two_pi = 6.283185307179586;

		// Token: 0x04000223 RID: 547
		private const double def_arc_tolerance = 0.25;

		// Token: 0x04000224 RID: 548
		private readonly List<DoublePoint> m_normals = new List<DoublePoint>();

		// Token: 0x04000225 RID: 549
		private readonly PolyNode m_polyNodes = new PolyNode();

		// Token: 0x04000226 RID: 550
		private double m_delta;

		// Token: 0x04000227 RID: 551
		private double m_sinA;

		// Token: 0x04000228 RID: 552
		private double m_sin;

		// Token: 0x04000229 RID: 553
		private double m_cos;

		// Token: 0x0400022A RID: 554
		private List<IntPoint> m_destPoly;

		// Token: 0x0400022B RID: 555
		private List<List<IntPoint>> m_destPolys;

		// Token: 0x0400022C RID: 556
		private IntPoint m_lowest;

		// Token: 0x0400022D RID: 557
		private double m_miterLim;

		// Token: 0x0400022E RID: 558
		private double m_StepsPerRad;

		// Token: 0x0400022F RID: 559
		private List<IntPoint> m_srcPoly;
	}
}
