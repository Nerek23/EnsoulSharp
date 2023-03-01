using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000068 RID: 104
	[Flags]
	public enum MeshOptimizeFlags
	{
		// Token: 0x040006F8 RID: 1784
		Compact = 16777216,
		// Token: 0x040006F9 RID: 1785
		AttributeSort = 33554432,
		// Token: 0x040006FA RID: 1786
		VertexCache = 67108864,
		// Token: 0x040006FB RID: 1787
		StripReorder = 134217728,
		// Token: 0x040006FC RID: 1788
		IgnoreVertices = 268435456,
		// Token: 0x040006FD RID: 1789
		DoNotSplit = 536870912,
		// Token: 0x040006FE RID: 1790
		DeviceIndependent = 4194304
	}
}
