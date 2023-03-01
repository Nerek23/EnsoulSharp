using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000324 RID: 804
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct GradientMeshPatch
	{
		// Token: 0x04000ACF RID: 2767
		public RawVector2 Point00;

		// Token: 0x04000AD0 RID: 2768
		public RawVector2 Point01;

		// Token: 0x04000AD1 RID: 2769
		public RawVector2 Point02;

		// Token: 0x04000AD2 RID: 2770
		public RawVector2 Point03;

		// Token: 0x04000AD3 RID: 2771
		public RawVector2 Point10;

		// Token: 0x04000AD4 RID: 2772
		public RawVector2 Point11;

		// Token: 0x04000AD5 RID: 2773
		public RawVector2 Point12;

		// Token: 0x04000AD6 RID: 2774
		public RawVector2 Point13;

		// Token: 0x04000AD7 RID: 2775
		public RawVector2 Point20;

		// Token: 0x04000AD8 RID: 2776
		public RawVector2 Point21;

		// Token: 0x04000AD9 RID: 2777
		public RawVector2 Point22;

		// Token: 0x04000ADA RID: 2778
		public RawVector2 Point23;

		// Token: 0x04000ADB RID: 2779
		public RawVector2 Point30;

		// Token: 0x04000ADC RID: 2780
		public RawVector2 Point31;

		// Token: 0x04000ADD RID: 2781
		public RawVector2 Point32;

		// Token: 0x04000ADE RID: 2782
		public RawVector2 Point33;

		// Token: 0x04000ADF RID: 2783
		public RawColor4 Color00;

		// Token: 0x04000AE0 RID: 2784
		public RawColor4 Color03;

		// Token: 0x04000AE1 RID: 2785
		public RawColor4 Color30;

		// Token: 0x04000AE2 RID: 2786
		public RawColor4 Color33;

		// Token: 0x04000AE3 RID: 2787
		public PatchEdgeMode TopEdgeMode;

		// Token: 0x04000AE4 RID: 2788
		public PatchEdgeMode LeftEdgeMode;

		// Token: 0x04000AE5 RID: 2789
		public PatchEdgeMode BottomEdgeMode;

		// Token: 0x04000AE6 RID: 2790
		public PatchEdgeMode RightEdgeMode;
	}
}
