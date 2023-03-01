using System;

namespace SharpDX.Win32
{
	// Token: 0x0200005F RID: 95
	[Flags]
	public enum CommitFlags
	{
		// Token: 0x04000103 RID: 259
		Default = 0,
		// Token: 0x04000104 RID: 260
		Overwrite = 1,
		// Token: 0x04000105 RID: 261
		OnlyCurrent = 2,
		// Token: 0x04000106 RID: 262
		DangerouslyCommitMerelyToDiskCache = 4,
		// Token: 0x04000107 RID: 263
		Consolidate = 8
	}
}
