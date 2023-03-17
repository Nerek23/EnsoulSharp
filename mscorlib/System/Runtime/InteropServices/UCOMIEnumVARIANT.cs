using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IEnumVARIANT" /> instead.</summary>
	// Token: 0x02000958 RID: 2392
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumVARIANT instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00020404-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumVARIANT
	{
		/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of elements to return in rgelt.</param>
		/// <param name="rgvar">On successful return, a reference to the enumerated elements.</param>
		/// <param name="pceltFetched">On successful return, a reference to the actual number of elements enumerated in rgelt.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the <paramref name="pceltFetched" /> parameter equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x0600617F RID: 24959
		[PreserveSig]
		int Next(int celt, int rgvar, int pceltFetched);

		/// <summary>Skips over a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of elements to skip in the enumeration.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the number of elements skipped equals <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x06006180 RID: 24960
		[PreserveSig]
		int Skip(int celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <returns>An HRESULT with the value <see langword="S_OK" />.</returns>
		// Token: 0x06006181 RID: 24961
		[PreserveSig]
		int Reset();

		/// <summary>Creates another enumerator that contains the same enumeration state as the current one.</summary>
		/// <param name="ppenum">On successful return, a reference to the newly created enumerator.</param>
		// Token: 0x06006182 RID: 24962
		void Clone(int ppenum);
	}
}
