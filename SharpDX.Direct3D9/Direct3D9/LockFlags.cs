using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000065 RID: 101
	[Flags]
	public enum LockFlags
	{
		// Token: 0x040006D4 RID: 1748
		ReadOnly = 16,
		// Token: 0x040006D5 RID: 1749
		Discard = 8192,
		// Token: 0x040006D6 RID: 1750
		NoOverwrite = 4096,
		// Token: 0x040006D7 RID: 1751
		NoSystemLock = 2048,
		// Token: 0x040006D8 RID: 1752
		DoNotWait = 16384,
		// Token: 0x040006D9 RID: 1753
		NoDirtyUpdate = 32768,
		// Token: 0x040006DA RID: 1754
		DoNotCopyData = 1,
		// Token: 0x040006DB RID: 1755
		None = 0
	}
}
