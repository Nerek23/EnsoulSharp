using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.ITypeLib" /> instead.</summary>
	// Token: 0x0200097B RID: 2427
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.ITypeLib instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00020402-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMITypeLib
	{
		/// <summary>Returns the number of type descriptions in the type library.</summary>
		/// <returns>The number of type descriptions in the type library.</returns>
		// Token: 0x060061D4 RID: 25044
		[PreserveSig]
		int GetTypeInfoCount();

		/// <summary>Retrieves the specified type description in the library.</summary>
		/// <param name="index">Index of the <see langword="UCOMITypeInfo" /> interface to return.</param>
		/// <param name="ppTI">On successful return, a <see langword="UCOMITypeInfo" /> describing the type referenced by <paramref name="index" />.</param>
		// Token: 0x060061D5 RID: 25045
		void GetTypeInfo(int index, out UCOMITypeInfo ppTI);

		/// <summary>Retrieves the type of a type description.</summary>
		/// <param name="index">The index of the type description within the type library.</param>
		/// <param name="pTKind">Reference to the <see langword="TYPEKIND" /> enumeration for the type description.</param>
		// Token: 0x060061D6 RID: 25046
		void GetTypeInfoType(int index, out TYPEKIND pTKind);

		/// <summary>Retrieves the type description that corresponds to the specified GUID.</summary>
		/// <param name="guid">IID of the interface of CLSID of the class whose type info is requested.</param>
		/// <param name="ppTInfo">On successful return, the requested <see langword="ITypeInfo" /> interface.</param>
		// Token: 0x060061D7 RID: 25047
		void GetTypeInfoOfGuid(ref Guid guid, out UCOMITypeInfo ppTInfo);

		/// <summary>Retrieves the structure that contains the library's attributes.</summary>
		/// <param name="ppTLibAttr">On successful return, a structure that contains the library's attributes.</param>
		// Token: 0x060061D8 RID: 25048
		void GetLibAttr(out IntPtr ppTLibAttr);

		/// <summary>Enables a client compiler to bind to a library's types, variables, constants, and global functions.</summary>
		/// <param name="ppTComp">On successful return, an instance of a <see langword="UCOMITypeComp" /> instance for this <see langword="ITypeLib" />.</param>
		// Token: 0x060061D9 RID: 25049
		void GetTypeComp(out UCOMITypeComp ppTComp);

		/// <summary>Retrieves the library's documentation string, the complete Help file name and path, and the context identifier for the library Help topic in the Help file.</summary>
		/// <param name="index">Index of the type description whose documentation is to be returned.</param>
		/// <param name="strName">Returns a string that contains the name of the specified item.</param>
		/// <param name="strDocString">Returns a string that contains the documentation string for the specified item.</param>
		/// <param name="dwHelpContext">Returns the Help context identifier associated with the specified item.</param>
		/// <param name="strHelpFile">Returns a string that contains the fully qualified name of the Help file.</param>
		// Token: 0x060061DA RID: 25050
		void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);

		/// <summary>Indicates whether a passed-in string contains the name of a type or member described in the library.</summary>
		/// <param name="szNameBuf">The string to test.</param>
		/// <param name="lHashVal">The hash value of <paramref name="szNameBuf" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="szNameBuf" /> was found in the type library; otherwise <see langword="false" />.</returns>
		// Token: 0x060061DB RID: 25051
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal);

		/// <summary>Finds occurrences of a type description in a type library.</summary>
		/// <param name="szNameBuf">The name to search for.</param>
		/// <param name="lHashVal">A hash value to speed up the search, computed by the <see langword="LHashValOfNameSys" /> function. If <paramref name="lHashVal" /> is 0, a value is computed.</param>
		/// <param name="ppTInfo">On successful return, an array of pointers to the type descriptions that contain the name specified in <paramref name="szNameBuf" />.</param>
		/// <param name="rgMemId">An array of the <see langword="MEMBERID" /> 's of the found items; <paramref name="rgMemId" /> [i] is the <see langword="MEMBERID" /> that indexes into the type description specified by <paramref name="ppTInfo" /> [i]. Cannot be <see langword="null" />.</param>
		/// <param name="pcFound">On entry, indicates how many instances to look for. For example, <paramref name="pcFound" /> = 1 can be called to find the first occurrence. The search stops when one instance is found.  
		///  On exit, indicates the number of instances that were found. If the <see langword="in" /> and <see langword="out" /> values of <paramref name="pcFound" /> are identical, there might be more type descriptions that contain the name.</param>
		// Token: 0x060061DC RID: 25052
		void FindName([MarshalAs(UnmanagedType.LPWStr)] string szNameBuf, int lHashVal, [MarshalAs(UnmanagedType.LPArray)] [Out] UCOMITypeInfo[] ppTInfo, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] rgMemId, ref short pcFound);

		/// <summary>Releases the <see cref="T:System.Runtime.InteropServices.TYPELIBATTR" /> originally obtained from <see cref="M:System.Runtime.InteropServices.UCOMITypeLib.GetLibAttr(System.IntPtr@)" />.</summary>
		/// <param name="pTLibAttr">The <see langword="TLIBATTR" /> to release.</param>
		// Token: 0x060061DD RID: 25053
		[PreserveSig]
		void ReleaseTLibAttr(IntPtr pTLibAttr);
	}
}
