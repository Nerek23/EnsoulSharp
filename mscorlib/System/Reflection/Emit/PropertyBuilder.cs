using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Defines the properties for a type.</summary>
	// Token: 0x02000630 RID: 1584
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_PropertyBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class PropertyBuilder : PropertyInfo, _PropertyBuilder
	{
		// Token: 0x06004BB1 RID: 19377 RVA: 0x00112575 File Offset: 0x00110775
		private PropertyBuilder()
		{
		}

		// Token: 0x06004BB2 RID: 19378 RVA: 0x00112580 File Offset: 0x00110780
		internal PropertyBuilder(ModuleBuilder mod, string name, SignatureHelper sig, PropertyAttributes attr, Type returnType, PropertyToken prToken, TypeBuilder containingType)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (name[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "name");
			}
			this.m_name = name;
			this.m_moduleBuilder = mod;
			this.m_signature = sig;
			this.m_attributes = attr;
			this.m_returnType = returnType;
			this.m_prToken = prToken;
			this.m_tkProperty = prToken.Token;
			this.m_containingType = containingType;
		}

		/// <summary>Sets the default value of this property.</summary>
		/// <param name="defaultValue">The default value of this property.</param>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		/// <exception cref="T:System.ArgumentException">The property is not one of the supported types.  
		///  -or-  
		///  The type of <paramref name="defaultValue" /> does not match the type of the property.  
		///  -or-  
		///  The property is of type <see cref="T:System.Object" /> or other reference type, <paramref name="defaultValue" /> is not <see langword="null" />, and the value cannot be assigned to the reference type.</exception>
		// Token: 0x06004BB3 RID: 19379 RVA: 0x0011261E File Offset: 0x0011081E
		[SecuritySafeCritical]
		public void SetConstant(object defaultValue)
		{
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.SetConstantValue(this.m_moduleBuilder, this.m_prToken.Token, this.m_returnType, defaultValue);
		}

		/// <summary>Retrieves the token for this property.</summary>
		/// <returns>Read-only. Retrieves the token for this property.</returns>
		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x06004BB4 RID: 19380 RVA: 0x00112648 File Offset: 0x00110848
		public PropertyToken PropertyToken
		{
			get
			{
				return this.m_prToken;
			}
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x06004BB5 RID: 19381 RVA: 0x00112650 File Offset: 0x00110850
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_tkProperty;
			}
		}

		/// <summary>Gets the module in which the type that declares the current property is being defined.</summary>
		/// <returns>The <see cref="T:System.Reflection.Module" /> in which the type that declares the current property is defined.</returns>
		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x06004BB6 RID: 19382 RVA: 0x00112658 File Offset: 0x00110858
		public override Module Module
		{
			get
			{
				return this.m_containingType.Module;
			}
		}

		// Token: 0x06004BB7 RID: 19383 RVA: 0x00112668 File Offset: 0x00110868
		[SecurityCritical]
		private void SetMethodSemantics(MethodBuilder mdBuilder, MethodSemanticsAttributes semantics)
		{
			if (mdBuilder == null)
			{
				throw new ArgumentNullException("mdBuilder");
			}
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.DefineMethodSemantics(this.m_moduleBuilder.GetNativeHandle(), this.m_prToken.Token, semantics, mdBuilder.GetToken().Token);
		}

		/// <summary>Sets the method that gets the property value.</summary>
		/// <param name="mdBuilder">A <see langword="MethodBuilder" /> object that represents the method that gets the property value.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="mdBuilder" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		// Token: 0x06004BB8 RID: 19384 RVA: 0x001126BE File Offset: 0x001108BE
		[SecuritySafeCritical]
		public void SetGetMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Getter);
			this.m_getMethod = mdBuilder;
		}

		/// <summary>Sets the method that sets the property value.</summary>
		/// <param name="mdBuilder">A <see langword="MethodBuilder" /> object that represents the method that sets the property value.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="mdBuilder" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		// Token: 0x06004BB9 RID: 19385 RVA: 0x001126CF File Offset: 0x001108CF
		[SecuritySafeCritical]
		public void SetSetMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Setter);
			this.m_setMethod = mdBuilder;
		}

		/// <summary>Adds one of the other methods associated with this property.</summary>
		/// <param name="mdBuilder">A <see langword="MethodBuilder" /> object that represents the other method.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="mdBuilder" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		// Token: 0x06004BBA RID: 19386 RVA: 0x001126E0 File Offset: 0x001108E0
		[SecuritySafeCritical]
		public void AddOtherMethod(MethodBuilder mdBuilder)
		{
			this.SetMethodSemantics(mdBuilder, MethodSemanticsAttributes.Other);
		}

		/// <summary>Set a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		// Token: 0x06004BBB RID: 19387 RVA: 0x001126EC File Offset: 0x001108EC
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			this.m_containingType.ThrowIfCreated();
			TypeBuilder.DefineCustomAttribute(this.m_moduleBuilder, this.m_prToken.Token, this.m_moduleBuilder.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		/// <summary>Set a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="customBuilder" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">if <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been called on the enclosing type.</exception>
		// Token: 0x06004BBC RID: 19388 RVA: 0x00112753 File Offset: 0x00110953
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			this.m_containingType.ThrowIfCreated();
			customBuilder.CreateCustomAttribute(this.m_moduleBuilder, this.m_prToken.Token);
		}

		/// <summary>Gets the value of the indexed property by calling the property's getter method.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <returns>The value of the specified indexed property.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BBD RID: 19389 RVA: 0x00112785 File Offset: 0x00110985
		public override object GetValue(object obj, object[] index)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Gets the value of a property having the specified binding, index, and <see langword="CultureInfo" />.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see langword="BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="Static" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />. A suitable invocation attribute must be specified. If a static member is to be invoked, the <see langword="Static" /> flag of <see langword="BindingFlags" /> must be set.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects using reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <param name="culture">The <see langword="CultureInfo" /> object that represents the culture for which the resource is to be localized. Note that if the resource is not localized for this culture, the <see langword="CultureInfo.Parent" /> method will be called successively in search of a match. If this value is <see langword="null" />, the <see langword="CultureInfo" /> is obtained from the <see langword="CultureInfo.CurrentUICulture" /> property.</param>
		/// <returns>The property value for <paramref name="obj" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BBE RID: 19390 RVA: 0x00112796 File Offset: 0x00110996
		public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Sets the value of the property with optional index values for index properties.</summary>
		/// <param name="obj">The object whose property value will be set.</param>
		/// <param name="value">The new value for this property.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BBF RID: 19391 RVA: 0x001127A7 File Offset: 0x001109A7
		public override void SetValue(object obj, object value, object[] index)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Sets the property value for the given object to the given value.</summary>
		/// <param name="obj">The object whose property value will be returned.</param>
		/// <param name="value">The new value for this property.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see langword="BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="Static" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />. A suitable invocation attribute must be specified. If a static member is to be invoked, the <see langword="Static" /> flag of <see langword="BindingFlags" /> must be set.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects using reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="index">Optional index values for indexed properties. This value should be <see langword="null" /> for non-indexed properties.</param>
		/// <param name="culture">The <see langword="CultureInfo" /> object that represents the culture for which the resource is to be localized. Note that if the resource is not localized for this culture, the <see langword="CultureInfo.Parent" /> method will be called successively in search of a match. If this value is <see langword="null" />, the <see langword="CultureInfo" /> is obtained from the <see langword="CultureInfo.CurrentUICulture" /> property.</param>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BC0 RID: 19392 RVA: 0x001127B8 File Offset: 0x001109B8
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns an array of the public and non-public <see langword="get" /> and <see langword="set" /> accessors on this property.</summary>
		/// <param name="nonPublic">Indicates whether non-public methods should be returned in the <see langword="MethodInfo" /> array. <see langword="true" /> if non-public methods are to be included; otherwise, <see langword="false" />.</param>
		/// <returns>An array of type <see langword="MethodInfo" /> containing the matching public or non-public accessors, or an empty array if matching accessors do not exist on this property.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BC1 RID: 19393 RVA: 0x001127C9 File Offset: 0x001109C9
		public override MethodInfo[] GetAccessors(bool nonPublic)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns the public and non-public get accessor for this property.</summary>
		/// <param name="nonPublic">Indicates whether non-public get accessors should be returned. <see langword="true" /> if non-public methods are to be included; otherwise, <see langword="false" />.</param>
		/// <returns>A <see langword="MethodInfo" /> object representing the get accessor for this property, if <paramref name="nonPublic" /> is <see langword="true" />. Returns <see langword="null" /> if <paramref name="nonPublic" /> is <see langword="false" /> and the get accessor is non-public, or if <paramref name="nonPublic" /> is <see langword="true" /> but no get accessors exist.</returns>
		// Token: 0x06004BC2 RID: 19394 RVA: 0x001127DA File Offset: 0x001109DA
		public override MethodInfo GetGetMethod(bool nonPublic)
		{
			if (nonPublic || this.m_getMethod == null)
			{
				return this.m_getMethod;
			}
			if ((this.m_getMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public)
			{
				return this.m_getMethod;
			}
			return null;
		}

		/// <summary>Returns the set accessor for this property.</summary>
		/// <param name="nonPublic">Indicates whether the accessor should be returned if it is non-public. <see langword="true" /> if non-public methods are to be included; otherwise, <see langword="false" />.</param>
		/// <returns>The property's <see langword="Set" /> method, or <see langword="null" />, as shown in the following table.  
		///   Value  
		///
		///   Condition  
		///
		///   A <see cref="T:System.Reflection.MethodInfo" /> object representing the Set method for this property.  
		///
		///   The set accessor is public.  
		///
		///  <paramref name="nonPublic" /> is true and non-public methods can be returned.  
		///
		///   null  
		///
		///  <paramref name="nonPublic" /> is true, but the property is read-only.  
		///
		///  <paramref name="nonPublic" /> is false and the set accessor is non-public.</returns>
		// Token: 0x06004BC3 RID: 19395 RVA: 0x0011280C File Offset: 0x00110A0C
		public override MethodInfo GetSetMethod(bool nonPublic)
		{
			if (nonPublic || this.m_setMethod == null)
			{
				return this.m_setMethod;
			}
			if ((this.m_setMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public)
			{
				return this.m_setMethod;
			}
			return null;
		}

		/// <summary>Returns an array of all the index parameters for the property.</summary>
		/// <returns>An array of type <see langword="ParameterInfo" /> containing the parameters for the indexes.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BC4 RID: 19396 RVA: 0x0011283E File Offset: 0x00110A3E
		public override ParameterInfo[] GetIndexParameters()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Gets the type of the field of this property.</summary>
		/// <returns>The type of this property.</returns>
		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x06004BC5 RID: 19397 RVA: 0x0011284F File Offset: 0x00110A4F
		public override Type PropertyType
		{
			get
			{
				return this.m_returnType;
			}
		}

		/// <summary>Gets the attributes for this property.</summary>
		/// <returns>Attributes of this property.</returns>
		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x06004BC6 RID: 19398 RVA: 0x00112857 File Offset: 0x00110A57
		public override PropertyAttributes Attributes
		{
			get
			{
				return this.m_attributes;
			}
		}

		/// <summary>Gets a value indicating whether the property can be read.</summary>
		/// <returns>
		///   <see langword="true" /> if this property can be read; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x06004BC7 RID: 19399 RVA: 0x0011285F File Offset: 0x00110A5F
		public override bool CanRead
		{
			get
			{
				return this.m_getMethod != null;
			}
		}

		/// <summary>Gets a value indicating whether the property can be written to.</summary>
		/// <returns>
		///   <see langword="true" /> if this property can be written to; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x06004BC8 RID: 19400 RVA: 0x00112872 File Offset: 0x00110A72
		public override bool CanWrite
		{
			get
			{
				return this.m_setMethod != null;
			}
		}

		/// <summary>Returns an array of all the custom attributes for this property.</summary>
		/// <param name="inherit">If <see langword="true" />, walks up this property's inheritance chain to find the custom attributes</param>
		/// <returns>An array of all the custom attributes.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BC9 RID: 19401 RVA: 0x00112885 File Offset: 0x00110A85
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns an array of custom attributes identified by <see cref="T:System.Type" />.</summary>
		/// <param name="attributeType">An array of custom attributes identified by type.</param>
		/// <param name="inherit">If <see langword="true" />, walks up this property's inheritance chain to find the custom attributes.</param>
		/// <returns>An array of custom attributes defined on this reflected member, or <see langword="null" /> if no attributes are defined on this member.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BCA RID: 19402 RVA: 0x00112896 File Offset: 0x00110A96
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Indicates whether one or more instance of <paramref name="attributeType" /> is defined on this property.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">Specifies whether to walk up this property's inheritance chain to find the custom attributes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of <paramref name="attributeType" /> is defined on this property; otherwise <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004BCB RID: 19403 RVA: 0x001128A7 File Offset: 0x00110AA7
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BCC RID: 19404 RVA: 0x001128B8 File Offset: 0x00110AB8
		void _PropertyBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BCD RID: 19405 RVA: 0x001128BF File Offset: 0x00110ABF
		void _PropertyBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BCE RID: 19406 RVA: 0x001128C6 File Offset: 0x00110AC6
		void _PropertyBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004BCF RID: 19407 RVA: 0x001128CD File Offset: 0x00110ACD
		void _PropertyBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the name of this member.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the name of this member.</returns>
		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x06004BD0 RID: 19408 RVA: 0x001128D4 File Offset: 0x00110AD4
		public override string Name
		{
			get
			{
				return this.m_name;
			}
		}

		/// <summary>Gets the class that declares this member.</summary>
		/// <returns>The <see langword="Type" /> object for the class that declares this member.</returns>
		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x06004BD1 RID: 19409 RVA: 0x001128DC File Offset: 0x00110ADC
		public override Type DeclaringType
		{
			get
			{
				return this.m_containingType;
			}
		}

		/// <summary>Gets the class object that was used to obtain this instance of <see langword="MemberInfo" />.</summary>
		/// <returns>The <see langword="Type" /> object through which this <see langword="MemberInfo" /> object was obtained.</returns>
		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x06004BD2 RID: 19410 RVA: 0x001128E4 File Offset: 0x00110AE4
		public override Type ReflectedType
		{
			get
			{
				return this.m_containingType;
			}
		}

		// Token: 0x040020D6 RID: 8406
		private string m_name;

		// Token: 0x040020D7 RID: 8407
		private PropertyToken m_prToken;

		// Token: 0x040020D8 RID: 8408
		private int m_tkProperty;

		// Token: 0x040020D9 RID: 8409
		private ModuleBuilder m_moduleBuilder;

		// Token: 0x040020DA RID: 8410
		private SignatureHelper m_signature;

		// Token: 0x040020DB RID: 8411
		private PropertyAttributes m_attributes;

		// Token: 0x040020DC RID: 8412
		private Type m_returnType;

		// Token: 0x040020DD RID: 8413
		private MethodInfo m_getMethod;

		// Token: 0x040020DE RID: 8414
		private MethodInfo m_setMethod;

		// Token: 0x040020DF RID: 8415
		private TypeBuilder m_containingType;
	}
}
