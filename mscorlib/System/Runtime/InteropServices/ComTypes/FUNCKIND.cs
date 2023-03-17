using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines how to access a function.</summary>
	// Token: 0x02000A1C RID: 2588
	[__DynamicallyInvokable]
	[Serializable]
	public enum FUNCKIND
	{
		/// <summary>The function is accessed in the same way as <see cref="F:System.Runtime.InteropServices.FUNCKIND.FUNC_PUREVIRTUAL" />, except the function has an implementation.</summary>
		// Token: 0x04002D15 RID: 11541
		[__DynamicallyInvokable]
		FUNC_VIRTUAL,
		/// <summary>The function is accessed through the virtual function table (VTBL), and takes an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002D16 RID: 11542
		[__DynamicallyInvokable]
		FUNC_PUREVIRTUAL,
		/// <summary>The function is accessed by <see langword="static" /> address and takes an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002D17 RID: 11543
		[__DynamicallyInvokable]
		FUNC_NONVIRTUAL,
		/// <summary>The function is accessed by <see langword="static" /> address and does not take an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002D18 RID: 11544
		[__DynamicallyInvokable]
		FUNC_STATIC,
		/// <summary>The function can be accessed only through <see langword="IDispatch" />.</summary>
		// Token: 0x04002D19 RID: 11545
		[__DynamicallyInvokable]
		FUNC_DISPATCH
	}
}
