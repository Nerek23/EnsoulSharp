using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes how to transfer a structure element, parameter, or function return value between processes.</summary>
	// Token: 0x02000A12 RID: 2578
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum IDLFLAG : short
	{
		/// <summary>Does not specify whether the parameter passes or receives information.</summary>
		// Token: 0x04002CE6 RID: 11494
		[__DynamicallyInvokable]
		IDLFLAG_NONE = 0,
		/// <summary>The parameter passes information from the caller to the callee.</summary>
		// Token: 0x04002CE7 RID: 11495
		[__DynamicallyInvokable]
		IDLFLAG_FIN = 1,
		/// <summary>The parameter returns information from the callee to the caller.</summary>
		// Token: 0x04002CE8 RID: 11496
		[__DynamicallyInvokable]
		IDLFLAG_FOUT = 2,
		/// <summary>The parameter is the local identifier of a client application.</summary>
		// Token: 0x04002CE9 RID: 11497
		[__DynamicallyInvokable]
		IDLFLAG_FLCID = 4,
		/// <summary>The parameter is the return value of the member.</summary>
		// Token: 0x04002CEA RID: 11498
		[__DynamicallyInvokable]
		IDLFLAG_FRETVAL = 8
	}
}
