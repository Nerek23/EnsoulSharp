using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E5 RID: 485
	[Guid("2cd906a1-12e2-11dc-9fed-001143a055f9")]
	public class Geometry : Resource
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x0001D718 File Offset: 0x0001B918
		// (set) Token: 0x06000A07 RID: 2567 RVA: 0x0001D720 File Offset: 0x0001B920
		public float FlatteningTolerance
		{
			get
			{
				return this._flatteningTolerance;
			}
			set
			{
				this._flatteningTolerance = value;
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0001D72C File Offset: 0x0001B92C
		public void Combine(Geometry inputGeometry, CombineMode combineMode, GeometrySink geometrySink)
		{
			this.Combine(inputGeometry, combineMode, null, this.FlatteningTolerance, geometrySink);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0001D754 File Offset: 0x0001B954
		public void Combine(Geometry inputGeometry, CombineMode combineMode, float flatteningTolerance, GeometrySink geometrySink)
		{
			this.Combine(inputGeometry, combineMode, null, flatteningTolerance, geometrySink);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0001D778 File Offset: 0x0001B978
		public GeometryRelation Compare(Geometry inputGeometry)
		{
			return this.Compare(inputGeometry, null, this.FlatteningTolerance);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0001D79C File Offset: 0x0001B99C
		public GeometryRelation Compare(Geometry inputGeometry, float flatteningTolerance)
		{
			return this.Compare(inputGeometry, null, flatteningTolerance);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0001D7BC File Offset: 0x0001B9BC
		public float ComputeArea()
		{
			return this.ComputeArea(null, this.FlatteningTolerance);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
		public float ComputeArea(float flatteningTolerance)
		{
			return this.ComputeArea(null, flatteningTolerance);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0001D800 File Offset: 0x0001BA00
		public float ComputeLength()
		{
			return this.ComputeLength(null, this.FlatteningTolerance);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0001D824 File Offset: 0x0001BA24
		public float ComputeLength(float flatteningTolerance)
		{
			return this.ComputeLength(null, flatteningTolerance);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0001D844 File Offset: 0x0001BA44
		public RawVector2 ComputePointAtLength(float length, out RawVector2 unitTangentVector)
		{
			return this.ComputePointAtLength(length, null, this.FlatteningTolerance, out unitTangentVector);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0001D868 File Offset: 0x0001BA68
		public RawVector2 ComputePointAtLength(float length, float flatteningTolerance, out RawVector2 unitTangentVector)
		{
			return this.ComputePointAtLength(length, null, flatteningTolerance, out unitTangentVector);
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0001D888 File Offset: 0x0001BA88
		public bool FillContainsPoint(RawPoint point)
		{
			return this.FillContainsPoint(new RawVector2
			{
				X = (float)point.X,
				Y = (float)point.Y
			}, null, this.FlatteningTolerance);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0001D8D4 File Offset: 0x0001BAD4
		public bool FillContainsPoint(RawVector2 point)
		{
			return this.FillContainsPoint(point, null, this.FlatteningTolerance);
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0001D8FC File Offset: 0x0001BAFC
		public bool FillContainsPoint(RawPoint point, float flatteningTolerance)
		{
			return this.FillContainsPoint(new RawVector2
			{
				X = (float)point.X,
				Y = (float)point.Y
			}, null, flatteningTolerance);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0001D944 File Offset: 0x0001BB44
		public bool FillContainsPoint(RawVector2 point, float flatteningTolerance)
		{
			return this.FillContainsPoint(point, null, flatteningTolerance);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0001D968 File Offset: 0x0001BB68
		public bool FillContainsPoint(RawPoint point, RawMatrix3x2 worldTransform, float flatteningTolerance)
		{
			return this.FillContainsPoint(new RawVector2
			{
				X = (float)point.X,
				Y = (float)point.Y
			}, new RawMatrix3x2?(worldTransform), flatteningTolerance);
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0001D9AC File Offset: 0x0001BBAC
		public RawRectangleF GetBounds()
		{
			return this.GetBounds(null);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0001D9C8 File Offset: 0x0001BBC8
		public RawRectangleF GetWidenedBounds(float strokeWidth)
		{
			return this.GetWidenedBounds(strokeWidth, null, null, this.FlatteningTolerance);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0001D9EC File Offset: 0x0001BBEC
		public RawRectangleF GetWidenedBounds(float strokeWidth, float flatteningTolerance)
		{
			return this.GetWidenedBounds(strokeWidth, null, null, flatteningTolerance);
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0001DA0C File Offset: 0x0001BC0C
		public RawRectangleF GetWidenedBounds(float strokeWidth, StrokeStyle strokeStyle, float flatteningTolerance)
		{
			return this.GetWidenedBounds(strokeWidth, strokeStyle, null, flatteningTolerance);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		public void Outline(GeometrySink geometrySink)
		{
			this.Outline(null, this.FlatteningTolerance, geometrySink);
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0001DA50 File Offset: 0x0001BC50
		public void Outline(float flatteningTolerance, GeometrySink geometrySink)
		{
			this.Outline(null, flatteningTolerance, geometrySink);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0001DA70 File Offset: 0x0001BC70
		public void Simplify(GeometrySimplificationOption simplificationOption, SimplifiedGeometrySink geometrySink)
		{
			this.Simplify(simplificationOption, null, this.FlatteningTolerance, geometrySink);
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0001DA94 File Offset: 0x0001BC94
		public void Simplify(GeometrySimplificationOption simplificationOption, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			this.Simplify(simplificationOption, null, flatteningTolerance, geometrySink);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0001DAB3 File Offset: 0x0001BCB3
		public bool StrokeContainsPoint(RawPoint point, float strokeWidth)
		{
			return this.StrokeContainsPoint(point, strokeWidth, null);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0001DABE File Offset: 0x0001BCBE
		public bool StrokeContainsPoint(RawVector2 point, float strokeWidth)
		{
			return this.StrokeContainsPoint(point, strokeWidth, null);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0001DACC File Offset: 0x0001BCCC
		public bool StrokeContainsPoint(RawPoint point, float strokeWidth, StrokeStyle strokeStyle)
		{
			return this.StrokeContainsPoint(new RawVector2
			{
				X = (float)point.X,
				Y = (float)point.Y
			}, strokeWidth, strokeStyle);
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0001DB08 File Offset: 0x0001BD08
		public bool StrokeContainsPoint(RawVector2 point, float strokeWidth, StrokeStyle strokeStyle)
		{
			return this.StrokeContainsPoint(point, strokeWidth, strokeStyle, null, this.FlatteningTolerance);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0001DB32 File Offset: 0x0001BD32
		public bool StrokeContainsPoint(RawPoint point, float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2 transform)
		{
			return this.StrokeContainsPoint(point, strokeWidth, strokeStyle, transform, this.FlatteningTolerance);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0001DB45 File Offset: 0x0001BD45
		public bool StrokeContainsPoint(RawVector2 point, float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2 transform)
		{
			return this.StrokeContainsPoint(point, strokeWidth, strokeStyle, new RawMatrix3x2?(transform), this.FlatteningTolerance);
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0001DB64 File Offset: 0x0001BD64
		public bool StrokeContainsPoint(RawPoint point, float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2 transform, float flatteningTolerance)
		{
			return this.StrokeContainsPoint(new RawVector2
			{
				X = (float)point.X,
				Y = (float)point.Y
			}, strokeWidth, strokeStyle, new RawMatrix3x2?(transform), flatteningTolerance);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0001DBAC File Offset: 0x0001BDAC
		public void Tessellate(TessellationSink tessellationSink)
		{
			this.Tessellate(null, this.FlatteningTolerance, tessellationSink);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0001DBD0 File Offset: 0x0001BDD0
		public void Tessellate(float flatteningTolerance, TessellationSink tessellationSink)
		{
			this.Tessellate(null, flatteningTolerance, tessellationSink);
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		public void Widen(float strokeWidth, GeometrySink geometrySink)
		{
			this.Widen(strokeWidth, null, null, this.FlatteningTolerance, geometrySink);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0001DC18 File Offset: 0x0001BE18
		public void Widen(float strokeWidth, float flatteningTolerance, GeometrySink geometrySink)
		{
			this.Widen(strokeWidth, null, null, flatteningTolerance, geometrySink);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0001DC38 File Offset: 0x0001BE38
		public void Widen(float strokeWidth, StrokeStyle strokeStyle, float flatteningTolerance, GeometrySink geometrySink)
		{
			this.Widen(strokeWidth, strokeStyle, null, flatteningTolerance, geometrySink);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0001DC59 File Offset: 0x0001BE59
		public Geometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0001DC6D File Offset: 0x0001BE6D
		public new static explicit operator Geometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Geometry(nativePtr);
			}
			return null;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0001DC84 File Offset: 0x0001BE84
		public unsafe RawRectangleF GetBounds(RawMatrix3x2? worldTransform)
		{
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			RawRectangleF result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (worldTransform == null) ? null : (&value), &result, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x0001DCE0 File Offset: 0x0001BEE0
		public unsafe RawRectangleF GetWidenedBounds(float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2? worldTransform, float flatteningTolerance)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			RawRectangleF result;
			calli(System.Int32(System.Void*,System.Single,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, strokeWidth, (void*)value, (worldTransform == null) ? null : (&value2), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0001DD54 File Offset: 0x0001BF54
		public unsafe RawBool StrokeContainsPoint(RawVector2 point, float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2? worldTransform, float flatteningTolerance)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			RawBool result;
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Single,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, point, strokeWidth, (void*)value, (worldTransform == null) ? null : (&value2), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		public unsafe RawBool FillContainsPoint(RawVector2 point, RawMatrix3x2? worldTransform, float flatteningTolerance)
		{
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			RawBool result;
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Single,System.Void*), this._nativePointer, point, (worldTransform == null) ? null : (&value), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0001DE28 File Offset: 0x0001C028
		public unsafe GeometryRelation Compare(Geometry inputGeometry, RawMatrix3x2? inputGeometryTransform, float flatteningTolerance)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(inputGeometry);
			RawMatrix3x2 value2;
			if (inputGeometryTransform != null)
			{
				value2 = inputGeometryTransform.Value;
			}
			GeometryRelation result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, (inputGeometryTransform == null) ? null : (&value2), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0001DE98 File Offset: 0x0001C098
		public unsafe void Simplify(GeometrySimplificationOption simplificationOption, RawMatrix3x2? worldTransform, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			value = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Single,System.Void*), this._nativePointer, simplificationOption, (worldTransform == null) ? null : (&value2), flatteningTolerance, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0001DF08 File Offset: 0x0001C108
		public unsafe void Tessellate(RawMatrix3x2? worldTransform, float flatteningTolerance, TessellationSink tessellationSink)
		{
			IntPtr value = IntPtr.Zero;
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			value = CppObject.ToCallbackPtr<TessellationSink>(tessellationSink);
			calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (worldTransform == null) ? null : (&value2), flatteningTolerance, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0001DF78 File Offset: 0x0001C178
		public unsafe void Combine(Geometry inputGeometry, CombineMode combineMode, RawMatrix3x2? inputGeometryTransform, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(inputGeometry);
			RawMatrix3x2 value3;
			if (inputGeometryTransform != null)
			{
				value3 = inputGeometryTransform.Value;
			}
			value2 = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, combineMode, (inputGeometryTransform == null) ? null : (&value3), flatteningTolerance, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0001DFFC File Offset: 0x0001C1FC
		public unsafe void Outline(RawMatrix3x2? worldTransform, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			RawMatrix3x2 value2;
			if (worldTransform != null)
			{
				value2 = worldTransform.Value;
			}
			value = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (worldTransform == null) ? null : (&value2), flatteningTolerance, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0001E06C File Offset: 0x0001C26C
		public unsafe float ComputeArea(RawMatrix3x2? worldTransform, float flatteningTolerance)
		{
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			float result;
			calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (worldTransform == null) ? null : (&value), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0001E0CC File Offset: 0x0001C2CC
		public unsafe float ComputeLength(RawMatrix3x2? worldTransform, float flatteningTolerance)
		{
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			float result;
			calli(System.Int32(System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (worldTransform == null) ? null : (&value), flatteningTolerance, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0001E12C File Offset: 0x0001C32C
		public unsafe RawVector2 ComputePointAtLength(float length, RawMatrix3x2? worldTransform, float flatteningTolerance, out RawVector2 unitTangentVector)
		{
			unitTangentVector = default(RawVector2);
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			RawVector2 result2;
			Result result;
			fixed (RawVector2* ptr = &unitTangentVector)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Single,System.Void*,System.Single,System.Void*,System.Void*), this._nativePointer, length, (worldTransform == null) ? null : (&value), flatteningTolerance, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0001E1A0 File Offset: 0x0001C3A0
		public unsafe void Widen(float strokeWidth, StrokeStyle strokeStyle, RawMatrix3x2? worldTransform, float flatteningTolerance, SimplifiedGeometrySink geometrySink)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			RawMatrix3x2 value3;
			if (worldTransform != null)
			{
				value3 = worldTransform.Value;
			}
			value2 = CppObject.ToCallbackPtr<SimplifiedGeometrySink>(geometrySink);
			calli(System.Int32(System.Void*,System.Single,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, strokeWidth, (void*)value, (worldTransform == null) ? null : (&value3), flatteningTolerance, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x04000667 RID: 1639
		private float _flatteningTolerance = 0.25f;

		// Token: 0x04000668 RID: 1640
		public const float DefaultFlatteningTolerance = 0.25f;
	}
}
