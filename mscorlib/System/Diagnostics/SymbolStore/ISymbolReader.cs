using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a symbol reader for managed code.</summary>
	// Token: 0x020003D4 RID: 980
	[ComVisible(true)]
	public interface ISymbolReader
	{
		/// <summary>Gets a document specified by the language, vendor, and type.</summary>
		/// <param name="url">The URL that identifies the document.</param>
		/// <param name="language">The document language. You can specify this parameter as <see cref="F:System.Guid.Empty" />.</param>
		/// <param name="languageVendor">The identity of the vendor for the document language. You can specify this parameter as <see cref="F:System.Guid.Empty" />.</param>
		/// <param name="documentType">The type of the document. You can specify this parameter as <see cref="F:System.Guid.Empty" />.</param>
		/// <returns>The specified document.</returns>
		// Token: 0x06003292 RID: 12946
		ISymbolDocument GetDocument(string url, Guid language, Guid languageVendor, Guid documentType);

		/// <summary>Gets an array of all documents defined in the symbol store.</summary>
		/// <returns>An array of all documents defined in the symbol store.</returns>
		// Token: 0x06003293 RID: 12947
		ISymbolDocument[] GetDocuments();

		/// <summary>Gets the metadata token for the method that was specified as the user entry point for the module, if any.</summary>
		/// <returns>The metadata token for the method that is the user entry point for the module.</returns>
		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06003294 RID: 12948
		SymbolToken UserEntryPoint { get; }

		/// <summary>Gets a symbol reader method object when given the identifier of a method.</summary>
		/// <param name="method">The metadata token of the method.</param>
		/// <returns>The symbol reader method object for the specified method identifier.</returns>
		// Token: 0x06003295 RID: 12949
		ISymbolMethod GetMethod(SymbolToken method);

		/// <summary>Gets a symbol reader method object when given the identifier of a method and its edit and continue version.</summary>
		/// <param name="method">The metadata token of the method.</param>
		/// <param name="version">The edit and continue version of the method.</param>
		/// <returns>The symbol reader method object for the specified method identifier.</returns>
		// Token: 0x06003296 RID: 12950
		ISymbolMethod GetMethod(SymbolToken method, int version);

		/// <summary>Gets the variables that are not local when given the parent.</summary>
		/// <param name="parent">The metadata token for the type for which the variables are requested.</param>
		/// <returns>An array of variables for the parent.</returns>
		// Token: 0x06003297 RID: 12951
		ISymbolVariable[] GetVariables(SymbolToken parent);

		/// <summary>Gets all global variables in the module.</summary>
		/// <returns>An array of all variables in the module.</returns>
		// Token: 0x06003298 RID: 12952
		ISymbolVariable[] GetGlobalVariables();

		/// <summary>Gets a symbol reader method object that contains a specified position in a document.</summary>
		/// <param name="document">The document in which the method is located.</param>
		/// <param name="line">The position of the line within the document. The lines are numbered, beginning with 1.</param>
		/// <param name="column">The position of column within the document. The columns are numbered, beginning with 1.</param>
		/// <returns>The reader method object for the specified position in the document.</returns>
		// Token: 0x06003299 RID: 12953
		ISymbolMethod GetMethodFromDocumentPosition(ISymbolDocument document, int line, int column);

		/// <summary>Gets an attribute value when given the attribute name.</summary>
		/// <param name="parent">The metadata token for the object for which the attribute is requested.</param>
		/// <param name="name">The attribute name.</param>
		/// <returns>The value of the attribute.</returns>
		// Token: 0x0600329A RID: 12954
		byte[] GetSymAttribute(SymbolToken parent, string name);

		/// <summary>Gets the namespaces that are defined in the global scope within the current symbol store.</summary>
		/// <returns>The namespaces defined in the global scope within the current symbol store.</returns>
		// Token: 0x0600329B RID: 12955
		ISymbolNamespace[] GetNamespaces();
	}
}
