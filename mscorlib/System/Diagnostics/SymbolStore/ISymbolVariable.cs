using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	/// <summary>Represents a variable within a symbol store.</summary>
	// Token: 0x020003D6 RID: 982
	[ComVisible(true)]
	public interface ISymbolVariable
	{
		/// <summary>Gets the name of the variable.</summary>
		/// <returns>The name of the variable.</returns>
		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x060032A3 RID: 12963
		string Name { get; }

		/// <summary>Gets the attributes of the variable.</summary>
		/// <returns>The variable attributes.</returns>
		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x060032A4 RID: 12964
		object Attributes { get; }

		/// <summary>Gets the variable signature.</summary>
		/// <returns>The variable signature as an opaque blob.</returns>
		// Token: 0x060032A5 RID: 12965
		byte[] GetSignature();

		/// <summary>Gets the <see cref="T:System.Diagnostics.SymbolStore.SymAddressKind" /> value describing the type of the address.</summary>
		/// <returns>The type of the address. One of the <see cref="T:System.Diagnostics.SymbolStore.SymAddressKind" /> values.</returns>
		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x060032A6 RID: 12966
		SymAddressKind AddressKind { get; }

		/// <summary>Gets the first address of a variable.</summary>
		/// <returns>The first address of the variable.</returns>
		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x060032A7 RID: 12967
		int AddressField1 { get; }

		/// <summary>Gets the second address of a variable.</summary>
		/// <returns>The second address of the variable.</returns>
		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x060032A8 RID: 12968
		int AddressField2 { get; }

		/// <summary>Gets the third address of a variable.</summary>
		/// <returns>The third address of the variable.</returns>
		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x060032A9 RID: 12969
		int AddressField3 { get; }

		/// <summary>Gets the start offset of the variable within the scope of the variable.</summary>
		/// <returns>The start offset of the variable.</returns>
		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x060032AA RID: 12970
		int StartOffset { get; }

		/// <summary>Gets the end offset of a variable within the scope of the variable.</summary>
		/// <returns>The end offset of the variable.</returns>
		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x060032AB RID: 12971
		int EndOffset { get; }
	}
}
