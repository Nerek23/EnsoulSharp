using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F7 RID: 503
	[Guid("b499923b-7029-478f-a8b3-432c7c5f5312")]
	public class Ink : Resource
	{
		// Token: 0x06000ABA RID: 2746 RVA: 0x0001ECF0 File Offset: 0x0001CEF0
		public Ink(DeviceContext2 context2, InkPoint startPoint) : this(IntPtr.Zero)
		{
			context2.CreateInk(startPoint, this);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00016258 File Offset: 0x00014458
		public Ink(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0001ED05 File Offset: 0x0001CF05
		public new static explicit operator Ink(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Ink(nativePtr);
			}
			return null;
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0001ED1C File Offset: 0x0001CF1C
		// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0001ED24 File Offset: 0x0001CF24
		public InkPoint StartPoint
		{
			get
			{
				return this.GetStartPoint();
			}
			set
			{
				this.SetStartPoint(value);
			}
		}

		// Token: 0x17000176 RID: 374
		// (set) Token: 0x06000ABF RID: 2751 RVA: 0x0001ED2D File Offset: 0x0001CF2D
		public InkBezierSegment SegmentAtEnd
		{
			set
			{
				this.SetSegmentAtEnd(ref value);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0001ED37 File Offset: 0x0001CF37
		public int SegmentCount
		{
			get
			{
				return this.GetSegmentCount();
			}
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0001618F File Offset: 0x0001438F
		internal unsafe void SetStartPoint(InkPoint startPoint)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &startPoint, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0001ED40 File Offset: 0x0001CF40
		internal unsafe InkPoint GetStartPoint()
		{
			InkPoint result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0001ED70 File Offset: 0x0001CF70
		public unsafe void AddSegments(InkBezierSegment[] segments, int segmentsCount)
		{
			Result result;
			fixed (InkBezierSegment[] array = segments)
			{
				void* ptr;
				if (segments == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, segmentsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0001EDC4 File Offset: 0x0001CFC4
		public unsafe void RemoveSegmentsAtEnd(int segmentsCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, segmentsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0001EDFC File Offset: 0x0001CFFC
		public unsafe void SetSegments(int startSegment, InkBezierSegment[] segments, int segmentsCount)
		{
			Result result;
			fixed (InkBezierSegment[] array = segments)
			{
				void* ptr;
				if (segments == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startSegment, ptr, segmentsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0001EE50 File Offset: 0x0001D050
		internal unsafe void SetSegmentAtEnd(ref InkBezierSegment segment)
		{
			Result result;
			fixed (InkBezierSegment* ptr = &segment)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0001EE91 File Offset: 0x0001D091
		internal unsafe int GetSegmentCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0001EEB4 File Offset: 0x0001D0B4
		public unsafe void GetSegments(int startSegment, InkBezierSegment[] segments, int segmentsCount)
		{
			Result result;
			fixed (InkBezierSegment[] array = segments)
			{
				void* ptr;
				if (segments == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startSegment, ptr, segmentsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0001EF0C File Offset: 0x0001D10C
		public unsafe void StreamAsGeometry(InkStyle inkStyle, RawMatrix3x2? worldTransform, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<InkStyle>(inkStyle);
			RawMatrix3x2 value3;
			if (worldTransform != null)
			{
				value3 = worldTransform.Value;
			}
			value2 = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, (worldTransform == null) ? null : (&value3), flatteningTolerance, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0001EF90 File Offset: 0x0001D190
		public unsafe void GetBounds(InkStyle inkStyle, RawMatrix3x2? worldTransform, out RawRectangleF bounds)
		{
			IntPtr value = IntPtr.Zero;
			bounds = default(RawRectangleF);
			value = CppObject.ToCallbackPtr<InkStyle>(inkStyle);
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			Result result;
			fixed (RawRectangleF* ptr = &bounds)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (worldTransform == null) ? null : (&value2), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
