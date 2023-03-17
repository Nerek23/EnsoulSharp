using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Describes and represents an enumeration type.</summary>
	// Token: 0x02000639 RID: 1593
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_EnumBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class EnumBuilder : TypeInfo, _EnumBuilder
	{
		/// <summary>Gets a value that indicates whether a specified <see cref="T:System.Reflection.TypeInfo" /> object can be assigned to this object.</summary>
		/// <param name="typeInfo">The object to test.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="typeInfo" /> can be assigned to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004D56 RID: 19798 RVA: 0x00116DB4 File Offset: 0x00114FB4
		public override bool IsAssignableFrom(TypeInfo typeInfo)
		{
			return !(typeInfo == null) && this.IsAssignableFrom(typeInfo.AsType());
		}

		/// <summary>Defines the named static field in an enumeration type with the specified constant value.</summary>
		/// <param name="literalName">The name of the static field.</param>
		/// <param name="literalValue">The constant value of the literal.</param>
		/// <returns>The defined field.</returns>
		// Token: 0x06004D57 RID: 19799 RVA: 0x00116DD0 File Offset: 0x00114FD0
		public FieldBuilder DefineLiteral(string literalName, object literalValue)
		{
			FieldBuilder fieldBuilder = this.m_typeBuilder.DefineField(literalName, this, FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static | FieldAttributes.Literal);
			fieldBuilder.SetConstant(literalValue);
			return fieldBuilder;
		}

		/// <summary>Gets a <see cref="T:System.Reflection.TypeInfo" /> object that represents this enumeration.</summary>
		/// <returns>An object that represents this enumeration.</returns>
		// Token: 0x06004D58 RID: 19800 RVA: 0x00116DF5 File Offset: 0x00114FF5
		public TypeInfo CreateTypeInfo()
		{
			return this.m_typeBuilder.CreateTypeInfo();
		}

		/// <summary>Creates a <see cref="T:System.Type" /> object for this enum.</summary>
		/// <returns>A <see cref="T:System.Type" /> object for this enum.</returns>
		/// <exception cref="T:System.InvalidOperationException">This type has been previously created.  
		///  -or-  
		///  The enclosing type has not been created.</exception>
		// Token: 0x06004D59 RID: 19801 RVA: 0x00116E02 File Offset: 0x00115002
		public Type CreateType()
		{
			return this.m_typeBuilder.CreateType();
		}

		/// <summary>Returns the internal metadata type token of this enum.</summary>
		/// <returns>Read-only. The type token of this enum.</returns>
		// Token: 0x17000C45 RID: 3141
		// (get) Token: 0x06004D5A RID: 19802 RVA: 0x00116E0F File Offset: 0x0011500F
		public TypeToken TypeToken
		{
			get
			{
				return this.m_typeBuilder.TypeToken;
			}
		}

		/// <summary>Returns the underlying field for this enum.</summary>
		/// <returns>Read-only. The underlying field for this enum.</returns>
		// Token: 0x17000C46 RID: 3142
		// (get) Token: 0x06004D5B RID: 19803 RVA: 0x00116E1C File Offset: 0x0011501C
		public FieldBuilder UnderlyingField
		{
			get
			{
				return this.m_underlyingField;
			}
		}

		/// <summary>Returns the name of this enum.</summary>
		/// <returns>Read-only. The name of this enum.</returns>
		// Token: 0x17000C47 RID: 3143
		// (get) Token: 0x06004D5C RID: 19804 RVA: 0x00116E24 File Offset: 0x00115024
		public override string Name
		{
			get
			{
				return this.m_typeBuilder.Name;
			}
		}

		/// <summary>Returns the GUID of this enum.</summary>
		/// <returns>Read-only. The GUID of this enum.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x17000C48 RID: 3144
		// (get) Token: 0x06004D5D RID: 19805 RVA: 0x00116E31 File Offset: 0x00115031
		public override Guid GUID
		{
			get
			{
				return this.m_typeBuilder.GUID;
			}
		}

		/// <summary>Invokes the specified member. The method that is to be invoked must be accessible and provide the most specific match with the specified argument list, under the contraints of the specified binder and invocation attributes.</summary>
		/// <param name="name">The name of the member to invoke. This can be a constructor, method, property, or field. A suitable invocation attribute must be specified. Note that it is possible to invoke the default member of a class by passing an empty string as the name of the member.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see langword="BindingFlags" />.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects using reflection. If binder is <see langword="null" />, the default binder is used. See <see cref="T:System.Reflection.Binder" />.</param>
		/// <param name="target">The object on which to invoke the specified member. If the member is static, this parameter is ignored.</param>
		/// <param name="args">An argument list. This is an array of objects that contains the number, order, and type of the parameters of the member to be invoked. If there are no parameters this should be null.</param>
		/// <param name="modifiers">An array of the same length as <paramref name="args" /> with elements that represent the attributes associated with the arguments of the member to be invoked. A parameter has attributes associated with it in the metadata. They are used by various interoperability services. See the metadata specs for details such as this.</param>
		/// <param name="culture">An instance of <see langword="CultureInfo" /> used to govern the coercion of types. If this is null, the <see langword="CultureInfo" /> for the current thread is used. (Note that this is necessary to, for example, convert a string that represents 1000 to a double value, since 1000 is represented differently by different cultures.)</param>
		/// <param name="namedParameters">Each parameter in the <paramref name="namedParameters" /> array gets the value in the corresponding element in the <paramref name="args" /> array. If the length of <paramref name="args" /> is greater than the length of <paramref name="namedParameters" />, the remaining argument values are passed in order.</param>
		/// <returns>Returns the return value of the invoked member.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D5E RID: 19806 RVA: 0x00116E40 File Offset: 0x00115040
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			return this.m_typeBuilder.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
		}

		/// <summary>Retrieves the dynamic module that contains this <see cref="T:System.Reflection.Emit.EnumBuilder" /> definition.</summary>
		/// <returns>Read-only. The dynamic module that contains this <see cref="T:System.Reflection.Emit.EnumBuilder" /> definition.</returns>
		// Token: 0x17000C49 RID: 3145
		// (get) Token: 0x06004D5F RID: 19807 RVA: 0x00116E65 File Offset: 0x00115065
		public override Module Module
		{
			get
			{
				return this.m_typeBuilder.Module;
			}
		}

		/// <summary>Retrieves the dynamic assembly that contains this enum definition.</summary>
		/// <returns>Read-only. The dynamic assembly that contains this enum definition.</returns>
		// Token: 0x17000C4A RID: 3146
		// (get) Token: 0x06004D60 RID: 19808 RVA: 0x00116E72 File Offset: 0x00115072
		public override Assembly Assembly
		{
			get
			{
				return this.m_typeBuilder.Assembly;
			}
		}

		/// <summary>Retrieves the internal handle for this enum.</summary>
		/// <returns>Read-only. The internal handle for this enum.</returns>
		/// <exception cref="T:System.NotSupportedException">This property is not currently supported.</exception>
		// Token: 0x17000C4B RID: 3147
		// (get) Token: 0x06004D61 RID: 19809 RVA: 0x00116E7F File Offset: 0x0011507F
		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				return this.m_typeBuilder.TypeHandle;
			}
		}

		/// <summary>Returns the full path of this enum.</summary>
		/// <returns>Read-only. The full path of this enum.</returns>
		// Token: 0x17000C4C RID: 3148
		// (get) Token: 0x06004D62 RID: 19810 RVA: 0x00116E8C File Offset: 0x0011508C
		public override string FullName
		{
			get
			{
				return this.m_typeBuilder.FullName;
			}
		}

		/// <summary>Returns the full path of this enum qualified by the display name of the parent assembly.</summary>
		/// <returns>Read-only. The full path of this enum qualified by the display name of the parent assembly.</returns>
		// Token: 0x17000C4D RID: 3149
		// (get) Token: 0x06004D63 RID: 19811 RVA: 0x00116E99 File Offset: 0x00115099
		public override string AssemblyQualifiedName
		{
			get
			{
				return this.m_typeBuilder.AssemblyQualifiedName;
			}
		}

		/// <summary>Returns the namespace of this enum.</summary>
		/// <returns>Read-only. The namespace of this enum.</returns>
		// Token: 0x17000C4E RID: 3150
		// (get) Token: 0x06004D64 RID: 19812 RVA: 0x00116EA6 File Offset: 0x001150A6
		public override string Namespace
		{
			get
			{
				return this.m_typeBuilder.Namespace;
			}
		}

		/// <summary>Returns the parent <see cref="T:System.Type" /> of this type which is always <see cref="T:System.Enum" />.</summary>
		/// <returns>Read-only. The parent <see cref="T:System.Type" /> of this type.</returns>
		// Token: 0x17000C4F RID: 3151
		// (get) Token: 0x06004D65 RID: 19813 RVA: 0x00116EB3 File Offset: 0x001150B3
		public override Type BaseType
		{
			get
			{
				return this.m_typeBuilder.BaseType;
			}
		}

		// Token: 0x06004D66 RID: 19814 RVA: 0x00116EC0 File Offset: 0x001150C0
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			return this.m_typeBuilder.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Returns an array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing the public and non-public constructors defined for this class, as specified.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing the specified constructors defined for this class. If no constructors are defined, an empty array is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D67 RID: 19815 RVA: 0x00116ED4 File Offset: 0x001150D4
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetConstructors(bindingAttr);
		}

		// Token: 0x06004D68 RID: 19816 RVA: 0x00116EE2 File Offset: 0x001150E2
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (types == null)
			{
				return this.m_typeBuilder.GetMethod(name, bindingAttr);
			}
			return this.m_typeBuilder.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Returns all the public and non-public methods declared or inherited by this type, as specified.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MethodInfo" /> objects representing the public and non-public methods defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public methods are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D69 RID: 19817 RVA: 0x00116F0A File Offset: 0x0011510A
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetMethods(bindingAttr);
		}

		/// <summary>Returns the field specified by the given name.</summary>
		/// <param name="name">The name of the field to get.</param>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns the <see cref="T:System.Reflection.FieldInfo" /> object representing the field declared or inherited by this type with the specified name and public or non-public modifier. If there are no matches, then null is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D6A RID: 19818 RVA: 0x00116F18 File Offset: 0x00115118
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetField(name, bindingAttr);
		}

		/// <summary>Returns the public and non-public fields that are declared by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as InvokeMethod, NonPublic, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.FieldInfo" /> objects representing the public and non-public fields declared or inherited by this type. An empty array is returned if there are no fields, as specified.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D6B RID: 19819 RVA: 0x00116F27 File Offset: 0x00115127
		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetFields(bindingAttr);
		}

		/// <summary>Returns the interface implemented (directly or indirectly) by this type, with the specified fully-qualified name.</summary>
		/// <param name="name">The name of the interface.</param>
		/// <param name="ignoreCase">If <see langword="true" />, the search is case-insensitive. If <see langword="false" />, the search is case-sensitive.</param>
		/// <returns>Returns a <see cref="T:System.Type" /> object representing the implemented interface. Returns null if no interface matching name is found.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D6C RID: 19820 RVA: 0x00116F35 File Offset: 0x00115135
		public override Type GetInterface(string name, bool ignoreCase)
		{
			return this.m_typeBuilder.GetInterface(name, ignoreCase);
		}

		/// <summary>Returns an array of all the interfaces implemented on this a class and its base classes.</summary>
		/// <returns>Returns an array of <see cref="T:System.Type" /> objects representing the implemented interfaces. If none are defined, an empty array is returned.</returns>
		// Token: 0x06004D6D RID: 19821 RVA: 0x00116F44 File Offset: 0x00115144
		public override Type[] GetInterfaces()
		{
			return this.m_typeBuilder.GetInterfaces();
		}

		/// <summary>Returns the event with the specified name.</summary>
		/// <param name="name">The name of the event to get.</param>
		/// <param name="bindingAttr">This invocation attribute. This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an <see cref="T:System.Reflection.EventInfo" /> object representing the event declared or inherited by this type with the specified name. If there are no matches, <see langword="null" /> is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D6E RID: 19822 RVA: 0x00116F51 File Offset: 0x00115151
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetEvent(name, bindingAttr);
		}

		/// <summary>Returns the events for the public events declared or inherited by this type.</summary>
		/// <returns>Returns an array of <see cref="T:System.Reflection.EventInfo" /> objects representing the public events declared or inherited by this type. An empty array is returned if there are no public events.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D6F RID: 19823 RVA: 0x00116F60 File Offset: 0x00115160
		public override EventInfo[] GetEvents()
		{
			return this.m_typeBuilder.GetEvents();
		}

		// Token: 0x06004D70 RID: 19824 RVA: 0x00116F6D File Offset: 0x0011516D
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns all the public and non-public properties declared or inherited by this type, as specified.</summary>
		/// <param name="bindingAttr">This invocation attribute. This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.PropertyInfo" /> objects representing the public and non-public properties defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public properties are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D71 RID: 19825 RVA: 0x00116F7E File Offset: 0x0011517E
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetProperties(bindingAttr);
		}

		/// <summary>Returns the public and non-public nested types that are declared or inherited by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the types nested within the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  An empty array of type <see cref="T:System.Type" />, if no types are nested within the current <see cref="T:System.Type" />, or if none of the nested types match the binding constraints.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D72 RID: 19826 RVA: 0x00116F8C File Offset: 0x0011518C
		public override Type[] GetNestedTypes(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetNestedTypes(bindingAttr);
		}

		/// <summary>Returns the specified nested type that is declared by this type.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the nested type to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to conduct a case-sensitive search for public methods.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the nested type that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D73 RID: 19827 RVA: 0x00116F9A File Offset: 0x0011519A
		public override Type GetNestedType(string name, BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetNestedType(name, bindingAttr);
		}

		/// <summary>Returns all members with the specified name, type, and binding that are declared or inherited by this type.</summary>
		/// <param name="name">The name of the member.</param>
		/// <param name="type">The type of member that is to be returned.</param>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public and non-public members defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public members are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D74 RID: 19828 RVA: 0x00116FA9 File Offset: 0x001151A9
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetMember(name, type, bindingAttr);
		}

		/// <summary>Returns the specified members declared or inherited by this type,.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public and non-public members declared or inherited by this type. An empty array is returned if there are no matching members.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D75 RID: 19829 RVA: 0x00116FB9 File Offset: 0x001151B9
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetMembers(bindingAttr);
		}

		/// <summary>Returns an interface mapping for the interface requested.</summary>
		/// <param name="interfaceType">The type of the interface for which the interface mapping is to be retrieved.</param>
		/// <returns>The requested interface mapping.</returns>
		/// <exception cref="T:System.ArgumentException">The type does not implement the interface.</exception>
		// Token: 0x06004D76 RID: 19830 RVA: 0x00116FC7 File Offset: 0x001151C7
		[ComVisible(true)]
		public override InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			return this.m_typeBuilder.GetInterfaceMap(interfaceType);
		}

		/// <summary>Returns the public and non-public events that are declared by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.EventInfo" /> objects representing the public and non-public events declared or inherited by this type. An empty array is returned if there are no events, as specified.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D77 RID: 19831 RVA: 0x00116FD5 File Offset: 0x001151D5
		public override EventInfo[] GetEvents(BindingFlags bindingAttr)
		{
			return this.m_typeBuilder.GetEvents(bindingAttr);
		}

		// Token: 0x06004D78 RID: 19832 RVA: 0x00116FE3 File Offset: 0x001151E3
		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			return this.m_typeBuilder.Attributes;
		}

		// Token: 0x06004D79 RID: 19833 RVA: 0x00116FF0 File Offset: 0x001151F0
		protected override bool IsArrayImpl()
		{
			return false;
		}

		// Token: 0x06004D7A RID: 19834 RVA: 0x00116FF3 File Offset: 0x001151F3
		protected override bool IsPrimitiveImpl()
		{
			return false;
		}

		// Token: 0x06004D7B RID: 19835 RVA: 0x00116FF6 File Offset: 0x001151F6
		protected override bool IsValueTypeImpl()
		{
			return true;
		}

		// Token: 0x06004D7C RID: 19836 RVA: 0x00116FF9 File Offset: 0x001151F9
		protected override bool IsByRefImpl()
		{
			return false;
		}

		// Token: 0x06004D7D RID: 19837 RVA: 0x00116FFC File Offset: 0x001151FC
		protected override bool IsPointerImpl()
		{
			return false;
		}

		// Token: 0x06004D7E RID: 19838 RVA: 0x00116FFF File Offset: 0x001151FF
		protected override bool IsCOMObjectImpl()
		{
			return false;
		}

		/// <summary>Gets a value that indicates whether this object represents a constructed generic type.</summary>
		/// <returns>
		///   <see langword="true" /> if this object represents a constructed generic type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000C50 RID: 3152
		// (get) Token: 0x06004D7F RID: 19839 RVA: 0x00117002 File Offset: 0x00115202
		public override bool IsConstructedGenericType
		{
			get
			{
				return false;
			}
		}

		/// <summary>Calling this method always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <returns>This method is not supported. No value is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported.</exception>
		// Token: 0x06004D80 RID: 19840 RVA: 0x00117005 File Offset: 0x00115205
		public override Type GetElementType()
		{
			return this.m_typeBuilder.GetElementType();
		}

		// Token: 0x06004D81 RID: 19841 RVA: 0x00117012 File Offset: 0x00115212
		protected override bool HasElementTypeImpl()
		{
			return this.m_typeBuilder.HasElementType;
		}

		/// <summary>Returns the underlying integer type of the current enumeration, which is set when the enumeration builder is defined.</summary>
		/// <returns>The underlying type.</returns>
		// Token: 0x06004D82 RID: 19842 RVA: 0x0011701F File Offset: 0x0011521F
		public override Type GetEnumUnderlyingType()
		{
			return this.m_underlyingField.FieldType;
		}

		/// <summary>Returns the underlying system type for this enum.</summary>
		/// <returns>Read-only. Returns the underlying system type.</returns>
		// Token: 0x17000C51 RID: 3153
		// (get) Token: 0x06004D83 RID: 19843 RVA: 0x0011702C File Offset: 0x0011522C
		public override Type UnderlyingSystemType
		{
			get
			{
				return this.GetEnumUnderlyingType();
			}
		}

		/// <summary>Returns all the custom attributes defined for this constructor.</summary>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>Returns an array of objects representing all the custom attributes of the constructor represented by this <see cref="T:System.Reflection.Emit.ConstructorBuilder" /> instance.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D84 RID: 19844 RVA: 0x00117034 File Offset: 0x00115234
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_typeBuilder.GetCustomAttributes(inherit);
		}

		/// <summary>Returns the custom attributes identified by the given type.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>Returns an array of objects representing the attributes of this constructor that are of <see cref="T:System.Type" /><paramref name="attributeType" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D85 RID: 19845 RVA: 0x00117042 File Offset: 0x00115242
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_typeBuilder.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Sets a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		// Token: 0x06004D86 RID: 19846 RVA: 0x00117051 File Offset: 0x00115251
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			this.m_typeBuilder.SetCustomAttribute(con, binaryAttribute);
		}

		/// <summary>Sets a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> is <see langword="null" />.</exception>
		// Token: 0x06004D87 RID: 19847 RVA: 0x00117060 File Offset: 0x00115260
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			this.m_typeBuilder.SetCustomAttribute(customBuilder);
		}

		/// <summary>Returns the type that declared this <see cref="T:System.Reflection.Emit.EnumBuilder" />.</summary>
		/// <returns>Read-only. The type that declared this <see cref="T:System.Reflection.Emit.EnumBuilder" />.</returns>
		// Token: 0x17000C52 RID: 3154
		// (get) Token: 0x06004D88 RID: 19848 RVA: 0x0011706E File Offset: 0x0011526E
		public override Type DeclaringType
		{
			get
			{
				return this.m_typeBuilder.DeclaringType;
			}
		}

		/// <summary>Returns the type that was used to obtain this <see cref="T:System.Reflection.Emit.EnumBuilder" />.</summary>
		/// <returns>Read-only. The type that was used to obtain this <see cref="T:System.Reflection.Emit.EnumBuilder" />.</returns>
		// Token: 0x17000C53 RID: 3155
		// (get) Token: 0x06004D89 RID: 19849 RVA: 0x0011707B File Offset: 0x0011527B
		public override Type ReflectedType
		{
			get
			{
				return this.m_typeBuilder.ReflectedType;
			}
		}

		/// <summary>Checks if the specified custom attribute type is defined.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of <paramref name="attributeType" /> is defined on this member; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported in types that are not complete.</exception>
		// Token: 0x06004D8A RID: 19850 RVA: 0x00117088 File Offset: 0x00115288
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_typeBuilder.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000C54 RID: 3156
		// (get) Token: 0x06004D8B RID: 19851 RVA: 0x00117097 File Offset: 0x00115297
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_typeBuilder.MetadataTokenInternal;
			}
		}

		// Token: 0x06004D8C RID: 19852 RVA: 0x001170A4 File Offset: 0x001152A4
		private EnumBuilder()
		{
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents a pointer to the current type.</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents a pointer to the current type.</returns>
		// Token: 0x06004D8D RID: 19853 RVA: 0x001170AC File Offset: 0x001152AC
		public override Type MakePointerType()
		{
			return SymbolType.FormCompoundType("*".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents the current type when passed as a ref parameter (ByRef parameter in Visual Basic).</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents the current type when passed as a ref parameter (ByRef parameter in Visual Basic).</returns>
		// Token: 0x06004D8E RID: 19854 RVA: 0x001170BF File Offset: 0x001152BF
		public override Type MakeByRefType()
		{
			return SymbolType.FormCompoundType("&".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object representing a one-dimensional array of the current type, with a lower bound of zero.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing a one-dimensional array of the current type, with a lower bound of zero.</returns>
		// Token: 0x06004D8F RID: 19855 RVA: 0x001170D2 File Offset: 0x001152D2
		public override Type MakeArrayType()
		{
			return SymbolType.FormCompoundType("[]".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object representing an array of the current type, with the specified number of dimensions.</summary>
		/// <param name="rank">The number of dimensions for the array. This number must be less than or equal to 32.</param>
		/// <returns>An object representing an array of the current type, with the specified number of dimensions.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="rank" /> is less than 1.</exception>
		// Token: 0x06004D90 RID: 19856 RVA: 0x001170E8 File Offset: 0x001152E8
		public override Type MakeArrayType(int rank)
		{
			if (rank <= 0)
			{
				throw new IndexOutOfRangeException();
			}
			string text = "";
			if (rank == 1)
			{
				text = "*";
			}
			else
			{
				for (int i = 1; i < rank; i++)
				{
					text += ",";
				}
			}
			string text2 = string.Format(CultureInfo.InvariantCulture, "[{0}]", text);
			return SymbolType.FormCompoundType(text2.ToCharArray(), this, 0);
		}

		// Token: 0x06004D91 RID: 19857 RVA: 0x00117148 File Offset: 0x00115348
		[SecurityCritical]
		internal EnumBuilder(string name, Type underlyingType, TypeAttributes visibility, ModuleBuilder module)
		{
			if ((visibility & ~TypeAttributes.VisibilityMask) != TypeAttributes.NotPublic)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ShouldOnlySetVisibilityFlags"), "name");
			}
			this.m_typeBuilder = new TypeBuilder(name, visibility | TypeAttributes.Sealed, typeof(Enum), null, module, PackingSize.Unspecified, 0, null);
			this.m_underlyingField = this.m_typeBuilder.DefineField("value__", underlyingType, FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.SpecialName | FieldAttributes.RTSpecialName);
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004D92 RID: 19858 RVA: 0x001171B5 File Offset: 0x001153B5
		void _EnumBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004D93 RID: 19859 RVA: 0x001171BC File Offset: 0x001153BC
		void _EnumBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x06004D94 RID: 19860 RVA: 0x001171C3 File Offset: 0x001153C3
		void _EnumBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x06004D95 RID: 19861 RVA: 0x001171CA File Offset: 0x001153CA
		void _EnumBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04002116 RID: 8470
		internal TypeBuilder m_typeBuilder;

		// Token: 0x04002117 RID: 8471
		private FieldBuilder m_underlyingField;
	}
}
