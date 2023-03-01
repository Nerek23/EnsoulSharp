using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E9 RID: 489
	[Guid("2cd9069f-12e2-11dc-9fed-001143a055f9")]
	internal class GeometrySinkNative : SimplifiedGeometrySinkNative, GeometrySink, SimplifiedGeometrySink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x0001E395 File Offset: 0x0001C595
		public void AddLine(RawVector2 point)
		{
			this.AddLine_(point);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0001E39E File Offset: 0x0001C59E
		public void AddBezier(BezierSegment bezier)
		{
			this.AddBezier_(ref bezier);
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0001E3A8 File Offset: 0x0001C5A8
		public void AddQuadraticBezier(QuadraticBezierSegment bezier)
		{
			this.AddQuadraticBezier_(bezier);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0001E3B1 File Offset: 0x0001C5B1
		public void AddQuadraticBeziers(QuadraticBezierSegment[] beziers)
		{
			this.AddQuadraticBeziers_(beziers, beziers.Length);
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0001E3BD File Offset: 0x0001C5BD
		public void AddArc(ArcSegment arc)
		{
			this.AddArc_(ref arc);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0001E3C7 File Offset: 0x0001C5C7
		public GeometrySinkNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0001E3D0 File Offset: 0x0001C5D0
		public new static explicit operator GeometrySinkNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GeometrySinkNative(nativePtr);
			}
			return null;
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0001E3E7 File Offset: 0x0001C5E7
		internal unsafe void AddLine_(RawVector2 point)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2), this._nativePointer, point, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0001E408 File Offset: 0x0001C608
		internal unsafe void AddBezier_(ref BezierSegment bezier)
		{
			fixed (BezierSegment* ptr = &bezier)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0001E43C File Offset: 0x0001C63C
		internal unsafe void AddQuadraticBezier_(QuadraticBezierSegment bezier)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &bezier, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0001E460 File Offset: 0x0001C660
		internal unsafe void AddQuadraticBeziers_(QuadraticBezierSegment[] beziers, int beziersCount)
		{
			fixed (QuadraticBezierSegment[] array = beziers)
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
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, beziersCount, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0001E4A8 File Offset: 0x0001C6A8
		internal unsafe void AddArc_(ref ArcSegment arc)
		{
			fixed (ArcSegment* ptr = &arc)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
