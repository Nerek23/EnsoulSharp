using System;

namespace System.Runtime
{
	/// <summary>Indicates whether the next blocking garbage collection compacts the large object heap (LOH).</summary>
	// Token: 0x020006E8 RID: 1768
	[__DynamicallyInvokable]
	[Serializable]
	public enum GCLargeObjectHeapCompactionMode
	{
		/// <summary>The large object heap (LOH) is not compacted.</summary>
		// Token: 0x04002338 RID: 9016
		[__DynamicallyInvokable]
		Default = 1,
		/// <summary>The large object heap (LOH) will be compacted during the next blocking generation 2 garbage collection.</summary>
		// Token: 0x04002339 RID: 9017
		[__DynamicallyInvokable]
		CompactOnce
	}
}
