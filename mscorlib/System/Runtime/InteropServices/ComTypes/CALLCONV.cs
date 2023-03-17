using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Identifies the calling convention used by a method described in a METHODDATA structure.</summary>
	// Token: 0x02000A1E RID: 2590
	[__DynamicallyInvokable]
	[Serializable]
	public enum CALLCONV
	{
		/// <summary>Indicates that the C declaration (CDECL) calling convention is used for a method.</summary>
		// Token: 0x04002D20 RID: 11552
		[__DynamicallyInvokable]
		CC_CDECL = 1,
		/// <summary>Indicates that the MSC Pascal (MSCPASCAL) calling convention is used for a method.</summary>
		// Token: 0x04002D21 RID: 11553
		[__DynamicallyInvokable]
		CC_MSCPASCAL,
		/// <summary>Indicates that the Pascal calling convention is used for a method.</summary>
		// Token: 0x04002D22 RID: 11554
		[__DynamicallyInvokable]
		CC_PASCAL = 2,
		/// <summary>Indicates that the Macintosh Pascal (MACPASCAL) calling convention is used for a method.</summary>
		// Token: 0x04002D23 RID: 11555
		[__DynamicallyInvokable]
		CC_MACPASCAL,
		/// <summary>Indicates that the standard calling convention (STDCALL) is used for a method.</summary>
		// Token: 0x04002D24 RID: 11556
		[__DynamicallyInvokable]
		CC_STDCALL,
		/// <summary>This value is reserved for future use.</summary>
		// Token: 0x04002D25 RID: 11557
		[__DynamicallyInvokable]
		CC_RESERVED,
		/// <summary>Indicates that the standard SYSCALL calling convention is used for a method.</summary>
		// Token: 0x04002D26 RID: 11558
		[__DynamicallyInvokable]
		CC_SYSCALL,
		/// <summary>Indicates that the Macintosh Programmers' Workbench (MPW) CDECL calling convention is used for a method.</summary>
		// Token: 0x04002D27 RID: 11559
		[__DynamicallyInvokable]
		CC_MPWCDECL,
		/// <summary>Indicates that the Macintosh Programmers' Workbench (MPW) PASCAL calling convention is used for a method.</summary>
		// Token: 0x04002D28 RID: 11560
		[__DynamicallyInvokable]
		CC_MPWPASCAL,
		/// <summary>Indicates the end of the <see cref="T:System.Runtime.InteropServices.ComTypes.CALLCONV" /> enumeration.</summary>
		// Token: 0x04002D29 RID: 11561
		[__DynamicallyInvokable]
		CC_MAX
	}
}
