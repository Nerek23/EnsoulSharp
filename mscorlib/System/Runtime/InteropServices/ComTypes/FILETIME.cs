using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Represents the number of 100-nanosecond intervals since January 1, 1601. This structure is a 64-bit value.</summary>
	// Token: 0x02000A03 RID: 2563
	[__DynamicallyInvokable]
	public struct FILETIME
	{
		/// <summary>Specifies the low 32 bits of the <see langword="FILETIME" />.</summary>
		// Token: 0x04002C90 RID: 11408
		[__DynamicallyInvokable]
		public int dwLowDateTime;

		/// <summary>Specifies the high 32 bits of the <see langword="FILETIME" />.</summary>
		// Token: 0x04002C91 RID: 11409
		[__DynamicallyInvokable]
		public int dwHighDateTime;
	}
}
