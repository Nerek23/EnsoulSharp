﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	/// <summary>Exposes the public members of the <see cref="T:System.Type" /> class to the unmanaged code.</summary>
	// Token: 0x020008D5 RID: 2261
	[Guid("BCA8B44D-AAD6-3A86-8AB7-03349F4F2DA2")]
	[CLSCompliant(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeLibImportClass(typeof(Type))]
	[ComVisible(true)]
	public interface _Type
	{
		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		// Token: 0x06005D46 RID: 23878
		void GetTypeInfoCount(out uint pcTInfo);

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		// Token: 0x06005D47 RID: 23879
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array that receives the IDs corresponding to the names.</param>
		// Token: 0x06005D48 RID: 23880
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		// Token: 0x06005D49 RID: 23881
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.ToString" /> method.</summary>
		/// <returns>A <see cref="T:System.String" /> representing the name of the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D4A RID: 23882
		string ToString();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.Equals(System.Object)" /> method.</summary>
		/// <param name="other">The <see cref="T:System.Object" /> whose underlying system type is to be compared with the underlying system type of the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the underlying system type of <paramref name="o" /> is the same as the underlying system type of the current <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005D4B RID: 23883
		bool Equals(object other);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetHashCode" /> method.</summary>
		/// <returns>An <see cref="T:System.Int32" /> containing the hash code for this instance.</returns>
		// Token: 0x06005D4C RID: 23884
		int GetHashCode();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetType" /> method.</summary>
		/// <returns>The current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D4D RID: 23885
		Type GetType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.MemberType" /> property.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a type or a nested type.</returns>
		// Token: 0x1700101C RID: 4124
		// (get) Token: 0x06005D4E RID: 23886
		MemberTypes MemberType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.Name" /> property.</summary>
		/// <returns>The name of the <see cref="T:System.Type" />.</returns>
		// Token: 0x1700101D RID: 4125
		// (get) Token: 0x06005D4F RID: 23887
		string Name { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.DeclaringType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> object for the class that declares this member. If the type is a nested type, this property returns the enclosing type.</returns>
		// Token: 0x1700101E RID: 4126
		// (get) Token: 0x06005D50 RID: 23888
		Type DeclaringType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.ReflectedType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> object through which this <see cref="T:System.Reflection.MemberInfo" /> object was obtained.</returns>
		// Token: 0x1700101F RID: 4127
		// (get) Token: 0x06005D51 RID: 23889
		Type ReflectedType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
		// Token: 0x06005D52 RID: 23890
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.Assembly.GetCustomAttributes(System.Boolean)" /> method.</summary>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
		// Token: 0x06005D53 RID: 23891
		object[] GetCustomAttributes(bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of <paramref name="attributeType" /> is applied to this member; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005D54 RID: 23892
		bool IsDefined(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.GUID" /> property.</summary>
		/// <returns>The GUID associated with the <see cref="T:System.Type" />.</returns>
		// Token: 0x17001020 RID: 4128
		// (get) Token: 0x06005D55 RID: 23893
		Guid GUID { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.Module" /> property.</summary>
		/// <returns>The name of the module in which the current <see cref="T:System.Type" /> is defined.</returns>
		// Token: 0x17001021 RID: 4129
		// (get) Token: 0x06005D56 RID: 23894
		Module Module { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.Assembly" /> property.</summary>
		/// <returns>An <see cref="T:System.Reflection.Assembly" /> instance that describes the assembly containing the current type.</returns>
		// Token: 0x17001022 RID: 4130
		// (get) Token: 0x06005D57 RID: 23895
		Assembly Assembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.TypeHandle" /> property.</summary>
		/// <returns>The handle for the current <see cref="T:System.Type" />.</returns>
		// Token: 0x17001023 RID: 4131
		// (get) Token: 0x06005D58 RID: 23896
		RuntimeTypeHandle TypeHandle { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.FullName" /> property.</summary>
		/// <returns>A string containing the fully qualified name of the <see cref="T:System.Type" />, including the namespace of the <see cref="T:System.Type" /> but not the assembly.</returns>
		// Token: 0x17001024 RID: 4132
		// (get) Token: 0x06005D59 RID: 23897
		string FullName { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.Namespace" /> property.</summary>
		/// <returns>The namespace of the <see cref="T:System.Type" />.</returns>
		// Token: 0x17001025 RID: 4133
		// (get) Token: 0x06005D5A RID: 23898
		string Namespace { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.AssemblyQualifiedName" /> property.</summary>
		/// <returns>The assembly-qualified name of the <see cref="T:System.Type" />, including the name of the assembly from which the <see cref="T:System.Type" /> was loaded.</returns>
		// Token: 0x17001026 RID: 4134
		// (get) Token: 0x06005D5B RID: 23899
		string AssemblyQualifiedName { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetArrayRank" /> method.</summary>
		/// <returns>An <see cref="T:System.Int32" /> containing the number of dimensions in the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D5C RID: 23900
		int GetArrayRank();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.BaseType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> from which the current <see cref="T:System.Type" /> directly inherits, or <see langword="null" /> if the current <see langword="Type" /> represents the <see cref="T:System.Object" /> class.</returns>
		// Token: 0x17001027 RID: 4135
		// (get) Token: 0x06005D5D RID: 23901
		Type BaseType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetConstructors(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing all constructors defined for the current <see cref="T:System.Type" /> that match the specified binding constraints, including the type initializer if it is defined. Returns an empty array of type <see cref="T:System.Reflection.ConstructorInfo" /> if no constructors are defined for the current <see cref="T:System.Type" />, if none of the defined constructors match the binding constraints, or if the current <see cref="T:System.Type" /> represents a type parameter of a generic type or method definition.</returns>
		// Token: 0x06005D5E RID: 23902
		ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetInterface(System.String,System.Boolean)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the interface to get. For generic interfaces, this is the mangled name.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to perform a case-insensitive search for <paramref name="name" />.  
		/// -or-  
		/// <see langword="false" /> to perform a case-sensitive search for <paramref name="name" />.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the interface with the specified name, implemented or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D5F RID: 23903
		Type GetInterface(string name, bool ignoreCase);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetInterfaces" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the interfaces implemented or inherited by the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Type" />, if no interfaces are implemented or inherited by the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D60 RID: 23904
		Type[] GetInterfaces();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.FindInterfaces(System.Reflection.TypeFilter,System.Object)" /> method.</summary>
		/// <param name="filter">The <see cref="T:System.Reflection.TypeFilter" /> delegate that compares the interfaces against <paramref name="filterCriteria" />.</param>
		/// <param name="filterCriteria">The search criteria that determines whether an interface should be included in the returned array.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing a filtered list of the interfaces implemented or inherited by the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Type" />, if no interfaces matching the filter are implemented or inherited by the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D61 RID: 23905
		Type[] FindInterfaces(TypeFilter filter, object filterCriteria);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetEvent(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of an event that is declared or inherited by the current <see cref="T:System.Type" />.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>The <see cref="T:System.Reflection.EventInfo" /> object representing the specified event that is declared or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D62 RID: 23906
		EventInfo GetEvent(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetEvents" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing all the public events that are declared or inherited by the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.EventInfo" />, if the current <see cref="T:System.Type" /> does not have public events.</returns>
		// Token: 0x06005D63 RID: 23907
		EventInfo[] GetEvents();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetEvents(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing all events that are declared or inherited by the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.EventInfo" />, if the current <see cref="T:System.Type" /> does not have events, or if none of the events match the binding constraints.</returns>
		// Token: 0x06005D64 RID: 23908
		EventInfo[] GetEvents(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetNestedTypes(System.Reflection.BindingFlags)" /> method, and searches for the types nested within the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the types nested within the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Type" />, if no types are nested within the current <see cref="T:System.Type" />, or if none of the nested types match the binding constraints.</returns>
		// Token: 0x06005D65 RID: 23909
		Type[] GetNestedTypes(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetNestedType(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The string containing the name of the nested type to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the nested type that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D66 RID: 23910
		Type GetNestedType(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMember(System.String,System.Reflection.MemberTypes,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the members to get.</param>
		/// <param name="type">The <see cref="T:System.Reflection.MemberTypes" /> value to search for.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return an empty array.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		// Token: 0x06005D67 RID: 23911
		MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetDefaultMembers" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all default members of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have default members.</returns>
		// Token: 0x06005D68 RID: 23912
		MemberInfo[] GetDefaultMembers();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.FindMembers(System.Reflection.MemberTypes,System.Reflection.BindingFlags,System.Reflection.MemberFilter,System.Object)" /> method.</summary>
		/// <param name="memberType">A <see langword="MemberTypes" /> object indicating the type of member to search for.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="filter">The delegate that does the comparisons, returning <see langword="true" /> if the member currently being inspected matches the <paramref name="filterCriteria" /> and <see langword="false" /> otherwise. You can use the <see langword="FilterAttribute" />, <see langword="FilterName" />, and <see langword="FilterNameIgnoreCase" /> delegates supplied by this class. The first uses the fields of <see langword="FieldAttributes" />, <see langword="MethodAttributes" />, and <see langword="MethodImplAttributes" /> as search criteria, and the other two delegates use <see langword="String" /> objects as the search criteria.</param>
		/// <param name="filterCriteria">The search criteria that determines whether a member is returned in the array of <see langword="MemberInfo" /> objects.  
		///  The fields of <see langword="FieldAttributes" />, <see langword="MethodAttributes" />, and <see langword="MethodImplAttributes" /> can be used in conjunction with the <see langword="FilterAttribute" /> delegate supplied by this class.</param>
		/// <returns>A filtered array of <see cref="T:System.Reflection.MemberInfo" /> objects of the specified member type.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have members of type <paramref name="memberType" /> that match the filter criteria.</returns>
		// Token: 0x06005D69 RID: 23913
		MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetElementType" /> method.</summary>
		/// <returns>The <see cref="T:System.Type" /> of the object encompassed or referred to by the current array, pointer or reference type.  
		///  -or-  
		///  <see langword="null" /> if the current <see cref="T:System.Type" /> is not an array or a pointer, or is not passed by reference, or represents a generic type or a type parameter of a generic type or method definition.</returns>
		// Token: 0x06005D6A RID: 23914
		Type GetElementType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.IsSubclassOf(System.Type)" /> method.</summary>
		/// <param name="c">The <see cref="T:System.Type" /> to compare with the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> represented by the <paramref name="c" /> parameter and the current <see cref="T:System.Type" /> represent classes, and the class represented by the current <see cref="T:System.Type" /> derives from the class represented by <paramref name="c" />; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if <paramref name="c" /> and the current <see cref="T:System.Type" /> represent the same class.</returns>
		// Token: 0x06005D6B RID: 23915
		bool IsSubclassOf(Type c);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.IsInstanceOfType(System.Object)" /> method.</summary>
		/// <param name="o">The object to compare with the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Type" /> is in the inheritance hierarchy of the object represented by <paramref name="o" />, or if the current <see cref="T:System.Type" /> is an interface that <paramref name="o" /> supports. <see langword="false" /> if neither of these conditions is the case, or if <paramref name="o" /> is <see langword="null" />, or if the current <see cref="T:System.Type" /> is an open generic type (that is, <see cref="P:System.Type.ContainsGenericParameters" /> returns <see langword="true" />).</returns>
		// Token: 0x06005D6C RID: 23916
		bool IsInstanceOfType(object o);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.IsAssignableFrom(System.Type)" /> method.</summary>
		/// <param name="c">The <see cref="T:System.Type" /> to compare with the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="c" /> and the current <see cref="T:System.Type" /> represent the same type, or if the current <see cref="T:System.Type" /> is in the inheritance hierarchy of <paramref name="c" />, or if the current <see cref="T:System.Type" /> is an interface that <paramref name="c" /> implements, or if <paramref name="c" /> is a generic type parameter and the current <see cref="T:System.Type" /> represents one of the constraints of <paramref name="c" />. <see langword="false" /> if none of these conditions are the case, or if <paramref name="c" /> is <see langword="null" />.</returns>
		// Token: 0x06005D6D RID: 23917
		bool IsAssignableFrom(Type c);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetInterfaceMap(System.Type)" /> method.</summary>
		/// <param name="interfaceType">The <see cref="T:System.Type" /> of the interface of which to retrieve a mapping.</param>
		/// <returns>An <see cref="T:System.Reflection.InterfaceMapping" /> object representing the interface mapping for <paramref name="interfaceType" />.</returns>
		// Token: 0x06005D6E RID: 23918
		InterfaceMapping GetInterfaceMap(Type interfaceType);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D6F RID: 23919
		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D70 RID: 23920
		MethodInfo GetMethod(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethods(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects representing all methods defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MethodInfo" />, if no methods are defined for the current <see cref="T:System.Type" />, or if none of the defined methods match the binding constraints.</returns>
		// Token: 0x06005D71 RID: 23921
		MethodInfo[] GetMethods(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetField(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the data field to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D72 RID: 23922
		FieldInfo GetField(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetFields(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.FieldInfo" /> objects representing all fields defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.FieldInfo" />, if no fields are defined for the current <see cref="T:System.Type" />, or if none of the defined fields match the binding constraints.</returns>
		// Token: 0x06005D73 RID: 23923
		FieldInfo[] GetFields(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D74 RID: 23924
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Type,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D75 RID: 23925
		PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperties(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.PropertyInfo" /> objects representing all properties of the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.PropertyInfo" />, if the current <see cref="T:System.Type" /> does not have properties, or if none of the properties match the binding constraints.</returns>
		// Token: 0x06005D76 RID: 23926
		PropertyInfo[] GetProperties(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMember(System.String,System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the members to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return an empty array.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		// Token: 0x06005D77 RID: 23927
		MemberInfo[] GetMember(string name, BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMembers(System.Reflection.BindingFlags)" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all members defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if no members are defined for the current <see cref="T:System.Type" />, or if none of the defined members match the binding constraints.</returns>
		// Token: 0x06005D78 RID: 23928
		MemberInfo[] GetMembers(BindingFlags bindingAttr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For IDispatch members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> will apply.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="target">The <see cref="T:System.Object" /> on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="args" /> array. A parameter's associated attributes are stored in the member's signature. The default binder does not process this parameter.</param>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> object representing the globalization locale to use, which may be necessary for locale-specific conversions, such as converting a numeric String to a Double.  
		///  -or-  
		///  <see langword="null" /> to use the current thread's <see cref="T:System.Globalization.CultureInfo" />.</param>
		/// <param name="namedParameters">An array containing the names of the parameters to which the values in the <paramref name="args" /> array are passed.</param>
		/// <returns>An <see cref="T:System.Object" /> representing the return value of the invoked member.</returns>
		// Token: 0x06005D79 RID: 23929
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.UnderlyingSystemType" /> property.</summary>
		/// <returns>The underlying system type for the <see cref="T:System.Type" />.</returns>
		// Token: 0x17001028 RID: 4136
		// (get) Token: 0x06005D7A RID: 23930
		Type UnderlyingSystemType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For IDispatch members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> will apply.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="target">The <see cref="T:System.Object" /> on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> object representing the globalization locale to use, which may be necessary for locale-specific conversions, such as converting a numeric String to a Double.  
		///  -or-  
		///  <see langword="null" /> to use the current thread's <see cref="T:System.Globalization.CultureInfo" />.</param>
		/// <returns>An <see cref="T:System.Object" /> representing the return value of the invoked member.</returns>
		// Token: 0x06005D7B RID: 23931
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For IDispatch members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> will apply.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="target">The <see cref="T:System.Object" /> on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <returns>An <see cref="T:System.Object" /> representing the return value of the invoked member.</returns>
		// Token: 0x06005D7C RID: 23932
		object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetConstructor(System.Reflection.BindingFlags,System.Reflection.Binder,System.Reflection.CallingConventions,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The <see cref="T:System.Reflection.CallingConventions" /> object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and the stack is cleaned up.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the constructor to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object representing the constructor that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D7D RID: 23933
		ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetConstructor(System.Reflection.BindingFlags,System.Reflection.Binder,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the constructor to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.  
		///  -or-  
		///  <see cref="F:System.Type.EmptyTypes" />.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the parameter type array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object representing the constructor that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D7E RID: 23934
		ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetConstructor(System.Type[])" /> method.</summary>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the desired constructor.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects, to get a constructor that takes no parameters. Such an empty array is provided by the <see langword="static" /> field <see cref="F:System.Type.EmptyTypes" />.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object representing the public instance constructor whose parameters match the types in the parameter type array, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D7F RID: 23935
		ConstructorInfo GetConstructor(Type[] types);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetConstructors" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing all the public instance constructors defined for the current <see cref="T:System.Type" />, but not including the type initializer (static constructor). If no public instance constructors are defined for the current <see cref="T:System.Type" />, or if the current <see cref="T:System.Type" /> represents a type parameter of a generic type or method definition, an empty array of type <see cref="T:System.Reflection.ConstructorInfo" /> is returned.</returns>
		// Token: 0x06005D80 RID: 23936
		ConstructorInfo[] GetConstructors();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.TypeInitializer" /> property.</summary>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> containing the name of the class constructor for the <see cref="T:System.Type" />.</returns>
		// Token: 0x17001029 RID: 4137
		// (get) Token: 0x06005D81 RID: 23937
		ConstructorInfo TypeInitializer { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Reflection.CallingConventions,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  <see langword="null" />, to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The <see cref="T:System.Reflection.CallingConventions" /> object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and how the stack is cleaned up.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D82 RID: 23938
		MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public method to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the public method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D83 RID: 23939
		MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String,System.Type[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public method to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a method that takes no parameters.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the public method whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D84 RID: 23940
		MethodInfo GetMethod(string name, Type[] types);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethod(System.String)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public method to get.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the public method with the specified name, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D85 RID: 23941
		MethodInfo GetMethod(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMethods" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects representing all the public methods defined for the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MethodInfo" />, if no public methods are defined for the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D86 RID: 23942
		MethodInfo[] GetMethods();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetField(System.String)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the data field to get.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the public field with the specified name, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D87 RID: 23943
		FieldInfo GetField(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetFields" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.FieldInfo" /> objects representing all the public fields defined for the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.FieldInfo" />, if no public fields are defined for the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D88 RID: 23944
		FieldInfo[] GetFields();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetInterface(System.String)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the interface to get. For generic interfaces, this is the mangled name.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the interface with the specified name, implemented or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D89 RID: 23945
		Type GetInterface(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetEvent(System.String)" /> method.</summary>
		/// <param name="name">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing all events that are declared or inherited by the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.EventInfo" />, if the current <see cref="T:System.Type" /> does not have events, or if none of the events match the binding constraints.</returns>
		// Token: 0x06005D8A RID: 23946
		EventInfo GetEvent(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Type,System.Type[],System.Reflection.ParameterModifier[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the public property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D8B RID: 23947
		PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Type,System.Type[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the public property whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D8C RID: 23948
		PropertyInfo GetProperty(string name, Type returnType, Type[] types);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Type[])" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public property to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the public property whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D8D RID: 23949
		PropertyInfo GetProperty(string name, Type[] types);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String,System.Type)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the public property with the specified name, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D8E RID: 23950
		PropertyInfo GetProperty(string name, Type returnType);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperty(System.String)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public property to get.</param>
		/// <returns>A <see cref="T:System.Reflection.PropertyInfo" /> object representing the public property with the specified name, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D8F RID: 23951
		PropertyInfo GetProperty(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetProperties" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.PropertyInfo" /> objects representing all public properties of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.PropertyInfo" />, if the current <see cref="T:System.Type" /> does not have public properties.</returns>
		// Token: 0x06005D90 RID: 23952
		PropertyInfo[] GetProperties();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetNestedTypes" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the types nested within the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Type" />, if no types are nested within the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06005D91 RID: 23953
		Type[] GetNestedTypes();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetNestedType(System.String)" /> method.</summary>
		/// <param name="name">The string containing the name of the nested type to get.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the public nested type with the specified name, if found; otherwise, <see langword="null" />.</returns>
		// Token: 0x06005D92 RID: 23954
		Type GetNestedType(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMember(System.String)" /> method.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the public members to get.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		// Token: 0x06005D93 RID: 23955
		MemberInfo[] GetMember(string name);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetMembers" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all the public members of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have public members.</returns>
		// Token: 0x06005D94 RID: 23956
		MemberInfo[] GetMembers();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.Attributes" /> property.</summary>
		/// <returns>A <see cref="T:System.Reflection.TypeAttributes" /> object representing the attribute set of the <see cref="T:System.Type" />, unless the <see cref="T:System.Type" /> represents a generic type parameter, in which case the value is unspecified.</returns>
		// Token: 0x1700102A RID: 4138
		// (get) Token: 0x06005D95 RID: 23957
		TypeAttributes Attributes { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNotPublic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the top-level <see cref="T:System.Type" /> is not declared public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700102B RID: 4139
		// (get) Token: 0x06005D96 RID: 23958
		bool IsNotPublic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsPublic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the top-level <see cref="T:System.Type" /> is declared public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700102C RID: 4140
		// (get) Token: 0x06005D97 RID: 23959
		bool IsPublic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedPublic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the class is nested and declared public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700102D RID: 4141
		// (get) Token: 0x06005D98 RID: 23960
		bool IsNestedPublic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedPrivate" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and declared private; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700102E RID: 4142
		// (get) Token: 0x06005D99 RID: 23961
		bool IsNestedPrivate { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedFamily" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only within its own family; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700102F RID: 4143
		// (get) Token: 0x06005D9A RID: 23962
		bool IsNestedFamily { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only within its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001030 RID: 4144
		// (get) Token: 0x06005D9B RID: 23963
		bool IsNestedAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedFamANDAssem" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only to classes that belong to both its own family and its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001031 RID: 4145
		// (get) Token: 0x06005D9C RID: 23964
		bool IsNestedFamANDAssem { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsNestedFamORAssem" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only to classes that belong to its own family or to its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001032 RID: 4146
		// (get) Token: 0x06005D9D RID: 23965
		bool IsNestedFamORAssem { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsAutoLayout" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the class layout attribute <see langword="AutoLayout" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001033 RID: 4147
		// (get) Token: 0x06005D9E RID: 23966
		bool IsAutoLayout { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsLayoutSequential" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the class layout attribute <see langword="SequentialLayout" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001034 RID: 4148
		// (get) Token: 0x06005D9F RID: 23967
		bool IsLayoutSequential { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsExplicitLayout" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the class layout attribute <see langword="ExplicitLayout" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001035 RID: 4149
		// (get) Token: 0x06005DA0 RID: 23968
		bool IsExplicitLayout { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsClass" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a class; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001036 RID: 4150
		// (get) Token: 0x06005DA1 RID: 23969
		bool IsClass { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsInterface" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an interface; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001037 RID: 4151
		// (get) Token: 0x06005DA2 RID: 23970
		bool IsInterface { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsValueType" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a value type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001038 RID: 4152
		// (get) Token: 0x06005DA3 RID: 23971
		bool IsValueType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsAbstract" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is abstract; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001039 RID: 4153
		// (get) Token: 0x06005DA4 RID: 23972
		bool IsAbstract { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsSealed" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is declared sealed; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103A RID: 4154
		// (get) Token: 0x06005DA5 RID: 23973
		bool IsSealed { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsEnum" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Type" /> represents an enumeration; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103B RID: 4155
		// (get) Token: 0x06005DA6 RID: 23974
		bool IsEnum { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsSpecialName" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> has a name that requires special handling; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103C RID: 4156
		// (get) Token: 0x06005DA7 RID: 23975
		bool IsSpecialName { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsImport" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> has <see cref="T:System.Runtime.InteropServices.ComImportAttribute" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103D RID: 4157
		// (get) Token: 0x06005DA8 RID: 23976
		bool IsImport { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsSerializable" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is serializable; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103E RID: 4158
		// (get) Token: 0x06005DA9 RID: 23977
		bool IsSerializable { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsAnsiClass" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="AnsiClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700103F RID: 4159
		// (get) Token: 0x06005DAA RID: 23978
		bool IsAnsiClass { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsUnicodeClass" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="UnicodeClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001040 RID: 4160
		// (get) Token: 0x06005DAB RID: 23979
		bool IsUnicodeClass { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsAutoClass" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="AutoClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001041 RID: 4161
		// (get) Token: 0x06005DAC RID: 23980
		bool IsAutoClass { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsArray" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an array; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001042 RID: 4162
		// (get) Token: 0x06005DAD RID: 23981
		bool IsArray { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsByRef" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001043 RID: 4163
		// (get) Token: 0x06005DAE RID: 23982
		bool IsByRef { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsPointer" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a pointer; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001044 RID: 4164
		// (get) Token: 0x06005DAF RID: 23983
		bool IsPointer { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsPrimitive" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is one of the primitive types; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001045 RID: 4165
		// (get) Token: 0x06005DB0 RID: 23984
		bool IsPrimitive { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsCOMObject" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a COM object; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001046 RID: 4166
		// (get) Token: 0x06005DB1 RID: 23985
		bool IsCOMObject { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.HasElementType" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an array, a pointer, or is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001047 RID: 4167
		// (get) Token: 0x06005DB2 RID: 23986
		bool HasElementType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsContextful" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> can be hosted in a context; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001048 RID: 4168
		// (get) Token: 0x06005DB3 RID: 23987
		bool IsContextful { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Type.IsMarshalByRef" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is marshaled by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001049 RID: 4169
		// (get) Token: 0x06005DB4 RID: 23988
		bool IsMarshalByRef { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.Equals(System.Type)" /> method.</summary>
		/// <param name="o">The <see cref="T:System.Type" /> whose underlying system type is to be compared with the underlying system type of the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the underlying system type of <paramref name="o" /> is the same as the underlying system type of the current <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005DB5 RID: 23989
		bool Equals(Type o);
	}
}
