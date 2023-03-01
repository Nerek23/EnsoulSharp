using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Win32
{
	// Token: 0x02000052 RID: 82
	public struct NativeMessage
	{
		// Token: 0x040000A5 RID: 165
		public IntPtr handle;

		// Token: 0x040000A6 RID: 166
		public uint msg;

		// Token: 0x040000A7 RID: 167
		public IntPtr wParam;

		// Token: 0x040000A8 RID: 168
		public IntPtr lParam;

		// Token: 0x040000A9 RID: 169
		public uint time;

		// Token: 0x040000AA RID: 170
		public RawPoint p;
	}
}
