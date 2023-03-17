using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Identifies the type description being bound to.</summary>
	// Token: 0x02000A0A RID: 2570
	[__DynamicallyInvokable]
	[Serializable]
	public enum DESCKIND
	{
		/// <summary>Indicates that no match was found.</summary>
		// Token: 0x04002C9E RID: 11422
		[__DynamicallyInvokable]
		DESCKIND_NONE,
		/// <summary>Indicates that a <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> structure was returned.</summary>
		// Token: 0x04002C9F RID: 11423
		[__DynamicallyInvokable]
		DESCKIND_FUNCDESC,
		/// <summary>Indicates that a <see langword="VARDESC" /> was returned.</summary>
		// Token: 0x04002CA0 RID: 11424
		[__DynamicallyInvokable]
		DESCKIND_VARDESC,
		/// <summary>Indicates that a <see langword="TYPECOMP" /> was returned.</summary>
		// Token: 0x04002CA1 RID: 11425
		[__DynamicallyInvokable]
		DESCKIND_TYPECOMP,
		/// <summary>Indicates that an <see langword="IMPLICITAPPOBJ" /> was returned.</summary>
		// Token: 0x04002CA2 RID: 11426
		[__DynamicallyInvokable]
		DESCKIND_IMPLICITAPPOBJ,
		/// <summary>Indicates an end-of-enumeration marker.</summary>
		// Token: 0x04002CA3 RID: 11427
		[__DynamicallyInvokable]
		DESCKIND_MAX
	}
}
