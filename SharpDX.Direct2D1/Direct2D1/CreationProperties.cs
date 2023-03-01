using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200031C RID: 796
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CreationProperties
	{
		// Token: 0x04000AB7 RID: 2743
		public ThreadingMode ThreadingMode;

		// Token: 0x04000AB8 RID: 2744
		public DebugLevel DebugLevel;

		// Token: 0x04000AB9 RID: 2745
		public DeviceContextOptions Options;
	}
}
