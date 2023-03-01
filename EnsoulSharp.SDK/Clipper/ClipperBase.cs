using System;
using System.Collections.Generic;

namespace EnsoulSharp.SDK.Clipper
{
	// Token: 0x02000060 RID: 96
	public class ClipperBase
	{
		// Token: 0x060003BC RID: 956 RVA: 0x0001A5E6 File Offset: 0x000187E6
		internal ClipperBase()
		{
			this.m_MinimaList = null;
			this.m_CurrentLM = null;
			this.m_UseFullRange = false;
			this.m_HasOpenPaths = false;
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0001A615 File Offset: 0x00018815
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0001A61D File Offset: 0x0001881D
		public bool PreserveCollinear { get; set; }

		// Token: 0x060003BF RID: 959 RVA: 0x0001A626 File Offset: 0x00018826
		internal static bool Near_zero(double val)
		{
			return val > -1E-20 && val < 1E-20;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0001A644 File Offset: 0x00018844
		public void Swap(ref long val1, ref long val2)
		{
			long num = val1;
			val1 = val2;
			val2 = num;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0001A65B File Offset: 0x0001885B
		internal static bool IsHorizontal(TEdge e)
		{
			return e.Delta.Y == 0L;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0001A66C File Offset: 0x0001886C
		internal bool PointIsVertex(IntPoint pt, OutPt pp)
		{
			OutPt outPt = pp;
			while (!(outPt.Pt == pt))
			{
				outPt = outPt.Next;
				if (outPt == pp)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001A698 File Offset: 0x00018898
		internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && Int128.Int128Mul(pt.X - linePt1.X, linePt2.Y - linePt1.Y) == Int128.Int128Mul(linePt2.X - linePt1.X, pt.Y - linePt1.Y));
			}
			return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && (pt.X - linePt1.X) * (linePt2.Y - linePt1.Y) == (linePt2.X - linePt1.X) * (pt.Y - linePt1.Y));
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001A81C File Offset: 0x00018A1C
		internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
		{
			OutPt outPt = pp;
			while (!this.PointOnLineSegment(pt, outPt.Pt, outPt.Next.Pt, UseFullRange))
			{
				outPt = outPt.Next;
				if (outPt == pp)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0001A854 File Offset: 0x00018A54
		internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(e1.Delta.Y, e2.Delta.X) == Int128.Int128Mul(e1.Delta.X, e2.Delta.Y);
			}
			return e1.Delta.Y * e2.Delta.X == e1.Delta.X * e2.Delta.Y;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0001A8D0 File Offset: 0x00018AD0
		internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(pt1.Y - pt2.Y, pt2.X - pt3.X) == Int128.Int128Mul(pt1.X - pt2.X, pt2.Y - pt3.Y);
			}
			return (pt1.Y - pt2.Y) * (pt2.X - pt3.X) - (pt1.X - pt2.X) * (pt2.Y - pt3.Y) == 0L;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001A960 File Offset: 0x00018B60
		internal static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(pt1.Y - pt2.Y, pt3.X - pt4.X) == Int128.Int128Mul(pt1.X - pt2.X, pt3.Y - pt4.Y);
			}
			return (pt1.Y - pt2.Y) * (pt3.X - pt4.X) - (pt1.X - pt2.X) * (pt3.Y - pt4.Y) == 0L;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0001A9F0 File Offset: 0x00018BF0
		public virtual void Clear()
		{
			this.DisposeLocalMinimaList();
			foreach (List<TEdge> list in this.m_edges)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = null;
				}
				list.Clear();
			}
			this.m_edges.Clear();
			this.m_UseFullRange = false;
			this.m_HasOpenPaths = false;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0001AA7C File Offset: 0x00018C7C
		private void DisposeLocalMinimaList()
		{
			while (this.m_MinimaList != null)
			{
				LocalMinima next = this.m_MinimaList.Next;
				this.m_MinimaList = null;
				this.m_MinimaList = next;
			}
			this.m_CurrentLM = null;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0001AAB4 File Offset: 0x00018CB4
		private void RangeTest(IntPoint Pt, ref bool useFullRange)
		{
			if (useFullRange)
			{
				if (Pt.X > 4611686018427387903L || Pt.Y > 4611686018427387903L || -Pt.X > 4611686018427387903L || -Pt.Y > 4611686018427387903L)
				{
					throw new ClipperException("Coordinate outside allowed range");
				}
			}
			else if (Pt.X > 1073741823L || Pt.Y > 1073741823L || -Pt.X > 1073741823L || -Pt.Y > 1073741823L)
			{
				useFullRange = true;
				this.RangeTest(Pt, ref useFullRange);
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0001AB5B File Offset: 0x00018D5B
		private void InitEdge(TEdge e, TEdge eNext, TEdge ePrev, IntPoint pt)
		{
			e.Next = eNext;
			e.Prev = ePrev;
			e.Curr = pt;
			e.OutIdx = -1;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0001AB7C File Offset: 0x00018D7C
		private void InitEdge2(TEdge e, PolyType polyType)
		{
			if (e.Curr.Y >= e.Next.Curr.Y)
			{
				e.Bot = e.Curr;
				e.Top = e.Next.Curr;
			}
			else
			{
				e.Top = e.Curr;
				e.Bot = e.Next.Curr;
			}
			this.SetDx(e);
			e.PolyTyp = polyType;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001ABF0 File Offset: 0x00018DF0
		private static TEdge FindNextLocMin(TEdge E)
		{
			TEdge tedge;
			for (;;)
			{
				if (!(E.Bot != E.Prev.Bot) && !(E.Curr == E.Top))
				{
					if (E.Dx != -3.4E+38 && E.Prev.Dx != -3.4E+38)
					{
						break;
					}
					while (E.Prev.Dx == -3.4E+38)
					{
						E = E.Prev;
					}
					tedge = E;
					while (E.Dx == -3.4E+38)
					{
						E = E.Next;
					}
					if (E.Top.Y != E.Prev.Bot.Y)
					{
						goto Block_7;
					}
				}
				else
				{
					E = E.Next;
				}
			}
			return E;
			Block_7:
			if (tedge.Prev.Bot.X < E.Bot.X)
			{
				E = tedge;
			}
			return E;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0001ACD8 File Offset: 0x00018ED8
		private TEdge ProcessBound(TEdge E, bool LeftBoundIsForward)
		{
			TEdge tedge = E;
			if (tedge.OutIdx == -2)
			{
				E = tedge;
				if (LeftBoundIsForward)
				{
					while (E.Top.Y == E.Next.Bot.Y)
					{
						E = E.Next;
					}
					while (E != tedge)
					{
						if (E.Dx != -3.4E+38)
						{
							break;
						}
						E = E.Prev;
					}
				}
				else
				{
					while (E.Top.Y == E.Prev.Bot.Y)
					{
						E = E.Prev;
					}
					while (E != tedge && E.Dx == -3.4E+38)
					{
						E = E.Next;
					}
				}
				if (E == tedge)
				{
					tedge = (LeftBoundIsForward ? E.Next : E.Prev);
				}
				else
				{
					E = (LeftBoundIsForward ? tedge.Next : tedge.Prev);
					LocalMinima newLm = new LocalMinima
					{
						Next = null,
						Y = E.Bot.Y,
						LeftBound = null,
						RightBound = E
					};
					E.WindDelta = 0;
					tedge = this.ProcessBound(E, LeftBoundIsForward);
					this.InsertLocalMinima(newLm);
				}
				return tedge;
			}
			TEdge tedge2;
			if (E.Dx == -3.4E+38)
			{
				tedge2 = (LeftBoundIsForward ? E.Prev : E.Next);
				if (tedge2.Dx == -3.4E+38)
				{
					if (tedge2.Bot.X != E.Bot.X && tedge2.Top.X != E.Bot.X)
					{
						this.ReverseHorizontal(E);
					}
				}
				else if (tedge2.Bot.X != E.Bot.X)
				{
					this.ReverseHorizontal(E);
				}
			}
			tedge2 = E;
			if (LeftBoundIsForward)
			{
				while (tedge.Top.Y == tedge.Next.Bot.Y && tedge.Next.OutIdx != -2)
				{
					tedge = tedge.Next;
				}
				if (tedge.Dx == -3.4E+38 && tedge.Next.OutIdx != -2)
				{
					TEdge tedge3 = tedge;
					while (tedge3.Prev.Dx == -3.4E+38)
					{
						tedge3 = tedge3.Prev;
					}
					if (tedge3.Prev.Top.X > tedge.Next.Top.X)
					{
						tedge = tedge3.Prev;
					}
				}
				while (E != tedge)
				{
					E.NextInLML = E.Next;
					if (E.Dx == -3.4E+38 && E != tedge2 && E.Bot.X != E.Prev.Top.X)
					{
						this.ReverseHorizontal(E);
					}
					E = E.Next;
				}
				if (E.Dx == -3.4E+38 && E != tedge2 && E.Bot.X != E.Prev.Top.X)
				{
					this.ReverseHorizontal(E);
				}
				tedge = tedge.Next;
			}
			else
			{
				while (tedge.Top.Y == tedge.Prev.Bot.Y && tedge.Prev.OutIdx != -2)
				{
					tedge = tedge.Prev;
				}
				if (tedge.Dx == -3.4E+38 && tedge.Prev.OutIdx != -2)
				{
					TEdge tedge3 = tedge;
					while (tedge3.Next.Dx == -3.4E+38)
					{
						tedge3 = tedge3.Next;
					}
					if (tedge3.Next.Top.X == tedge.Prev.Top.X || tedge3.Next.Top.X > tedge.Prev.Top.X)
					{
						tedge = tedge3.Next;
					}
				}
				while (E != tedge)
				{
					E.NextInLML = E.Prev;
					if (E.Dx == -3.4E+38 && E != tedge2 && E.Bot.X != E.Next.Top.X)
					{
						this.ReverseHorizontal(E);
					}
					E = E.Prev;
				}
				if (E.Dx == -3.4E+38 && E != tedge2 && E.Bot.X != E.Next.Top.X)
				{
					this.ReverseHorizontal(E);
				}
				tedge = tedge.Prev;
			}
			return tedge;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001B120 File Offset: 0x00019320
		public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
		{
			if (!Closed && polyType == PolyType.ptClip)
			{
				throw new ClipperException("AddPath: Open paths must be subject.");
			}
			int i = pg.Count - 1;
			if (Closed)
			{
				while (i > 0)
				{
					if (!(pg[i] == pg[0]))
					{
						break;
					}
					i--;
				}
			}
			while (i > 0 && pg[i] == pg[i - 1])
			{
				i--;
			}
			if ((Closed && i < 2) || (!Closed && i < 1))
			{
				return false;
			}
			List<TEdge> list = new List<TEdge>(i + 1);
			for (int j = 0; j <= i; j++)
			{
				list.Add(new TEdge());
			}
			bool flag = true;
			list[1].Curr = pg[1];
			this.RangeTest(pg[0], ref this.m_UseFullRange);
			this.RangeTest(pg[i], ref this.m_UseFullRange);
			this.InitEdge(list[0], list[1], list[i], pg[0]);
			this.InitEdge(list[i], list[0], list[i - 1], pg[i]);
			for (int k = i - 1; k >= 1; k--)
			{
				this.RangeTest(pg[k], ref this.m_UseFullRange);
				this.InitEdge(list[k], list[k + 1], list[k - 1], pg[k]);
			}
			TEdge tedge = list[0];
			TEdge tedge2 = tedge;
			TEdge tedge3 = tedge;
			for (;;)
			{
				if (tedge2.Curr == tedge2.Next.Curr && (Closed || tedge2.Next != tedge))
				{
					if (tedge2 == tedge2.Next)
					{
						break;
					}
					if (tedge2 == tedge)
					{
						tedge = tedge2.Next;
					}
					tedge2 = this.RemoveEdge(tedge2);
					tedge3 = tedge2;
				}
				else
				{
					if (tedge2.Prev == tedge2.Next)
					{
						break;
					}
					if (Closed && ClipperBase.SlopesEqual(tedge2.Prev.Curr, tedge2.Curr, tedge2.Next.Curr, this.m_UseFullRange) && (!this.PreserveCollinear || !this.Pt2IsBetweenPt1AndPt3(tedge2.Prev.Curr, tedge2.Curr, tedge2.Next.Curr)))
					{
						if (tedge2 == tedge)
						{
							tedge = tedge2.Next;
						}
						tedge2 = this.RemoveEdge(tedge2);
						tedge2 = tedge2.Prev;
						tedge3 = tedge2;
					}
					else
					{
						tedge2 = tedge2.Next;
						if (tedge2 == tedge3 || (!Closed && tedge2.Next == tedge))
						{
							break;
						}
					}
				}
			}
			if ((!Closed && tedge2 == tedge2.Next) || (Closed && tedge2.Prev == tedge2.Next))
			{
				return false;
			}
			if (!Closed)
			{
				this.m_HasOpenPaths = true;
				tedge.Prev.OutIdx = -2;
			}
			tedge2 = tedge;
			do
			{
				this.InitEdge2(tedge2, polyType);
				tedge2 = tedge2.Next;
				if (flag && tedge2.Curr.Y != tedge.Curr.Y)
				{
					flag = false;
				}
			}
			while (tedge2 != tedge);
			if (!flag)
			{
				this.m_edges.Add(list);
				TEdge tedge4 = null;
				if (tedge2.Prev.Bot == tedge2.Prev.Top)
				{
					tedge2 = tedge2.Next;
				}
				for (;;)
				{
					tedge2 = ClipperBase.FindNextLocMin(tedge2);
					if (tedge2 == tedge4)
					{
						break;
					}
					if (tedge4 == null)
					{
						tedge4 = tedge2;
					}
					LocalMinima localMinima = new LocalMinima
					{
						Next = null,
						Y = tedge2.Bot.Y
					};
					bool flag2;
					if (tedge2.Dx < tedge2.Prev.Dx)
					{
						localMinima.LeftBound = tedge2.Prev;
						localMinima.RightBound = tedge2;
						flag2 = false;
					}
					else
					{
						localMinima.LeftBound = tedge2;
						localMinima.RightBound = tedge2.Prev;
						flag2 = true;
					}
					localMinima.LeftBound.Side = EdgeSide.esLeft;
					localMinima.RightBound.Side = EdgeSide.esRight;
					if (!Closed)
					{
						localMinima.LeftBound.WindDelta = 0;
					}
					else if (localMinima.LeftBound.Next == localMinima.RightBound)
					{
						localMinima.LeftBound.WindDelta = -1;
					}
					else
					{
						localMinima.LeftBound.WindDelta = 1;
					}
					localMinima.RightBound.WindDelta = -localMinima.LeftBound.WindDelta;
					tedge2 = this.ProcessBound(localMinima.LeftBound, flag2);
					if (tedge2.OutIdx == -2)
					{
						tedge2 = this.ProcessBound(tedge2, flag2);
					}
					TEdge tedge5 = this.ProcessBound(localMinima.RightBound, !flag2);
					if (tedge5.OutIdx == -2)
					{
						tedge5 = this.ProcessBound(tedge5, !flag2);
					}
					if (localMinima.LeftBound.OutIdx == -2)
					{
						localMinima.LeftBound = null;
					}
					else if (localMinima.RightBound.OutIdx == -2)
					{
						localMinima.RightBound = null;
					}
					this.InsertLocalMinima(localMinima);
					if (!flag2)
					{
						tedge2 = tedge5;
					}
				}
				return true;
			}
			if (Closed)
			{
				return false;
			}
			tedge2.Prev.OutIdx = -2;
			LocalMinima localMinima2 = new LocalMinima
			{
				Next = null,
				Y = tedge2.Bot.Y,
				LeftBound = null,
				RightBound = tedge2
			};
			localMinima2.RightBound.Side = EdgeSide.esRight;
			localMinima2.RightBound.WindDelta = 0;
			for (;;)
			{
				if (tedge2.Bot.X != tedge2.Prev.Top.X)
				{
					this.ReverseHorizontal(tedge2);
				}
				if (tedge2.Next.OutIdx == -2)
				{
					break;
				}
				tedge2.NextInLML = tedge2.Next;
				tedge2 = tedge2.Next;
			}
			this.InsertLocalMinima(localMinima2);
			this.m_edges.Add(list);
			return true;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001B6BC File Offset: 0x000198BC
		public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
		{
			bool result = false;
			foreach (List<IntPoint> pg in ppg)
			{
				if (this.AddPath(pg, polyType, closed))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001B714 File Offset: 0x00019914
		internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3)
		{
			if (pt1 == pt3 || pt1 == pt2 || pt3 == pt2)
			{
				return false;
			}
			if (pt1.X != pt3.X)
			{
				return pt2.X > pt1.X == pt2.X < pt3.X;
			}
			return pt2.Y > pt1.Y == pt2.Y < pt3.Y;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001B789 File Offset: 0x00019989
		private TEdge RemoveEdge(TEdge e)
		{
			e.Prev.Next = e.Next;
			e.Next.Prev = e.Prev;
			TEdge next = e.Next;
			e.Prev = null;
			return next;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001B7BC File Offset: 0x000199BC
		private void SetDx(TEdge e)
		{
			e.Delta.X = e.Top.X - e.Bot.X;
			e.Delta.Y = e.Top.Y - e.Bot.Y;
			if (e.Delta.Y == 0L)
			{
				e.Dx = -3.4E+38;
				return;
			}
			e.Dx = (double)e.Delta.X / (double)e.Delta.Y;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001B84C File Offset: 0x00019A4C
		private void InsertLocalMinima(LocalMinima newLm)
		{
			if (this.m_MinimaList == null)
			{
				this.m_MinimaList = newLm;
				return;
			}
			if (newLm.Y >= this.m_MinimaList.Y)
			{
				newLm.Next = this.m_MinimaList;
				this.m_MinimaList = newLm;
				return;
			}
			LocalMinima localMinima = this.m_MinimaList;
			while (localMinima.Next != null && newLm.Y < localMinima.Next.Y)
			{
				localMinima = localMinima.Next;
			}
			newLm.Next = localMinima.Next;
			localMinima.Next = newLm;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0001B8CE File Offset: 0x00019ACE
		internal bool PopLocalMinima(long Y, out LocalMinima current)
		{
			current = this.m_CurrentLM;
			if (this.m_CurrentLM != null && this.m_CurrentLM.Y == Y)
			{
				this.m_CurrentLM = this.m_CurrentLM.Next;
				return true;
			}
			return false;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001B902 File Offset: 0x00019B02
		private void ReverseHorizontal(TEdge e)
		{
			this.Swap(ref e.Top.X, ref e.Bot.X);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001B920 File Offset: 0x00019B20
		internal virtual void Reset()
		{
			this.m_CurrentLM = this.m_MinimaList;
			if (this.m_CurrentLM == null)
			{
				return;
			}
			this.m_Scanbeam = null;
			for (LocalMinima localMinima = this.m_MinimaList; localMinima != null; localMinima = localMinima.Next)
			{
				this.InsertScanbeam(localMinima.Y);
				TEdge tedge = localMinima.LeftBound;
				if (tedge != null)
				{
					tedge.Curr = tedge.Bot;
					tedge.OutIdx = -1;
				}
				tedge = localMinima.RightBound;
				if (tedge != null)
				{
					tedge.Curr = tedge.Bot;
					tedge.OutIdx = -1;
				}
			}
			this.m_ActiveEdges = null;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001B9AC File Offset: 0x00019BAC
		public static IntRect GetBounds(List<List<IntPoint>> paths)
		{
			int i = 0;
			int count = paths.Count;
			while (i < count && paths[i].Count == 0)
			{
				i++;
			}
			if (i == count)
			{
				return new IntRect(0L, 0L, 0L, 0L);
			}
			IntRect intRect = new IntRect
			{
				left = paths[i][0].X
			};
			intRect.right = intRect.left;
			intRect.top = paths[i][0].Y;
			intRect.bottom = intRect.top;
			while (i < count)
			{
				for (int j = 0; j < paths[i].Count; j++)
				{
					if (paths[i][j].X < intRect.left)
					{
						intRect.left = paths[i][j].X;
					}
					else if (paths[i][j].X > intRect.right)
					{
						intRect.right = paths[i][j].X;
					}
					if (paths[i][j].Y < intRect.top)
					{
						intRect.top = paths[i][j].Y;
					}
					else if (paths[i][j].Y > intRect.bottom)
					{
						intRect.bottom = paths[i][j].Y;
					}
				}
				i++;
			}
			return intRect;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001BB4C File Offset: 0x00019D4C
		internal void InsertScanbeam(long Y)
		{
			if (this.m_Scanbeam == null)
			{
				this.m_Scanbeam = new Scanbeam
				{
					Next = null,
					Y = Y
				};
				return;
			}
			if (Y > this.m_Scanbeam.Y)
			{
				Scanbeam scanbeam = new Scanbeam
				{
					Y = Y,
					Next = this.m_Scanbeam
				};
				this.m_Scanbeam = scanbeam;
				return;
			}
			Scanbeam scanbeam2 = this.m_Scanbeam;
			while (scanbeam2.Next != null && Y <= scanbeam2.Next.Y)
			{
				scanbeam2 = scanbeam2.Next;
			}
			if (Y == scanbeam2.Y)
			{
				return;
			}
			Scanbeam next = new Scanbeam
			{
				Y = Y,
				Next = scanbeam2.Next
			};
			scanbeam2.Next = next;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001BBFA File Offset: 0x00019DFA
		internal bool PopScanbeam(out long Y)
		{
			if (this.m_Scanbeam == null)
			{
				Y = 0L;
				return false;
			}
			Y = this.m_Scanbeam.Y;
			this.m_Scanbeam = this.m_Scanbeam.Next;
			return true;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0001BC29 File Offset: 0x00019E29
		internal bool LocalMinimaPending()
		{
			return this.m_CurrentLM != null;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0001BC34 File Offset: 0x00019E34
		internal OutRec CreateOutRec()
		{
			OutRec outRec = new OutRec
			{
				Idx = -1,
				IsHole = false,
				IsOpen = false,
				FirstLeft = null,
				Pts = null,
				BottomPt = null,
				PolyNode = null
			};
			this.m_PolyOuts.Add(outRec);
			outRec.Idx = this.m_PolyOuts.Count - 1;
			return outRec;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001BC98 File Offset: 0x00019E98
		internal void DisposeOutRec(int index)
		{
			this.m_PolyOuts[index].Pts = null;
			this.m_PolyOuts[index] = null;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001BCBC File Offset: 0x00019EBC
		internal void UpdateEdgeIntoAEL(ref TEdge e)
		{
			if (e.NextInLML == null)
			{
				throw new ClipperException("UpdateEdgeIntoAEL: invalid call");
			}
			TEdge prevInAEL = e.PrevInAEL;
			TEdge nextInAEL = e.NextInAEL;
			e.NextInLML.OutIdx = e.OutIdx;
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = e.NextInLML;
			}
			else
			{
				this.m_ActiveEdges = e.NextInLML;
			}
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = e.NextInLML;
			}
			e.NextInLML.Side = e.Side;
			e.NextInLML.WindDelta = e.WindDelta;
			e.NextInLML.WindCnt = e.WindCnt;
			e.NextInLML.WindCnt2 = e.WindCnt2;
			e = e.NextInLML;
			e.Curr = e.Bot;
			e.PrevInAEL = prevInAEL;
			e.NextInAEL = nextInAEL;
			if (!ClipperBase.IsHorizontal(e))
			{
				this.InsertScanbeam(e.Top.Y);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001BDC0 File Offset: 0x00019FC0
		internal void SwapPositionsInAEL(TEdge edge1, TEdge edge2)
		{
			if (edge1.NextInAEL == edge1.PrevInAEL || edge2.NextInAEL == edge2.PrevInAEL)
			{
				return;
			}
			if (edge1.NextInAEL == edge2)
			{
				TEdge nextInAEL = edge2.NextInAEL;
				if (nextInAEL != null)
				{
					nextInAEL.PrevInAEL = edge1;
				}
				TEdge prevInAEL = edge1.PrevInAEL;
				if (prevInAEL != null)
				{
					prevInAEL.NextInAEL = edge2;
				}
				edge2.PrevInAEL = prevInAEL;
				edge2.NextInAEL = edge1;
				edge1.PrevInAEL = edge2;
				edge1.NextInAEL = nextInAEL;
			}
			else if (edge2.NextInAEL == edge1)
			{
				TEdge nextInAEL2 = edge1.NextInAEL;
				if (nextInAEL2 != null)
				{
					nextInAEL2.PrevInAEL = edge2;
				}
				TEdge prevInAEL2 = edge2.PrevInAEL;
				if (prevInAEL2 != null)
				{
					prevInAEL2.NextInAEL = edge1;
				}
				edge1.PrevInAEL = prevInAEL2;
				edge1.NextInAEL = edge2;
				edge2.PrevInAEL = edge1;
				edge2.NextInAEL = nextInAEL2;
			}
			else
			{
				TEdge nextInAEL3 = edge1.NextInAEL;
				TEdge prevInAEL3 = edge1.PrevInAEL;
				edge1.NextInAEL = edge2.NextInAEL;
				if (edge1.NextInAEL != null)
				{
					edge1.NextInAEL.PrevInAEL = edge1;
				}
				edge1.PrevInAEL = edge2.PrevInAEL;
				if (edge1.PrevInAEL != null)
				{
					edge1.PrevInAEL.NextInAEL = edge1;
				}
				edge2.NextInAEL = nextInAEL3;
				if (edge2.NextInAEL != null)
				{
					edge2.NextInAEL.PrevInAEL = edge2;
				}
				edge2.PrevInAEL = prevInAEL3;
				if (edge2.PrevInAEL != null)
				{
					edge2.PrevInAEL.NextInAEL = edge2;
				}
			}
			if (edge1.PrevInAEL == null)
			{
				this.m_ActiveEdges = edge1;
				return;
			}
			if (edge2.PrevInAEL == null)
			{
				this.m_ActiveEdges = edge2;
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0001BF2C File Offset: 0x0001A12C
		internal void DeleteFromAEL(TEdge e)
		{
			TEdge prevInAEL = e.PrevInAEL;
			TEdge nextInAEL = e.NextInAEL;
			if (prevInAEL == null && nextInAEL == null && e != this.m_ActiveEdges)
			{
				return;
			}
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = nextInAEL;
			}
			else
			{
				this.m_ActiveEdges = nextInAEL;
			}
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = prevInAEL;
			}
			e.NextInAEL = null;
			e.PrevInAEL = null;
		}

		// Token: 0x04000203 RID: 515
		internal const double horizontal = -3.4E+38;

		// Token: 0x04000204 RID: 516
		internal const int Skip = -2;

		// Token: 0x04000205 RID: 517
		internal const int Unassigned = -1;

		// Token: 0x04000206 RID: 518
		internal const double tolerance = 1E-20;

		// Token: 0x04000207 RID: 519
		public const long loRange = 1073741823L;

		// Token: 0x04000208 RID: 520
		public const long hiRange = 4611686018427387903L;

		// Token: 0x04000209 RID: 521
		internal TEdge m_ActiveEdges;

		// Token: 0x0400020A RID: 522
		internal LocalMinima m_CurrentLM;

		// Token: 0x0400020B RID: 523
		internal List<List<TEdge>> m_edges = new List<List<TEdge>>();

		// Token: 0x0400020C RID: 524
		internal bool m_HasOpenPaths;

		// Token: 0x0400020D RID: 525
		internal LocalMinima m_MinimaList;

		// Token: 0x0400020E RID: 526
		internal List<OutRec> m_PolyOuts;

		// Token: 0x0400020F RID: 527
		internal Scanbeam m_Scanbeam;

		// Token: 0x04000210 RID: 528
		internal bool m_UseFullRange;
	}
}
