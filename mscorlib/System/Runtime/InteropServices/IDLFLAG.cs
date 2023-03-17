using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IDLFLAG" /> instead.</summary>
	// Token: 0x02000969 RID: 2409
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IDLFLAG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum IDLFLAG : short
	{
		/// <summary>Whether the parameter passes or receives information is unspecified.</summary>
		// Token: 0x04002B82 RID: 11138
		IDLFLAG_NONE = 0,
		/// <summary>The parameter passes information from the caller to the callee.</summary>
		// Token: 0x04002B83 RID: 11139
		IDLFLAG_FIN = 1,
		/// <summary>The parameter returns information from the callee to the caller.</summary>
		// Token: 0x04002B84 RID: 11140
		IDLFLAG_FOUT = 2,
		/// <summary>The parameter is the local identifier of a client application.</summary>
		// Token: 0x04002B85 RID: 11141
		IDLFLAG_FLCID = 4,
		/// <summary>The parameter is the return value of the member.</summary>
		// Token: 0x04002B86 RID: 11142
		IDLFLAG_FRETVAL = 8
	}
}
