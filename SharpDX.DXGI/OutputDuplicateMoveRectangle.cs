using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000095 RID: 149
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OutputDuplicateMoveRectangle
	{
		// Token: 0x04000DD0 RID: 3536
		public RawPoint SourcePoint;

		// Token: 0x04000DD1 RID: 3537
		public RawRectangle DestinationRect;
	}
}
