using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001E7 RID: 487
	[Guid("a16907d7-bc02-4801-99e8-8cf7f485f774")]
	public class GeometryRealization : Resource
	{
		// Token: 0x06000A44 RID: 2628 RVA: 0x0001E34E File Offset: 0x0001C54E
		public GeometryRealization(DeviceContext1 context, Geometry geometry, float flatteningTolerance) : this(IntPtr.Zero)
		{
			context.CreateFilledGeometryRealization(geometry, flatteningTolerance, this);
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0001E364 File Offset: 0x0001C564
		public GeometryRealization(DeviceContext1 context, Geometry geometry, float flatteningTolerance, float strokeWidth, StrokeStyle strokeStyle) : this(IntPtr.Zero)
		{
			context.CreateStrokedGeometryRealization(geometry, flatteningTolerance, strokeWidth, strokeStyle, this);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00016258 File Offset: 0x00014458
		public GeometryRealization(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0001E37E File Offset: 0x0001C57E
		public new static explicit operator GeometryRealization(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GeometryRealization(nativePtr);
			}
			return null;
		}
	}
}
