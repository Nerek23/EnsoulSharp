using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000179 RID: 377
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VideoProcessorCustomRate
	{
		// Token: 0x04000B58 RID: 2904
		public Rational CustomRate;

		// Token: 0x04000B59 RID: 2905
		public int OutputFrames;

		// Token: 0x04000B5A RID: 2906
		public RawBool InputInterlaced;

		// Token: 0x04000B5B RID: 2907
		public int InputFramesOrFields;
	}
}
