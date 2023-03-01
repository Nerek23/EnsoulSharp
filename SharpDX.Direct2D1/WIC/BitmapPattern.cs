using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000077 RID: 119
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapPattern
	{
		// Token: 0x040001CD RID: 461
		public long Position;

		// Token: 0x040001CE RID: 462
		public int Length;

		// Token: 0x040001CF RID: 463
		public IntPtr Pattern;

		// Token: 0x040001D0 RID: 464
		public IntPtr Mask;

		// Token: 0x040001D1 RID: 465
		public RawBool EndOfStream;
	}
}
