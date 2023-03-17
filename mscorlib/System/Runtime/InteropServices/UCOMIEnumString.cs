using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IEnumString" /> instead.</summary>
	// Token: 0x02000957 RID: 2391
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumString instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00000101-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumString
	{
		/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of strings to return in <paramref name="rgelt" />.</param>
		/// <param name="rgelt">On successful return, a reference to the enumerated strings.</param>
		/// <param name="pceltFetched">On successful return, a reference to the actual number of strings enumerated in <paramref name="rgelt" />.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the <paramref name="pceltFetched" /> parameter equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x0600617B RID: 24955
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] [Out] string[] rgelt, out int pceltFetched);

		/// <summary>Skips over a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of elements to skip in the enumeration.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the number of elements skipped equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x0600617C RID: 24956
		[PreserveSig]
		int Skip(int celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <returns>An HRESULT with the value <see langword="S_OK" />.</returns>
		// Token: 0x0600617D RID: 24957
		[PreserveSig]
		int Reset();

		/// <summary>Creates another enumerator that contains the same enumeration state as the current one.</summary>
		/// <param name="ppenum">On successful return, a reference to the newly created enumerator.</param>
		// Token: 0x0600617E RID: 24958
		void Clone(out UCOMIEnumString ppenum);
	}
}
