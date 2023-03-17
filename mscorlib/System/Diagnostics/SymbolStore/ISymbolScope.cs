using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a lexical scope within <see cref="T:System.Diagnostics.SymbolStore.ISymbolMethod" />, providing access to the start and end offsets of the scope, as well as its child and parent scopes.</summary>
	// Token: 0x020003D5 RID: 981
	[ComVisible(true)]
	public interface ISymbolScope
	{
		/// <summary>Gets the method that contains the current lexical scope.</summary>
		/// <returns>The method that contains the current lexical scope.</returns>
		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x0600329C RID: 12956
		ISymbolMethod Method { get; }

		/// <summary>Gets the parent lexical scope of the current scope.</summary>
		/// <returns>The parent lexical scope of the current scope.</returns>
		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x0600329D RID: 12957
		ISymbolScope Parent { get; }

		/// <summary>Gets the child lexical scopes of the current lexical scope.</summary>
		/// <returns>The child lexical scopes that of the current lexical scope.</returns>
		// Token: 0x0600329E RID: 12958
		ISymbolScope[] GetChildren();

		/// <summary>Gets the start offset of the current lexical scope.</summary>
		/// <returns>The start offset of the current lexical scope.</returns>
		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x0600329F RID: 12959
		int StartOffset { get; }

		/// <summary>Gets the end offset of the current lexical scope.</summary>
		/// <returns>The end offset of the current lexical scope.</returns>
		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x060032A0 RID: 12960
		int EndOffset { get; }

		/// <summary>Gets the local variables within the current lexical scope.</summary>
		/// <returns>The local variables within the current lexical scope.</returns>
		// Token: 0x060032A1 RID: 12961
		ISymbolVariable[] GetLocals();

		/// <summary>Gets the namespaces that are used within the current scope.</summary>
		/// <returns>The namespaces that are used within the current scope.</returns>
		// Token: 0x060032A2 RID: 12962
		ISymbolNamespace[] GetNamespaces();
	}
}
