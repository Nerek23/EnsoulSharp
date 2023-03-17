using System;

namespace System.Runtime.Versioning
{
	/// <summary>Identifies the scope of a sharable resource.</summary>
	// Token: 0x020006F4 RID: 1780
	[Flags]
	public enum ResourceScope
	{
		/// <summary>There is no shared state.</summary>
		// Token: 0x04002358 RID: 9048
		None = 0,
		/// <summary>The state is shared by objects within the machine.</summary>
		// Token: 0x04002359 RID: 9049
		Machine = 1,
		/// <summary>The state is shared within a process.</summary>
		// Token: 0x0400235A RID: 9050
		Process = 2,
		/// <summary>The state is shared by objects within an <see cref="T:System.AppDomain" />.</summary>
		// Token: 0x0400235B RID: 9051
		AppDomain = 4,
		/// <summary>The state is shared by objects within a library.</summary>
		// Token: 0x0400235C RID: 9052
		Library = 8,
		/// <summary>The resource is visible to only the type.</summary>
		// Token: 0x0400235D RID: 9053
		Private = 16,
		/// <summary>The resource is visible at an assembly scope.</summary>
		// Token: 0x0400235E RID: 9054
		Assembly = 32
	}
}
