using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000208 RID: 520
	[Guid("62baa2d2-ab54-41b7-b872-787e0106a421")]
	public class PathGeometry1 : PathGeometry
	{
		// Token: 0x06000B1A RID: 2842 RVA: 0x0001FAFD File Offset: 0x0001DCFD
		public PathGeometry1(Factory1 factory) : base(IntPtr.Zero)
		{
			factory.CreatePathGeometry(this);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0001FB11 File Offset: 0x0001DD11
		public PathGeometry1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0001FB1A File Offset: 0x0001DD1A
		public new static explicit operator PathGeometry1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PathGeometry1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0001FB34 File Offset: 0x0001DD34
		public unsafe void ComputePointAndSegmentAtLength(float length, int startSegment, RawMatrix3x2? worldTransform, float flatteningTolerance, out PointDescription ointDescriptionRef)
		{
			ointDescriptionRef = default(PointDescription);
			RawMatrix3x2 value;
			if (worldTransform != null)
			{
				value = worldTransform.Value;
			}
			Result result;
			fixed (PointDescription* ptr = &ointDescriptionRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Single,System.Int32,System.Void*,System.Single,System.Void*), this._nativePointer, length, startSegment, (worldTransform == null) ? null : (&value), flatteningTolerance, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
