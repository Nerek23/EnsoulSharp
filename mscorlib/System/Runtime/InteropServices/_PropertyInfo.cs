﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	/// <summary>Exposes the public members of the <see cref="T:System.Reflection.PropertyInfo" /> class to unmanaged code.</summary>
	// Token: 0x020008DC RID: 2268
	[Guid("F59ED4E4-E68F-3218-BD77-061AA82824BF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(PropertyInfo))]
	[ComVisible(true)]
	public interface _PropertyInfo
	{
		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">When this method returns, contains a pointer to a location that receives the number of type information interfaces provided by the object. This parameter is passed uninitialized.</param>
		// Token: 0x06005E82 RID: 24194
		void GetTypeInfoCount(out uint pcTInfo);

		/// <summary>Retrieves the type information for an object, which can be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">A pointer to the requested type information object.</param>
		// Token: 0x06005E83 RID: 24195
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">An array of names to be mapped.</param>
		/// <param name="cNames">The count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">An array allocated by the caller that receives the identifiers corresponding to the names.</param>
		// Token: 0x06005E84 RID: 24196
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">An identifier of a member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">A pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">A pointer to the location where the result will be stored.</param>
		/// <param name="pExcepInfo">A pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		// Token: 0x06005E85 RID: 24197
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.ToString" /> method.</summary>
		/// <returns>A string that represents the current <see cref="T:System.Object" />.</returns>
		// Token: 0x06005E86 RID: 24198
		string ToString();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.Equals(System.Object)" /> method.</summary>
		/// <param name="other">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005E87 RID: 24199
		bool Equals(object other);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetHashCode" /> method.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06005E88 RID: 24200
		int GetHashCode();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetType" /> method.</summary>
		/// <returns>A <see cref="T:System.Type" /> object.</returns>
		// Token: 0x06005E89 RID: 24201
		Type GetType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.MemberType" /> property.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.MemberTypes" /> values indicating that this member is a property.</returns>
		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x06005E8A RID: 24202
		MemberTypes MemberType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.Name" /> property.</summary>
		/// <returns>A <see cref="T:System.String" /> object containing the name of this member.</returns>
		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x06005E8B RID: 24203
		string Name { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.DeclaringType" /> property.</summary>
		/// <returns>The <see langword="Type" /> object for the class that declares this member.</returns>
		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x06005E8C RID: 24204
		Type DeclaringType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.ReflectedType" /> property.</summary>
		/// <returns>The <see cref="T:System.Type" /> object through which this <see cref="T:System.Reflection.MemberInfo" /> object was obtained.</returns>
		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x06005E8D RID: 24205
		Type ReflectedType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
		// Token: 0x06005E8E RID: 24206
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)" /> method.</summary>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
		// Token: 0x06005E8F RID: 24207
		object[] GetCustomAttributes(bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The <see cref="T:System.Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of the <paramref name="attributeType" /> parameter are applied to this member; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005E90 RID: 24208
		bool IsDefined(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.PropertyType" /> property.</summary>
		/// <returns>The type of this property.</returns>
		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06005E91 RID: 24209
		Type PropertyType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetValue(System.Object,System.Object[])" /> method.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <returns>The property value for the <paramref name="obj" /> parameter.</returns>
		// Token: 0x06005E92 RID: 24210
		object GetValue(object obj, object[] index);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetValue(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see langword="BindingFlags" />: <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="Static" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />. A suitable invocation attribute must be specified. If a static member will be invoked, the <see langword="Static" /> flag of <see langword="BindingFlags" /> must be set.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects through reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <param name="culture">The <see langword="CultureInfo" /> object that represents the culture for which the resource will be localized. Note that if the resource is not localized for this culture, the <see langword="CultureInfo.Parent" /> method will be called successively in search of a match. If this value is <see langword="null" />, the <see langword="CultureInfo" /> is obtained from the <see langword="CultureInfo.CurrentUICulture" /> property.</param>
		/// <returns>The property value for the <paramref name="obj" /> parameter.</returns>
		// Token: 0x06005E93 RID: 24211
		object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.SetValue(System.Object,System.Object,System.Object[])" /> method.</summary>
		/// <param name="obj">The object whose property value will be set.</param>
		/// <param name="value">The new value for this property.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		// Token: 0x06005E94 RID: 24212
		void SetValue(object obj, object value, object[] index);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.FieldInfo.SetValue(System.Object,System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="value">The new value for this property.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />: <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="Static" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />. A suitable invocation attribute must be specified. If a static member will be invoked, the <see langword="Static" /> flag of <see langword="BindingFlags" /> must be set.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see cref="T:System.Reflection.MemberInfo" /> objects through reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> object that represents the culture for which the resource will be localized. Note that if the resource is not localized for this culture, the <see langword="CultureInfo.Parent" /> method will be called successively in search of a match. If this value is <see langword="null" />, the <see langword="CultureInfo" /> is obtained from the <see langword="CultureInfo.CurrentUICulture" /> property.</param>
		// Token: 0x06005E95 RID: 24213
		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetAccessors(System.Boolean)" /> method.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> to include non-public methods in the returned <see langword="MethodInfo" /> array; otherwise, <see langword="false" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects whose elements reflect the <see langword="get" />, <see langword="set" />, and other accessors of the property reflected by the current instance. If the <paramref name="nonPublic" /> parameter is <see langword="true" />, this array contains public and non-public <see langword="get" />, <see langword="set" />, and other accessors. If <paramref name="nonPublic" /> is <see langword="false" />, this array contains only public <see langword="get" />, <see langword="set" />, and other accessors. If no accessors with the specified visibility are found, this method returns an array with zero (0) elements.</returns>
		// Token: 0x06005E96 RID: 24214
		MethodInfo[] GetAccessors(bool nonPublic);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetGetMethod(System.Boolean)" /> method.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> to return a non-public <see langword="get" /> accessor; otherwise, <see langword="false" />.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the <see langword="get" /> accessor for this property, if the <paramref name="nonPublic" /> parameter is <see langword="true" />. Or <see langword="null" /> if <paramref name="nonPublic" /> is <see langword="false" /> and the <see langword="get" /> accessor is non-public, or if <paramref name="nonPublic" /> is <see langword="true" /> but no <see langword="get" /> accessors exist.</returns>
		// Token: 0x06005E97 RID: 24215
		MethodInfo GetGetMethod(bool nonPublic);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetSetMethod(System.Boolean)" /> method.</summary>
		/// <param name="nonPublic">
		///   <see langword="true" /> to return a non-public accessor; otherwise, <see langword="false" />.</param>
		/// <returns>One of the values in the following table.  
		///   Value  
		///
		///   Meaning  
		///
		///   A <see cref="T:System.Reflection.MethodInfo" /> object representing the <see langword="Set" /> method for this property.  
		///
		///   The <see langword="set" /> accessor is public.  
		///
		///  -or-  
		///
		///  The <paramref name="nonPublic" /> parameter is <see langword="true" /> and the <see langword="set" /> accessor is non-public.  
		///
		///  <see langword="null" /> The <paramref name="nonPublic" /> parameter is <see langword="true" />, but the property is read-only.  
		///
		///  -or-  
		///
		///  The <paramref name="nonPublic" /> parameter is <see langword="false" /> and the <see langword="set" /> accessor is non-public.  
		///
		///  -or-  
		///
		///  There is no <see langword="set" /> accessor.</returns>
		// Token: 0x06005E98 RID: 24216
		MethodInfo GetSetMethod(bool nonPublic);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetIndexParameters" /> method.</summary>
		/// <returns>An array of type <see cref="T:System.Reflection.ParameterInfo" /> containing the parameters for the indexes.</returns>
		// Token: 0x06005E99 RID: 24217
		ParameterInfo[] GetIndexParameters();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.Attributes" /> property.</summary>
		/// <returns>The attributes of this property.</returns>
		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06005E9A RID: 24218
		PropertyAttributes Attributes { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.CanRead" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this property can be read; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06005E9B RID: 24219
		bool CanRead { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.CanWrite" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this property can be written to; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x06005E9C RID: 24220
		bool CanWrite { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetAccessors" /> method.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects that reflect the public <see langword="get" />, <see langword="set" />, and other accessors of the property reflected by the current instance, if accessors are found; otherwise, this method returns an array with zero (0) elements.</returns>
		// Token: 0x06005E9D RID: 24221
		MethodInfo[] GetAccessors();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetGetMethod" /> method.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing the public <see langword="get" /> accessor for this property, or <see langword="null" /> if the <see langword="get" /> accessor is non-public or does not exist.</returns>
		// Token: 0x06005E9E RID: 24222
		MethodInfo GetGetMethod();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.PropertyInfo.GetSetMethod" /> method.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodInfo" /> object representing the <see langword="Set" /> method for this property if the <see langword="set" /> accessor is public, or <see langword="null" /> if the <see langword="set" /> accessor is not public.</returns>
		// Token: 0x06005E9F RID: 24223
		MethodInfo GetSetMethod();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.PropertyInfo.IsSpecialName" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this property is the special name; otherwise, <see langword="false" />.</returns>
		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x06005EA0 RID: 24224
		bool IsSpecialName { get; }
	}
}
