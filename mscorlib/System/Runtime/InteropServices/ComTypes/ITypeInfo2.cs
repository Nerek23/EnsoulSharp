﻿using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Provides the managed definition of the <see langword="ITypeInfo2" /> interface.</summary>
	// Token: 0x02000A27 RID: 2599
	[Guid("00020412-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface ITypeInfo2 : ITypeInfo
	{
		/// <summary>Retrieves a <see cref="T:System.Runtime.InteropServices.TYPEATTR" /> structure that contains the attributes of the type description.</summary>
		/// <param name="ppTypeAttr">When this method returns, contains a reference to the structure that contains the attributes of this type description. This parameter is passed uninitialized.</param>
		// Token: 0x06006580 RID: 25984
		void GetTypeAttr(out IntPtr ppTypeAttr);

		/// <summary>Retrieves the <see langword="ITypeComp" /> interface for the type description, which enables a client compiler to bind to the type description's members.</summary>
		/// <param name="ppTComp">When this method returns, contains a reference to the <see langword="ITypeComp" /> of the containing type library. This parameter is passed uninitialized.</param>
		// Token: 0x06006581 RID: 25985
		[__DynamicallyInvokable]
		void GetTypeComp(out ITypeComp ppTComp);

		/// <summary>Retrieves the <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> structure that contains information about a specified function.</summary>
		/// <param name="index">The index of the function description to return.</param>
		/// <param name="ppFuncDesc">When this method returns, contains a reference to a <see langword="FUNCDESC" /> structure that describes the specified function. This parameter is passed uninitialized.</param>
		// Token: 0x06006582 RID: 25986
		void GetFuncDesc(int index, out IntPtr ppFuncDesc);

		/// <summary>Retrieves a <see langword="VARDESC" /> structure that describes the specified variable.</summary>
		/// <param name="index">The index of the variable description to return.</param>
		/// <param name="ppVarDesc">When this method returns, contains a reference to the <see langword="VARDESC" /> structure that describes the specified variable. This parameter is passed uninitialized.</param>
		// Token: 0x06006583 RID: 25987
		void GetVarDesc(int index, out IntPtr ppVarDesc);

		/// <summary>Retrieves the variable with the specified member ID (or the name of the property or method and its parameters) that corresponds to the specified function ID.</summary>
		/// <param name="memid">The ID of the member whose name (or names) is to be returned.</param>
		/// <param name="rgBstrNames">When this method returns, contains the name (or names) associated with the member. This parameter is passed uninitialized.</param>
		/// <param name="cMaxNames">The length of the <paramref name="rgBstrNames" /> array.</param>
		/// <param name="pcNames">When this method returns, contains the number of names in the <paramref name="rgBstrNames" /> array. This parameter is passed uninitialized.</param>
		// Token: 0x06006584 RID: 25988
		[__DynamicallyInvokable]
		void GetNames(int memid, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [Out] string[] rgBstrNames, int cMaxNames, out int pcNames);

		/// <summary>Retrieves the type description of the implemented interface types, if a type description describes a COM class.</summary>
		/// <param name="index">The index of the implemented type whose handle is returned.</param>
		/// <param name="href">When this method returns, contains a reference to a handle for the implemented interface. This parameter is passed uninitialized.</param>
		// Token: 0x06006585 RID: 25989
		[__DynamicallyInvokable]
		void GetRefTypeOfImplType(int index, out int href);

		/// <summary>Retrieves the <see cref="T:System.Runtime.InteropServices.IMPLTYPEFLAGS" /> value for one implemented interface or base interface in a type description.</summary>
		/// <param name="index">The index of the implemented interface or base interface.</param>
		/// <param name="pImplTypeFlags">When this method returns, contains a reference to the <see langword="IMPLTYPEFLAGS" /> enumeration. This parameter is passed uninitialized.</param>
		// Token: 0x06006586 RID: 25990
		[__DynamicallyInvokable]
		void GetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags);

		/// <summary>Maps between member names and member IDs, and parameter names and parameter IDs.</summary>
		/// <param name="rgszNames">An array of names to map.</param>
		/// <param name="cNames">The count of names to map.</param>
		/// <param name="pMemId">When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.</param>
		// Token: 0x06006587 RID: 25991
		[__DynamicallyInvokable]
		void GetIDsOfNames([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] [In] string[] rgszNames, int cNames, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] int[] pMemId);

		/// <summary>Invokes a method, or accesses a property of an object, that implements the interface described by the type description.</summary>
		/// <param name="pvInstance">A reference to the interface described by this type description.</param>
		/// <param name="memid">Identifier of the interface member.</param>
		/// <param name="wFlags">Flags describing the context of the invoke call.</param>
		/// <param name="pDispParams">A reference to a structure that contains an array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.</param>
		/// <param name="pVarResult">A reference to the location at which the result is to be stored. If <paramref name="wFlags" /> specifies <see langword="DISPATCH_PROPERTYPUT" /> or <see langword="DISPATCH_PROPERTYPUTREF" />, <paramref name="pVarResult" /> is ignored. Set to <see langword="null" /> if no result is desired.</param>
		/// <param name="pExcepInfo">A pointer to an exception information structure, which is filled in only if <see langword="DISP_E_EXCEPTION" /> is returned.</param>
		/// <param name="puArgErr">If <see langword="Invoke" /> returns <see langword="DISP_E_TYPEMISMATCH" />, <paramref name="puArgErr" /> indicates the index of the argument with incorrect type. If more than one argument returns an error, <paramref name="puArgErr" /> indicates only the first argument with an error.</param>
		// Token: 0x06006588 RID: 25992
		void Invoke([MarshalAs(UnmanagedType.IUnknown)] object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);

		/// <summary>Retrieves the documentation string, the complete Help file name and path, and the context ID for the Help topic for a specified type description.</summary>
		/// <param name="index">The ID of the member whose documentation is to be returned.</param>
		/// <param name="strName">When this method returns, contains the name of the item method. This parameter is passed uninitialized.</param>
		/// <param name="strDocString">When this method returns, contains the documentation string for the specified item. This parameter is passed uninitialized.</param>
		/// <param name="dwHelpContext">When this method returns, contains a reference to the Help context associated with the specified item. This parameter is passed uninitialized.</param>
		/// <param name="strHelpFile">When this method returns, contains the fully qualified name of the Help file. This parameter is passed uninitialized.</param>
		// Token: 0x06006589 RID: 25993
		[__DynamicallyInvokable]
		void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);

		/// <summary>Retrieves a description or specification of an entry point for a function in a DLL.</summary>
		/// <param name="memid">The ID of the member function whose DLL entry description is to be returned.</param>
		/// <param name="invKind">One of the <see cref="T:System.Runtime.InteropServices.ComTypes.INVOKEKIND" /> values that specifies the kind of member identified by <paramref name="memid" />.</param>
		/// <param name="pBstrDllName">If not <see langword="null" />, the function sets <paramref name="pBstrDllName" /> to a <see langword="BSTR" /> that contains the name of the DLL.</param>
		/// <param name="pBstrName">If not <see langword="null" />, the function sets lpbstrName to a <see langword="BSTR" /> that contains the name of the entry point.</param>
		/// <param name="pwOrdinal">If not <see langword="null" />, and the function is defined by an ordinal, then lpwOrdinal is set to point to the ordinal.</param>
		// Token: 0x0600658A RID: 25994
		void GetDllEntry(int memid, INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);

		/// <summary>Retrieves the referenced type descriptions, if a type description references other type descriptions.</summary>
		/// <param name="hRef">A handle to the referenced type description to return.</param>
		/// <param name="ppTI">When this method returns, contains the referenced type description. This parameter is passed uninitialized.</param>
		// Token: 0x0600658B RID: 25995
		[__DynamicallyInvokable]
		void GetRefTypeInfo(int hRef, out ITypeInfo ppTI);

		/// <summary>Retrieves the addresses of static functions or variables, such as those defined in a DLL.</summary>
		/// <param name="memid">The member ID of the <see langword="static" /> member's address to retrieve.</param>
		/// <param name="invKind">One of the <see cref="T:System.Runtime.InteropServices.ComTypes.INVOKEKIND" /> values that specifies whether the member is a property, and if so, what kind.</param>
		/// <param name="ppv">When this method returns, contains a reference to the <see langword="static" /> member. This parameter is passed uninitialized.</param>
		// Token: 0x0600658C RID: 25996
		void AddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv);

		/// <summary>Creates a new instance of a type that describes a component class (coclass).</summary>
		/// <param name="pUnkOuter">An object that acts as the controlling <see langword="IUnknown" />.</param>
		/// <param name="riid">The IID of the interface that the caller uses to communicate with the resulting object.</param>
		/// <param name="ppvObj">When this method returns, contains a reference to the created object. This parameter is passed uninitialized.</param>
		// Token: 0x0600658D RID: 25997
		[__DynamicallyInvokable]
		void CreateInstance([MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		/// <summary>Retrieves marshaling information.</summary>
		/// <param name="memid">The member ID that indicates which marshaling information is needed.</param>
		/// <param name="pBstrMops">When this method returns, contains a reference to the <see langword="opcode" /> string used in marshaling the fields of the structure described by the referenced type description, or returns <see langword="null" /> if there is no information to return. This parameter is passed uninitialized.</param>
		// Token: 0x0600658E RID: 25998
		[__DynamicallyInvokable]
		void GetMops(int memid, out string pBstrMops);

		/// <summary>Retrieves the type library that contains this type description and its index within that type library.</summary>
		/// <param name="ppTLB">When this method returns, contains a reference to the containing type library. This parameter is passed uninitialized.</param>
		/// <param name="pIndex">When this method returns, contains a reference to the index of the type description within the containing type library. This parameter is passed uninitialized.</param>
		// Token: 0x0600658F RID: 25999
		[__DynamicallyInvokable]
		void GetContainingTypeLib(out ITypeLib ppTLB, out int pIndex);

		/// <summary>Releases a <see cref="T:System.Runtime.InteropServices.TYPEATTR" /> structure previously returned by the <see cref="M:System.Runtime.InteropServices.ComTypes.ITypeInfo.GetTypeAttr(System.IntPtr@)" /> method.</summary>
		/// <param name="pTypeAttr">A reference to the <see langword="TYPEATTR" /> structure to release.</param>
		// Token: 0x06006590 RID: 26000
		[PreserveSig]
		void ReleaseTypeAttr(IntPtr pTypeAttr);

		/// <summary>Releases a <see cref="T:System.Runtime.InteropServices.FUNCDESC" /> structure previously returned by the <see cref="M:System.Runtime.InteropServices.ComTypes.ITypeInfo.GetFuncDesc(System.Int32,System.IntPtr@)" /> method.</summary>
		/// <param name="pFuncDesc">A reference to the <see langword="FUNCDESC" /> structure to release.</param>
		// Token: 0x06006591 RID: 26001
		[PreserveSig]
		void ReleaseFuncDesc(IntPtr pFuncDesc);

		/// <summary>Releases a <see langword="VARDESC" /> structure previously returned by the <see cref="M:System.Runtime.InteropServices.ComTypes.ITypeInfo.GetVarDesc(System.Int32,System.IntPtr@)" /> method.</summary>
		/// <param name="pVarDesc">A reference to the <see langword="VARDESC" /> structure to release.</param>
		// Token: 0x06006592 RID: 26002
		[PreserveSig]
		void ReleaseVarDesc(IntPtr pVarDesc);

		/// <summary>Returns the <see langword="TYPEKIND" /> enumeration quickly, without doing any allocations.</summary>
		/// <param name="pTypeKind">When this method returns, contains a reference to a <see langword="TYPEKIND" /> enumeration. This parameter is passed uninitialized.</param>
		// Token: 0x06006593 RID: 26003
		[__DynamicallyInvokable]
		void GetTypeKind(out TYPEKIND pTypeKind);

		/// <summary>Returns the type flags without any allocations. This method returns a <see langword="DWORD" /> type flag, which expands the type flags without growing the <see langword="TYPEATTR" /> (type attribute).</summary>
		/// <param name="pTypeFlags">When this method returns, contains a <see langword="DWORD" /> reference to a <see langword="TYPEFLAG" />. This parameter is passed uninitialized.</param>
		// Token: 0x06006594 RID: 26004
		[__DynamicallyInvokable]
		void GetTypeFlags(out int pTypeFlags);

		/// <summary>Binds to a specific member based on a known DISPID, where the member name is not known (for example, when binding to a default member).</summary>
		/// <param name="memid">The member identifier.</param>
		/// <param name="invKind">One of the <see cref="T:System.Runtime.InteropServices.ComTypes.INVOKEKIND" /> values that specifies the kind of member identified by memid.</param>
		/// <param name="pFuncIndex">When this method returns, contains an index into the function. This parameter is passed uninitialized.</param>
		// Token: 0x06006595 RID: 26005
		[__DynamicallyInvokable]
		void GetFuncIndexOfMemId(int memid, INVOKEKIND invKind, out int pFuncIndex);

		/// <summary>Binds to a specific member based on a known <see langword="DISPID" />, where the member name is not known (for example, when binding to a default member).</summary>
		/// <param name="memid">The member identifier.</param>
		/// <param name="pVarIndex">When this method returns, contains an index of <paramref name="memid" />. This parameter is passed uninitialized.</param>
		// Token: 0x06006596 RID: 26006
		[__DynamicallyInvokable]
		void GetVarIndexOfMemId(int memid, out int pVarIndex);

		/// <summary>Gets the custom data.</summary>
		/// <param name="guid">The GUID used to identify the data.</param>
		/// <param name="pVarVal">When this method returns, contains an <see langword="Object" /> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
		// Token: 0x06006597 RID: 26007
		[__DynamicallyInvokable]
		void GetCustData(ref Guid guid, out object pVarVal);

		/// <summary>Gets the custom data from the specified function.</summary>
		/// <param name="index">The index of the function to get the custom data for.</param>
		/// <param name="guid">The GUID used to identify the data.</param>
		/// <param name="pVarVal">When this method returns, contains an <see langword="Object" /> that specified where to put the data. This parameter is passed uninitialized.</param>
		// Token: 0x06006598 RID: 26008
		[__DynamicallyInvokable]
		void GetFuncCustData(int index, ref Guid guid, out object pVarVal);

		/// <summary>Gets the specified custom data parameter.</summary>
		/// <param name="indexFunc">The index of the function to get the custom data for.</param>
		/// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
		/// <param name="guid">The GUID used to identify the data.</param>
		/// <param name="pVarVal">When this method returns, contains an <see langword="Object" /> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
		// Token: 0x06006599 RID: 26009
		[__DynamicallyInvokable]
		void GetParamCustData(int indexFunc, int indexParam, ref Guid guid, out object pVarVal);

		/// <summary>Gets the variable for the custom data.</summary>
		/// <param name="index">The index of the variable to get the custom data for.</param>
		/// <param name="guid">The GUID used to identify the data.</param>
		/// <param name="pVarVal">When this method returns, contains an <see langword="Object" /> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
		// Token: 0x0600659A RID: 26010
		[__DynamicallyInvokable]
		void GetVarCustData(int index, ref Guid guid, out object pVarVal);

		/// <summary>Gets the implementation type of the custom data.</summary>
		/// <param name="index">The index of the implementation type for the custom data.</param>
		/// <param name="guid">The GUID used to identify the data.</param>
		/// <param name="pVarVal">When this method returns, contains an <see langword="Object" /> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
		// Token: 0x0600659B RID: 26011
		[__DynamicallyInvokable]
		void GetImplTypeCustData(int index, ref Guid guid, out object pVarVal);

		/// <summary>Retrieves the documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.</summary>
		/// <param name="memid">The member identifier for the type description.</param>
		/// <param name="pbstrHelpString">When this method returns, contains a <see langword="BSTR" /> that contains the name of the specified item. If the caller does not need the item name, <paramref name="pbstrHelpString" /> can be <see langword="null" />. This parameter is passed uninitialized.</param>
		/// <param name="pdwHelpStringContext">When this method returns, contains the Help localization context. If the caller does not need the Help context, <paramref name="pdwHelpStringContext" /> can be <see langword="null" />. This parameter is passed uninitialized.</param>
		/// <param name="pbstrHelpStringDll">When this method returns, contains a <see langword="BSTR" /> that contains the fully qualified name of the file containing the DLL used for the Help file. If the caller does not need the file name, <paramref name="pbstrHelpStringDll" /> can be <see langword="null" />. This parameter is passed uninitialized.</param>
		// Token: 0x0600659C RID: 26012
		[LCIDConversion(1)]
		[__DynamicallyInvokable]
		void GetDocumentation2(int memid, out string pbstrHelpString, out int pdwHelpStringContext, out string pbstrHelpStringDll);

		/// <summary>Gets all custom data items for the library.</summary>
		/// <param name="pCustData">A pointer to <see langword="CUSTDATA" />, which holds all custom data items.</param>
		// Token: 0x0600659D RID: 26013
		void GetAllCustData(IntPtr pCustData);

		/// <summary>Gets all custom data from the specified function.</summary>
		/// <param name="index">The index of the function to get the custom data for.</param>
		/// <param name="pCustData">A pointer to <see langword="CUSTDATA" />, which holds all custom data items.</param>
		// Token: 0x0600659E RID: 26014
		void GetAllFuncCustData(int index, IntPtr pCustData);

		/// <summary>Gets all of the custom data for the specified function parameter.</summary>
		/// <param name="indexFunc">The index of the function to get the custom data for.</param>
		/// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
		/// <param name="pCustData">A pointer to <see langword="CUSTDATA" />, which holds all custom data items.</param>
		// Token: 0x0600659F RID: 26015
		void GetAllParamCustData(int indexFunc, int indexParam, IntPtr pCustData);

		/// <summary>Gets the variable for the custom data.</summary>
		/// <param name="index">The index of the variable to get the custom data for.</param>
		/// <param name="pCustData">A pointer to <see langword="CUSTDATA" />, which holds all custom data items.</param>
		// Token: 0x060065A0 RID: 26016
		void GetAllVarCustData(int index, IntPtr pCustData);

		/// <summary>Gets all custom data for the specified implementation type.</summary>
		/// <param name="index">The index of the implementation type for the custom data.</param>
		/// <param name="pCustData">A pointer to <see langword="CUSTDATA" /> which holds all custom data items.</param>
		// Token: 0x060065A1 RID: 26017
		void GetAllImplTypeCustData(int index, IntPtr pCustData);
	}
}
