using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200021E RID: 542
	internal class SimplifiedGeometrySinkShadow : ComObjectShadow
	{
		// Token: 0x06000C4D RID: 3149 RVA: 0x00022A50 File Offset: 0x00020C50
		public static IntPtr ToIntPtr(SimplifiedGeometrySink callback)
		{
			return CppObject.ToCallbackPtr<SimplifiedGeometrySink>(callback);
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00022A58 File Offset: 0x00020C58
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return SimplifiedGeometrySinkShadow.Vtbl;
			}
		}

		// Token: 0x040006C2 RID: 1730
		private static readonly SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl Vtbl = new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl(0);

		// Token: 0x0200021F RID: 543
		public class SimplifiedGeometrySinkVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000C51 RID: 3153 RVA: 0x00022A6C File Offset: 0x00020C6C
			public SimplifiedGeometrySinkVtbl(int nbMethods) : base(nbMethods + 7)
			{
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.SetFillModeDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.SetFillModeImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.SetSegmentFlagsDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.SetSegmentFlagsImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.BeginFigureDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.BeginFigureImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.AddLinesDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.AddLinesImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.AddBeziersDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.AddBeziersImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.EndFigureDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.EndFigureImpl));
				base.AddMethod(new SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.CloseDelegate(SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl.CloseImpl));
			}

			// Token: 0x06000C52 RID: 3154 RVA: 0x00022B00 File Offset: 0x00020D00
			private static void SetFillModeImpl(IntPtr thisPtr, FillMode fillMode)
			{
				((SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback).SetFillMode(fillMode);
			}

			// Token: 0x06000C53 RID: 3155 RVA: 0x00022B18 File Offset: 0x00020D18
			private static void SetSegmentFlagsImpl(IntPtr thisPtr, PathSegment vertexFlags)
			{
				((SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback).SetSegmentFlags(vertexFlags);
			}

			// Token: 0x06000C54 RID: 3156 RVA: 0x00022B30 File Offset: 0x00020D30
			private static void BeginFigureImpl(IntPtr thisPtr, RawVector2 startPoint, FigureBegin figureBegin)
			{
				((SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback).BeginFigure(startPoint, figureBegin);
			}

			// Token: 0x06000C55 RID: 3157 RVA: 0x00022B4C File Offset: 0x00020D4C
			private static void AddLinesImpl(IntPtr thisPtr, IntPtr points, int pointsCount)
			{
				SimplifiedGeometrySink simplifiedGeometrySink = (SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback;
				RawVector2[] array = new RawVector2[pointsCount];
				Utilities.Read<RawVector2>(points, array, 0, pointsCount);
				simplifiedGeometrySink.AddLines(array);
			}

			// Token: 0x06000C56 RID: 3158 RVA: 0x00022B80 File Offset: 0x00020D80
			private static void AddBeziersImpl(IntPtr thisPtr, IntPtr beziers, int beziersCount)
			{
				SimplifiedGeometrySink simplifiedGeometrySink = (SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback;
				BezierSegment[] array = new BezierSegment[beziersCount];
				Utilities.Read<BezierSegment>(beziers, array, 0, beziersCount);
				simplifiedGeometrySink.AddBeziers(array);
			}

			// Token: 0x06000C57 RID: 3159 RVA: 0x00022BB4 File Offset: 0x00020DB4
			private static void EndFigureImpl(IntPtr thisPtr, FigureEnd figureEnd)
			{
				((SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback).EndFigure(figureEnd);
			}

			// Token: 0x06000C58 RID: 3160 RVA: 0x00022BCC File Offset: 0x00020DCC
			private static int CloseImpl(IntPtr thisPtr)
			{
				try
				{
					((SimplifiedGeometrySink)CppObjectShadow.ToShadow<SimplifiedGeometrySinkShadow>(thisPtr).Callback).Close();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000220 RID: 544
			// (Invoke) Token: 0x06000C5A RID: 3162
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void SetFillModeDelegate(IntPtr thisPtr, FillMode fillMode);

			// Token: 0x02000221 RID: 545
			// (Invoke) Token: 0x06000C5E RID: 3166
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void SetSegmentFlagsDelegate(IntPtr thisPtr, PathSegment vertexFlags);

			// Token: 0x02000222 RID: 546
			// (Invoke) Token: 0x06000C62 RID: 3170
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void BeginFigureDelegate(IntPtr thisPtr, RawVector2 startPoint, FigureBegin figureBegin);

			// Token: 0x02000223 RID: 547
			// (Invoke) Token: 0x06000C66 RID: 3174
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddLinesDelegate(IntPtr thisPtr, IntPtr points, int pointsCount);

			// Token: 0x02000224 RID: 548
			// (Invoke) Token: 0x06000C6A RID: 3178
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddBeziersDelegate(IntPtr thisPtr, IntPtr beziers, int beziersCount);

			// Token: 0x02000225 RID: 549
			// (Invoke) Token: 0x06000C6E RID: 3182
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void EndFigureDelegate(IntPtr thisPtr, FigureEnd figureEnd);

			// Token: 0x02000226 RID: 550
			// (Invoke) Token: 0x06000C72 RID: 3186
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CloseDelegate(IntPtr thisPtr);
		}
	}
}
