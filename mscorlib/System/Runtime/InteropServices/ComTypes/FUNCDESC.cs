using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines a function description.</summary>
	// Token: 0x02000A11 RID: 2577
	[__DynamicallyInvokable]
	public struct FUNCDESC
	{
		/// <summary>Identifies the function member ID.</summary>
		// Token: 0x04002CD9 RID: 11481
		[__DynamicallyInvokable]
		public int memid;

		/// <summary>Stores the count of errors a function can return on a 16-bit system.</summary>
		// Token: 0x04002CDA RID: 11482
		public IntPtr lprgscode;

		/// <summary>Indicates the size of <see cref="F:System.Runtime.InteropServices.FUNCDESC.cParams" />.</summary>
		// Token: 0x04002CDB RID: 11483
		public IntPtr lprgelemdescParam;

		/// <summary>Specifies whether the function is virtual, static, or dispatch-only.</summary>
		// Token: 0x04002CDC RID: 11484
		[__DynamicallyInvokable]
		public FUNCKIND funckind;

		/// <summary>Specifies the type of a property function.</summary>
		// Token: 0x04002CDD RID: 11485
		[__DynamicallyInvokable]
		public INVOKEKIND invkind;

		/// <summary>Specifies the calling convention of a function.</summary>
		// Token: 0x04002CDE RID: 11486
		[__DynamicallyInvokable]
		public CALLCONV callconv;

		/// <summary>Counts the total number of parameters.</summary>
		// Token: 0x04002CDF RID: 11487
		[__DynamicallyInvokable]
		public short cParams;

		/// <summary>Counts the optional parameters.</summary>
		// Token: 0x04002CE0 RID: 11488
		[__DynamicallyInvokable]
		public short cParamsOpt;

		/// <summary>Specifies the offset in the VTBL for <see cref="F:System.Runtime.InteropServices.FUNCKIND.FUNC_VIRTUAL" />.</summary>
		// Token: 0x04002CE1 RID: 11489
		[__DynamicallyInvokable]
		public short oVft;

		/// <summary>Counts the permitted return values.</summary>
		// Token: 0x04002CE2 RID: 11490
		[__DynamicallyInvokable]
		public short cScodes;

		/// <summary>Contains the return type of the function.</summary>
		// Token: 0x04002CE3 RID: 11491
		[__DynamicallyInvokable]
		public ELEMDESC elemdescFunc;

		/// <summary>Indicates the <see cref="T:System.Runtime.InteropServices.FUNCFLAGS" /> of a function.</summary>
		// Token: 0x04002CE4 RID: 11492
		[__DynamicallyInvokable]
		public short wFuncFlags;
	}
}
