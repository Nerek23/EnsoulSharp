using System;

namespace SharpDX.Win32
{
	// Token: 0x0200005E RID: 94
	[Flags]
	public enum VariantType : ushort
	{
		// Token: 0x040000FD RID: 253
		Default = 0,
		// Token: 0x040000FE RID: 254
		Vector = 4096,
		// Token: 0x040000FF RID: 255
		Array = 8192,
		// Token: 0x04000100 RID: 256
		ByRef = 16384,
		// Token: 0x04000101 RID: 257
		Reserved = 32768
	}
}
