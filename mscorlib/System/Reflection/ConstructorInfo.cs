using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Discovers the attributes of a class constructor and provides access to constructor metadata.</summary>
	// Token: 0x020005A5 RID: 1445
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ConstructorInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class ConstructorInfo : MethodBase, _ConstructorInfo
	{
		/// <summary>Indicates whether two <see cref="T:System.Reflection.ConstructorInfo" /> objects are equal.</summary>
		/// <param name="left">The first <see cref="T:System.Reflection.ConstructorInfo" /> to compare.</param>
		/// <param name="right">The second <see cref="T:System.Reflection.ConstructorInfo" /> to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise <see langword="false" />.</returns>
		// Token: 0x060043C8 RID: 17352 RVA: 0x000F88DC File Offset: 0x000F6ADC
		[__DynamicallyInvokable]
		public static bool operator ==(ConstructorInfo left, ConstructorInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeConstructorInfo) && !(right is RuntimeConstructorInfo) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.ConstructorInfo" /> objects are not equal.</summary>
		/// <param name="left">The first <see cref="T:System.Reflection.ConstructorInfo" /> to compare.</param>
		/// <param name="right">The second <see cref="T:System.Reflection.ConstructorInfo" /> to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise <see langword="false" />.</returns>
		// Token: 0x060043C9 RID: 17353 RVA: 0x000F8903 File Offset: 0x000F6B03
		[__DynamicallyInvokable]
		public static bool operator !=(ConstructorInfo left, ConstructorInfo right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060043CA RID: 17354 RVA: 0x000F890F File Offset: 0x000F6B0F
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060043CB RID: 17355 RVA: 0x000F8918 File Offset: 0x000F6B18
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060043CC RID: 17356 RVA: 0x000F8920 File Offset: 0x000F6B20
		internal virtual Type GetReturnType()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a constructor.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a constructor.</returns>
		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x060043CD RID: 17357 RVA: 0x000F8927 File Offset: 0x000F6B27
		[ComVisible(true)]
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Constructor;
			}
		}

		/// <summary>When implemented in a derived class, invokes the constructor reflected by this <see langword="ConstructorInfo" /> with the specified arguments, under the constraints of the specified <see langword="Binder" />.</summary>
		/// <param name="invokeAttr">One of the <see langword="BindingFlags" /> values that specifies the type of binding.</param>
		/// <param name="binder">A <see langword="Binder" /> that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder" /> is <see langword="null" />, then <see langword="Binder.DefaultBinding" /> is used.</param>
		/// <param name="parameters">An array of type <see langword="Object" /> used to match the number, order and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements, as in Object[] parameters = new Object[0]. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used.</param>
		/// <returns>An instance of the class associated with the constructor.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="parameters" /> array does not contain values that match the types accepted by this constructor, under the constraints of the <paramref name="binder" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The invoked constructor throws an exception.</exception>
		/// <exception cref="T:System.Reflection.TargetParameterCountException">An incorrect number of parameters was passed.</exception>
		/// <exception cref="T:System.NotSupportedException">Creation of <see cref="T:System.TypedReference" />, <see cref="T:System.ArgIterator" />, and <see cref="T:System.RuntimeArgumentHandle" /> types is not supported.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the necessary code access permissions.</exception>
		/// <exception cref="T:System.MemberAccessException">The class is abstract.  
		///  -or-  
		///  The constructor is a class initializer.</exception>
		/// <exception cref="T:System.MethodAccessException">The constructor is private or protected, and the caller lacks <see cref="F:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess" />.</exception>
		// Token: 0x060043CE RID: 17358
		public abstract object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		/// <summary>Invokes the constructor reflected by the instance that has the specified parameters, providing default values for the parameters not commonly used.</summary>
		/// <param name="parameters">An array of values that matches the number, order and type (under the constraints of the default binder) of the parameters for this constructor. If this constructor takes no parameters, then use either an array with zero elements or <see langword="null" />, as in Object[] parameters = new Object[0]. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <returns>An instance of the class associated with the constructor.</returns>
		/// <exception cref="T:System.MemberAccessException">The class is abstract.  
		///  -or-  
		///  The constructor is a class initializer.</exception>
		/// <exception cref="T:System.MethodAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The constructor is private or protected, and the caller lacks <see cref="F:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="parameters" /> array does not contain values that match the types accepted by this constructor.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The invoked constructor throws an exception.</exception>
		/// <exception cref="T:System.Reflection.TargetParameterCountException">An incorrect number of parameters was passed.</exception>
		/// <exception cref="T:System.NotSupportedException">Creation of <see cref="T:System.TypedReference" />, <see cref="T:System.ArgIterator" />, and <see cref="T:System.RuntimeArgumentHandle" /> types is not supported.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the necessary code access permission.</exception>
		// Token: 0x060043CF RID: 17359 RVA: 0x000F892A File Offset: 0x000F6B2A
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public object Invoke(object[] parameters)
		{
			return this.Invoke(BindingFlags.Default, null, parameters, null);
		}

		/// <summary>Gets a <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.ConstructorInfo" /> type.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.ConstructorInfo" /> type.</returns>
		// Token: 0x060043D0 RID: 17360 RVA: 0x000F8936 File Offset: 0x000F6B36
		Type _ConstructorInfo.GetType()
		{
			return base.GetType();
		}

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="obj">The instance that created this method.</param>
		/// <param name="invokeAttr">One of the <see cref="T:System.Reflection.BindingFlags" /> values that specifies the type of binding.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder" /> is <see langword="null" />, then <see cref="P:System.Type.DefaultBinder" /> is used.</param>
		/// <param name="parameters">An array of objects used to match the number, order, and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used.</param>
		/// <returns>An instance of the type.</returns>
		// Token: 0x060043D1 RID: 17361 RVA: 0x000F893E File Offset: 0x000F6B3E
		object _ConstructorInfo.Invoke_2(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			return this.Invoke(obj, invokeAttr, binder, parameters, culture);
		}

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.Invoke(System.Object,System.Object[])" /> method.</summary>
		/// <param name="obj">The instance that created this method.</param>
		/// <param name="parameters">An array of objects used to match the number, order, and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <returns>An instance of the type.</returns>
		// Token: 0x060043D2 RID: 17362 RVA: 0x000F894D File Offset: 0x000F6B4D
		object _ConstructorInfo.Invoke_3(object obj, object[] parameters)
		{
			return base.Invoke(obj, parameters);
		}

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.ConstructorInfo.Invoke(System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="invokeAttr">One of the <see cref="T:System.Reflection.BindingFlags" /> values that specifies the type of binding.</param>
		/// <param name="binder">A <see cref="T:System.Reflection.Binder" /> that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder" /> is <see langword="null" />, then <see cref="P:System.Type.DefaultBinder" /> is used.</param>
		/// <param name="parameters">An array of objects used to match the number, order, and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used.</param>
		/// <returns>An instance of the type.</returns>
		// Token: 0x060043D3 RID: 17363 RVA: 0x000F8957 File Offset: 0x000F6B57
		object _ConstructorInfo.Invoke_4(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			return this.Invoke(invokeAttr, binder, parameters, culture);
		}

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.ConstructorInfo.Invoke(System.Object[])" /> method.</summary>
		/// <param name="parameters">An array of objects used to match the number, order, and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is <see langword="null" />. For value-type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <returns>An instance of the type.</returns>
		// Token: 0x060043D4 RID: 17364 RVA: 0x000F8964 File Offset: 0x000F6B64
		object _ConstructorInfo.Invoke_5(object[] parameters)
		{
			return this.Invoke(parameters);
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060043D5 RID: 17365 RVA: 0x000F896D File Offset: 0x000F6B6D
		void _ConstructorInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060043D6 RID: 17366 RVA: 0x000F8974 File Offset: 0x000F6B74
		void _ConstructorInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x060043D7 RID: 17367 RVA: 0x000F897B File Offset: 0x000F6B7B
		void _ConstructorInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x060043D8 RID: 17368 RVA: 0x000F8982 File Offset: 0x000F6B82
		void _ConstructorInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>Represents the name of the class constructor method as it is stored in metadata. This name is always ".ctor". This field is read-only.</summary>
		// Token: 0x04001B8F RID: 7055
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public static readonly string ConstructorName = ".ctor";

		/// <summary>Represents the name of the type constructor method as it is stored in metadata. This name is always ".cctor". This property is read-only.</summary>
		// Token: 0x04001B90 RID: 7056
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public static readonly string TypeConstructorName = ".cctor";
	}
}
