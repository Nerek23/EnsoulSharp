using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000097 RID: 151
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OutputDuplicatePointerShapeInformation
	{
		// Token: 0x04000DD4 RID: 3540
		public int Type;

		// Token: 0x04000DD5 RID: 3541
		public int Width;

		// Token: 0x04000DD6 RID: 3542
		public int Height;

		// Token: 0x04000DD7 RID: 3543
		public int Pitch;

		// Token: 0x04000DD8 RID: 3544
		public RawPoint HotSpot;
	}
}
