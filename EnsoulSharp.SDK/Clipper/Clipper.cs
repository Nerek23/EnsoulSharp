using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000061 RID: 97
	public class Clipper : ClipperBase
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x0001BF84 File Offset: 0x0001A184
		public Clipper(int InitOptions = 0)
		{
			this.m_Scanbeam = null;
			this.m_Maxima = null;
			this.m_ActiveEdges = null;
			this.m_SortedEdges = null;
			this.m_IntersectList = new List<IntersectNode>();
			this.m_IntersectNodeComparer = new MyIntersectNodeSort();
			this.m_ExecuteLocked = false;
			this.m_UsingPolyTree = false;
			this.m_PolyOuts = new List<OutRec>();
			this.m_Joins = new List<Join>();
			this.m_GhostJoins = new List<Join>();
			this.ReverseSolution = ((1 & InitOptions) != 0);
			this.StrictlySimple = ((2 & InitOptions) != 0);
			base.PreserveCollinear = ((4 & InitOptions) != 0);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x0001C01C File Offset: 0x0001A21C
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x0001C024 File Offset: 0x0001A224
		public bool ReverseSolution { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0001C02D File Offset: 0x0001A22D
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0001C035 File Offset: 0x0001A235
		public bool StrictlySimple { get; set; }

		// Token: 0x060003E6 RID: 998 RVA: 0x0001C040 File Offset: 0x0001A240
		private void InsertMaxima(long X)
		{
			Maxima maxima = new Maxima
			{
				X = X
			};
			if (this.m_Maxima == null)
			{
				this.m_Maxima = maxima;
				this.m_Maxima.Next = null;
				this.m_Maxima.Prev = null;
				return;
			}
			if (X < this.m_Maxima.X)
			{
				maxima.Next = this.m_Maxima;
				maxima.Prev = null;
				this.m_Maxima = maxima;
				return;
			}
			Maxima maxima2 = this.m_Maxima;
			while (maxima2.Next != null && X >= maxima2.Next.X)
			{
				maxima2 = maxima2.Next;
			}
			if (X == maxima2.X)
			{
				return;
			}
			maxima.Next = maxima2.Next;
			maxima.Prev = maxima2;
			if (maxima2.Next != null)
			{
				maxima2.Next.Prev = maxima;
			}
			maxima2.Next = maxima;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0001C109 File Offset: 0x0001A309
		public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType FillType = PolyFillType.pftEvenOdd)
		{
			return this.Execute(clipType, solution, FillType, FillType);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001C115 File Offset: 0x0001A315
		public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType FillType = PolyFillType.pftEvenOdd)
		{
			return this.Execute(clipType, polytree, FillType, FillType);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001C124 File Offset: 0x0001A324
		public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType subjFillType, PolyFillType clipFillType)
		{
			if (this.m_ExecuteLocked)
			{
				return false;
			}
			if (this.m_HasOpenPaths)
			{
				throw new ClipperException("Error: PolyTree struct is needed for open path clipping.");
			}
			this.m_ExecuteLocked = true;
			solution.Clear();
			this.m_SubjFillType = subjFillType;
			this.m_ClipFillType = clipFillType;
			this.m_ClipType = clipType;
			this.m_UsingPolyTree = false;
			bool flag = this.ExecuteInternal();
			if (flag)
			{
				this.BuildResult(solution);
			}
			return flag;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0001C188 File Offset: 0x0001A388
		public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType subjFillType, PolyFillType clipFillType)
		{
			if (this.m_ExecuteLocked)
			{
				return false;
			}
			this.m_ExecuteLocked = true;
			this.m_SubjFillType = subjFillType;
			this.m_ClipFillType = clipFillType;
			this.m_ClipType = clipType;
			this.m_UsingPolyTree = true;
			bool flag = this.ExecuteInternal();
			if (flag)
			{
				this.BuildResult2(polytree);
			}
			return flag;
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001C1C8 File Offset: 0x0001A3C8
		internal void FixHoleLinkage(OutRec outRec)
		{
			if (outRec.FirstLeft == null || (outRec.IsHole != outRec.FirstLeft.IsHole && outRec.FirstLeft.Pts != null))
			{
				return;
			}
			OutRec firstLeft = outRec.FirstLeft;
			while (firstLeft != null && (firstLeft.IsHole == outRec.IsHole || firstLeft.Pts == null))
			{
				firstLeft = firstLeft.FirstLeft;
			}
			outRec.FirstLeft = firstLeft;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0001C230 File Offset: 0x0001A430
		private bool ExecuteInternal()
		{
			this.Reset();
			this.m_SortedEdges = null;
			this.m_Maxima = null;
			long botY;
			if (!base.PopScanbeam(out botY))
			{
				return false;
			}
			this.InsertLocalMinimaIntoAEL(botY);
			long num;
			while (base.PopScanbeam(out num) || base.LocalMinimaPending())
			{
				this.ProcessHorizontals();
				this.m_GhostJoins.Clear();
				if (!this.ProcessIntersections(num))
				{
					return false;
				}
				this.ProcessEdgesAtTopOfScanbeam(num);
				botY = num;
				this.InsertLocalMinimaIntoAEL(botY);
			}
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				if (outRec.Pts != null && !outRec.IsOpen && (outRec.IsHole ^ this.ReverseSolution) == this.Area(outRec) > 0.0)
				{
					this.ReversePolyPtLinks(outRec.Pts);
				}
			}
			this.JoinCommonEdges();
			foreach (OutRec outRec2 in this.m_PolyOuts)
			{
				if (outRec2.Pts != null)
				{
					if (outRec2.IsOpen)
					{
						this.FixupOutPolyline(outRec2);
					}
					else
					{
						this.FixupOutPolygon(outRec2);
					}
				}
			}
			if (this.StrictlySimple)
			{
				this.DoSimplePolygons();
			}
			return true;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0001C398 File Offset: 0x0001A598
		private void DisposeAllPolyPts()
		{
			for (int i = 0; i < this.m_PolyOuts.Count; i++)
			{
				base.DisposeOutRec(i);
			}
			this.m_PolyOuts.Clear();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0001C3D0 File Offset: 0x0001A5D0
		private void AddJoin(OutPt Op1, OutPt Op2, IntPoint OffPt)
		{
			Join item = new Join
			{
				OutPt1 = Op1,
				OutPt2 = Op2,
				OffPt = OffPt
			};
			this.m_Joins.Add(item);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0001C404 File Offset: 0x0001A604
		private void AddGhostJoin(OutPt Op, IntPoint OffPt)
		{
			Join item = new Join
			{
				OutPt1 = Op,
				OffPt = OffPt
			};
			this.m_GhostJoins.Add(item);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001C434 File Offset: 0x0001A634
		private void InsertLocalMinimaIntoAEL(long botY)
		{
			LocalMinima localMinima;
			while (base.PopLocalMinima(botY, out localMinima))
			{
				TEdge leftBound = localMinima.LeftBound;
				TEdge rightBound = localMinima.RightBound;
				OutPt outPt = null;
				if (leftBound == null)
				{
					this.InsertEdgeIntoAEL(rightBound, null);
					this.SetWindingCount(rightBound);
					if (this.IsContributing(rightBound))
					{
						outPt = this.AddOutPt(rightBound, rightBound.Bot);
					}
				}
				else if (rightBound == null)
				{
					this.InsertEdgeIntoAEL(leftBound, null);
					this.SetWindingCount(leftBound);
					if (this.IsContributing(leftBound))
					{
						outPt = this.AddOutPt(leftBound, leftBound.Bot);
					}
					base.InsertScanbeam(leftBound.Top.Y);
				}
				else
				{
					this.InsertEdgeIntoAEL(leftBound, null);
					this.InsertEdgeIntoAEL(rightBound, leftBound);
					this.SetWindingCount(leftBound);
					rightBound.WindCnt = leftBound.WindCnt;
					rightBound.WindCnt2 = leftBound.WindCnt2;
					if (this.IsContributing(leftBound))
					{
						outPt = this.AddLocalMinPoly(leftBound, rightBound, leftBound.Bot);
					}
					base.InsertScanbeam(leftBound.Top.Y);
				}
				if (rightBound != null)
				{
					if (ClipperBase.IsHorizontal(rightBound))
					{
						if (rightBound.NextInLML != null)
						{
							base.InsertScanbeam(rightBound.NextInLML.Top.Y);
						}
						this.AddEdgeToSEL(rightBound);
					}
					else
					{
						base.InsertScanbeam(rightBound.Top.Y);
					}
				}
				if (leftBound != null && rightBound != null)
				{
					if (outPt != null && ClipperBase.IsHorizontal(rightBound) && this.m_GhostJoins.Count > 0 && rightBound.WindDelta != 0)
					{
						foreach (Join join in this.m_GhostJoins)
						{
							if (this.HorzSegmentsOverlap(join.OutPt1.Pt.X, join.OffPt.X, rightBound.Bot.X, rightBound.Top.X))
							{
								this.AddJoin(join.OutPt1, outPt, join.OffPt);
							}
						}
					}
					if (leftBound.OutIdx >= 0 && leftBound.PrevInAEL != null && leftBound.PrevInAEL.Curr.X == leftBound.Bot.X && leftBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(leftBound.PrevInAEL.Curr, leftBound.PrevInAEL.Top, leftBound.Curr, leftBound.Top, this.m_UseFullRange) && leftBound.WindDelta != 0 && leftBound.PrevInAEL.WindDelta != 0)
					{
						OutPt op = this.AddOutPt(leftBound.PrevInAEL, leftBound.Bot);
						this.AddJoin(outPt, op, leftBound.Top);
					}
					if (leftBound.NextInAEL != rightBound)
					{
						if (rightBound.OutIdx >= 0 && rightBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(rightBound.PrevInAEL.Curr, rightBound.PrevInAEL.Top, rightBound.Curr, rightBound.Top, this.m_UseFullRange) && rightBound.WindDelta != 0 && rightBound.PrevInAEL.WindDelta != 0)
						{
							OutPt op2 = this.AddOutPt(rightBound.PrevInAEL, rightBound.Bot);
							this.AddJoin(outPt, op2, rightBound.Top);
						}
						TEdge nextInAEL = leftBound.NextInAEL;
						if (nextInAEL != null)
						{
							while (nextInAEL != rightBound)
							{
								this.IntersectEdges(rightBound, nextInAEL, leftBound.Curr);
								nextInAEL = nextInAEL.NextInAEL;
							}
						}
					}
				}
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0001C798 File Offset: 0x0001A998
		private void InsertEdgeIntoAEL(TEdge edge, TEdge startEdge)
		{
			if (this.m_ActiveEdges == null)
			{
				edge.PrevInAEL = null;
				edge.NextInAEL = null;
				this.m_ActiveEdges = edge;
				return;
			}
			if (startEdge == null && this.E2InsertsBeforeE1(this.m_ActiveEdges, edge))
			{
				edge.PrevInAEL = null;
				edge.NextInAEL = this.m_ActiveEdges;
				this.m_ActiveEdges.PrevInAEL = edge;
				this.m_ActiveEdges = edge;
				return;
			}
			if (startEdge == null)
			{
				startEdge = this.m_ActiveEdges;
			}
			while (startEdge.NextInAEL != null && !this.E2InsertsBeforeE1(startEdge.NextInAEL, edge))
			{
				startEdge = startEdge.NextInAEL;
			}
			edge.NextInAEL = startEdge.NextInAEL;
			if (startEdge.NextInAEL != null)
			{
				startEdge.NextInAEL.PrevInAEL = edge;
			}
			edge.PrevInAEL = startEdge;
			startEdge.NextInAEL = edge;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0001C858 File Offset: 0x0001AA58
		private bool E2InsertsBeforeE1(TEdge e1, TEdge e2)
		{
			if (e2.Curr.X != e1.Curr.X)
			{
				return e2.Curr.X < e1.Curr.X;
			}
			if (e2.Top.Y > e1.Top.Y)
			{
				return e2.Top.X < Clipper.TopX(e1, e2.Top.Y);
			}
			return e1.Top.X > Clipper.TopX(e2, e1.Top.Y);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0001C8EB File Offset: 0x0001AAEB
		private bool IsEvenOddFillType(TEdge edge)
		{
			if (edge.PolyTyp == PolyType.ptSubject)
			{
				return this.m_SubjFillType == PolyFillType.pftEvenOdd;
			}
			return this.m_ClipFillType == PolyFillType.pftEvenOdd;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0001C908 File Offset: 0x0001AB08
		private bool IsEvenOddAltFillType(TEdge edge)
		{
			if (edge.PolyTyp == PolyType.ptSubject)
			{
				return this.m_ClipFillType == PolyFillType.pftEvenOdd;
			}
			return this.m_SubjFillType == PolyFillType.pftEvenOdd;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001C928 File Offset: 0x0001AB28
		private bool IsContributing(TEdge edge)
		{
			PolyFillType polyFillType;
			PolyFillType polyFillType2;
			if (edge.PolyTyp == PolyType.ptSubject)
			{
				polyFillType = this.m_SubjFillType;
				polyFillType2 = this.m_ClipFillType;
			}
			else
			{
				polyFillType = this.m_ClipFillType;
				polyFillType2 = this.m_SubjFillType;
			}
			switch (polyFillType)
			{
			case PolyFillType.pftEvenOdd:
				if (edge.WindDelta == 0 && edge.WindCnt != 1)
				{
					return false;
				}
				break;
			case PolyFillType.pftNonZero:
				if (Math.Abs(edge.WindCnt) != 1)
				{
					return false;
				}
				break;
			case PolyFillType.pftPositive:
				if (edge.WindCnt != 1)
				{
					return false;
				}
				break;
			default:
				if (edge.WindCnt != -1)
				{
					return false;
				}
				break;
			}
			switch (this.m_ClipType)
			{
			case ClipType.ctIntersection:
				if (polyFillType2 <= PolyFillType.pftNonZero)
				{
					return edge.WindCnt2 != 0;
				}
				if (polyFillType2 != PolyFillType.pftPositive)
				{
					return edge.WindCnt2 < 0;
				}
				return edge.WindCnt2 > 0;
			case ClipType.ctUnion:
				if (polyFillType2 <= PolyFillType.pftNonZero)
				{
					return edge.WindCnt2 == 0;
				}
				if (polyFillType2 != PolyFillType.pftPositive)
				{
					return edge.WindCnt2 >= 0;
				}
				return edge.WindCnt2 <= 0;
			case ClipType.ctDifference:
				if (edge.PolyTyp == PolyType.ptSubject)
				{
					if (polyFillType2 <= PolyFillType.pftNonZero)
					{
						return edge.WindCnt2 == 0;
					}
					if (polyFillType2 != PolyFillType.pftPositive)
					{
						return edge.WindCnt2 >= 0;
					}
					return edge.WindCnt2 <= 0;
				}
				else
				{
					if (polyFillType2 <= PolyFillType.pftNonZero)
					{
						return edge.WindCnt2 != 0;
					}
					if (polyFillType2 != PolyFillType.pftPositive)
					{
						return edge.WindCnt2 < 0;
					}
					return edge.WindCnt2 > 0;
				}
				break;
			case ClipType.ctXor:
				if (edge.WindDelta != 0)
				{
					return true;
				}
				if (polyFillType2 <= PolyFillType.pftNonZero)
				{
					return edge.WindCnt2 == 0;
				}
				if (polyFillType2 != PolyFillType.pftPositive)
				{
					return edge.WindCnt2 >= 0;
				}
				return edge.WindCnt2 <= 0;
			default:
				return true;
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001CAB8 File Offset: 0x0001ACB8
		private void SetWindingCount(TEdge edge)
		{
			TEdge tedge = edge.PrevInAEL;
			while (tedge != null && (tedge.PolyTyp != edge.PolyTyp || tedge.WindDelta == 0))
			{
				tedge = tedge.PrevInAEL;
			}
			if (tedge == null)
			{
				PolyFillType polyFillType = (edge.PolyTyp == PolyType.ptSubject) ? this.m_SubjFillType : this.m_ClipFillType;
				if (edge.WindDelta == 0)
				{
					edge.WindCnt = ((polyFillType == PolyFillType.pftNegative) ? -1 : 1);
				}
				else
				{
					edge.WindCnt = edge.WindDelta;
				}
				edge.WindCnt2 = 0;
				tedge = this.m_ActiveEdges;
			}
			else if (edge.WindDelta == 0 && this.m_ClipType != ClipType.ctUnion)
			{
				edge.WindCnt = 1;
				edge.WindCnt2 = tedge.WindCnt2;
				tedge = tedge.NextInAEL;
			}
			else if (this.IsEvenOddFillType(edge))
			{
				if (edge.WindDelta == 0)
				{
					bool flag = true;
					for (TEdge prevInAEL = tedge.PrevInAEL; prevInAEL != null; prevInAEL = prevInAEL.PrevInAEL)
					{
						if (prevInAEL.PolyTyp == tedge.PolyTyp && prevInAEL.WindDelta != 0)
						{
							flag = !flag;
						}
					}
					edge.WindCnt = (flag ? 0 : 1);
				}
				else
				{
					edge.WindCnt = edge.WindDelta;
				}
				edge.WindCnt2 = tedge.WindCnt2;
				tedge = tedge.NextInAEL;
			}
			else
			{
				if (tedge.WindCnt * tedge.WindDelta < 0)
				{
					if (Math.Abs(tedge.WindCnt) > 1)
					{
						if (tedge.WindDelta * edge.WindDelta < 0)
						{
							edge.WindCnt = tedge.WindCnt;
						}
						else
						{
							edge.WindCnt = tedge.WindCnt + edge.WindDelta;
						}
					}
					else
					{
						edge.WindCnt = ((edge.WindDelta == 0) ? 1 : edge.WindDelta);
					}
				}
				else if (edge.WindDelta == 0)
				{
					edge.WindCnt = ((tedge.WindCnt < 0) ? (tedge.WindCnt - 1) : (tedge.WindCnt + 1));
				}
				else if (tedge.WindDelta * edge.WindDelta < 0)
				{
					edge.WindCnt = tedge.WindCnt;
				}
				else
				{
					edge.WindCnt = tedge.WindCnt + edge.WindDelta;
				}
				edge.WindCnt2 = tedge.WindCnt2;
				tedge = tedge.NextInAEL;
			}
			if (this.IsEvenOddAltFillType(edge))
			{
				while (tedge != edge)
				{
					if (tedge.WindDelta != 0)
					{
						edge.WindCnt2 = ((edge.WindCnt2 == 0) ? 1 : 0);
					}
					tedge = tedge.NextInAEL;
				}
				return;
			}
			while (tedge != edge)
			{
				edge.WindCnt2 += tedge.WindDelta;
				tedge = tedge.NextInAEL;
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001CD10 File Offset: 0x0001AF10
		private void AddEdgeToSEL(TEdge edge)
		{
			if (this.m_SortedEdges == null)
			{
				this.m_SortedEdges = edge;
				edge.PrevInSEL = null;
				edge.NextInSEL = null;
				return;
			}
			edge.NextInSEL = this.m_SortedEdges;
			edge.PrevInSEL = null;
			this.m_SortedEdges.PrevInSEL = edge;
			this.m_SortedEdges = edge;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001CD64 File Offset: 0x0001AF64
		internal bool PopEdgeFromSEL(out TEdge e)
		{
			e = this.m_SortedEdges;
			if (e == null)
			{
				return false;
			}
			TEdge tedge = e;
			this.m_SortedEdges = e.NextInSEL;
			if (this.m_SortedEdges != null)
			{
				this.m_SortedEdges.PrevInSEL = null;
			}
			tedge.NextInSEL = null;
			tedge.PrevInSEL = null;
			return true;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001CDB0 File Offset: 0x0001AFB0
		private void CopyAELToSEL()
		{
			TEdge tedge = this.m_ActiveEdges;
			this.m_SortedEdges = tedge;
			while (tedge != null)
			{
				tedge.PrevInSEL = tedge.PrevInAEL;
				tedge.NextInSEL = tedge.NextInAEL;
				tedge = tedge.NextInAEL;
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001CDF0 File Offset: 0x0001AFF0
		private void SwapPositionsInSEL(TEdge edge1, TEdge edge2)
		{
			if (edge1.NextInSEL == null && edge1.PrevInSEL == null)
			{
				return;
			}
			if (edge2.NextInSEL == null && edge2.PrevInSEL == null)
			{
				return;
			}
			if (edge1.NextInSEL == edge2)
			{
				TEdge nextInSEL = edge2.NextInSEL;
				if (nextInSEL != null)
				{
					nextInSEL.PrevInSEL = edge1;
				}
				TEdge prevInSEL = edge1.PrevInSEL;
				if (prevInSEL != null)
				{
					prevInSEL.NextInSEL = edge2;
				}
				edge2.PrevInSEL = prevInSEL;
				edge2.NextInSEL = edge1;
				edge1.PrevInSEL = edge2;
				edge1.NextInSEL = nextInSEL;
			}
			else if (edge2.NextInSEL == edge1)
			{
				TEdge nextInSEL2 = edge1.NextInSEL;
				if (nextInSEL2 != null)
				{
					nextInSEL2.PrevInSEL = edge2;
				}
				TEdge prevInSEL2 = edge2.PrevInSEL;
				if (prevInSEL2 != null)
				{
					prevInSEL2.NextInSEL = edge1;
				}
				edge1.PrevInSEL = prevInSEL2;
				edge1.NextInSEL = edge2;
				edge2.PrevInSEL = edge1;
				edge2.NextInSEL = nextInSEL2;
			}
			else
			{
				TEdge nextInSEL3 = edge1.NextInSEL;
				TEdge prevInSEL3 = edge1.PrevInSEL;
				edge1.NextInSEL = edge2.NextInSEL;
				if (edge1.NextInSEL != null)
				{
					edge1.NextInSEL.PrevInSEL = edge1;
				}
				edge1.PrevInSEL = edge2.PrevInSEL;
				if (edge1.PrevInSEL != null)
				{
					edge1.PrevInSEL.NextInSEL = edge1;
				}
				edge2.NextInSEL = nextInSEL3;
				if (edge2.NextInSEL != null)
				{
					edge2.NextInSEL.PrevInSEL = edge2;
				}
				edge2.PrevInSEL = prevInSEL3;
				if (edge2.PrevInSEL != null)
				{
					edge2.PrevInSEL.NextInSEL = edge2;
				}
			}
			if (edge1.PrevInSEL == null)
			{
				this.m_SortedEdges = edge1;
				return;
			}
			if (edge2.PrevInSEL == null)
			{
				this.m_SortedEdges = edge2;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0001CF60 File Offset: 0x0001B160
		private void AddLocalMaxPoly(TEdge e1, TEdge e2, IntPoint pt)
		{
			this.AddOutPt(e1, pt);
			if (e2.WindDelta == 0)
			{
				this.AddOutPt(e2, pt);
			}
			if (e1.OutIdx == e2.OutIdx)
			{
				e1.OutIdx = -1;
				e2.OutIdx = -1;
				return;
			}
			if (e1.OutIdx < e2.OutIdx)
			{
				this.AppendPolygon(e1, e2);
				return;
			}
			this.AppendPolygon(e2, e1);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
		private OutPt AddLocalMinPoly(TEdge e1, TEdge e2, IntPoint pt)
		{
			OutPt outPt;
			TEdge tedge;
			TEdge tedge2;
			if (ClipperBase.IsHorizontal(e2) || e1.Dx > e2.Dx)
			{
				outPt = this.AddOutPt(e1, pt);
				e2.OutIdx = e1.OutIdx;
				e1.Side = EdgeSide.esLeft;
				e2.Side = EdgeSide.esRight;
				tedge = e1;
				tedge2 = ((tedge.PrevInAEL == e2) ? e2.PrevInAEL : tedge.PrevInAEL);
			}
			else
			{
				outPt = this.AddOutPt(e2, pt);
				e1.OutIdx = e2.OutIdx;
				e1.Side = EdgeSide.esRight;
				e2.Side = EdgeSide.esLeft;
				tedge = e2;
				tedge2 = ((tedge.PrevInAEL == e1) ? e1.PrevInAEL : tedge.PrevInAEL);
			}
			if (tedge2 != null && tedge2.OutIdx >= 0 && tedge2.Top.Y < pt.Y && tedge.Top.Y < pt.Y)
			{
				long num = Clipper.TopX(tedge2, pt.Y);
				long num2 = Clipper.TopX(tedge, pt.Y);
				if (num == num2 && tedge.WindDelta != 0 && tedge2.WindDelta != 0 && ClipperBase.SlopesEqual(new IntPoint(num, pt.Y), tedge2.Top, new IntPoint(num2, pt.Y), tedge.Top, this.m_UseFullRange))
				{
					OutPt op = this.AddOutPt(tedge2, pt);
					this.AddJoin(outPt, op, tedge.Top);
				}
			}
			return outPt;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0001D11C File Offset: 0x0001B31C
		private OutPt AddOutPt(TEdge e, IntPoint pt)
		{
			if (e.OutIdx < 0)
			{
				OutRec outRec = base.CreateOutRec();
				outRec.IsOpen = (e.WindDelta == 0);
				OutPt outPt = new OutPt();
				outRec.Pts = outPt;
				outPt.Idx = outRec.Idx;
				outPt.Pt = pt;
				outPt.Next = outPt;
				outPt.Prev = outPt;
				if (!outRec.IsOpen)
				{
					this.SetHoleState(e, outRec);
				}
				e.OutIdx = outRec.Idx;
				return outPt;
			}
			OutRec outRec2 = this.m_PolyOuts[e.OutIdx];
			OutPt pts = outRec2.Pts;
			bool flag = e.Side == EdgeSide.esLeft;
			if (flag && pt == pts.Pt)
			{
				return pts;
			}
			if (!flag && pt == pts.Prev.Pt)
			{
				return pts.Prev;
			}
			OutPt outPt2 = new OutPt
			{
				Idx = outRec2.Idx,
				Pt = pt,
				Next = pts,
				Prev = pts.Prev
			};
			outPt2.Prev.Next = outPt2;
			pts.Prev = outPt2;
			if (flag)
			{
				outRec2.Pts = outPt2;
			}
			return outPt2;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0001D23C File Offset: 0x0001B43C
		private OutPt GetLastOutPt(TEdge e)
		{
			OutRec outRec = this.m_PolyOuts[e.OutIdx];
			if (e.Side != EdgeSide.esLeft)
			{
				return outRec.Pts.Prev;
			}
			return outRec.Pts;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001D278 File Offset: 0x0001B478
		internal void SwapPoints(ref IntPoint pt1, ref IntPoint pt2)
		{
			IntPoint intPoint = new IntPoint(pt1);
			pt1 = pt2;
			pt2 = intPoint;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0001D2A5 File Offset: 0x0001B4A5
		private bool HorzSegmentsOverlap(long seg1a, long seg1b, long seg2a, long seg2b)
		{
			if (seg1a > seg1b)
			{
				base.Swap(ref seg1a, ref seg1b);
			}
			if (seg2a > seg2b)
			{
				base.Swap(ref seg2a, ref seg2b);
			}
			return seg1a < seg2b && seg2a < seg1b;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001D2D0 File Offset: 0x0001B4D0
		private void SetHoleState(TEdge e, OutRec outRec)
		{
			TEdge prevInAEL = e.PrevInAEL;
			TEdge tedge = null;
			while (prevInAEL != null)
			{
				if (prevInAEL.OutIdx >= 0 && prevInAEL.WindDelta != 0)
				{
					if (tedge == null)
					{
						tedge = prevInAEL;
					}
					else if (tedge.OutIdx == prevInAEL.OutIdx)
					{
						tedge = null;
					}
				}
				prevInAEL = prevInAEL.PrevInAEL;
			}
			if (tedge == null)
			{
				outRec.FirstLeft = null;
				outRec.IsHole = false;
				return;
			}
			outRec.FirstLeft = this.m_PolyOuts[tedge.OutIdx];
			outRec.IsHole = !outRec.FirstLeft.IsHole;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0001D357 File Offset: 0x0001B557
		private double GetDx(IntPoint pt1, IntPoint pt2)
		{
			if (pt1.Y == pt2.Y)
			{
				return -3.4E+38;
			}
			return (double)(pt2.X - pt1.X) / (double)(pt2.Y - pt1.Y);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001D390 File Offset: 0x0001B590
		private bool FirstIsBottomPt(OutPt btmPt1, OutPt btmPt2)
		{
			OutPt outPt = btmPt1.Prev;
			while (outPt.Pt == btmPt1.Pt && outPt != btmPt1)
			{
				outPt = outPt.Prev;
			}
			double num = Math.Abs(this.GetDx(btmPt1.Pt, outPt.Pt));
			outPt = btmPt1.Next;
			while (outPt.Pt == btmPt1.Pt && outPt != btmPt1)
			{
				outPt = outPt.Next;
			}
			double num2 = Math.Abs(this.GetDx(btmPt1.Pt, outPt.Pt));
			outPt = btmPt2.Prev;
			while (outPt.Pt == btmPt2.Pt && outPt != btmPt2)
			{
				outPt = outPt.Prev;
			}
			double num3 = Math.Abs(this.GetDx(btmPt2.Pt, outPt.Pt));
			outPt = btmPt2.Next;
			while (outPt.Pt == btmPt2.Pt && outPt != btmPt2)
			{
				outPt = outPt.Next;
			}
			double num4 = Math.Abs(this.GetDx(btmPt2.Pt, outPt.Pt));
			if (Math.Max(num, num2) == Math.Max(num3, num4) && Math.Min(num, num2) == Math.Min(num3, num4))
			{
				return this.Area(btmPt1) > 0.0;
			}
			return (num >= num3 && num >= num4) || (num2 >= num3 && num2 >= num4);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0001D4E8 File Offset: 0x0001B6E8
		private OutPt GetBottomPt(OutPt pp)
		{
			OutPt outPt = null;
			OutPt next;
			for (next = pp.Next; next != pp; next = next.Next)
			{
				if (next.Pt.Y > pp.Pt.Y)
				{
					pp = next;
					outPt = null;
				}
				else if (next.Pt.Y == pp.Pt.Y && next.Pt.X <= pp.Pt.X)
				{
					if (next.Pt.X < pp.Pt.X)
					{
						outPt = null;
						pp = next;
					}
					else if (next.Next != pp && next.Prev != pp)
					{
						outPt = next;
					}
				}
			}
			if (outPt != null)
			{
				while (outPt != next)
				{
					if (!this.FirstIsBottomPt(next, outPt))
					{
						pp = outPt;
					}
					outPt = outPt.Next;
					while (outPt.Pt != pp.Pt)
					{
						outPt = outPt.Next;
					}
				}
			}
			return pp;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0001D5D0 File Offset: 0x0001B7D0
		private OutRec GetLowermostRec(OutRec outRec1, OutRec outRec2)
		{
			if (outRec1.BottomPt == null)
			{
				outRec1.BottomPt = this.GetBottomPt(outRec1.Pts);
			}
			if (outRec2.BottomPt == null)
			{
				outRec2.BottomPt = this.GetBottomPt(outRec2.Pts);
			}
			OutPt bottomPt = outRec1.BottomPt;
			OutPt bottomPt2 = outRec2.BottomPt;
			if (bottomPt.Pt.Y > bottomPt2.Pt.Y)
			{
				return outRec1;
			}
			if (bottomPt.Pt.Y < bottomPt2.Pt.Y)
			{
				return outRec2;
			}
			if (bottomPt.Pt.X < bottomPt2.Pt.X)
			{
				return outRec1;
			}
			if (bottomPt.Pt.X > bottomPt2.Pt.X)
			{
				return outRec2;
			}
			if (bottomPt.Next == bottomPt)
			{
				return outRec2;
			}
			if (bottomPt2.Next == bottomPt2)
			{
				return outRec1;
			}
			if (!this.FirstIsBottomPt(bottomPt, bottomPt2))
			{
				return outRec2;
			}
			return outRec1;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001D6AA File Offset: 0x0001B8AA
		private bool OutRec1RightOfOutRec2(OutRec outRec1, OutRec outRec2)
		{
			for (;;)
			{
				outRec1 = outRec1.FirstLeft;
				if (outRec1 == outRec2)
				{
					break;
				}
				if (outRec1 == null)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		private OutRec GetOutRec(int idx)
		{
			OutRec outRec;
			for (outRec = this.m_PolyOuts[idx]; outRec != this.m_PolyOuts[outRec.Idx]; outRec = this.m_PolyOuts[outRec.Idx])
			{
			}
			return outRec;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0001D704 File Offset: 0x0001B904
		private void AppendPolygon(TEdge e1, TEdge e2)
		{
			OutRec outRec = this.m_PolyOuts[e1.OutIdx];
			OutRec outRec2 = this.m_PolyOuts[e2.OutIdx];
			OutRec outRec3;
			if (this.OutRec1RightOfOutRec2(outRec, outRec2))
			{
				outRec3 = outRec2;
			}
			else if (this.OutRec1RightOfOutRec2(outRec2, outRec))
			{
				outRec3 = outRec;
			}
			else
			{
				outRec3 = this.GetLowermostRec(outRec, outRec2);
			}
			OutPt pts = outRec.Pts;
			OutPt prev = pts.Prev;
			OutPt pts2 = outRec2.Pts;
			OutPt prev2 = pts2.Prev;
			if (e1.Side == EdgeSide.esLeft)
			{
				if (e2.Side == EdgeSide.esLeft)
				{
					this.ReversePolyPtLinks(pts2);
					pts2.Next = pts;
					pts.Prev = pts2;
					prev.Next = prev2;
					prev2.Prev = prev;
					outRec.Pts = prev2;
				}
				else
				{
					prev2.Next = pts;
					pts.Prev = prev2;
					pts2.Prev = prev;
					prev.Next = pts2;
					outRec.Pts = pts2;
				}
			}
			else if (e2.Side == EdgeSide.esRight)
			{
				this.ReversePolyPtLinks(pts2);
				prev.Next = prev2;
				prev2.Prev = prev;
				pts2.Next = pts;
				pts.Prev = pts2;
			}
			else
			{
				prev.Next = pts2;
				pts2.Prev = prev;
				pts.Prev = prev2;
				prev2.Next = pts;
			}
			outRec.BottomPt = null;
			if (outRec3 == outRec2)
			{
				if (outRec2.FirstLeft != outRec)
				{
					outRec.FirstLeft = outRec2.FirstLeft;
				}
				outRec.IsHole = outRec2.IsHole;
			}
			outRec2.Pts = null;
			outRec2.BottomPt = null;
			outRec2.FirstLeft = outRec;
			int outIdx = e1.OutIdx;
			int outIdx2 = e2.OutIdx;
			e1.OutIdx = -1;
			e2.OutIdx = -1;
			for (TEdge tedge = this.m_ActiveEdges; tedge != null; tedge = tedge.NextInAEL)
			{
				if (tedge.OutIdx == outIdx2)
				{
					tedge.OutIdx = outIdx;
					tedge.Side = e1.Side;
					break;
				}
			}
			outRec2.Idx = outRec.Idx;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0001D8EC File Offset: 0x0001BAEC
		private void ReversePolyPtLinks(OutPt pp)
		{
			if (pp == null)
			{
				return;
			}
			OutPt outPt = pp;
			do
			{
				OutPt next = outPt.Next;
				outPt.Next = outPt.Prev;
				outPt.Prev = next;
				outPt = next;
			}
			while (outPt != pp);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0001D920 File Offset: 0x0001BB20
		private static void SwapSides(TEdge edge1, TEdge edge2)
		{
			EdgeSide side = edge1.Side;
			edge1.Side = edge2.Side;
			edge2.Side = side;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001D948 File Offset: 0x0001BB48
		private static void SwapPolyIndexes(TEdge edge1, TEdge edge2)
		{
			int outIdx = edge1.OutIdx;
			edge1.OutIdx = edge2.OutIdx;
			edge2.OutIdx = outIdx;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001D970 File Offset: 0x0001BB70
		private void IntersectEdges(TEdge e1, TEdge e2, IntPoint pt)
		{
			bool flag = e1.OutIdx >= 0;
			bool flag2 = e2.OutIdx >= 0;
			if (e1.WindDelta == 0 || e2.WindDelta == 0)
			{
				if (e1.WindDelta == 0 && e2.WindDelta == 0)
				{
					return;
				}
				if (e1.PolyTyp == e2.PolyTyp && e1.WindDelta != e2.WindDelta && this.m_ClipType == ClipType.ctUnion)
				{
					if (e1.WindDelta == 0)
					{
						if (flag2)
						{
							this.AddOutPt(e1, pt);
							if (flag)
							{
								e1.OutIdx = -1;
								return;
							}
						}
					}
					else if (flag)
					{
						this.AddOutPt(e2, pt);
						if (flag2)
						{
							e2.OutIdx = -1;
							return;
						}
					}
				}
				else if (e1.PolyTyp != e2.PolyTyp)
				{
					if (e1.WindDelta == 0 && Math.Abs(e2.WindCnt) == 1 && (this.m_ClipType != ClipType.ctUnion || e2.WindCnt2 == 0))
					{
						this.AddOutPt(e1, pt);
						if (flag)
						{
							e1.OutIdx = -1;
							return;
						}
					}
					else if (e2.WindDelta == 0 && Math.Abs(e1.WindCnt) == 1 && (this.m_ClipType != ClipType.ctUnion || e1.WindCnt2 == 0))
					{
						this.AddOutPt(e2, pt);
						if (flag2)
						{
							e2.OutIdx = -1;
						}
					}
				}
				return;
			}
			else
			{
				if (e1.PolyTyp == e2.PolyTyp)
				{
					if (this.IsEvenOddFillType(e1))
					{
						int windCnt = e1.WindCnt;
						e1.WindCnt = e2.WindCnt;
						e2.WindCnt = windCnt;
					}
					else
					{
						if (e1.WindCnt + e2.WindDelta == 0)
						{
							e1.WindCnt = -e1.WindCnt;
						}
						else
						{
							e1.WindCnt += e2.WindDelta;
						}
						if (e2.WindCnt - e1.WindDelta == 0)
						{
							e2.WindCnt = -e2.WindCnt;
						}
						else
						{
							e2.WindCnt -= e1.WindDelta;
						}
					}
				}
				else
				{
					if (!this.IsEvenOddFillType(e2))
					{
						e1.WindCnt2 += e2.WindDelta;
					}
					else
					{
						e1.WindCnt2 = ((e1.WindCnt2 == 0) ? 1 : 0);
					}
					if (!this.IsEvenOddFillType(e1))
					{
						e2.WindCnt2 -= e1.WindDelta;
					}
					else
					{
						e2.WindCnt2 = ((e2.WindCnt2 == 0) ? 1 : 0);
					}
				}
				PolyFillType polyFillType;
				PolyFillType polyFillType2;
				if (e1.PolyTyp == PolyType.ptSubject)
				{
					polyFillType = this.m_SubjFillType;
					polyFillType2 = this.m_ClipFillType;
				}
				else
				{
					polyFillType = this.m_ClipFillType;
					polyFillType2 = this.m_SubjFillType;
				}
				PolyFillType polyFillType3;
				PolyFillType polyFillType4;
				if (e2.PolyTyp == PolyType.ptSubject)
				{
					polyFillType3 = this.m_SubjFillType;
					polyFillType4 = this.m_ClipFillType;
				}
				else
				{
					polyFillType3 = this.m_ClipFillType;
					polyFillType4 = this.m_SubjFillType;
				}
				int num;
				if (polyFillType != PolyFillType.pftPositive)
				{
					if (polyFillType != PolyFillType.pftNegative)
					{
						num = Math.Abs(e1.WindCnt);
					}
					else
					{
						num = -e1.WindCnt;
					}
				}
				else
				{
					num = e1.WindCnt;
				}
				int num2;
				if (polyFillType3 != PolyFillType.pftPositive)
				{
					if (polyFillType3 != PolyFillType.pftNegative)
					{
						num2 = Math.Abs(e2.WindCnt);
					}
					else
					{
						num2 = -e2.WindCnt;
					}
				}
				else
				{
					num2 = e2.WindCnt;
				}
				if (!flag || !flag2)
				{
					if (flag)
					{
						if (num2 == 0 || num2 == 1)
						{
							this.AddOutPt(e1, pt);
							Clipper.SwapSides(e1, e2);
							Clipper.SwapPolyIndexes(e1, e2);
							return;
						}
					}
					else if (flag2)
					{
						if (num == 0 || num == 1)
						{
							this.AddOutPt(e2, pt);
							Clipper.SwapSides(e1, e2);
							Clipper.SwapPolyIndexes(e1, e2);
							return;
						}
					}
					else if ((num == 0 || num == 1) && (num2 == 0 || num2 == 1))
					{
						long num3;
						if (polyFillType2 != PolyFillType.pftPositive)
						{
							if (polyFillType2 != PolyFillType.pftNegative)
							{
								num3 = (long)Math.Abs(e1.WindCnt2);
							}
							else
							{
								num3 = (long)(-(long)e1.WindCnt2);
							}
						}
						else
						{
							num3 = (long)e1.WindCnt2;
						}
						long num4;
						if (polyFillType4 != PolyFillType.pftPositive)
						{
							if (polyFillType4 != PolyFillType.pftNegative)
							{
								num4 = (long)Math.Abs(e2.WindCnt2);
							}
							else
							{
								num4 = (long)(-(long)e2.WindCnt2);
							}
						}
						else
						{
							num4 = (long)e2.WindCnt2;
						}
						if (e1.PolyTyp != e2.PolyTyp)
						{
							this.AddLocalMinPoly(e1, e2, pt);
							return;
						}
						if (num == 1 && num2 == 1)
						{
							switch (this.m_ClipType)
							{
							case ClipType.ctIntersection:
								if (num3 > 0L && num4 > 0L)
								{
									this.AddLocalMinPoly(e1, e2, pt);
									return;
								}
								break;
							case ClipType.ctUnion:
								if (num3 <= 0L && num4 <= 0L)
								{
									this.AddLocalMinPoly(e1, e2, pt);
									return;
								}
								break;
							case ClipType.ctDifference:
								if ((e1.PolyTyp == PolyType.ptClip && num3 > 0L && num4 > 0L) || (e1.PolyTyp == PolyType.ptSubject && num3 <= 0L && num4 <= 0L))
								{
									this.AddLocalMinPoly(e1, e2, pt);
									return;
								}
								break;
							case ClipType.ctXor:
								this.AddLocalMinPoly(e1, e2, pt);
								return;
							default:
								return;
							}
						}
						else
						{
							Clipper.SwapSides(e1, e2);
						}
					}
					return;
				}
				if ((num != 0 && num != 1) || (num2 != 0 && num2 != 1) || (e1.PolyTyp != e2.PolyTyp && this.m_ClipType != ClipType.ctXor))
				{
					this.AddLocalMaxPoly(e1, e2, pt);
					return;
				}
				this.AddOutPt(e1, pt);
				this.AddOutPt(e2, pt);
				Clipper.SwapSides(e1, e2);
				Clipper.SwapPolyIndexes(e1, e2);
				return;
			}
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0001DE2C File Offset: 0x0001C02C
		private void ProcessHorizontals()
		{
			TEdge horzEdge;
			while (this.PopEdgeFromSEL(out horzEdge))
			{
				this.ProcessHorizontal(horzEdge);
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0001DE4C File Offset: 0x0001C04C
		private static void GetHorzDirection(TEdge HorzEdge, out Direction Dir, out long Left, out long Right)
		{
			if (HorzEdge.Bot.X < HorzEdge.Top.X)
			{
				Left = HorzEdge.Bot.X;
				Right = HorzEdge.Top.X;
				Dir = Direction.dLeftToRight;
				return;
			}
			Left = HorzEdge.Top.X;
			Right = HorzEdge.Bot.X;
			Dir = Direction.dRightToLeft;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001DEAC File Offset: 0x0001C0AC
		private void ProcessHorizontal(TEdge horzEdge)
		{
			bool flag = horzEdge.WindDelta == 0;
			Direction direction;
			long num;
			long num2;
			Clipper.GetHorzDirection(horzEdge, out direction, out num, out num2);
			TEdge tedge = horzEdge;
			TEdge tedge2 = null;
			while (tedge.NextInLML != null && ClipperBase.IsHorizontal(tedge.NextInLML))
			{
				tedge = tedge.NextInLML;
			}
			if (tedge.NextInLML == null)
			{
				tedge2 = this.GetMaximaPair(tedge);
			}
			Maxima maxima = this.m_Maxima;
			if (maxima != null)
			{
				if (direction == Direction.dLeftToRight)
				{
					while (maxima != null && maxima.X <= horzEdge.Bot.X)
					{
						maxima = maxima.Next;
					}
					if (maxima != null && maxima.X >= tedge.Top.X)
					{
						maxima = null;
					}
				}
				else
				{
					while (maxima.Next != null && maxima.Next.X < horzEdge.Bot.X)
					{
						maxima = maxima.Next;
					}
					if (maxima.X <= tedge.Top.X)
					{
						maxima = null;
					}
				}
			}
			OutPt outPt = null;
			for (;;)
			{
				bool flag2 = horzEdge == tedge;
				TEdge nextInAEL;
				for (TEdge tedge3 = this.GetNextInAEL(horzEdge, direction); tedge3 != null; tedge3 = nextInAEL)
				{
					if (maxima != null)
					{
						if (direction == Direction.dLeftToRight)
						{
							while (maxima != null)
							{
								if (maxima.X >= tedge3.Curr.X)
								{
									break;
								}
								if (horzEdge.OutIdx >= 0 && !flag)
								{
									this.AddOutPt(horzEdge, new IntPoint(maxima.X, horzEdge.Bot.Y));
								}
								maxima = maxima.Next;
							}
						}
						else
						{
							while (maxima != null && maxima.X > tedge3.Curr.X)
							{
								if (horzEdge.OutIdx >= 0 && !flag)
								{
									this.AddOutPt(horzEdge, new IntPoint(maxima.X, horzEdge.Bot.Y));
								}
								maxima = maxima.Prev;
							}
						}
					}
					if ((direction == Direction.dLeftToRight && tedge3.Curr.X > num2) || (direction == Direction.dRightToLeft && tedge3.Curr.X < num) || (tedge3.Curr.X == horzEdge.Top.X && horzEdge.NextInLML != null && tedge3.Dx < horzEdge.NextInLML.Dx))
					{
						break;
					}
					if (horzEdge.OutIdx >= 0 && !flag)
					{
						outPt = this.AddOutPt(horzEdge, tedge3.Curr);
						for (TEdge tedge4 = this.m_SortedEdges; tedge4 != null; tedge4 = tedge4.NextInSEL)
						{
							if (tedge4.OutIdx >= 0 && this.HorzSegmentsOverlap(horzEdge.Bot.X, horzEdge.Top.X, tedge4.Bot.X, tedge4.Top.X))
							{
								OutPt lastOutPt = this.GetLastOutPt(tedge4);
								this.AddJoin(lastOutPt, outPt, tedge4.Top);
							}
						}
						this.AddGhostJoin(outPt, horzEdge.Bot);
					}
					if (tedge3 == tedge2 && flag2)
					{
						goto Block_28;
					}
					if (direction == Direction.dLeftToRight)
					{
						IntPoint pt = new IntPoint(tedge3.Curr.X, horzEdge.Curr.Y);
						this.IntersectEdges(horzEdge, tedge3, pt);
					}
					else
					{
						IntPoint pt2 = new IntPoint(tedge3.Curr.X, horzEdge.Curr.Y);
						this.IntersectEdges(tedge3, horzEdge, pt2);
					}
					nextInAEL = this.GetNextInAEL(tedge3, direction);
					base.SwapPositionsInAEL(horzEdge, tedge3);
				}
				if (horzEdge.NextInLML == null || !ClipperBase.IsHorizontal(horzEdge.NextInLML))
				{
					goto IL_39D;
				}
				base.UpdateEdgeIntoAEL(ref horzEdge);
				if (horzEdge.OutIdx >= 0)
				{
					this.AddOutPt(horzEdge, horzEdge.Bot);
				}
				Clipper.GetHorzDirection(horzEdge, out direction, out num, out num2);
			}
			Block_28:
			if (horzEdge.OutIdx >= 0)
			{
				this.AddLocalMaxPoly(horzEdge, tedge2, horzEdge.Top);
			}
			base.DeleteFromAEL(horzEdge);
			base.DeleteFromAEL(tedge2);
			return;
			IL_39D:
			if (horzEdge.OutIdx >= 0 && outPt == null)
			{
				outPt = this.GetLastOutPt(horzEdge);
				for (TEdge tedge5 = this.m_SortedEdges; tedge5 != null; tedge5 = tedge5.NextInSEL)
				{
					if (tedge5.OutIdx >= 0 && this.HorzSegmentsOverlap(horzEdge.Bot.X, horzEdge.Top.X, tedge5.Bot.X, tedge5.Top.X))
					{
						OutPt lastOutPt2 = this.GetLastOutPt(tedge5);
						this.AddJoin(lastOutPt2, outPt, tedge5.Top);
					}
				}
				this.AddGhostJoin(outPt, horzEdge.Top);
			}
			if (horzEdge.NextInLML != null)
			{
				if (horzEdge.OutIdx < 0)
				{
					base.UpdateEdgeIntoAEL(ref horzEdge);
					return;
				}
				outPt = this.AddOutPt(horzEdge, horzEdge.Top);
				base.UpdateEdgeIntoAEL(ref horzEdge);
				if (horzEdge.WindDelta == 0)
				{
					return;
				}
				TEdge prevInAEL = horzEdge.PrevInAEL;
				TEdge nextInAEL2 = horzEdge.NextInAEL;
				if (prevInAEL != null && prevInAEL.Curr.X == horzEdge.Bot.X && prevInAEL.Curr.Y == horzEdge.Bot.Y && prevInAEL.WindDelta != 0 && prevInAEL.OutIdx >= 0 && prevInAEL.Curr.Y > prevInAEL.Top.Y && ClipperBase.SlopesEqual(horzEdge, prevInAEL, this.m_UseFullRange))
				{
					OutPt op = this.AddOutPt(prevInAEL, horzEdge.Bot);
					this.AddJoin(outPt, op, horzEdge.Top);
					return;
				}
				if (nextInAEL2 != null && nextInAEL2.Curr.X == horzEdge.Bot.X && nextInAEL2.Curr.Y == horzEdge.Bot.Y && nextInAEL2.WindDelta != 0 && nextInAEL2.OutIdx >= 0 && nextInAEL2.Curr.Y > nextInAEL2.Top.Y && ClipperBase.SlopesEqual(horzEdge, nextInAEL2, this.m_UseFullRange))
				{
					OutPt op2 = this.AddOutPt(nextInAEL2, horzEdge.Bot);
					this.AddJoin(outPt, op2, horzEdge.Top);
					return;
				}
			}
			else
			{
				if (horzEdge.OutIdx >= 0)
				{
					this.AddOutPt(horzEdge, horzEdge.Top);
				}
				base.DeleteFromAEL(horzEdge);
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001E494 File Offset: 0x0001C694
		private TEdge GetNextInAEL(TEdge e, Direction Direction)
		{
			if (Direction != Direction.dLeftToRight)
			{
				return e.PrevInAEL;
			}
			return e.NextInAEL;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001E4A7 File Offset: 0x0001C6A7
		private static bool IsMaxima(TEdge e, double Y)
		{
			return e != null && (double)e.Top.Y == Y && e.NextInLML == null;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001E4C6 File Offset: 0x0001C6C6
		private static bool IsIntermediate(TEdge e, double Y)
		{
			return (double)e.Top.Y == Y && e.NextInLML != null;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0001E4E4 File Offset: 0x0001C6E4
		internal TEdge GetMaximaPair(TEdge e)
		{
			if (e.Next.Top == e.Top && e.Next.NextInLML == null)
			{
				return e.Next;
			}
			if (e.Prev.Top == e.Top && e.Prev.NextInLML == null)
			{
				return e.Prev;
			}
			return null;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0001E54C File Offset: 0x0001C74C
		internal TEdge GetMaximaPairEx(TEdge e)
		{
			TEdge maximaPair = this.GetMaximaPair(e);
			if (maximaPair == null || maximaPair.OutIdx == -2 || (maximaPair.NextInAEL == maximaPair.PrevInAEL && !ClipperBase.IsHorizontal(maximaPair)))
			{
				return null;
			}
			return maximaPair;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001E588 File Offset: 0x0001C788
		private bool ProcessIntersections(long topY)
		{
			if (this.m_ActiveEdges == null)
			{
				return true;
			}
			this.BuildIntersectList(topY);
			if (this.m_IntersectList.Count == 0)
			{
				return true;
			}
			if (this.m_IntersectList.Count == 1 || this.FixupIntersectionOrder())
			{
				this.ProcessIntersectList();
				this.m_SortedEdges = null;
				return true;
			}
			return false;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001E5E0 File Offset: 0x0001C7E0
		private void BuildIntersectList(long topY)
		{
			if (this.m_ActiveEdges == null)
			{
				return;
			}
			TEdge tedge = this.m_ActiveEdges;
			this.m_SortedEdges = tedge;
			while (tedge != null)
			{
				tedge.PrevInSEL = tedge.PrevInAEL;
				tedge.NextInSEL = tedge.NextInAEL;
				tedge.Curr.X = Clipper.TopX(tedge, topY);
				tedge = tedge.NextInAEL;
			}
			bool flag = true;
			while (flag && this.m_SortedEdges != null)
			{
				flag = false;
				tedge = this.m_SortedEdges;
				while (tedge.NextInSEL != null)
				{
					TEdge nextInSEL = tedge.NextInSEL;
					if (tedge.Curr.X > nextInSEL.Curr.X)
					{
						IntPoint intPoint;
						this.IntersectPoint(tedge, nextInSEL, out intPoint);
						if (intPoint.Y < topY)
						{
							intPoint = new IntPoint(Clipper.TopX(tedge, topY), topY);
						}
						IntersectNode item = new IntersectNode
						{
							Edge1 = tedge,
							Edge2 = nextInSEL,
							Pt = intPoint
						};
						this.m_IntersectList.Add(item);
						this.SwapPositionsInSEL(tedge, nextInSEL);
						flag = true;
					}
					else
					{
						tedge = nextInSEL;
					}
				}
				if (tedge.PrevInSEL == null)
				{
					break;
				}
				tedge.PrevInSEL.NextInSEL = null;
			}
			this.m_SortedEdges = null;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0001E6F5 File Offset: 0x0001C8F5
		private static bool EdgesAdjacent(IntersectNode inode)
		{
			return inode.Edge1.NextInSEL == inode.Edge2 || inode.Edge1.PrevInSEL == inode.Edge2;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x0001E720 File Offset: 0x0001C920
		private bool FixupIntersectionOrder()
		{
			this.m_IntersectList.Sort(this.m_IntersectNodeComparer);
			this.CopyAELToSEL();
			int count = this.m_IntersectList.Count;
			for (int i = 0; i < count; i++)
			{
				if (!Clipper.EdgesAdjacent(this.m_IntersectList[i]))
				{
					int num = i + 1;
					while (num < count && !Clipper.EdgesAdjacent(this.m_IntersectList[num]))
					{
						num++;
					}
					if (num == count)
					{
						return false;
					}
					IntersectNode value = this.m_IntersectList[i];
					this.m_IntersectList[i] = this.m_IntersectList[num];
					this.m_IntersectList[num] = value;
				}
				this.SwapPositionsInSEL(this.m_IntersectList[i].Edge1, this.m_IntersectList[i].Edge2);
			}
			return true;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001E7F8 File Offset: 0x0001C9F8
		private void ProcessIntersectList()
		{
			foreach (IntersectNode intersectNode in this.m_IntersectList)
			{
				this.IntersectEdges(intersectNode.Edge1, intersectNode.Edge2, intersectNode.Pt);
				base.SwapPositionsInAEL(intersectNode.Edge1, intersectNode.Edge2);
			}
			this.m_IntersectList.Clear();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001E87C File Offset: 0x0001CA7C
		internal static long Round(double value)
		{
			if (value >= 0.0)
			{
				return (long)(value + 0.5);
			}
			return (long)(value - 0.5);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0001E8A4 File Offset: 0x0001CAA4
		private static long TopX(TEdge edge, long currentY)
		{
			if (currentY == edge.Top.Y)
			{
				return edge.Top.X;
			}
			return edge.Bot.X + Clipper.Round(edge.Dx * (double)(currentY - edge.Bot.Y));
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0001E8F4 File Offset: 0x0001CAF4
		private void IntersectPoint(TEdge edge1, TEdge edge2, out IntPoint ip)
		{
			ip = default(IntPoint);
			if (edge1.Dx == edge2.Dx)
			{
				ip.Y = edge1.Curr.Y;
				ip.X = Clipper.TopX(edge1, ip.Y);
				return;
			}
			if (edge1.Delta.X == 0L)
			{
				ip.X = edge1.Bot.X;
				if (ClipperBase.IsHorizontal(edge2))
				{
					ip.Y = edge2.Bot.Y;
				}
				else
				{
					double num = (double)edge2.Bot.Y - (double)edge2.Bot.X / edge2.Dx;
					ip.Y = Clipper.Round((double)ip.X / edge2.Dx + num);
				}
			}
			else if (edge2.Delta.X == 0L)
			{
				ip.X = edge2.Bot.X;
				if (ClipperBase.IsHorizontal(edge1))
				{
					ip.Y = edge1.Bot.Y;
				}
				else
				{
					double num2 = (double)edge1.Bot.Y - (double)edge1.Bot.X / edge1.Dx;
					ip.Y = Clipper.Round((double)ip.X / edge1.Dx + num2);
				}
			}
			else
			{
				double num2 = (double)edge1.Bot.X - (double)edge1.Bot.Y * edge1.Dx;
				double num = (double)edge2.Bot.X - (double)edge2.Bot.Y * edge2.Dx;
				double num3 = (num - num2) / (edge1.Dx - edge2.Dx);
				ip.Y = Clipper.Round(num3);
				ip.X = ((Math.Abs(edge1.Dx) < Math.Abs(edge2.Dx)) ? Clipper.Round(edge1.Dx * num3 + num2) : Clipper.Round(edge2.Dx * num3 + num));
			}
			if (ip.Y < edge1.Top.Y || ip.Y < edge2.Top.Y)
			{
				ip.Y = ((edge1.Top.Y > edge2.Top.Y) ? edge1.Top.Y : edge2.Top.Y);
				ip.X = Clipper.TopX((Math.Abs(edge1.Dx) < Math.Abs(edge2.Dx)) ? edge1 : edge2, ip.Y);
			}
			if (ip.Y > edge1.Curr.Y)
			{
				ip.Y = edge1.Curr.Y;
				ip.X = Clipper.TopX((Math.Abs(edge1.Dx) > Math.Abs(edge2.Dx)) ? edge2 : edge1, ip.Y);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001EBAC File Offset: 0x0001CDAC
		private void ProcessEdgesAtTopOfScanbeam(long topY)
		{
			TEdge tedge = this.m_ActiveEdges;
			while (tedge != null)
			{
				bool flag = Clipper.IsMaxima(tedge, (double)topY);
				if (flag)
				{
					TEdge maximaPairEx = this.GetMaximaPairEx(tedge);
					flag = (maximaPairEx == null || !ClipperBase.IsHorizontal(maximaPairEx));
				}
				if (flag)
				{
					if (this.StrictlySimple)
					{
						this.InsertMaxima(tedge.Top.X);
					}
					TEdge prevInAEL = tedge.PrevInAEL;
					this.DoMaxima(tedge);
					tedge = ((prevInAEL == null) ? this.m_ActiveEdges : prevInAEL.NextInAEL);
				}
				else
				{
					if (Clipper.IsIntermediate(tedge, (double)topY) && ClipperBase.IsHorizontal(tedge.NextInLML))
					{
						base.UpdateEdgeIntoAEL(ref tedge);
						if (tedge.OutIdx >= 0)
						{
							this.AddOutPt(tedge, tedge.Bot);
						}
						this.AddEdgeToSEL(tedge);
					}
					else
					{
						tedge.Curr.X = Clipper.TopX(tedge, topY);
						tedge.Curr.Y = topY;
					}
					if (this.StrictlySimple)
					{
						TEdge prevInAEL2 = tedge.PrevInAEL;
						if (tedge.OutIdx >= 0 && tedge.WindDelta != 0 && prevInAEL2 != null && prevInAEL2.OutIdx >= 0 && prevInAEL2.Curr.X == tedge.Curr.X && prevInAEL2.WindDelta != 0)
						{
							IntPoint intPoint = new IntPoint(tedge.Curr);
							OutPt op = this.AddOutPt(prevInAEL2, intPoint);
							OutPt op2 = this.AddOutPt(tedge, intPoint);
							this.AddJoin(op, op2, intPoint);
						}
					}
					tedge = tedge.NextInAEL;
				}
			}
			this.ProcessHorizontals();
			this.m_Maxima = null;
			for (tedge = this.m_ActiveEdges; tedge != null; tedge = tedge.NextInAEL)
			{
				if (Clipper.IsIntermediate(tedge, (double)topY))
				{
					OutPt outPt = null;
					if (tedge.OutIdx >= 0)
					{
						outPt = this.AddOutPt(tedge, tedge.Top);
					}
					base.UpdateEdgeIntoAEL(ref tedge);
					TEdge prevInAEL3 = tedge.PrevInAEL;
					TEdge nextInAEL = tedge.NextInAEL;
					if (prevInAEL3 != null && prevInAEL3.Curr.X == tedge.Bot.X && prevInAEL3.Curr.Y == tedge.Bot.Y && outPt != null && prevInAEL3.OutIdx >= 0 && prevInAEL3.Curr.Y > prevInAEL3.Top.Y && ClipperBase.SlopesEqual(tedge.Curr, tedge.Top, prevInAEL3.Curr, prevInAEL3.Top, this.m_UseFullRange) && tedge.WindDelta != 0 && prevInAEL3.WindDelta != 0)
					{
						OutPt op3 = this.AddOutPt(prevInAEL3, tedge.Bot);
						this.AddJoin(outPt, op3, tedge.Top);
					}
					else if (nextInAEL != null && nextInAEL.Curr.X == tedge.Bot.X && nextInAEL.Curr.Y == tedge.Bot.Y && outPt != null && nextInAEL.OutIdx >= 0 && nextInAEL.Curr.Y > nextInAEL.Top.Y && ClipperBase.SlopesEqual(tedge.Curr, tedge.Top, nextInAEL.Curr, nextInAEL.Top, this.m_UseFullRange) && tedge.WindDelta != 0 && nextInAEL.WindDelta != 0)
					{
						OutPt op4 = this.AddOutPt(nextInAEL, tedge.Bot);
						this.AddJoin(outPt, op4, tedge.Top);
					}
				}
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001EF04 File Offset: 0x0001D104
		private void DoMaxima(TEdge e)
		{
			TEdge maximaPairEx = this.GetMaximaPairEx(e);
			if (maximaPairEx == null)
			{
				if (e.OutIdx >= 0)
				{
					this.AddOutPt(e, e.Top);
				}
				base.DeleteFromAEL(e);
				return;
			}
			TEdge nextInAEL = e.NextInAEL;
			while (nextInAEL != null && nextInAEL != maximaPairEx)
			{
				this.IntersectEdges(e, nextInAEL, e.Top);
				base.SwapPositionsInAEL(e, nextInAEL);
				nextInAEL = e.NextInAEL;
			}
			if (e.OutIdx == -1 && maximaPairEx.OutIdx == -1)
			{
				base.DeleteFromAEL(e);
				base.DeleteFromAEL(maximaPairEx);
				return;
			}
			if (e.OutIdx >= 0 && maximaPairEx.OutIdx >= 0)
			{
				if (e.OutIdx >= 0)
				{
					this.AddLocalMaxPoly(e, maximaPairEx, e.Top);
				}
				base.DeleteFromAEL(e);
				base.DeleteFromAEL(maximaPairEx);
				return;
			}
			if (e.WindDelta == 0)
			{
				if (e.OutIdx >= 0)
				{
					this.AddOutPt(e, e.Top);
					e.OutIdx = -1;
				}
				base.DeleteFromAEL(e);
				if (maximaPairEx.OutIdx >= 0)
				{
					this.AddOutPt(maximaPairEx, e.Top);
					maximaPairEx.OutIdx = -1;
				}
				base.DeleteFromAEL(maximaPairEx);
				return;
			}
			throw new ClipperException("DoMaxima error");
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001F020 File Offset: 0x0001D220
		public static void ReversePaths(List<List<IntPoint>> polys)
		{
			foreach (List<IntPoint> list in polys)
			{
				list.Reverse();
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001F06C File Offset: 0x0001D26C
		public static bool Orientation(List<IntPoint> poly)
		{
			return Clipper.Area(poly) >= 0.0;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001F084 File Offset: 0x0001D284
		private static int PointCount(OutPt pts)
		{
			if (pts == null)
			{
				return 0;
			}
			int num = 0;
			OutPt outPt = pts;
			do
			{
				num++;
				outPt = outPt.Next;
			}
			while (outPt != pts);
			return num;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0001F0AC File Offset: 0x0001D2AC
		private void BuildResult(List<List<IntPoint>> polyg)
		{
			polyg.Clear();
			polyg.Capacity = this.m_PolyOuts.Count;
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				if (outRec.Pts != null)
				{
					OutPt prev = outRec.Pts.Prev;
					int num = Clipper.PointCount(prev);
					if (num >= 2)
					{
						List<IntPoint> list = new List<IntPoint>(num);
						for (int i = 0; i < num; i++)
						{
							list.Add(prev.Pt);
							prev = prev.Prev;
						}
						polyg.Add(list);
					}
				}
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0001F164 File Offset: 0x0001D364
		private void BuildResult2(PolyTree polytree)
		{
			polytree.Clear();
			polytree.m_AllPolys.Capacity = this.m_PolyOuts.Count;
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				int num = Clipper.PointCount(outRec.Pts);
				if ((!outRec.IsOpen || num >= 2) && (outRec.IsOpen || num >= 3))
				{
					this.FixHoleLinkage(outRec);
					PolyNode polyNode = new PolyNode();
					polytree.m_AllPolys.Add(polyNode);
					outRec.PolyNode = polyNode;
					polyNode.m_polygon.Capacity = num;
					OutPt prev = outRec.Pts.Prev;
					for (int i = 0; i < num; i++)
					{
						polyNode.m_polygon.Add(prev.Pt);
						prev = prev.Prev;
					}
				}
			}
			polytree.m_Childs.Capacity = this.m_PolyOuts.Count;
			foreach (OutRec outRec2 in this.m_PolyOuts)
			{
				if (outRec2.PolyNode != null)
				{
					if (outRec2.IsOpen)
					{
						outRec2.PolyNode.IsOpen = true;
						polytree.AddChild(outRec2.PolyNode);
					}
					else
					{
						OutRec firstLeft = outRec2.FirstLeft;
						if (((firstLeft != null) ? firstLeft.PolyNode : null) != null)
						{
							outRec2.FirstLeft.PolyNode.AddChild(outRec2.PolyNode);
						}
						else
						{
							polytree.AddChild(outRec2.PolyNode);
						}
					}
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0001F318 File Offset: 0x0001D518
		private void FixupOutPolyline(OutRec outrec)
		{
			OutPt outPt = outrec.Pts;
			OutPt prev = outPt.Prev;
			while (outPt != prev)
			{
				outPt = outPt.Next;
				if (outPt.Pt == outPt.Prev.Pt)
				{
					if (outPt == prev)
					{
						prev = outPt.Prev;
					}
					OutPt prev2 = outPt.Prev;
					prev2.Next = outPt.Next;
					outPt.Next.Prev = prev2;
					outPt = prev2;
				}
			}
			if (outPt == outPt.Prev)
			{
				outrec.Pts = null;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001F394 File Offset: 0x0001D594
		private void FixupOutPolygon(OutRec outRec)
		{
			OutPt outPt = null;
			outRec.BottomPt = null;
			OutPt outPt2 = outRec.Pts;
			bool flag = base.PreserveCollinear || this.StrictlySimple;
			while (outPt2.Prev != outPt2 && outPt2.Prev != outPt2.Next)
			{
				if (outPt2.Pt == outPt2.Next.Pt || outPt2.Pt == outPt2.Prev.Pt || (ClipperBase.SlopesEqual(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt, this.m_UseFullRange) && (!flag || !base.Pt2IsBetweenPt1AndPt3(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt))))
				{
					outPt = null;
					outPt2.Prev.Next = outPt2.Next;
					outPt2.Next.Prev = outPt2.Prev;
					outPt2 = outPt2.Prev;
				}
				else
				{
					if (outPt2 == outPt)
					{
						outRec.Pts = outPt2;
						return;
					}
					if (outPt == null)
					{
						outPt = outPt2;
					}
					outPt2 = outPt2.Next;
				}
			}
			outRec.Pts = null;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0001F4B0 File Offset: 0x0001D6B0
		private OutPt DupOutPt(OutPt outPt, bool InsertAfter)
		{
			OutPt outPt2 = new OutPt
			{
				Pt = outPt.Pt,
				Idx = outPt.Idx
			};
			if (InsertAfter)
			{
				outPt2.Next = outPt.Next;
				outPt2.Prev = outPt;
				outPt.Next.Prev = outPt2;
				outPt.Next = outPt2;
			}
			else
			{
				outPt2.Prev = outPt.Prev;
				outPt2.Next = outPt;
				outPt.Prev.Next = outPt2;
				outPt.Prev = outPt2;
			}
			return outPt2;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0001F530 File Offset: 0x0001D730
		private bool GetOverlap(long a1, long a2, long b1, long b2, out long Left, out long Right)
		{
			if (a1 < a2)
			{
				if (b1 < b2)
				{
					Left = Math.Max(a1, b1);
					Right = Math.Min(a2, b2);
				}
				else
				{
					Left = Math.Max(a1, b2);
					Right = Math.Min(a2, b1);
				}
			}
			else if (b1 < b2)
			{
				Left = Math.Max(a2, b1);
				Right = Math.Min(a1, b2);
			}
			else
			{
				Left = Math.Max(a2, b2);
				Right = Math.Min(a1, b1);
			}
			return Left < Right;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0001F5B0 File Offset: 0x0001D7B0
		private bool JoinHorz(OutPt op1, OutPt op1b, OutPt op2, OutPt op2b, IntPoint Pt, bool DiscardLeft)
		{
			Direction direction = (op1.Pt.X > op1b.Pt.X) ? Direction.dRightToLeft : Direction.dLeftToRight;
			Direction direction2 = (op2.Pt.X > op2b.Pt.X) ? Direction.dRightToLeft : Direction.dLeftToRight;
			if (direction == direction2)
			{
				return false;
			}
			if (direction == Direction.dLeftToRight)
			{
				while (op1.Next.Pt.X <= Pt.X && op1.Next.Pt.X >= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
				{
					op1 = op1.Next;
				}
				if (DiscardLeft && op1.Pt.X != Pt.X)
				{
					op1 = op1.Next;
				}
				op1b = this.DupOutPt(op1, !DiscardLeft);
				if (op1b.Pt != Pt)
				{
					op1 = op1b;
					op1.Pt = Pt;
					op1b = this.DupOutPt(op1, !DiscardLeft);
				}
			}
			else
			{
				while (op1.Next.Pt.X >= Pt.X && op1.Next.Pt.X <= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
				{
					op1 = op1.Next;
				}
				if (!DiscardLeft && op1.Pt.X != Pt.X)
				{
					op1 = op1.Next;
				}
				op1b = this.DupOutPt(op1, DiscardLeft);
				if (op1b.Pt != Pt)
				{
					op1 = op1b;
					op1.Pt = Pt;
					op1b = this.DupOutPt(op1, DiscardLeft);
				}
			}
			if (direction2 == Direction.dLeftToRight)
			{
				while (op2.Next.Pt.X <= Pt.X && op2.Next.Pt.X >= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
				{
					op2 = op2.Next;
				}
				if (DiscardLeft && op2.Pt.X != Pt.X)
				{
					op2 = op2.Next;
				}
				op2b = this.DupOutPt(op2, !DiscardLeft);
				if (op2b.Pt != Pt)
				{
					op2 = op2b;
					op2.Pt = Pt;
					op2b = this.DupOutPt(op2, !DiscardLeft);
				}
			}
			else
			{
				while (op2.Next.Pt.X >= Pt.X && op2.Next.Pt.X <= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
				{
					op2 = op2.Next;
				}
				if (!DiscardLeft && op2.Pt.X != Pt.X)
				{
					op2 = op2.Next;
				}
				op2b = this.DupOutPt(op2, DiscardLeft);
				if (op2b.Pt != Pt)
				{
					op2 = op2b;
					op2.Pt = Pt;
					op2b = this.DupOutPt(op2, DiscardLeft);
				}
			}
			if (direction == Direction.dLeftToRight == DiscardLeft)
			{
				op1.Prev = op2;
				op2.Next = op1;
				op1b.Next = op2b;
				op2b.Prev = op1b;
			}
			else
			{
				op1.Next = op2;
				op2.Prev = op1;
				op1b.Prev = op2b;
				op2b.Next = op1b;
			}
			return true;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001F914 File Offset: 0x0001DB14
		private bool JoinPoints(Join j, OutRec outRec1, OutRec outRec2)
		{
			OutPt outPt = j.OutPt1;
			OutPt outPt2 = j.OutPt2;
			bool flag = j.OutPt1.Pt.Y == j.OffPt.Y;
			if (flag && j.OffPt == j.OutPt1.Pt && j.OffPt == j.OutPt2.Pt)
			{
				if (outRec1 != outRec2)
				{
					return false;
				}
				OutPt outPt3 = j.OutPt1.Next;
				while (outPt3 != outPt && outPt3.Pt == j.OffPt)
				{
					outPt3 = outPt3.Next;
				}
				bool flag2 = outPt3.Pt.Y > j.OffPt.Y;
				OutPt outPt4 = j.OutPt2.Next;
				while (outPt4 != outPt2 && outPt4.Pt == j.OffPt)
				{
					outPt4 = outPt4.Next;
				}
				bool flag3 = outPt4.Pt.Y > j.OffPt.Y;
				if (flag2 == flag3)
				{
					return false;
				}
				if (flag2)
				{
					outPt3 = this.DupOutPt(outPt, false);
					outPt4 = this.DupOutPt(outPt2, true);
					outPt.Prev = outPt2;
					outPt2.Next = outPt;
					outPt3.Next = outPt4;
					outPt4.Prev = outPt3;
					j.OutPt1 = outPt;
					j.OutPt2 = outPt3;
					return true;
				}
				outPt3 = this.DupOutPt(outPt, true);
				outPt4 = this.DupOutPt(outPt2, false);
				outPt.Next = outPt2;
				outPt2.Prev = outPt;
				outPt3.Prev = outPt4;
				outPt4.Next = outPt3;
				j.OutPt1 = outPt;
				j.OutPt2 = outPt3;
				return true;
			}
			else if (flag)
			{
				OutPt outPt3 = outPt;
				while (outPt.Prev.Pt.Y == outPt.Pt.Y && outPt.Prev != outPt3)
				{
					if (outPt.Prev == outPt2)
					{
						break;
					}
					outPt = outPt.Prev;
				}
				while (outPt3.Next.Pt.Y == outPt3.Pt.Y && outPt3.Next != outPt && outPt3.Next != outPt2)
				{
					outPt3 = outPt3.Next;
				}
				if (outPt3.Next == outPt || outPt3.Next == outPt2)
				{
					return false;
				}
				OutPt outPt4 = outPt2;
				while (outPt2.Prev.Pt.Y == outPt2.Pt.Y && outPt2.Prev != outPt4)
				{
					if (outPt2.Prev == outPt3)
					{
						break;
					}
					outPt2 = outPt2.Prev;
				}
				while (outPt4.Next.Pt.Y == outPt4.Pt.Y && outPt4.Next != outPt2 && outPt4.Next != outPt)
				{
					outPt4 = outPt4.Next;
				}
				if (outPt4.Next == outPt2 || outPt4.Next == outPt)
				{
					return false;
				}
				long num;
				long num2;
				if (!this.GetOverlap(outPt.Pt.X, outPt3.Pt.X, outPt2.Pt.X, outPt4.Pt.X, out num, out num2))
				{
					return false;
				}
				IntPoint pt;
				bool discardLeft;
				if (outPt.Pt.X >= num && outPt.Pt.X <= num2)
				{
					pt = outPt.Pt;
					discardLeft = (outPt.Pt.X > outPt3.Pt.X);
				}
				else if (outPt2.Pt.X >= num && outPt2.Pt.X <= num2)
				{
					pt = outPt2.Pt;
					discardLeft = (outPt2.Pt.X > outPt4.Pt.X);
				}
				else if (outPt3.Pt.X >= num && outPt3.Pt.X <= num2)
				{
					pt = outPt3.Pt;
					discardLeft = (outPt3.Pt.X > outPt.Pt.X);
				}
				else
				{
					pt = outPt4.Pt;
					discardLeft = (outPt4.Pt.X > outPt2.Pt.X);
				}
				j.OutPt1 = outPt;
				j.OutPt2 = outPt2;
				return this.JoinHorz(outPt, outPt3, outPt2, outPt4, pt, discardLeft);
			}
			else
			{
				OutPt outPt3 = outPt.Next;
				while (outPt3.Pt == outPt.Pt && outPt3 != outPt)
				{
					outPt3 = outPt3.Next;
				}
				bool flag4 = outPt3.Pt.Y > outPt.Pt.Y || !ClipperBase.SlopesEqual(outPt.Pt, outPt3.Pt, j.OffPt, this.m_UseFullRange);
				if (flag4)
				{
					outPt3 = outPt.Prev;
					while (outPt3.Pt == outPt.Pt && outPt3 != outPt)
					{
						outPt3 = outPt3.Prev;
					}
					if (outPt3.Pt.Y > outPt.Pt.Y || !ClipperBase.SlopesEqual(outPt.Pt, outPt3.Pt, j.OffPt, this.m_UseFullRange))
					{
						return false;
					}
				}
				OutPt outPt4 = outPt2.Next;
				while (outPt4.Pt == outPt2.Pt && outPt4 != outPt2)
				{
					outPt4 = outPt4.Next;
				}
				bool flag5 = outPt4.Pt.Y > outPt2.Pt.Y || !ClipperBase.SlopesEqual(outPt2.Pt, outPt4.Pt, j.OffPt, this.m_UseFullRange);
				if (flag5)
				{
					outPt4 = outPt2.Prev;
					while (outPt4.Pt == outPt2.Pt && outPt4 != outPt2)
					{
						outPt4 = outPt4.Prev;
					}
					if (outPt4.Pt.Y > outPt2.Pt.Y || !ClipperBase.SlopesEqual(outPt2.Pt, outPt4.Pt, j.OffPt, this.m_UseFullRange))
					{
						return false;
					}
				}
				if (outPt3 == outPt || outPt4 == outPt2 || outPt3 == outPt4 || (outRec1 == outRec2 && flag4 == flag5))
				{
					return false;
				}
				if (flag4)
				{
					outPt3 = this.DupOutPt(outPt, false);
					outPt4 = this.DupOutPt(outPt2, true);
					outPt.Prev = outPt2;
					outPt2.Next = outPt;
					outPt3.Next = outPt4;
					outPt4.Prev = outPt3;
					j.OutPt1 = outPt;
					j.OutPt2 = outPt3;
					return true;
				}
				outPt3 = this.DupOutPt(outPt, true);
				outPt4 = this.DupOutPt(outPt2, false);
				outPt.Next = outPt2;
				outPt2.Prev = outPt;
				outPt3.Prev = outPt4;
				outPt4.Next = outPt3;
				j.OutPt1 = outPt;
				j.OutPt2 = outPt3;
				return true;
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0001FF24 File Offset: 0x0001E124
		public static int PointInPolygon(IntPoint pt, List<IntPoint> path)
		{
			int num = 0;
			int count = path.Count;
			if (count < 3)
			{
				return 0;
			}
			IntPoint intPoint = path[0];
			for (int i = 1; i <= count; i++)
			{
				IntPoint intPoint2 = (i == count) ? path[0] : path[i];
				if (intPoint2.Y == pt.Y && (intPoint2.X == pt.X || (intPoint.Y == pt.Y && intPoint2.X > pt.X == intPoint.X < pt.X)))
				{
					return -1;
				}
				if (intPoint.Y < pt.Y != intPoint2.Y < pt.Y)
				{
					if (intPoint.X >= pt.X)
					{
						if (intPoint2.X > pt.X)
						{
							num = 1 - num;
						}
						else
						{
							double num2 = (double)(intPoint.X - pt.X) * (double)(intPoint2.Y - pt.Y) - (double)(intPoint2.X - pt.X) * (double)(intPoint.Y - pt.Y);
							if (num2 == 0.0)
							{
								return -1;
							}
							if (num2 > 0.0 == intPoint2.Y > intPoint.Y)
							{
								num = 1 - num;
							}
						}
					}
					else if (intPoint2.X > pt.X)
					{
						double num3 = (double)(intPoint.X - pt.X) * (double)(intPoint2.Y - pt.Y) - (double)(intPoint2.X - pt.X) * (double)(intPoint.Y - pt.Y);
						if (num3 == 0.0)
						{
							return -1;
						}
						if (num3 > 0.0 == intPoint2.Y > intPoint.Y)
						{
							num = 1 - num;
						}
					}
				}
				intPoint = intPoint2;
			}
			return num;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00020100 File Offset: 0x0001E300
		private static int PointInPolygon(IntPoint pt, OutPt op)
		{
			int num = 0;
			OutPt outPt = op;
			long x = pt.X;
			long y = pt.Y;
			long num2 = op.Pt.X;
			long num3 = op.Pt.Y;
			for (;;)
			{
				op = op.Next;
				long x2 = op.Pt.X;
				long y2 = op.Pt.Y;
				if (y2 == y && (x2 == x || (num3 == y && x2 > x == num2 < x)))
				{
					break;
				}
				if (num3 < y != y2 < y)
				{
					if (num2 >= x)
					{
						if (x2 > x)
						{
							num = 1 - num;
						}
						else
						{
							double num4 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
							if (num4 == 0.0)
							{
								return -1;
							}
							if (num4 > 0.0 == y2 > num3)
							{
								num = 1 - num;
							}
						}
					}
					else if (x2 > x)
					{
						double num5 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
						if (num5 == 0.0)
						{
							return -1;
						}
						if (num5 > 0.0 == y2 > num3)
						{
							num = 1 - num;
						}
					}
				}
				num2 = x2;
				num3 = y2;
				if (outPt == op)
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00020234 File Offset: 0x0001E434
		private static bool Poly2ContainsPoly1(OutPt outPt1, OutPt outPt2)
		{
			OutPt outPt3 = outPt1;
			int num;
			for (;;)
			{
				num = Clipper.PointInPolygon(outPt3.Pt, outPt2);
				if (num >= 0)
				{
					break;
				}
				outPt3 = outPt3.Next;
				if (outPt3 == outPt1)
				{
					return true;
				}
			}
			return num > 0;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00020268 File Offset: 0x0001E468
		private void FixupFirstLefts1(OutRec OldOutRec, OutRec NewOutRec)
		{
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				OutRec outRec2 = Clipper.ParseFirstLeft(outRec.FirstLeft);
				if (outRec.Pts != null && outRec2 == OldOutRec && Clipper.Poly2ContainsPoly1(outRec.Pts, NewOutRec.Pts))
				{
					outRec.FirstLeft = NewOutRec;
				}
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000202E8 File Offset: 0x0001E4E8
		private void FixupFirstLefts2(OutRec innerOutRec, OutRec outerOutRec)
		{
			OutRec firstLeft = outerOutRec.FirstLeft;
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				if (outRec.Pts != null && outRec != outerOutRec && outRec != innerOutRec)
				{
					OutRec outRec2 = Clipper.ParseFirstLeft(outRec.FirstLeft);
					if (outRec2 == firstLeft || outRec2 == innerOutRec || outRec2 == outerOutRec)
					{
						if (Clipper.Poly2ContainsPoly1(outRec.Pts, innerOutRec.Pts))
						{
							outRec.FirstLeft = innerOutRec;
						}
						else if (Clipper.Poly2ContainsPoly1(outRec.Pts, outerOutRec.Pts))
						{
							outRec.FirstLeft = outerOutRec;
						}
						else if (outRec.FirstLeft == innerOutRec || outRec.FirstLeft == outerOutRec)
						{
							outRec.FirstLeft = firstLeft;
						}
					}
				}
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000203BC File Offset: 0x0001E5BC
		private void FixupFirstLefts3(OutRec OldOutRec, OutRec NewOutRec)
		{
			foreach (OutRec outRec in this.m_PolyOuts)
			{
				OutRec outRec2 = Clipper.ParseFirstLeft(outRec.FirstLeft);
				if (outRec.Pts != null && outRec2 == OldOutRec)
				{
					outRec.FirstLeft = NewOutRec;
				}
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00020428 File Offset: 0x0001E628
		private static OutRec ParseFirstLeft(OutRec FirstLeft)
		{
			while (FirstLeft != null && FirstLeft.Pts == null)
			{
				FirstLeft = FirstLeft.FirstLeft;
			}
			return FirstLeft;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00020440 File Offset: 0x0001E640
		private void JoinCommonEdges()
		{
			foreach (Join join in this.m_Joins)
			{
				OutRec outRec = this.GetOutRec(join.OutPt1.Idx);
				OutRec outRec2 = this.GetOutRec(join.OutPt2.Idx);
				if (outRec.Pts != null && outRec2.Pts != null && !outRec.IsOpen && !outRec2.IsOpen)
				{
					OutRec outRec3;
					if (outRec == outRec2)
					{
						outRec3 = outRec;
					}
					else if (this.OutRec1RightOfOutRec2(outRec, outRec2))
					{
						outRec3 = outRec2;
					}
					else if (this.OutRec1RightOfOutRec2(outRec2, outRec))
					{
						outRec3 = outRec;
					}
					else
					{
						outRec3 = this.GetLowermostRec(outRec, outRec2);
					}
					if (this.JoinPoints(join, outRec, outRec2))
					{
						if (outRec == outRec2)
						{
							outRec.Pts = join.OutPt1;
							outRec.BottomPt = null;
							outRec2 = base.CreateOutRec();
							outRec2.Pts = join.OutPt2;
							this.UpdateOutPtIdxs(outRec2);
							if (Clipper.Poly2ContainsPoly1(outRec2.Pts, outRec.Pts))
							{
								outRec2.IsHole = !outRec.IsHole;
								outRec2.FirstLeft = outRec;
								if (this.m_UsingPolyTree)
								{
									this.FixupFirstLefts2(outRec2, outRec);
								}
								if ((outRec2.IsHole ^ this.ReverseSolution) == this.Area(outRec2) > 0.0)
								{
									this.ReversePolyPtLinks(outRec2.Pts);
								}
							}
							else if (Clipper.Poly2ContainsPoly1(outRec.Pts, outRec2.Pts))
							{
								outRec2.IsHole = outRec.IsHole;
								outRec.IsHole = !outRec2.IsHole;
								outRec2.FirstLeft = outRec.FirstLeft;
								outRec.FirstLeft = outRec2;
								if (this.m_UsingPolyTree)
								{
									this.FixupFirstLefts2(outRec, outRec2);
								}
								if ((outRec.IsHole ^ this.ReverseSolution) == this.Area(outRec) > 0.0)
								{
									this.ReversePolyPtLinks(outRec.Pts);
								}
							}
							else
							{
								outRec2.IsHole = outRec.IsHole;
								outRec2.FirstLeft = outRec.FirstLeft;
								if (this.m_UsingPolyTree)
								{
									this.FixupFirstLefts1(outRec, outRec2);
								}
							}
						}
						else
						{
							outRec2.Pts = null;
							outRec2.BottomPt = null;
							outRec2.Idx = outRec.Idx;
							outRec.IsHole = outRec3.IsHole;
							if (outRec3 == outRec2)
							{
								outRec.FirstLeft = outRec2.FirstLeft;
							}
							outRec2.FirstLeft = outRec;
							if (this.m_UsingPolyTree)
							{
								this.FixupFirstLefts3(outRec2, outRec);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000206CC File Offset: 0x0001E8CC
		private void UpdateOutPtIdxs(OutRec outrec)
		{
			OutPt outPt = outrec.Pts;
			do
			{
				outPt.Idx = outrec.Idx;
				outPt = outPt.Prev;
			}
			while (outPt != outrec.Pts);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000206FC File Offset: 0x0001E8FC
		private void DoSimplePolygons()
		{
			int i = 0;
			while (i < this.m_PolyOuts.Count)
			{
				OutRec outRec = this.m_PolyOuts[i++];
				OutPt outPt = outRec.Pts;
				if (outPt != null && !outRec.IsOpen)
				{
					do
					{
						for (OutPt outPt2 = outPt.Next; outPt2 != outRec.Pts; outPt2 = outPt2.Next)
						{
							if (outPt.Pt == outPt2.Pt && outPt2.Next != outPt && outPt2.Prev != outPt)
							{
								OutPt prev = outPt.Prev;
								OutPt prev2 = outPt2.Prev;
								outPt.Prev = prev2;
								prev2.Next = outPt;
								outPt2.Prev = prev;
								prev.Next = outPt2;
								outRec.Pts = outPt;
								OutRec outRec2 = base.CreateOutRec();
								outRec2.Pts = outPt2;
								this.UpdateOutPtIdxs(outRec2);
								if (Clipper.Poly2ContainsPoly1(outRec2.Pts, outRec.Pts))
								{
									outRec2.IsHole = !outRec.IsHole;
									outRec2.FirstLeft = outRec;
									if (this.m_UsingPolyTree)
									{
										this.FixupFirstLefts2(outRec2, outRec);
									}
								}
								else if (Clipper.Poly2ContainsPoly1(outRec.Pts, outRec2.Pts))
								{
									outRec2.IsHole = outRec.IsHole;
									outRec.IsHole = !outRec2.IsHole;
									outRec2.FirstLeft = outRec.FirstLeft;
									outRec.FirstLeft = outRec2;
									if (this.m_UsingPolyTree)
									{
										this.FixupFirstLefts2(outRec, outRec2);
									}
								}
								else
								{
									outRec2.IsHole = outRec.IsHole;
									outRec2.FirstLeft = outRec.FirstLeft;
									if (this.m_UsingPolyTree)
									{
										this.FixupFirstLefts1(outRec, outRec2);
									}
								}
								outPt2 = outPt;
							}
						}
						outPt = outPt.Next;
					}
					while (outPt != outRec.Pts);
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000208C4 File Offset: 0x0001EAC4
		public static double Area(List<IntPoint> poly)
		{
			int count = poly.Count;
			if (count < 3)
			{
				return 0.0;
			}
			double num = 0.0;
			int i = 0;
			int index = count - 1;
			while (i < count)
			{
				num += ((double)poly[index].X + (double)poly[i].X) * ((double)poly[index].Y - (double)poly[i].Y);
				index = i;
				i++;
			}
			return -num * 0.5;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00020948 File Offset: 0x0001EB48
		internal double Area(OutRec outRec)
		{
			return this.Area(outRec.Pts);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00020958 File Offset: 0x0001EB58
		internal double Area(OutPt op)
		{
			OutPt outPt = op;
			if (op == null)
			{
				return 0.0;
			}
			double num = 0.0;
			do
			{
				num += (double)(op.Prev.Pt.X + op.Pt.X) * (double)(op.Prev.Pt.Y - op.Pt.Y);
				op = op.Next;
			}
			while (op != outPt);
			return num * 0.5;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x000209D4 File Offset: 0x0001EBD4
		public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = PolyFillType.pftEvenOdd)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			clipper.StrictlySimple = true;
			clipper.AddPath(poly, PolyType.ptSubject, true);
			clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
			return list;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00020A0C File Offset: 0x0001EC0C
		public static List<List<IntPoint>> SimplifyPolygons(List<List<IntPoint>> polys, PolyFillType fillType = PolyFillType.pftEvenOdd)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			clipper.StrictlySimple = true;
			clipper.AddPaths(polys, PolyType.ptSubject, true);
			clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
			return list;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00020A44 File Offset: 0x0001EC44
		private static double DistanceFromLineSqrd(IntPoint pt, IntPoint ln1, IntPoint ln2)
		{
			double num = (double)(ln1.Y - ln2.Y);
			double num2 = (double)(ln2.X - ln1.X);
			double num3 = num * (double)ln1.X + num2 * (double)ln1.Y;
			num3 = num * (double)pt.X + num2 * (double)pt.Y - num3;
			return num3 * num3 / (num * num + num2 * num2);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00020AA4 File Offset: 0x0001ECA4
		private static bool SlopesNearCollinear(IntPoint pt1, IntPoint pt2, IntPoint pt3, double distSqrd)
		{
			if (Math.Abs(pt1.X - pt2.X) > Math.Abs(pt1.Y - pt2.Y))
			{
				if (pt1.X > pt2.X == pt1.X < pt3.X)
				{
					return Clipper.DistanceFromLineSqrd(pt1, pt2, pt3) < distSqrd;
				}
				if (pt2.X > pt1.X == pt2.X < pt3.X)
				{
					return Clipper.DistanceFromLineSqrd(pt2, pt1, pt3) < distSqrd;
				}
				return Clipper.DistanceFromLineSqrd(pt3, pt1, pt2) < distSqrd;
			}
			else
			{
				if (pt1.Y > pt2.Y == pt1.Y < pt3.Y)
				{
					return Clipper.DistanceFromLineSqrd(pt1, pt2, pt3) < distSqrd;
				}
				if (pt2.Y > pt1.Y == pt2.Y < pt3.Y)
				{
					return Clipper.DistanceFromLineSqrd(pt2, pt1, pt3) < distSqrd;
				}
				return Clipper.DistanceFromLineSqrd(pt3, pt1, pt2) < distSqrd;
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00020B98 File Offset: 0x0001ED98
		private static bool PointsAreClose(IntPoint pt1, IntPoint pt2, double distSqrd)
		{
			double num = (double)pt1.X - (double)pt2.X;
			double num2 = (double)pt1.Y - (double)pt2.Y;
			return num * num + num2 * num2 <= distSqrd;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00020BD0 File Offset: 0x0001EDD0
		private static OutPt ExcludeOp(OutPt op)
		{
			OutPt prev = op.Prev;
			prev.Next = op.Next;
			op.Next.Prev = prev;
			prev.Idx = 0;
			return prev;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00020C04 File Offset: 0x0001EE04
		public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
		{
			int num = path.Count;
			if (num == 0)
			{
				return new List<IntPoint>();
			}
			OutPt[] array = new OutPt[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new OutPt();
			}
			for (int j = 0; j < num; j++)
			{
				array[j].Pt = path[j];
				array[j].Next = array[(j + 1) % num];
				array[j].Next.Prev = array[j];
				array[j].Idx = 0;
			}
			double distSqrd = distance * distance;
			OutPt outPt = array[0];
			while (outPt.Idx == 0 && outPt.Next != outPt.Prev)
			{
				if (Clipper.PointsAreClose(outPt.Pt, outPt.Prev.Pt, distSqrd))
				{
					outPt = Clipper.ExcludeOp(outPt);
					num--;
				}
				else if (Clipper.PointsAreClose(outPt.Prev.Pt, outPt.Next.Pt, distSqrd))
				{
					Clipper.ExcludeOp(outPt.Next);
					outPt = Clipper.ExcludeOp(outPt);
					num -= 2;
				}
				else if (Clipper.SlopesNearCollinear(outPt.Prev.Pt, outPt.Pt, outPt.Next.Pt, distSqrd))
				{
					outPt = Clipper.ExcludeOp(outPt);
					num--;
				}
				else
				{
					outPt.Idx = 1;
					outPt = outPt.Next;
				}
			}
			if (num < 3)
			{
				num = 0;
			}
			List<IntPoint> list = new List<IntPoint>(num);
			for (int k = 0; k < num; k++)
			{
				list.Add(outPt.Pt);
				outPt = outPt.Next;
			}
			return list;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00020D88 File Offset: 0x0001EF88
		public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>(polys.Count);
			foreach (List<IntPoint> path in polys)
			{
				list.Add(Clipper.CleanPolygon(path, distance));
			}
			return list;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00020DEC File Offset: 0x0001EFEC
		internal static List<List<IntPoint>> Minkowski(List<IntPoint> pattern, List<IntPoint> path, bool IsSum, bool IsClosed)
		{
			int num = IsClosed ? 1 : 0;
			int count = pattern.Count;
			int count2 = path.Count;
			List<List<IntPoint>> list = new List<List<IntPoint>>(count2);
			if (IsSum)
			{
				for (int i = 0; i < count2; i++)
				{
					List<IntPoint> list2 = new List<IntPoint>(count);
					foreach (IntPoint intPoint in pattern)
					{
						list2.Add(new IntPoint(path[i].X + intPoint.X, path[i].Y + intPoint.Y));
					}
					list.Add(list2);
				}
			}
			else
			{
				for (int j = 0; j < count2; j++)
				{
					List<IntPoint> list3 = new List<IntPoint>(count);
					foreach (IntPoint intPoint2 in pattern)
					{
						list3.Add(new IntPoint(path[j].X - intPoint2.X, path[j].Y - intPoint2.Y));
					}
					list.Add(list3);
				}
			}
			List<List<IntPoint>> list4 = new List<List<IntPoint>>((count2 + num) * (count + 1));
			for (int k = 0; k < count2 - 1 + num; k++)
			{
				for (int l = 0; l < count; l++)
				{
					List<IntPoint> list5 = new List<IntPoint>(4)
					{
						list[k % count2][l % count],
						list[(k + 1) % count2][l % count],
						list[(k + 1) % count2][(l + 1) % count],
						list[k % count2][(l + 1) % count]
					};
					if (!Clipper.Orientation(list5))
					{
						list5.Reverse();
					}
					list4.Add(list5);
				}
			}
			return list4;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00021010 File Offset: 0x0001F210
		public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<IntPoint> path, bool pathIsClosed)
		{
			List<List<IntPoint>> list = Clipper.Minkowski(pattern, path, true, pathIsClosed);
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(list, PolyType.ptSubject, true);
			clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
			return list;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00021044 File Offset: 0x0001F244
		private static List<IntPoint> TranslatePath(List<IntPoint> path, IntPoint delta)
		{
			List<IntPoint> list = new List<IntPoint>(path.Count);
			for (int i = 0; i < path.Count; i++)
			{
				list.Add(new IntPoint(path[i].X + delta.X, path[i].Y + delta.Y));
			}
			return list;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000210A0 File Offset: 0x0001F2A0
		public static List<List<IntPoint>> MinkowskiSum(List<IntPoint> pattern, List<List<IntPoint>> paths, bool pathIsClosed)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>();
			Clipper clipper = new Clipper(0);
			foreach (List<IntPoint> path in paths)
			{
				List<List<IntPoint>> ppg = Clipper.Minkowski(pattern, path, true, pathIsClosed);
				clipper.AddPaths(ppg, PolyType.ptSubject, true);
				if (pathIsClosed)
				{
					List<IntPoint> pg = Clipper.TranslatePath(path, pattern[0]);
					clipper.AddPath(pg, PolyType.ptClip, true);
				}
			}
			clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
			return list;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00021134 File Offset: 0x0001F334
		public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2)
		{
			List<List<IntPoint>> list = Clipper.Minkowski(poly1, poly2, false, true);
			Clipper clipper = new Clipper(0);
			clipper.AddPaths(list, PolyType.ptSubject, true);
			clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
			return list;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00021168 File Offset: 0x0001F368
		public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>
			{
				Capacity = polytree.Total
			};
			Clipper.AddPolyNodeToPaths(polytree, Clipper.NodeType.ntAny, list);
			return list;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00021190 File Offset: 0x0001F390
		internal static void AddPolyNodeToPaths(PolyNode polynode, Clipper.NodeType nt, List<List<IntPoint>> paths)
		{
			bool flag = true;
			if (nt != Clipper.NodeType.ntOpen)
			{
				if (nt == Clipper.NodeType.ntClosed)
				{
					flag = !polynode.IsOpen;
				}
				if (polynode.m_polygon.Count > 0 && flag)
				{
					paths.Add(polynode.m_polygon);
				}
				foreach (PolyNode polynode2 in polynode.Childs)
				{
					Clipper.AddPolyNodeToPaths(polynode2, nt, paths);
				}
				return;
			}
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00021218 File Offset: 0x0001F418
		public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>
			{
				Capacity = polytree.ChildCount
			};
			for (int i = 0; i < polytree.ChildCount; i++)
			{
				if (polytree.Childs[i].IsOpen)
				{
					list.Add(polytree.Childs[i].m_polygon);
				}
			}
			return list;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00021274 File Offset: 0x0001F474
		public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
		{
			List<List<IntPoint>> list = new List<List<IntPoint>>
			{
				Capacity = polytree.Total
			};
			Clipper.AddPolyNodeToPaths(polytree, Clipper.NodeType.ntClosed, list);
			return list;
		}

		// Token: 0x04000212 RID: 530
		public const int ioReverseSolution = 1;

		// Token: 0x04000213 RID: 531
		public const int ioStrictlySimple = 2;

		// Token: 0x04000214 RID: 532
		public const int ioPreserveCollinear = 4;

		// Token: 0x04000215 RID: 533
		private readonly List<Join> m_GhostJoins;

		// Token: 0x04000216 RID: 534
		private readonly List<IntersectNode> m_IntersectList;

		// Token: 0x04000217 RID: 535
		private readonly IComparer<IntersectNode> m_IntersectNodeComparer;

		// Token: 0x04000218 RID: 536
		private readonly List<Join> m_Joins;

		// Token: 0x04000219 RID: 537
		private PolyFillType m_ClipFillType;

		// Token: 0x0400021A RID: 538
		private ClipType m_ClipType;

		// Token: 0x0400021B RID: 539
		private bool m_ExecuteLocked;

		// Token: 0x0400021C RID: 540
		private Maxima m_Maxima;

		// Token: 0x0400021D RID: 541
		private TEdge m_SortedEdges;

		// Token: 0x0400021E RID: 542
		private PolyFillType m_SubjFillType;

		// Token: 0x0400021F RID: 543
		private bool m_UsingPolyTree;

		// Token: 0x020004C4 RID: 1220
		internal enum NodeType
		{
			// Token: 0x04000C61 RID: 3169
			ntAny,
			// Token: 0x04000C62 RID: 3170
			ntOpen,
			// Token: 0x04000C63 RID: 3171
			ntClosed
		}
	}
}
