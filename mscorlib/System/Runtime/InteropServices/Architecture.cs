using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates the processor architecture.</summary>
	// Token: 0x0200097C RID: 2428
	public enum Architecture
	{
		/// <summary>An Intel-based 32-bit processor architecture.</summary>
		// Token: 0x04002BEB RID: 11243
		X86,
		/// <summary>An Intel-based 64-bit processor architecture.</summary>
		// Token: 0x04002BEC RID: 11244
		X64,
		/// <summary>A 32-bit ARM processor architecture.</summary>
		// Token: 0x04002BED RID: 11245
		Arm,
		/// <summary>A 64-bit ARM processor architecture.</summary>
		// Token: 0x04002BEE RID: 11246
		Arm64
	}
}
