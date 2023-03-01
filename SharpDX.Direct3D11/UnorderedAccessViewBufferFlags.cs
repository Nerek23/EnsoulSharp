using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000093 RID: 147
	[Flags]
	public enum UnorderedAccessViewBufferFlags
	{
		// Token: 0x040007F8 RID: 2040
		Raw = 1,
		// Token: 0x040007F9 RID: 2041
		Append = 2,
		// Token: 0x040007FA RID: 2042
		Counter = 4,
		// Token: 0x040007FB RID: 2043
		None = 0
	}
}
