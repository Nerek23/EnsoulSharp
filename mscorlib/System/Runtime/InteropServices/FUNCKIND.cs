using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.FUNCKIND" /> instead.</summary>
	// Token: 0x02000972 RID: 2418
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.FUNCKIND instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Serializable]
	public enum FUNCKIND
	{
		/// <summary>The function is accessed the same as <see cref="F:System.Runtime.InteropServices.FUNCKIND.FUNC_PUREVIRTUAL" />, except the function has an implementation.</summary>
		// Token: 0x04002BAA RID: 11178
		FUNC_VIRTUAL,
		/// <summary>The function is accessed through the virtual function table (VTBL), and takes an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002BAB RID: 11179
		FUNC_PUREVIRTUAL,
		/// <summary>The function is accessed by <see langword="static" /> address and takes an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002BAC RID: 11180
		FUNC_NONVIRTUAL,
		/// <summary>The function is accessed by <see langword="static" /> address and does not take an implicit <see langword="this" /> pointer.</summary>
		// Token: 0x04002BAD RID: 11181
		FUNC_STATIC,
		/// <summary>The function can be accessed only through <see langword="IDispatch" />.</summary>
		// Token: 0x04002BAE RID: 11182
		FUNC_DISPATCH
	}
}
