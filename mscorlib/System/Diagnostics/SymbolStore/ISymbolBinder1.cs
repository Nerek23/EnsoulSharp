using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a symbol binder for managed code.</summary>
	// Token: 0x020003CF RID: 975
	[ComVisible(true)]
	public interface ISymbolBinder1
	{
		/// <summary>Gets the interface of the symbol reader for the current file.</summary>
		/// <param name="importer">An <see cref="T:System.IntPtr" /> that refers to the metadata import interface.</param>
		/// <param name="filename">The name of the file for which the reader interface is required.</param>
		/// <param name="searchPath">The search path used to locate the symbol file.</param>
		/// <returns>The <see cref="T:System.Diagnostics.SymbolStore.ISymbolReader" /> interface that reads the debugging symbols.</returns>
		// Token: 0x06003278 RID: 12920
		ISymbolReader GetReader(IntPtr importer, string filename, string searchPath);
	}
}
