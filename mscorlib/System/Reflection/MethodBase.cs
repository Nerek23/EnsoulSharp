using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace System.Reflection
{
	/// <summary>Provides information about methods and constructors.</summary>
	// Token: 0x020005D9 RID: 1497
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MethodBase))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MethodBase : MemberInfo, _MethodBase
	{
		/// <summary>Gets method information by using the method's internal metadata representation (handle).</summary>
		/// <param name="handle">The method's handle.</param>
		/// <returns>A <see langword="MethodBase" /> containing information about the method.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="handle" /> is invalid.</exception>
		// Token: 0x060045D2 RID: 17874 RVA: 0x000FECE8 File Offset: 0x000FCEE8
		[__DynamicallyInvokable]
		public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			MethodBase methodBase = RuntimeType.GetMethodBase(handle.GetMethodInfo());
			Type declaringType = methodBase.DeclaringType;
			if (declaringType != null && declaringType.IsGenericType)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_MethodDeclaringTypeGeneric"), methodBase, declaringType.GetGenericTypeDefinition()));
			}
			return methodBase;
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MethodBase" /> object for the constructor or method represented by the specified handle, for the specified generic type.</summary>
		/// <param name="handle">A handle to the internal metadata representation of a constructor or method.</param>
		/// <param name="declaringType">A handle to the generic type that defines the constructor or method.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodBase" /> object representing the method or constructor specified by <paramref name="handle" />, in the generic type specified by <paramref name="declaringType" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="handle" /> is invalid.</exception>
		// Token: 0x060045D3 RID: 17875 RVA: 0x000FED55 File Offset: 0x000FCF55
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle, RuntimeTypeHandle declaringType)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return RuntimeType.GetMethodBase(declaringType.GetRuntimeType(), handle.GetMethodInfo());
		}

		/// <summary>Returns a <see langword="MethodBase" /> object representing the currently executing method.</summary>
		/// <returns>
		///   <see cref="M:System.Reflection.MethodBase.GetCurrentMethod" /> is a static method that is called from within an executing method and that returns information about that method.  
		/// A <see langword="MethodBase" /> object representing the currently executing method.</returns>
		/// <exception cref="T:System.Reflection.TargetException">This member was invoked with a late-binding mechanism.</exception>
		// Token: 0x060045D4 RID: 17876 RVA: 0x000FED84 File Offset: 0x000FCF84
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase GetCurrentMethod()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeMethodInfo.InternalGetCurrentMethod(ref stackCrawlMark);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.MethodBase" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060045D6 RID: 17878 RVA: 0x000FEDA4 File Offset: 0x000FCFA4
		[__DynamicallyInvokable]
		public static bool operator ==(MethodBase left, MethodBase right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			MethodInfo left2;
			MethodInfo right2;
			if ((left2 = (left as MethodInfo)) != null && (right2 = (right as MethodInfo)) != null)
			{
				return left2 == right2;
			}
			ConstructorInfo left3;
			ConstructorInfo right3;
			return (left3 = (left as ConstructorInfo)) != null && (right3 = (right as ConstructorInfo)) != null && left3 == right3;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.MethodBase" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060045D7 RID: 17879 RVA: 0x000FEE10 File Offset: 0x000FD010
		[__DynamicallyInvokable]
		public static bool operator !=(MethodBase left, MethodBase right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060045D8 RID: 17880 RVA: 0x000FEE1C File Offset: 0x000FD01C
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060045D9 RID: 17881 RVA: 0x000FEE25 File Offset: 0x000FD025
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060045DA RID: 17882 RVA: 0x000FEE30 File Offset: 0x000FD030
		[SecurityCritical]
		private IntPtr GetMethodDesc()
		{
			return this.MethodHandle.Value;
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x060045DB RID: 17883 RVA: 0x000FEE4B File Offset: 0x000FD04B
		internal virtual bool IsDynamicallyInvokable
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x060045DC RID: 17884 RVA: 0x000FEE4E File Offset: 0x000FD04E
		internal virtual ParameterInfo[] GetParametersNoCopy()
		{
			return this.GetParameters();
		}

		/// <summary>When overridden in a derived class, gets the parameters of the specified method or constructor.</summary>
		/// <returns>An array of type <see langword="ParameterInfo" /> containing information that matches the signature of the method (or constructor) reflected by this <see langword="MethodBase" /> instance.</returns>
		// Token: 0x060045DD RID: 17885
		[__DynamicallyInvokable]
		public abstract ParameterInfo[] GetParameters();

		/// <summary>Gets the <see cref="T:System.Reflection.MethodImplAttributes" /> flags that specify the attributes of a method implementation.</summary>
		/// <returns>The method implementation flags.</returns>
		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x060045DE RID: 17886 RVA: 0x000FEE56 File Offset: 0x000FD056
		[__DynamicallyInvokable]
		public virtual MethodImplAttributes MethodImplementationFlags
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetMethodImplementationFlags();
			}
		}

		/// <summary>When overridden in a derived class, returns the <see cref="T:System.Reflection.MethodImplAttributes" /> flags.</summary>
		/// <returns>The <see langword="MethodImplAttributes" /> flags.</returns>
		// Token: 0x060045DF RID: 17887
		public abstract MethodImplAttributes GetMethodImplementationFlags();

		/// <summary>Gets a handle to the internal metadata representation of a method.</summary>
		/// <returns>A <see cref="T:System.RuntimeMethodHandle" /> object.</returns>
		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x060045E0 RID: 17888
		[__DynamicallyInvokable]
		public abstract RuntimeMethodHandle MethodHandle { [__DynamicallyInvokable] get; }

		/// <summary>Gets the attributes associated with this method.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.MethodAttributes" /> values.</returns>
		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x060045E1 RID: 17889
		[__DynamicallyInvokable]
		public abstract MethodAttributes Attributes { [__DynamicallyInvokable] get; }

		/// <summary>When overridden in a derived class, invokes the reflected method or constructor with the given parameters.</summary>
		/// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be <see langword="null" /> or an instance of the class that defines the constructor.</param>
		/// <param name="invokeAttr">A bitmask that is a combination of 0 or more bit flags from <see cref="T:System.Reflection.BindingFlags" />. If <paramref name="binder" /> is <see langword="null" />, this parameter is assigned the value <see cref="F:System.Reflection.BindingFlags.Default" />; thus, whatever you pass in is ignored.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects via reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, this should be <see langword="null" />.  
		///  If the method or constructor represented by this instance takes a ByRef parameter, there is no special attribute required for that parameter in order to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <param name="culture">An instance of <see langword="CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see langword="CultureInfo" /> for the current thread is used. (This is necessary to convert a <see langword="String" /> that represents 1000 to a <see langword="Double" /> value, for example, since 1000 is represented differently by different cultures.)</param>
		/// <returns>An <see langword="Object" /> containing the return value of the invoked method, or <see langword="null" /> in the case of a constructor, or <see langword="null" /> if the method's return type is <see langword="void" />. Before calling the method or constructor, <see langword="Invoke" /> checks to see if the user has access permission and verifies that the parameters are valid.</returns>
		/// <exception cref="T:System.Reflection.TargetException">The <paramref name="obj" /> parameter is <see langword="null" /> and the method is not static.  
		///  -or-  
		///  The method is not declared or inherited by the class of <paramref name="obj" />.  
		///  -or-  
		///  A static constructor is invoked, and <paramref name="obj" /> is neither <see langword="null" /> nor an instance of the class that declared the constructor.</exception>
		/// <exception cref="T:System.ArgumentException">The type of the <paramref name="parameters" /> parameter does not match the signature of the method or constructor reflected by this instance.</exception>
		/// <exception cref="T:System.Reflection.TargetParameterCountException">The <paramref name="parameters" /> array does not have the correct number of arguments.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The invoked method or constructor throws an exception.</exception>
		/// <exception cref="T:System.MethodAccessException">The caller does not have permission to execute the method or constructor that is represented by the current instance.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type that declares the method is an open generic type. That is, the <see cref="P:System.Type.ContainsGenericParameters" /> property returns <see langword="true" /> for the declaring type.</exception>
		// Token: 0x060045E2 RID: 17890
		public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		/// <summary>Gets a value indicating the calling conventions for this method.</summary>
		/// <returns>The <see cref="T:System.Reflection.CallingConventions" /> for this method.</returns>
		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x060045E3 RID: 17891 RVA: 0x000FEE5E File Offset: 0x000FD05E
		[__DynamicallyInvokable]
		public virtual CallingConventions CallingConvention
		{
			[__DynamicallyInvokable]
			get
			{
				return CallingConventions.Standard;
			}
		}

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects that represent the type arguments of a generic method or the type parameters of a generic method definition.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that represent the type arguments of a generic method or the type parameters of a generic method definition. Returns an empty array if the current method is not a generic method.</returns>
		/// <exception cref="T:System.NotSupportedException">The current object is a <see cref="T:System.Reflection.ConstructorInfo" />. Generic constructors are not supported in the .NET Framework version 2.0. This exception is the default behavior if this method is not overridden in a derived class.</exception>
		// Token: 0x060045E4 RID: 17892 RVA: 0x000FEE61 File Offset: 0x000FD061
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual Type[] GetGenericArguments()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Gets a value indicating whether the method is a generic method definition.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Reflection.MethodBase" /> object represents the definition of a generic method; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x060045E5 RID: 17893 RVA: 0x000FEE72 File Offset: 0x000FD072
		[__DynamicallyInvokable]
		public virtual bool IsGenericMethodDefinition
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value indicating whether the generic method contains unassigned generic type parameters.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Reflection.MethodBase" /> object represents a generic method that contains unassigned generic type parameters; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x060045E6 RID: 17894 RVA: 0x000FEE75 File Offset: 0x000FD075
		[__DynamicallyInvokable]
		public virtual bool ContainsGenericParameters
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value indicating whether the method is generic.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Reflection.MethodBase" /> represents a generic method; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x060045E7 RID: 17895 RVA: 0x000FEE78 File Offset: 0x000FD078
		[__DynamicallyInvokable]
		public virtual bool IsGenericMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value that indicates whether the current method or constructor is security-critical or security-safe-critical at the current trust level, and therefore can perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the current method or constructor is security-critical or security-safe-critical at the current trust level; <see langword="false" /> if it is transparent.</returns>
		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x060045E8 RID: 17896 RVA: 0x000FEE7B File Offset: 0x000FD07B
		public virtual bool IsSecurityCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current method or constructor is security-safe-critical at the current trust level; that is, whether it can perform critical operations and can be accessed by transparent code.</summary>
		/// <returns>
		///   <see langword="true" /> if the method or constructor is security-safe-critical at the current trust level; <see langword="false" /> if it is security-critical or transparent.</returns>
		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x060045E9 RID: 17897 RVA: 0x000FEE82 File Offset: 0x000FD082
		public virtual bool IsSecuritySafeCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current method or constructor is transparent at the current trust level, and therefore cannot perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the method or constructor is security-transparent at the current trust level; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x060045EA RID: 17898 RVA: 0x000FEE89 File Offset: 0x000FD089
		public virtual bool IsSecurityTransparent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Invokes the method or constructor represented by the current instance, using the specified parameters.</summary>
		/// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. If a constructor is static, this argument must be <see langword="null" /> or an instance of the class that defines the constructor.</param>
		/// <param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, <paramref name="parameters" /> should be <see langword="null" />.  
		///  If the method or constructor represented by this instance takes a <see langword="ref" /> parameter (<see langword="ByRef" /> in Visual Basic), no special attribute is required for that parameter in order to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <returns>An object containing the return value of the invoked method, or <see langword="null" /> in the case of a constructor.</returns>
		/// <exception cref="T:System.Reflection.TargetException">In the.NET for Windows Store apps or the Portable Class Library, catch <see cref="T:System.Exception" /> instead.  
		///
		///
		///
		///
		///  The <paramref name="obj" /> parameter is <see langword="null" /> and the method is not static.  
		///  -or-  
		///  The method is not declared or inherited by the class of <paramref name="obj" />.  
		///  -or-  
		///  A static constructor is invoked, and <paramref name="obj" /> is neither <see langword="null" /> nor an instance of the class that declared the constructor.</exception>
		/// <exception cref="T:System.ArgumentException">The elements of the <paramref name="parameters" /> array do not match the signature of the method or constructor reflected by this instance.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The invoked method or constructor throws an exception.  
		///  -or-  
		///  The current instance is a <see cref="T:System.Reflection.Emit.DynamicMethod" /> that contains unverifiable code. See the "Verification" section in Remarks for <see cref="T:System.Reflection.Emit.DynamicMethod" />.</exception>
		/// <exception cref="T:System.Reflection.TargetParameterCountException">The <paramref name="parameters" /> array does not have the correct number of arguments.</exception>
		/// <exception cref="T:System.MethodAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The caller does not have permission to execute the method or constructor that is represented by the current instance.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type that declares the method is an open generic type. That is, the <see cref="P:System.Type.ContainsGenericParameters" /> property returns <see langword="true" /> for the declaring type.</exception>
		/// <exception cref="T:System.NotSupportedException">The current instance is a <see cref="T:System.Reflection.Emit.MethodBuilder" />.</exception>
		// Token: 0x060045EB RID: 17899 RVA: 0x000FEE90 File Offset: 0x000FD090
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public object Invoke(object obj, object[] parameters)
		{
			return this.Invoke(obj, BindingFlags.Default, null, parameters, null);
		}

		/// <summary>Gets a value indicating whether this is a public method.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is public; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x060045EC RID: 17900 RVA: 0x000FEE9D File Offset: 0x000FD09D
		[__DynamicallyInvokable]
		public bool IsPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public;
			}
		}

		/// <summary>Gets a value indicating whether this member is private.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method is restricted to other members of the class itself; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x060045ED RID: 17901 RVA: 0x000FEEAA File Offset: 0x000FD0AA
		[__DynamicallyInvokable]
		public bool IsPrivate
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private;
			}
		}

		/// <summary>Gets a value indicating whether the visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.Family" />; that is, the method or constructor is visible only within its class and derived classes.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.Family" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x060045EE RID: 17902 RVA: 0x000FEEB7 File Offset: 0x000FD0B7
		[__DynamicallyInvokable]
		public bool IsFamily
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family;
			}
		}

		/// <summary>Gets a value indicating whether the potential visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.Assembly" />; that is, the method or constructor is visible at most to other types in the same assembly, and is not visible to derived types outside the assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the visibility of this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.Assembly" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x060045EF RID: 17903 RVA: 0x000FEEC4 File Offset: 0x000FD0C4
		[__DynamicallyInvokable]
		public bool IsAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Assembly;
			}
		}

		/// <summary>Gets a value indicating whether the visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.FamANDAssem" />; that is, the method or constructor can be called by derived classes, but only if they are in the same assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.FamANDAssem" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x060045F0 RID: 17904 RVA: 0x000FEED1 File Offset: 0x000FD0D1
		[__DynamicallyInvokable]
		public bool IsFamilyAndAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamANDAssem;
			}
		}

		/// <summary>Gets a value indicating whether the potential visibility of this method or constructor is described by <see cref="F:System.Reflection.MethodAttributes.FamORAssem" />; that is, the method or constructor can be called by derived classes wherever they are, and by classes in the same assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method or constructor is exactly described by <see cref="F:System.Reflection.MethodAttributes.FamORAssem" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x060045F1 RID: 17905 RVA: 0x000FEEDE File Offset: 0x000FD0DE
		[__DynamicallyInvokable]
		public bool IsFamilyOrAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem;
			}
		}

		/// <summary>Gets a value indicating whether the method is <see langword="static" />.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="static" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x060045F2 RID: 17906 RVA: 0x000FEEEB File Offset: 0x000FD0EB
		[__DynamicallyInvokable]
		public bool IsStatic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Static) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether this method is <see langword="final" />.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="final" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x060045F3 RID: 17907 RVA: 0x000FEEF9 File Offset: 0x000FD0F9
		[__DynamicallyInvokable]
		public bool IsFinal
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Final) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the method is <see langword="virtual" />.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="virtual" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x060045F4 RID: 17908 RVA: 0x000FEF07 File Offset: 0x000FD107
		[__DynamicallyInvokable]
		public bool IsVirtual
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Virtual) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether only a member of the same kind with exactly the same signature is hidden in the derived class.</summary>
		/// <returns>
		///   <see langword="true" /> if the member is hidden by signature; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x060045F5 RID: 17909 RVA: 0x000FEF15 File Offset: 0x000FD115
		[__DynamicallyInvokable]
		public bool IsHideBySig
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.HideBySig) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the method is abstract.</summary>
		/// <returns>
		///   <see langword="true" /> if the method is abstract; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x060045F6 RID: 17910 RVA: 0x000FEF26 File Offset: 0x000FD126
		[__DynamicallyInvokable]
		public bool IsAbstract
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Abstract) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether this method has a special name.</summary>
		/// <returns>
		///   <see langword="true" /> if this method has a special name; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x060045F7 RID: 17911 RVA: 0x000FEF37 File Offset: 0x000FD137
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.SpecialName) > MethodAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the method is a constructor.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is a constructor represented by a <see cref="T:System.Reflection.ConstructorInfo" /> object (see note in Remarks about <see cref="T:System.Reflection.Emit.ConstructorBuilder" /> objects); otherwise, <see langword="false" />.</returns>
		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x060045F8 RID: 17912 RVA: 0x000FEF48 File Offset: 0x000FD148
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public bool IsConstructor
		{
			[__DynamicallyInvokable]
			get
			{
				return this is ConstructorInfo && !this.IsStatic && (this.Attributes & MethodAttributes.RTSpecialName) == MethodAttributes.RTSpecialName;
			}
		}

		/// <summary>When overridden in a derived class, gets a <see cref="T:System.Reflection.MethodBody" /> object that provides access to the MSIL stream, local variables, and exceptions for the current method.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodBody" /> object that provides access to the MSIL stream, local variables, and exceptions for the current method.</returns>
		/// <exception cref="T:System.InvalidOperationException">This method is invalid unless overridden in a derived class.</exception>
		// Token: 0x060045F9 RID: 17913 RVA: 0x000FEF6F File Offset: 0x000FD16F
		[SecuritySafeCritical]
		[ReflectionPermission(SecurityAction.Demand, Flags = ReflectionPermissionFlag.MemberAccess)]
		public virtual MethodBody GetMethodBody()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x060045FA RID: 17914 RVA: 0x000FEF78 File Offset: 0x000FD178
		internal static string ConstructParameters(Type[] parameterTypes, CallingConventions callingConvention, bool serialization)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = "";
			foreach (Type type in parameterTypes)
			{
				stringBuilder.Append(value);
				string text = type.FormatTypeName(serialization);
				if (type.IsByRef && !serialization)
				{
					stringBuilder.Append(text.TrimEnd(new char[]
					{
						'&'
					}));
					stringBuilder.Append(" ByRef");
				}
				else
				{
					stringBuilder.Append(text);
				}
				value = ", ";
			}
			if ((callingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
			{
				stringBuilder.Append(value);
				stringBuilder.Append("...");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x060045FB RID: 17915 RVA: 0x000FF015 File Offset: 0x000FD215
		internal string FullName
		{
			get
			{
				return string.Format("{0}.{1}", this.DeclaringType.FullName, this.FormatNameAndSig());
			}
		}

		// Token: 0x060045FC RID: 17916 RVA: 0x000FF032 File Offset: 0x000FD232
		internal string FormatNameAndSig()
		{
			return this.FormatNameAndSig(false);
		}

		// Token: 0x060045FD RID: 17917 RVA: 0x000FF03C File Offset: 0x000FD23C
		internal virtual string FormatNameAndSig(bool serialization)
		{
			StringBuilder stringBuilder = new StringBuilder(this.Name);
			stringBuilder.Append("(");
			stringBuilder.Append(MethodBase.ConstructParameters(this.GetParameterTypes(), this.CallingConvention, serialization));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		// Token: 0x060045FE RID: 17918 RVA: 0x000FF08C File Offset: 0x000FD28C
		internal virtual Type[] GetParameterTypes()
		{
			ParameterInfo[] parametersNoCopy = this.GetParametersNoCopy();
			Type[] array = new Type[parametersNoCopy.Length];
			for (int i = 0; i < parametersNoCopy.Length; i++)
			{
				array[i] = parametersNoCopy[i].ParameterType;
			}
			return array;
		}

		// Token: 0x060045FF RID: 17919 RVA: 0x000FF0C4 File Offset: 0x000FD2C4
		[SecuritySafeCritical]
		internal object[] CheckArguments(object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)
		{
			object[] array = new object[parameters.Length];
			ParameterInfo[] array2 = null;
			for (int i = 0; i < parameters.Length; i++)
			{
				object obj = parameters[i];
				RuntimeType runtimeType = sig.Arguments[i];
				if (obj == Type.Missing)
				{
					if (array2 == null)
					{
						array2 = this.GetParametersNoCopy();
					}
					if (array2[i].DefaultValue == DBNull.Value)
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_VarMissNull"), "parameters");
					}
					obj = array2[i].DefaultValue;
				}
				array[i] = runtimeType.CheckValue(obj, binder, culture, invokeAttr);
			}
			return array;
		}

		/// <summary>For a description of this member, see <see cref="M:System.Runtime.InteropServices._MethodBase.GetType" />.</summary>
		/// <returns>For a description of this member, see <see cref="M:System.Runtime.InteropServices._MethodBase.GetType" />.</returns>
		// Token: 0x06004600 RID: 17920 RVA: 0x000FF148 File Offset: 0x000FD348
		Type _MethodBase.GetType()
		{
			return base.GetType();
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsPublic" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsPublic" />.</returns>
		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06004601 RID: 17921 RVA: 0x000FF150 File Offset: 0x000FD350
		bool _MethodBase.IsPublic
		{
			get
			{
				return this.IsPublic;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsPrivate" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsPrivate" />.</returns>
		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06004602 RID: 17922 RVA: 0x000FF158 File Offset: 0x000FD358
		bool _MethodBase.IsPrivate
		{
			get
			{
				return this.IsPrivate;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamily" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamily" />.</returns>
		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06004603 RID: 17923 RVA: 0x000FF160 File Offset: 0x000FD360
		bool _MethodBase.IsFamily
		{
			get
			{
				return this.IsFamily;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsAssembly" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsAssembly" />.</returns>
		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x06004604 RID: 17924 RVA: 0x000FF168 File Offset: 0x000FD368
		bool _MethodBase.IsAssembly
		{
			get
			{
				return this.IsAssembly;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamilyAndAssembly" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamilyAndAssembly" />.</returns>
		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06004605 RID: 17925 RVA: 0x000FF170 File Offset: 0x000FD370
		bool _MethodBase.IsFamilyAndAssembly
		{
			get
			{
				return this.IsFamilyAndAssembly;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamilyOrAssembly" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFamilyOrAssembly" />.</returns>
		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06004606 RID: 17926 RVA: 0x000FF178 File Offset: 0x000FD378
		bool _MethodBase.IsFamilyOrAssembly
		{
			get
			{
				return this.IsFamilyOrAssembly;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsStatic" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsStatic" />.</returns>
		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06004607 RID: 17927 RVA: 0x000FF180 File Offset: 0x000FD380
		bool _MethodBase.IsStatic
		{
			get
			{
				return this.IsStatic;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFinal" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsFinal" />.</returns>
		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06004608 RID: 17928 RVA: 0x000FF188 File Offset: 0x000FD388
		bool _MethodBase.IsFinal
		{
			get
			{
				return this.IsFinal;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsVirtual" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsVirtual" />.</returns>
		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06004609 RID: 17929 RVA: 0x000FF190 File Offset: 0x000FD390
		bool _MethodBase.IsVirtual
		{
			get
			{
				return this.IsVirtual;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsHideBySig" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsHideBySig" />.</returns>
		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x0600460A RID: 17930 RVA: 0x000FF198 File Offset: 0x000FD398
		bool _MethodBase.IsHideBySig
		{
			get
			{
				return this.IsHideBySig;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsAbstract" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsAbstract" />.</returns>
		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x0600460B RID: 17931 RVA: 0x000FF1A0 File Offset: 0x000FD3A0
		bool _MethodBase.IsAbstract
		{
			get
			{
				return this.IsAbstract;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsSpecialName" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsSpecialName" />.</returns>
		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x0600460C RID: 17932 RVA: 0x000FF1A8 File Offset: 0x000FD3A8
		bool _MethodBase.IsSpecialName
		{
			get
			{
				return this.IsSpecialName;
			}
		}

		/// <summary>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsConstructor" />.</summary>
		/// <returns>For a description of this member, see <see cref="P:System.Runtime.InteropServices._MethodBase.IsConstructor" />.</returns>
		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x0600460D RID: 17933 RVA: 0x000FF1B0 File Offset: 0x000FD3B0
		bool _MethodBase.IsConstructor
		{
			get
			{
				return this.IsConstructor;
			}
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600460E RID: 17934 RVA: 0x000FF1B8 File Offset: 0x000FD3B8
		void _MethodBase.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600460F RID: 17935 RVA: 0x000FF1BF File Offset: 0x000FD3BF
		void _MethodBase.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x06004610 RID: 17936 RVA: 0x000FF1C6 File Offset: 0x000FD3C6
		void _MethodBase.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x06004611 RID: 17937 RVA: 0x000FF1CD File Offset: 0x000FD3CD
		void _MethodBase.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
