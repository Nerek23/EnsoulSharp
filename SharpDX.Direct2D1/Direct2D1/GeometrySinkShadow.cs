using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001EA RID: 490
	internal class GeometrySinkShadow : SimplifiedGeometrySinkShadow
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x0001E4DC File Offset: 0x0001C6DC
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return GeometrySinkShadow.Vtbl;
			}
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0001E4E3 File Offset: 0x0001C6E3
		public static IntPtr ToIntPtr(GeometrySink geometrySink)
		{
			return CppObject.ToCallbackPtr<GeometrySink>(geometrySink);
		}

		// Token: 0x04000669 RID: 1641
		private static readonly GeometrySinkShadow.GeometrySinkVtbl Vtbl = new GeometrySinkShadow.GeometrySinkVtbl();

		// Token: 0x020001EB RID: 491
		private class GeometrySinkVtbl : SimplifiedGeometrySinkShadow.SimplifiedGeometrySinkVtbl
		{
			// Token: 0x06000A5D RID: 2653 RVA: 0x0001E500 File Offset: 0x0001C700
			public GeometrySinkVtbl() : base(5)
			{
				base.AddMethod(new GeometrySinkShadow.GeometrySinkVtbl.AddLineDelegate(GeometrySinkShadow.GeometrySinkVtbl.AddLineImpl));
				base.AddMethod(new GeometrySinkShadow.GeometrySinkVtbl.AddBezierDelegate(GeometrySinkShadow.GeometrySinkVtbl.AddBezierImpl));
				base.AddMethod(new GeometrySinkShadow.GeometrySinkVtbl.AddQuadraticBezierDelegate(GeometrySinkShadow.GeometrySinkVtbl.AddQuadraticBezierImpl));
				base.AddMethod(new GeometrySinkShadow.GeometrySinkVtbl.AddQuadraticBeziersDelegate(GeometrySinkShadow.GeometrySinkVtbl.AddQuadraticBeziersImpl));
				base.AddMethod(new GeometrySinkShadow.GeometrySinkVtbl.AddArcDelegate(GeometrySinkShadow.GeometrySinkVtbl.AddArcImpl));
			}

			// Token: 0x06000A5E RID: 2654 RVA: 0x0001E56E File Offset: 0x0001C76E
			private static void AddLineImpl(IntPtr thisPtr, RawVector2 point)
			{
				((GeometrySink)CppObjectShadow.ToShadow<GeometrySinkShadow>(thisPtr).Callback).AddLine(point);
			}

			// Token: 0x06000A5F RID: 2655 RVA: 0x0001E586 File Offset: 0x0001C786
			private unsafe static void AddBezierImpl(IntPtr thisPtr, IntPtr bezier)
			{
				((GeometrySink)CppObjectShadow.ToShadow<GeometrySinkShadow>(thisPtr).Callback).AddBezier(*(BezierSegment*)((void*)bezier));
			}

			// Token: 0x06000A60 RID: 2656 RVA: 0x0001E5A8 File Offset: 0x0001C7A8
			private unsafe static void AddQuadraticBezierImpl(IntPtr thisPtr, IntPtr bezier)
			{
				((GeometrySink)CppObjectShadow.ToShadow<GeometrySinkShadow>(thisPtr).Callback).AddQuadraticBezier(*(QuadraticBezierSegment*)((void*)bezier));
			}

			// Token: 0x06000A61 RID: 2657 RVA: 0x0001E5CC File Offset: 0x0001C7CC
			private static void AddQuadraticBeziersImpl(IntPtr thisPtr, IntPtr beziers, int beziersCount)
			{
				GeometrySink geometrySink = (GeometrySink)CppObjectShadow.ToShadow<GeometrySinkShadow>(thisPtr).Callback;
				QuadraticBezierSegment[] array = new QuadraticBezierSegment[beziersCount];
				Utilities.Read<QuadraticBezierSegment>(beziers, array, 0, beziersCount);
				geometrySink.AddQuadraticBeziers(array);
			}

			// Token: 0x06000A62 RID: 2658 RVA: 0x0001E600 File Offset: 0x0001C800
			private unsafe static void AddArcImpl(IntPtr thisPtr, IntPtr arc)
			{
				((GeometrySink)CppObjectShadow.ToShadow<GeometrySinkShadow>(thisPtr).Callback).AddArc(*(ArcSegment*)((void*)arc));
			}

			// Token: 0x020001EC RID: 492
			// (Invoke) Token: 0x06000A64 RID: 2660
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddLineDelegate(IntPtr thisPtr, RawVector2 point);

			// Token: 0x020001ED RID: 493
			// (Invoke) Token: 0x06000A68 RID: 2664
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddBezierDelegate(IntPtr thisPtr, IntPtr bezier);

			// Token: 0x020001EE RID: 494
			// (Invoke) Token: 0x06000A6C RID: 2668
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddQuadraticBezierDelegate(IntPtr thisPtr, IntPtr bezier);

			// Token: 0x020001EF RID: 495
			// (Invoke) Token: 0x06000A70 RID: 2672
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddQuadraticBeziersDelegate(IntPtr thisPtr, IntPtr beziers, int beziersCount);

			// Token: 0x020001F0 RID: 496
			// (Invoke) Token: 0x06000A74 RID: 2676
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddArcDelegate(IntPtr thisPtr, IntPtr arc);
		}
	}
}
