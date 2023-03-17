using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a namespace within a symbol store.</summary>
	// Token: 0x020003D3 RID: 979
	[ComVisible(true)]
	public interface ISymbolNamespace
	{
		/// <summary>Gets the current namespace.</summary>
		/// <returns>The current namespace.</returns>
		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x0600328F RID: 12943
		string Name { get; }

		/// <summary>Gets the child members of the current namespace.</summary>
		/// <returns>The child members of the current namespace.</returns>
		// Token: 0x06003290 RID: 12944
		ISymbolNamespace[] GetNamespaces();

		/// <summary>Gets all the variables defined at global scope within the current namespace.</summary>
		/// <returns>The variables defined at global scope within the current namespace.</returns>
		// Token: 0x06003291 RID: 12945
		ISymbolVariable[] GetVariables();
	}
}
