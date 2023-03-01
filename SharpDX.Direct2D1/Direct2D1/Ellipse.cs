using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DD RID: 477
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Ellipse
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x0001C731 File Offset: 0x0001A931
		public Ellipse(RawVector2 center, float radiusX, float radiusY)
		{
			this.Point = center;
			this.RadiusX = radiusX;
			this.RadiusY = radiusY;
		}

		// Token: 0x04000660 RID: 1632
		public RawVector2 Point;

		// Token: 0x04000661 RID: 1633
		public float RadiusX;

		// Token: 0x04000662 RID: 1634
		public float RadiusY;
	}
}
