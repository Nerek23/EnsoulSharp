using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200021D RID: 541
	[Guid("2cd9069e-12e2-11dc-9fed-001143a055f9")]
	internal class SimplifiedGeometrySinkNative : ComObject, SimplifiedGeometrySink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000C3B RID: 3131 RVA: 0x000228CB File Offset: 0x00020ACB
		public void AddBeziers(BezierSegment[] beziers)
		{
			this.AddBeziers_(beziers, beziers.Length);
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x000228D7 File Offset: 0x00020AD7
		public void AddLines(RawVector2[] points)
		{
			this.AddLines_(points, points.Length);
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x000228E3 File Offset: 0x00020AE3
		public void BeginFigure(RawVector2 startPoint, FigureBegin figureBegin)
		{
			this.BeginFigure_(startPoint, figureBegin);
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x000228ED File Offset: 0x00020AED
		public void Close()
		{
			this.Close_();
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000228F5 File Offset: 0x00020AF5
		public void EndFigure(FigureEnd figureEnd)
		{
			this.EndFigure_(figureEnd);
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x000228FE File Offset: 0x00020AFE
		public void SetFillMode(FillMode fillMode)
		{
			this.SetFillMode_(fillMode);
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00022907 File Offset: 0x00020B07
		public void SetSegmentFlags(PathSegment vertexFlags)
		{
			this.SetSegmentFlags_(vertexFlags);
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00002A7F File Offset: 0x00000C7F
		public SimplifiedGeometrySinkNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00022910 File Offset: 0x00020B10
		public new static explicit operator SimplifiedGeometrySinkNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SimplifiedGeometrySinkNative(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A2 RID: 418
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x000228FE File Offset: 0x00020AFE
		public FillMode FillMode_
		{
			set
			{
				this.SetFillMode_(value);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00022907 File Offset: 0x00020B07
		public PathSegment SegmentFlags_
		{
			set
			{
				this.SetSegmentFlags_(value);
			}
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00022927 File Offset: 0x00020B27
		internal unsafe void SetFillMode_(FillMode fillMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, fillMode, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00022947 File Offset: 0x00020B47
		internal unsafe void SetSegmentFlags_(PathSegment vertexFlags)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, vertexFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00022967 File Offset: 0x00020B67
		internal unsafe void BeginFigure_(RawVector2 startPoint, FigureBegin figureBegin)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Int32), this._nativePointer, startPoint, figureBegin, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00022988 File Offset: 0x00020B88
		internal unsafe void AddLines_(RawVector2[] ointsRef, int pointsCount)
		{
			fixed (RawVector2[] array = ointsRef)
			{
				void* ptr;
				if (ointsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, pointsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x000229D0 File Offset: 0x00020BD0
		internal unsafe void AddBeziers_(BezierSegment[] beziers, int beziersCount)
		{
			fixed (BezierSegment[] array = beziers)
			{
				void* ptr;
				if (beziers == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, beziersCount, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00015ABF File Offset: 0x00013CBF
		internal unsafe void EndFigure_(FigureEnd figureEnd)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, figureEnd, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00022A18 File Offset: 0x00020C18
		internal unsafe void Close_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
