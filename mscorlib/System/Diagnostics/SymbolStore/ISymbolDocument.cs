using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a document referenced by a symbol store.</summary>
	// Token: 0x020003D0 RID: 976
	[ComVisible(true)]
	public interface ISymbolDocument
	{
		/// <summary>Gets the URL of the current document.</summary>
		/// <returns>The URL of the current document.</returns>
		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06003279 RID: 12921
		string URL { get; }

		/// <summary>Gets the type of the current document.</summary>
		/// <returns>The type of the current document.</returns>
		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x0600327A RID: 12922
		Guid DocumentType { get; }

		/// <summary>Gets the language of the current document.</summary>
		/// <returns>The language of the current document.</returns>
		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x0600327B RID: 12923
		Guid Language { get; }

		/// <summary>Gets the language vendor of the current document.</summary>
		/// <returns>The language vendor of the current document.</returns>
		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x0600327C RID: 12924
		Guid LanguageVendor { get; }

		/// <summary>Gets the checksum algorithm identifier.</summary>
		/// <returns>A GUID identifying the checksum algorithm. The value is all zeros, if there is no checksum.</returns>
		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x0600327D RID: 12925
		Guid CheckSumAlgorithmId { get; }

		/// <summary>Gets the checksum.</summary>
		/// <returns>The checksum.</returns>
		// Token: 0x0600327E RID: 12926
		byte[] GetCheckSum();

		/// <summary>Returns the closest line that is a sequence point, given a line in the current document that might or might not be a sequence point.</summary>
		/// <param name="line">The specified line in the document.</param>
		/// <returns>The closest line that is a sequence point.</returns>
		// Token: 0x0600327F RID: 12927
		int FindClosestLine(int line);

		/// <summary>Checks whether the current document is stored in the symbol store.</summary>
		/// <returns>
		///   <see langword="true" /> if the current document is stored in the symbol store; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06003280 RID: 12928
		bool HasEmbeddedSource { get; }

		/// <summary>Gets the length, in bytes, of the embedded source.</summary>
		/// <returns>The source length of the current document.</returns>
		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06003281 RID: 12929
		int SourceLength { get; }

		/// <summary>Gets the embedded document source for the specified range.</summary>
		/// <param name="startLine">The starting line in the current document.</param>
		/// <param name="startColumn">The starting column in the current document.</param>
		/// <param name="endLine">The ending line in the current document.</param>
		/// <param name="endColumn">The ending column in the current document.</param>
		/// <returns>The document source for the specified range.</returns>
		// Token: 0x06003282 RID: 12930
		byte[] GetSourceRange(int startLine, int startColumn, int endLine, int endColumn);
	}
}
