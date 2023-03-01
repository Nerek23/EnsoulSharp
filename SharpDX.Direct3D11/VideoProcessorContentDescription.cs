using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000178 RID: 376
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorContentDescription
	{
		// Token: 0x04000B50 RID: 2896
		public VideoFrameFormat InputFrameFormat;

		// Token: 0x04000B51 RID: 2897
		public Rational InputFrameRate;

		// Token: 0x04000B52 RID: 2898
		public int InputWidth;

		// Token: 0x04000B53 RID: 2899
		public int InputHeight;

		// Token: 0x04000B54 RID: 2900
		public Rational OutputFrameRate;

		// Token: 0x04000B55 RID: 2901
		public int OutputWidth;

		// Token: 0x04000B56 RID: 2902
		public int OutputHeight;

		// Token: 0x04000B57 RID: 2903
		public VideoUsage Usage;
	}
}
