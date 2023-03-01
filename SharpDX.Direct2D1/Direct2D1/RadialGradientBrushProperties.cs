using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000330 RID: 816
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RadialGradientBrushProperties
	{
		// Token: 0x04000B06 RID: 2822
		public RawVector2 Center;

		// Token: 0x04000B07 RID: 2823
		public RawVector2 GradientOriginOffset;

		// Token: 0x04000B08 RID: 2824
		public float RadiusX;

		// Token: 0x04000B09 RID: 2825
		public float RadiusY;
	}
}
