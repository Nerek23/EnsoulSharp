using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Defines and represents a constructor of a dynamic class.</summary>
	// Token: 0x02000603 RID: 1539
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ConstructorBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class ConstructorBuilder : ConstructorInfo, _ConstructorBuilder
	{
		// Token: 0x0600488D RID: 18573 RVA: 0x001061C7 File Offset: 0x001043C7
		private ConstructorBuilder()
		{
		}

		// Token: 0x0600488E RID: 18574 RVA: 0x001061D0 File Offset: 0x001043D0
		[SecurityCritical]
		internal ConstructorBuilder(string name, MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers, ModuleBuilder mod, TypeBuilder type)
		{
			this.m_methodBuilder = new MethodBuilder(name, attributes, callingConvention, null, null, null, parameterTypes, requiredCustomModifiers, optionalCustomModifiers, mod, type, false);
			type.m_listMethods.Add(this.m_methodBuilder);
			int num;
			byte[] array = this.m_methodBuilder.GetMethodSignature().InternalGetSignature(out num);
			MethodToken token = this.m_methodBuilder.GetToken();
		}

		// Token: 0x0600488F RID: 18575 RVA: 0x00106230 File Offset: 0x00104430
		[SecurityCritical]
		internal ConstructorBuilder(string name, MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, ModuleBuilder mod, TypeBuilder type) : this(name, attributes, callingConvention, parameterTypes, null, null, mod, type)
		{
		}

		// Token: 0x06004890 RID: 18576 RVA: 0x0010624E File Offset: 0x0010444E
		internal override Type[] GetParameterTypes()
		{
			return this.m_methodBuilder.GetParameterTypes();
		}

		// Token: 0x06004891 RID: 18577 RVA: 0x0010625B File Offset: 0x0010445B
		private TypeBuilder GetTypeBuilder()
		{
			return this.m_methodBuilder.GetTypeBuilder();
		}

		// Token: 0x06004892 RID: 18578 RVA: 0x00106268 File Offset: 0x00104468
		internal ModuleBuilder GetModuleBuilder()
		{
			return this.GetTypeBuilder().GetModuleBuilder();
		}

		/// <summary>Returns this <see cref="T:System.Reflection.Emit.ConstructorBuilder" /> instance as a <see cref="T:System.String" />.</summary>
		/// <returns>A string containing the name, attributes, and exceptions of this constructor, followed by the current Microsoft intermediate language (MSIL) stream.</returns>
		// Token: 0x06004893 RID: 18579 RVA: 0x00106275 File Offset: 0x00104475
		public override string ToString()
		{
			return this.m_methodBuilder.ToString();
		}

		// Token: 0x17000B67 RID: 2919
		// (get) Token: 0x06004894 RID: 18580 RVA: 0x00106282 File Offset: 0x00104482
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_methodBuilder.MetadataTokenInternal;
			}
		}

		/// <summary>Gets the dynamic module in which this constructor is defined.</summary>
		/// <returns>A <see cref="T:System.Reflection.Module" /> object that represents the dynamic module in which this constructor is defined.</returns>
		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x06004895 RID: 18581 RVA: 0x0010628F File Offset: 0x0010448F
		public override Module Module
		{
			get
			{
				return this.m_methodBuilder.Module;
			}
		}

		/// <summary>Holds a reference to the <see cref="T:System.Type" /> object from which this object was obtained.</summary>
		/// <returns>The <see langword="Type" /> object from which this object was obtained.</returns>
		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x06004896 RID: 18582 RVA: 0x0010629C File Offset: 0x0010449C
		public override Type ReflectedType
		{
			get
			{
				return this.m_methodBuilder.ReflectedType;
			}
		}

		/// <summary>Gets a reference to the <see cref="T:System.Type" /> object for the type that declares this member.</summary>
		/// <returns>The type that declares this member.</returns>
		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x06004897 RID: 18583 RVA: 0x001062A9 File Offset: 0x001044A9
		public override Type DeclaringType
		{
			get
			{
				return this.m_methodBuilder.DeclaringType;
			}
		}

		/// <summary>Retrieves the name of this constructor.</summary>
		/// <returns>The name of this constructor.</returns>
		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x06004898 RID: 18584 RVA: 0x001062B6 File Offset: 0x001044B6
		public override string Name
		{
			get
			{
				return this.m_methodBuilder.Name;
			}
		}

		/// <summary>Dynamically invokes the constructor reflected by this instance with the specified arguments, under the constraints of the specified <see langword="Binder" />.</summary>
		/// <param name="obj">The object that needs to be reinitialized.</param>
		/// <param name="invokeAttr">One of the <see langword="BindingFlags" /> values that specifies the type of binding that is desired.</param>
		/// <param name="binder">A <see langword="Binder" /> that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder" /> is <see langword="null" />, then Binder.DefaultBinding is used.</param>
		/// <param name="parameters">An argument list. This is an array of arguments with the same number, order, and type as the parameters of the constructor to be invoked. If there are no parameters, this should be a null reference (<see langword="Nothing" /> in Visual Basic).</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is null, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used.</param>
		/// <returns>An instance of the class associated with the constructor.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported. You can retrieve the constructor using <see cref="M:System.Type.GetConstructor(System.Reflection.BindingFlags,System.Reflection.Binder,System.Reflection.CallingConventions,System.Type[],System.Reflection.ParameterModifier[])" /> and call <see cref="M:System.Reflection.ConstructorInfo.Invoke(System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> on the returned <see cref="T:System.Reflection.ConstructorInfo" />.</exception>
		// Token: 0x06004899 RID: 18585 RVA: 0x001062C3 File Offset: 0x001044C3
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns the parameters of this constructor.</summary>
		/// <returns>An array that represents the parameters of this constructor.</returns>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has not been called on this constructor's type, in the .NET Framework versions 1.0 and 1.1.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has not been called on this constructor's type, in the .NET Framework version 2.0.</exception>
		// Token: 0x0600489A RID: 18586 RVA: 0x001062D4 File Offset: 0x001044D4
		public override ParameterInfo[] GetParameters()
		{
			ConstructorInfo constructor = this.GetTypeBuilder().GetConstructor(this.m_methodBuilder.m_parameterTypes);
			return constructor.GetParameters();
		}

		/// <summary>Gets the attributes for this constructor.</summary>
		/// <returns>The attributes for this constructor.</returns>
		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x0600489B RID: 18587 RVA: 0x001062FE File Offset: 0x001044FE
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_methodBuilder.Attributes;
			}
		}

		/// <summary>Returns the method implementation flags for this constructor.</summary>
		/// <returns>The method implementation flags for this constructor.</returns>
		// Token: 0x0600489C RID: 18588 RVA: 0x0010630B File Offset: 0x0010450B
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_methodBuilder.GetMethodImplementationFlags();
		}

		/// <summary>Gets the internal handle for the method. Use this handle to access the underlying metadata handle.</summary>
		/// <returns>The internal handle for the method. Use this handle to access the underlying metadata handle.</returns>
		/// <exception cref="T:System.NotSupportedException">This property is not supported on this class.</exception>
		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x0600489D RID: 18589 RVA: 0x00106318 File Offset: 0x00104518
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				return this.m_methodBuilder.MethodHandle;
			}
		}

		/// <summary>Dynamically invokes the constructor represented by this instance on the given object, passing along the specified parameters, and under the constraints of the given binder.</summary>
		/// <param name="invokeAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as InvokeMethod, NonPublic, and so on.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects using reflection. If binder is <see langword="null" />, the default binder is used. See <see cref="T:System.Reflection.Binder" />.</param>
		/// <param name="parameters">An argument list. This is an array of arguments with the same number, order, and type as the parameters of the constructor to be invoked. If there are no parameters this should be <see langword="null" />.</param>
		/// <param name="culture">An instance of <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is null, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used. (For example, this is necessary to convert a <see cref="T:System.String" /> that represents 1000 to a <see cref="T:System.Double" /> value, since 1000 is represented differently by different cultures.)</param>
		/// <returns>The value returned by the invoked constructor.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported. You can retrieve the constructor using <see cref="M:System.Type.GetConstructor(System.Reflection.BindingFlags,System.Reflection.Binder,System.Reflection.CallingConventions,System.Type[],System.Reflection.ParameterModifier[])" /> and call <see cref="M:System.Reflection.ConstructorInfo.Invoke(System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> on the returned <see cref="T:System.Reflection.ConstructorInfo" />.</exception>
		// Token: 0x0600489E RID: 18590 RVA: 0x00106325 File Offset: 0x00104525
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns all the custom attributes defined for this constructor.</summary>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes. This parameter is ignored.</param>
		/// <returns>An array of objects representing all the custom attributes of the constructor represented by this <see cref="T:System.Reflection.Emit.ConstructorBuilder" /> instance.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported.</exception>
		// Token: 0x0600489F RID: 18591 RVA: 0x00106336 File Offset: 0x00104536
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_methodBuilder.GetCustomAttributes(inherit);
		}

		/// <summary>Returns the custom attributes identified by the given type.</summary>
		/// <param name="attributeType">The custom attribute type.</param>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes. This parameter is ignored.</param>
		/// <returns>An object array that represents the attributes of this constructor.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported.</exception>
		// Token: 0x060048A0 RID: 18592 RVA: 0x00106344 File Offset: 0x00104544
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_methodBuilder.GetCustomAttributes(attributeType, inherit);
		}

		/// <summary>Checks if the specified custom attribute type is defined.</summary>
		/// <param name="attributeType">A custom attribute type.</param>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes. This parameter is ignored.</param>
		/// <returns>
		///   <see langword="true" /> if the specified custom attribute type is defined; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported. You can retrieve the constructor using <see cref="M:System.Type.GetConstructor(System.Reflection.BindingFlags,System.Reflection.Binder,System.Reflection.CallingConventions,System.Type[],System.Reflection.ParameterModifier[])" /> and call <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> on the returned <see cref="T:System.Reflection.ConstructorInfo" />.</exception>
		// Token: 0x060048A1 RID: 18593 RVA: 0x00106353 File Offset: 0x00104553
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_methodBuilder.IsDefined(attributeType, inherit);
		}

		/// <summary>Returns the <see cref="T:System.Reflection.Emit.MethodToken" /> that represents the token for this constructor.</summary>
		/// <returns>The <see cref="T:System.Reflection.Emit.MethodToken" /> of this constructor.</returns>
		// Token: 0x060048A2 RID: 18594 RVA: 0x00106362 File Offset: 0x00104562
		public MethodToken GetToken()
		{
			return this.m_methodBuilder.GetToken();
		}

		/// <summary>Defines a parameter of this constructor.</summary>
		/// <param name="iSequence">The position of the parameter in the parameter list. Parameters are indexed beginning with the number 1 for the first parameter.</param>
		/// <param name="attributes">The attributes of the parameter.</param>
		/// <param name="strParamName">The name of the parameter. The name can be the null string.</param>
		/// <returns>An object that represents the new parameter of this constructor.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="iSequence" /> is less than 0 (zero), or it is greater than the number of parameters of the constructor.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x060048A3 RID: 18595 RVA: 0x0010636F File Offset: 0x0010456F
		public ParameterBuilder DefineParameter(int iSequence, ParameterAttributes attributes, string strParamName)
		{
			attributes &= ~ParameterAttributes.ReservedMask;
			return this.m_methodBuilder.DefineParameter(iSequence, attributes, strParamName);
		}

		/// <summary>Sets this constructor's custom attribute associated with symbolic information.</summary>
		/// <param name="name">The name of the custom attribute.</param>
		/// <param name="data">The value of the custom attribute.</param>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  The module does not have a symbol writer defined. For example, the module is not a debug module.</exception>
		// Token: 0x060048A4 RID: 18596 RVA: 0x00106388 File Offset: 0x00104588
		public void SetSymCustomAttribute(string name, byte[] data)
		{
			this.m_methodBuilder.SetSymCustomAttribute(name, data);
		}

		/// <summary>Gets an <see cref="T:System.Reflection.Emit.ILGenerator" /> for this constructor.</summary>
		/// <returns>An <see cref="T:System.Reflection.Emit.ILGenerator" /> object for this constructor.</returns>
		/// <exception cref="T:System.InvalidOperationException">The constructor is a default constructor.  
		///  -or-  
		///  The constructor has <see cref="T:System.Reflection.MethodAttributes" /> or <see cref="T:System.Reflection.MethodImplAttributes" /> flags indicating that it should not have a method body.</exception>
		// Token: 0x060048A5 RID: 18597 RVA: 0x00106397 File Offset: 0x00104597
		public ILGenerator GetILGenerator()
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorILGen"));
			}
			return this.m_methodBuilder.GetILGenerator();
		}

		/// <summary>Gets an <see cref="T:System.Reflection.Emit.ILGenerator" /> object, with the specified MSIL stream size, that can be used to build a method body for this constructor.</summary>
		/// <param name="streamSize">The size of the MSIL stream, in bytes.</param>
		/// <returns>An <see cref="T:System.Reflection.Emit.ILGenerator" /> for this constructor.</returns>
		/// <exception cref="T:System.InvalidOperationException">The constructor is a default constructor.  
		///  -or-  
		///  The constructor has <see cref="T:System.Reflection.MethodAttributes" /> or <see cref="T:System.Reflection.MethodImplAttributes" /> flags indicating that it should not have a method body.</exception>
		// Token: 0x060048A6 RID: 18598 RVA: 0x001063BC File Offset: 0x001045BC
		public ILGenerator GetILGenerator(int streamSize)
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorILGen"));
			}
			return this.m_methodBuilder.GetILGenerator(streamSize);
		}

		/// <summary>Creates the body of the constructor by using a specified byte array of Microsoft intermediate language (MSIL) instructions.</summary>
		/// <param name="il">An array that contains valid MSIL instructions.</param>
		/// <param name="maxStack">The maximum stack evaluation depth.</param>
		/// <param name="localSignature">An array of bytes that contain the serialized local variable structure. Specify <see langword="null" /> if the constructor has no local variables.</param>
		/// <param name="exceptionHandlers">A collection that contains the exception handlers for the constructor. Specify <see langword="null" /> if the constructor has no exception handlers.</param>
		/// <param name="tokenFixups">A collection of values that represent offsets in <paramref name="il" />, each of which specifies the beginning of a token that may be modified. Specify <see langword="null" /> if the constructor has no tokens that have to be modified.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="il" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="maxStack" /> is negative.  
		/// -or-  
		/// One of <paramref name="exceptionHandlers" /> specifies an offset outside of <paramref name="il" />.  
		/// -or-  
		/// One of <paramref name="tokenFixups" /> specifies an offset that is outside the <paramref name="il" /> array.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type was previously created using the <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method.  
		///  -or-  
		///  This method was called previously on this <see cref="T:System.Reflection.Emit.ConstructorBuilder" /> object.</exception>
		// Token: 0x060048A7 RID: 18599 RVA: 0x001063E2 File Offset: 0x001045E2
		public void SetMethodBody(byte[] il, int maxStack, byte[] localSignature, IEnumerable<ExceptionHandler> exceptionHandlers, IEnumerable<int> tokenFixups)
		{
			if (this.m_isDefaultConstructor)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DefaultConstructorDefineBody"));
			}
			this.m_methodBuilder.SetMethodBody(il, maxStack, localSignature, exceptionHandlers, tokenFixups);
		}

		/// <summary>Adds declarative security to this constructor.</summary>
		/// <param name="action">The security action to be taken, such as Demand, Assert, and so on.</param>
		/// <param name="pset">The set of permissions the action applies to.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="action" /> is invalid (RequestMinimum, RequestOptional, and RequestRefuse are invalid).</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  The permission set <paramref name="pset" /> contains an action that was added earlier by <see langword="AddDeclarativeSecurity" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="pset" /> is <see langword="null" />.</exception>
		// Token: 0x060048A8 RID: 18600 RVA: 0x00106410 File Offset: 0x00104610
		[SecuritySafeCritical]
		public void AddDeclarativeSecurity(SecurityAction action, PermissionSet pset)
		{
			if (pset == null)
			{
				throw new ArgumentNullException("pset");
			}
			if (!Enum.IsDefined(typeof(SecurityAction), action) || action == SecurityAction.RequestMinimum || action == SecurityAction.RequestOptional || action == SecurityAction.RequestRefuse)
			{
				throw new ArgumentOutOfRangeException("action");
			}
			if (this.m_methodBuilder.IsTypeCreated())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TypeHasBeenCreated"));
			}
			byte[] array = pset.EncodeXml();
			TypeBuilder.AddDeclarativeSecurity(this.GetModuleBuilder().GetNativeHandle(), this.GetToken().Token, action, array, array.Length);
		}

		/// <summary>Gets a <see cref="T:System.Reflection.CallingConventions" /> value that depends on whether the declaring type is generic.</summary>
		/// <returns>
		///   <see cref="F:System.Reflection.CallingConventions.HasThis" /> if the declaring type is generic; otherwise, <see cref="F:System.Reflection.CallingConventions.Standard" />.</returns>
		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x060048A9 RID: 18601 RVA: 0x001064A2 File Offset: 0x001046A2
		public override CallingConventions CallingConvention
		{
			get
			{
				if (this.DeclaringType.IsGenericType)
				{
					return CallingConventions.HasThis;
				}
				return CallingConventions.Standard;
			}
		}

		/// <summary>Returns a reference to the module that contains this constructor.</summary>
		/// <returns>The module that contains this constructor.</returns>
		// Token: 0x060048AA RID: 18602 RVA: 0x001064B5 File Offset: 0x001046B5
		public Module GetModule()
		{
			return this.m_methodBuilder.GetModule();
		}

		/// <summary>Gets <see langword="null" />.</summary>
		/// <returns>Returns <see langword="null" />.</returns>
		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x060048AB RID: 18603 RVA: 0x001064C2 File Offset: 0x001046C2
		[Obsolete("This property has been deprecated. http://go.microsoft.com/fwlink/?linkid=14202")]
		public Type ReturnType
		{
			get
			{
				return this.GetReturnType();
			}
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x001064CA File Offset: 0x001046CA
		internal override Type GetReturnType()
		{
			return this.m_methodBuilder.ReturnType;
		}

		/// <summary>Retrieves the signature of the field in the form of a string.</summary>
		/// <returns>The signature of the field.</returns>
		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x060048AD RID: 18605 RVA: 0x001064D7 File Offset: 0x001046D7
		public string Signature
		{
			get
			{
				return this.m_methodBuilder.Signature;
			}
		}

		/// <summary>Set a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		// Token: 0x060048AE RID: 18606 RVA: 0x001064E4 File Offset: 0x001046E4
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			this.m_methodBuilder.SetCustomAttribute(con, binaryAttribute);
		}

		/// <summary>Set a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="customBuilder" /> is <see langword="null" />.</exception>
		// Token: 0x060048AF RID: 18607 RVA: 0x001064F3 File Offset: 0x001046F3
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			this.m_methodBuilder.SetCustomAttribute(customBuilder);
		}

		/// <summary>Sets the method implementation flags for this constructor.</summary>
		/// <param name="attributes">The method implementation flags.</param>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x060048B0 RID: 18608 RVA: 0x00106501 File Offset: 0x00104701
		public void SetImplementationFlags(MethodImplAttributes attributes)
		{
			this.m_methodBuilder.SetImplementationFlags(attributes);
		}

		/// <summary>Gets or sets whether the local variables in this constructor should be zero-initialized.</summary>
		/// <returns>Read/write. Gets or sets whether the local variables in this constructor should be zero-initialized.</returns>
		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x060048B1 RID: 18609 RVA: 0x0010650F File Offset: 0x0010470F
		// (set) Token: 0x060048B2 RID: 18610 RVA: 0x0010651C File Offset: 0x0010471C
		public bool InitLocals
		{
			get
			{
				return this.m_methodBuilder.InitLocals;
			}
			set
			{
				this.m_methodBuilder.InitLocals = value;
			}
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060048B3 RID: 18611 RVA: 0x0010652A File Offset: 0x0010472A
		void _ConstructorBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060048B4 RID: 18612 RVA: 0x00106531 File Offset: 0x00104731
		void _ConstructorBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060048B5 RID: 18613 RVA: 0x00106538 File Offset: 0x00104738
		void _ConstructorBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060048B6 RID: 18614 RVA: 0x0010653F File Offset: 0x0010473F
		void _ConstructorBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001DC8 RID: 7624
		private readonly MethodBuilder m_methodBuilder;

		// Token: 0x04001DC9 RID: 7625
		internal bool m_isDefaultConstructor;
	}
}
