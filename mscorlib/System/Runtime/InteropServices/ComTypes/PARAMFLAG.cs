using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes how to transfer a structure element, parameter, or function return value between processes.</summary>
	// Token: 0x02000A14 RID: 2580
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum PARAMFLAG : short
	{
		/// <summary>Does not specify whether the parameter passes or receives information.</summary>
		// Token: 0x04002CEE RID: 11502
		[__DynamicallyInvokable]
		PARAMFLAG_NONE = 0,
		/// <summary>The parameter passes information from the caller to the callee.</summary>
		// Token: 0x04002CEF RID: 11503
		[__DynamicallyInvokable]
		PARAMFLAG_FIN = 1,
		/// <summary>The parameter returns information from the callee to the caller.</summary>
		// Token: 0x04002CF0 RID: 11504
		[__DynamicallyInvokable]
		PARAMFLAG_FOUT = 2,
		/// <summary>The parameter is the local identifier of a client application.</summary>
		// Token: 0x04002CF1 RID: 11505
		[__DynamicallyInvokable]
		PARAMFLAG_FLCID = 4,
		/// <summary>The parameter is the return value of the member.</summary>
		// Token: 0x04002CF2 RID: 11506
		[__DynamicallyInvokable]
		PARAMFLAG_FRETVAL = 8,
		/// <summary>The parameter is optional.</summary>
		// Token: 0x04002CF3 RID: 11507
		[__DynamicallyInvokable]
		PARAMFLAG_FOPT = 16,
		/// <summary>The parameter has default behaviors defined.</summary>
		// Token: 0x04002CF4 RID: 11508
		[__DynamicallyInvokable]
		PARAMFLAG_FHASDEFAULT = 32,
		/// <summary>The parameter has custom data.</summary>
		// Token: 0x04002CF5 RID: 11509
		[__DynamicallyInvokable]
		PARAMFLAG_FHASCUSTDATA = 64
	}
}
