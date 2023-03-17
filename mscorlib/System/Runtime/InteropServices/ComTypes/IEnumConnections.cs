using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Manages the definition of the <see langword="IEnumConnections" /> interface.</summary>
	// Token: 0x020009FE RID: 2558
	[Guid("B196B287-BAB4-101A-B69C-00AA00341D07")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IEnumConnections
	{
		/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of <see cref="T:System.Runtime.InteropServices.CONNECTDATA" /> structures to return in <paramref name="rgelt" />.</param>
		/// <param name="rgelt">When this method returns, contains a reference to the enumerated connections. This parameter is passed uninitialized.</param>
		/// <param name="pceltFetched">When this method returns, contains a reference to the actual number of connections enumerated in <paramref name="rgelt" />.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the <paramref name="pceltFetched" /> parameter equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x06006507 RID: 25863
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] CONNECTDATA[] rgelt, IntPtr pceltFetched);

		/// <summary>Skips a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of elements to skip in the enumeration.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the number of elements skipped equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x06006508 RID: 25864
		[__DynamicallyInvokable]
		[PreserveSig]
		int Skip(int celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		// Token: 0x06006509 RID: 25865
		[__DynamicallyInvokable]
		void Reset();

		/// <summary>Creates a new enumerator that contains the same enumeration state as the current one.</summary>
		/// <param name="ppenum">When this method returns, contains a reference to the newly created enumerator. This parameter is passed uninitialized.</param>
		// Token: 0x0600650A RID: 25866
		[__DynamicallyInvokable]
		void Clone(out IEnumConnections ppenum);
	}
}
