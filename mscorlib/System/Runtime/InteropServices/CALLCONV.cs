using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.CALLCONV" /> instead.</summary>
	// Token: 0x02000974 RID: 2420
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.CALLCONV instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum CALLCONV
	{
		/// <summary>Indicates that the Cdecl calling convention is used for a method.</summary>
		// Token: 0x04002BB5 RID: 11189
		CC_CDECL = 1,
		/// <summary>Indicates that the Mscpascal calling convention is used for a method.</summary>
		// Token: 0x04002BB6 RID: 11190
		CC_MSCPASCAL,
		/// <summary>Indicates that the Pascal calling convention is used for a method.</summary>
		// Token: 0x04002BB7 RID: 11191
		CC_PASCAL = 2,
		/// <summary>Indicates that the Macpascal calling convention is used for a method.</summary>
		// Token: 0x04002BB8 RID: 11192
		CC_MACPASCAL,
		/// <summary>Indicates that the Stdcall calling convention is used for a method.</summary>
		// Token: 0x04002BB9 RID: 11193
		CC_STDCALL,
		/// <summary>This value is reserved for future use.</summary>
		// Token: 0x04002BBA RID: 11194
		CC_RESERVED,
		/// <summary>Indicates that the Syscall calling convention is used for a method.</summary>
		// Token: 0x04002BBB RID: 11195
		CC_SYSCALL,
		/// <summary>Indicates that the Mpwcdecl calling convention is used for a method.</summary>
		// Token: 0x04002BBC RID: 11196
		CC_MPWCDECL,
		/// <summary>Indicates that the Mpwpascal calling convention is used for a method.</summary>
		// Token: 0x04002BBD RID: 11197
		CC_MPWPASCAL,
		/// <summary>Indicates the end of the <see cref="T:System.Runtime.InteropServices.CALLCONV" /> enumeration.</summary>
		// Token: 0x04002BBE RID: 11198
		CC_MAX
	}
}
