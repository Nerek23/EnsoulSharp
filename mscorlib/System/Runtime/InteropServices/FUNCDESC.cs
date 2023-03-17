using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.FUNCDESC" /> instead.</summary>
	// Token: 0x02000968 RID: 2408
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.FUNCDESC instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	public struct FUNCDESC
	{
		/// <summary>Identifies the function member ID.</summary>
		// Token: 0x04002B75 RID: 11125
		public int memid;

		/// <summary>Stores the count of errors a function can return on a 16-bit system.</summary>
		// Token: 0x04002B76 RID: 11126
		public IntPtr lprgscode;

		/// <summary>Indicates the size of <see cref="F:System.Runtime.InteropServices.FUNCDESC.cParams" />.</summary>
		// Token: 0x04002B77 RID: 11127
		public IntPtr lprgelemdescParam;

		/// <summary>Specifies whether the function is virtual, static, or dispatch-only.</summary>
		// Token: 0x04002B78 RID: 11128
		public FUNCKIND funckind;

		/// <summary>Specifies the type of a property function.</summary>
		// Token: 0x04002B79 RID: 11129
		public INVOKEKIND invkind;

		/// <summary>Specifies the calling convention of a function.</summary>
		// Token: 0x04002B7A RID: 11130
		public CALLCONV callconv;

		/// <summary>Counts the total number of parameters.</summary>
		// Token: 0x04002B7B RID: 11131
		public short cParams;

		/// <summary>Counts the optional parameters.</summary>
		// Token: 0x04002B7C RID: 11132
		public short cParamsOpt;

		/// <summary>Specifies the offset in the VTBL for <see cref="F:System.Runtime.InteropServices.FUNCKIND.FUNC_VIRTUAL" />.</summary>
		// Token: 0x04002B7D RID: 11133
		public short oVft;

		/// <summary>Counts the permitted return values.</summary>
		// Token: 0x04002B7E RID: 11134
		public short cScodes;

		/// <summary>Contains the return type of the function.</summary>
		// Token: 0x04002B7F RID: 11135
		public ELEMDESC elemdescFunc;

		/// <summary>Indicates the <see cref="T:System.Runtime.InteropServices.FUNCFLAGS" /> of a function.</summary>
		// Token: 0x04002B80 RID: 11136
		public short wFuncFlags;
	}
}
