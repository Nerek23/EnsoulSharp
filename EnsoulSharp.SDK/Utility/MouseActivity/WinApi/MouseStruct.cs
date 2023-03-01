using System;
using System.Runtime.InteropServices;

namespace EnsoulSharp.SDK.Utility.MouseActivity.WinApi
{
	// Token: 0x0200008C RID: 140
	[StructLayout(LayoutKind.Explicit)]
	internal struct MouseStruct
	{
		// Token: 0x040002DA RID: 730
		[FieldOffset(0)]
		public Point Point;

		// Token: 0x040002DB RID: 731
		[FieldOffset(22)]
		public short MouseData;
	}
}
