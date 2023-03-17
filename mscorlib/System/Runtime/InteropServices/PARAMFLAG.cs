using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.PARAMFLAG" /> instead.</summary>
	// Token: 0x0200096B RID: 2411
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.PARAMFLAG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Flags]
	[Serializable]
	public enum PARAMFLAG : short
	{
		/// <summary>Whether the parameter passes or receives information is unspecified.</summary>
		// Token: 0x04002B8A RID: 11146
		PARAMFLAG_NONE = 0,
		/// <summary>The parameter passes information from the caller to the callee.</summary>
		// Token: 0x04002B8B RID: 11147
		PARAMFLAG_FIN = 1,
		/// <summary>The parameter returns information from the callee to the caller.</summary>
		// Token: 0x04002B8C RID: 11148
		PARAMFLAG_FOUT = 2,
		/// <summary>The parameter is the local identifier of a client application.</summary>
		// Token: 0x04002B8D RID: 11149
		PARAMFLAG_FLCID = 4,
		/// <summary>The parameter is the return value of the member.</summary>
		// Token: 0x04002B8E RID: 11150
		PARAMFLAG_FRETVAL = 8,
		/// <summary>The parameter is optional.</summary>
		// Token: 0x04002B8F RID: 11151
		PARAMFLAG_FOPT = 16,
		/// <summary>The parameter has default behaviors defined.</summary>
		// Token: 0x04002B90 RID: 11152
		PARAMFLAG_FHASDEFAULT = 32,
		/// <summary>The parameter has custom data.</summary>
		// Token: 0x04002B91 RID: 11153
		PARAMFLAG_FHASCUSTDATA = 64
	}
}
