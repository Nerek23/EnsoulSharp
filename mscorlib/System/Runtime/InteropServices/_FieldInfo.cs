﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	/// <summary>Exposes the public members of the <see cref="T:System.Reflection.FieldInfo" /> class to unmanaged code.</summary>
	// Token: 0x020008DB RID: 2267
	[Guid("8A7C1442-A9FB-366B-80D8-4939FFA6DBE0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(FieldInfo))]
	[ComVisible(true)]
	public interface _FieldInfo
	{
		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		// Token: 0x06005E5F RID: 24159
		void GetTypeInfoCount(out uint pcTInfo);

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		// Token: 0x06005E60 RID: 24160
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array that receives the IDs corresponding to the names.</param>
		// Token: 0x06005E61 RID: 24161
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
		// Token: 0x06005E62 RID: 24162
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.ToString" /> method.</summary>
		/// <returns>A string that represents the current <see cref="T:System.Object" />.</returns>
		// Token: 0x06005E63 RID: 24163
		string ToString();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.Equals(System.Object)" /> method.</summary>
		/// <param name="other">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005E64 RID: 24164
		bool Equals(object other);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetHashCode" /> method.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06005E65 RID: 24165
		int GetHashCode();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetType" /> method.</summary>
		/// <returns>A <see cref="T:System.Type" /> object.</returns>
		// Token: 0x06005E66 RID: 24166
		Type GetType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.MemberType" /> property.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a field.</returns>
		// Token: 0x17001093 RID: 4243
		// (get) Token: 0x06005E67 RID: 24167
		MemberTypes MemberType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.Name" /> property.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the name of this member.</returns>
		// Token: 0x17001094 RID: 4244
		// (get) Token: 0x06005E68 RID: 24168
		string Name { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.DeclaringType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> object for the class that declares this member.</returns>
		// Token: 0x17001095 RID: 4245
		// (get) Token: 0x06005E69 RID: 24169
		Type DeclaringType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.ReflectedType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> object through which this object was obtained.</returns>
		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x06005E6A RID: 24170
		Type ReflectedType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
		// Token: 0x06005E6B RID: 24171
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)" /> method.</summary>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
		// Token: 0x06005E6C RID: 24172
		object[] GetCustomAttributes(bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The <see cref="T:System.Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of <paramref name="attributeType" /> is applied to this member; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005E6D RID: 24173
		bool IsDefined(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.FieldType" /> property.</summary>
		/// <returns>The type of this field object.</returns>
		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x06005E6E RID: 24174
		Type FieldType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.FieldInfo.GetValue(System.Object)" /> method.</summary>
		/// <param name="obj">The object whose field value will be returned.</param>
		/// <returns>An object containing the value of the field reflected by this instance.</returns>
		// Token: 0x06005E6F RID: 24175
		object GetValue(object obj);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.FieldInfo.GetValueDirect(System.TypedReference)" /> method.</summary>
		/// <param name="obj">A <see cref="T:System.TypedReference" /> structure that encapsulates a managed pointer to a location and a runtime representation of the type that might be stored at that location.</param>
		/// <returns>An <see cref="T:System.Object" /> containing a field value.</returns>
		// Token: 0x06005E70 RID: 24176
		object GetValueDirect(TypedReference obj);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.SetValue(System.Object,System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="obj">The object whose field value will be set.</param>
		/// <param name="value">The value to assign to the field.</param>
		/// <param name="invokeAttr">A field of <see cref="T:System.Reflection.Binder" /> that specifies the type of binding that is desired (for example, <see langword="Binder.CreateInstance" /> or <see langword="Binder.ExactBinding" />).</param>
		/// <param name="binder">A set of properties that enables the binding, coercion of argument types, and invocation of members through reflection. If <paramref name="binder" /> is <see langword="null" />, then <see langword="Binder.DefaultBinding" /> is used.</param>
		/// <param name="culture">The software preferences of a particular culture.</param>
		// Token: 0x06005E71 RID: 24177
		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.FieldInfo.SetValueDirect(System.TypedReference,System.Object)" /> method.</summary>
		/// <param name="obj">The object whose field value will be set.</param>
		/// <param name="value">The value to assign to the field.</param>
		// Token: 0x06005E72 RID: 24178
		void SetValueDirect(TypedReference obj, object value);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.FieldHandle" /> property.</summary>
		/// <returns>A handle to the internal metadata representation of a field.</returns>
		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x06005E73 RID: 24179
		RuntimeFieldHandle FieldHandle { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.Attributes" /> property.</summary>
		/// <returns>The <see cref="T:System.Reflection.FieldAttributes" /> for this field.</returns>
		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x06005E74 RID: 24180
		FieldAttributes Attributes { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.FieldInfo.SetValue(System.Object,System.Object)" /> method.</summary>
		/// <param name="obj">The object whose field value will be set.</param>
		/// <param name="value">The value to assign to the field.</param>
		// Token: 0x06005E75 RID: 24181
		void SetValue(object obj, object value);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsPublic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this field is public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06005E76 RID: 24182
		bool IsPublic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsPrivate" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field is private; otherwise; <see langword="false" />.</returns>
		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06005E77 RID: 24183
		bool IsPrivate { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsFamily" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="Family" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06005E78 RID: 24184
		bool IsFamily { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="Assembly" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06005E79 RID: 24185
		bool IsAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsFamilyAndAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="FamANDAssem" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x06005E7A RID: 24186
		bool IsFamilyAndAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsFamilyOrAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="FamORAssem" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x06005E7B RID: 24187
		bool IsFamilyOrAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsStatic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this field is static; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06005E7C RID: 24188
		bool IsStatic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsInitOnly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="InitOnly" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06005E7D RID: 24189
		bool IsInitOnly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsLiteral" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="Literal" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06005E7E RID: 24190
		bool IsLiteral { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsNotSerialized" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="NotSerialized" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x06005E7F RID: 24191
		bool IsNotSerialized { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsSpecialName" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see langword="SpecialName" /> attribute is set in <see cref="T:System.Reflection.FieldAttributes" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x06005E80 RID: 24192
		bool IsSpecialName { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.FieldInfo.IsPinvokeImpl" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see langword="PinvokeImpl" /> attribute is set in <see cref="T:System.Reflection.FieldAttributes" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x06005E81 RID: 24193
		bool IsPinvokeImpl { get; }
	}
}
