using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Discovers the attributes of a field and provides access to field metadata.</summary>
	// Token: 0x020005B8 RID: 1464
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_FieldInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class FieldInfo : MemberInfo, _FieldInfo
	{
		/// <summary>Gets a <see cref="T:System.Reflection.FieldInfo" /> for the field represented by the specified handle.</summary>
		/// <param name="handle">A <see cref="T:System.RuntimeFieldHandle" /> structure that contains the handle to the internal metadata representation of a field.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field specified by <paramref name="handle" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="handle" /> is invalid.</exception>
		// Token: 0x060044C8 RID: 17608 RVA: 0x000FCD6C File Offset: 0x000FAF6C
		[__DynamicallyInvokable]
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			FieldInfo fieldInfo = RuntimeType.GetFieldInfo(handle.GetRuntimeFieldInfo());
			Type declaringType = fieldInfo.DeclaringType;
			if (declaringType != null && declaringType.IsGenericType)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_FieldDeclaringTypeGeneric"), fieldInfo.Name, declaringType.GetGenericTypeDefinition()));
			}
			return fieldInfo;
		}

		/// <summary>Gets a <see cref="T:System.Reflection.FieldInfo" /> for the field represented by the specified handle, for the specified generic type.</summary>
		/// <param name="handle">A <see cref="T:System.RuntimeFieldHandle" /> structure that contains the handle to the internal metadata representation of a field.</param>
		/// <param name="declaringType">A <see cref="T:System.RuntimeTypeHandle" /> structure that contains the handle to the generic type that defines the field.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field specified by <paramref name="handle" />, in the generic type specified by <paramref name="declaringType" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="handle" /> is invalid.  
		/// -or-  
		/// <paramref name="declaringType" /> is not compatible with <paramref name="handle" />. For example, <paramref name="declaringType" /> is the runtime type handle of the generic type definition, and <paramref name="handle" /> comes from a constructed type.</exception>
		// Token: 0x060044C9 RID: 17609 RVA: 0x000FCDDE File Offset: 0x000FAFDE
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return RuntimeType.GetFieldInfo(declaringType.GetRuntimeType(), handle.GetRuntimeFieldInfo());
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.FieldInfo" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060044CB RID: 17611 RVA: 0x000FCE14 File Offset: 0x000FB014
		[__DynamicallyInvokable]
		public static bool operator ==(FieldInfo left, FieldInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeFieldInfo) && !(right is RuntimeFieldInfo) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.FieldInfo" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060044CC RID: 17612 RVA: 0x000FCE3B File Offset: 0x000FB03B
		[__DynamicallyInvokable]
		public static bool operator !=(FieldInfo left, FieldInfo right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060044CD RID: 17613 RVA: 0x000FCE47 File Offset: 0x000FB047
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060044CE RID: 17614 RVA: 0x000FCE50 File Offset: 0x000FB050
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a field.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a field.</returns>
		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x060044CF RID: 17615 RVA: 0x000FCE58 File Offset: 0x000FB058
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Field;
			}
		}

		/// <summary>Gets an array of types that identify the required custom modifiers of the property.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that identify the required custom modifiers of the current property, such as <see cref="T:System.Runtime.CompilerServices.IsConst" /> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced" />.</returns>
		// Token: 0x060044D0 RID: 17616 RVA: 0x000FCE5B File Offset: 0x000FB05B
		public virtual Type[] GetRequiredCustomModifiers()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets an array of types that identify the optional custom modifiers of the field.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that identify the optional custom modifiers of the current field, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />.</returns>
		// Token: 0x060044D1 RID: 17617 RVA: 0x000FCE62 File Offset: 0x000FB062
		public virtual Type[] GetOptionalCustomModifiers()
		{
			throw new NotImplementedException();
		}

		/// <summary>Sets the value of the field supported by the given object.</summary>
		/// <param name="obj">A <see cref="T:System.TypedReference" /> structure that encapsulates a managed pointer to a location and a runtime representation of the type that can be stored at that location.</param>
		/// <param name="value">The value to assign to the field.</param>
		/// <exception cref="T:System.NotSupportedException">The caller requires the Common Language Specification (CLS) alternative, but called this method instead.</exception>
		// Token: 0x060044D2 RID: 17618 RVA: 0x000FCE69 File Offset: 0x000FB069
		[CLSCompliant(false)]
		public virtual void SetValueDirect(TypedReference obj, object value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		/// <summary>Returns the value of a field supported by a given object.</summary>
		/// <param name="obj">A <see cref="T:System.TypedReference" /> structure that encapsulates a managed pointer to a location and a runtime representation of the type that might be stored at that location.</param>
		/// <returns>An <see langword="Object" /> containing a field value.</returns>
		/// <exception cref="T:System.NotSupportedException">The caller requires the Common Language Specification (CLS) alternative, but called this method instead.</exception>
		// Token: 0x060044D3 RID: 17619 RVA: 0x000FCE7A File Offset: 0x000FB07A
		[CLSCompliant(false)]
		public virtual object GetValueDirect(TypedReference obj)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		/// <summary>Gets a <see langword="RuntimeFieldHandle" />, which is a handle to the internal metadata representation of a field.</summary>
		/// <returns>A handle to the internal metadata representation of a field.</returns>
		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x060044D4 RID: 17620
		[__DynamicallyInvokable]
		public abstract RuntimeFieldHandle FieldHandle { [__DynamicallyInvokable] get; }

		/// <summary>Gets the type of this field object.</summary>
		/// <returns>The type of this field object.</returns>
		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x060044D5 RID: 17621
		[__DynamicallyInvokable]
		public abstract Type FieldType { [__DynamicallyInvokable] get; }

		/// <summary>When overridden in a derived class, returns the value of a field supported by a given object.</summary>
		/// <param name="obj">The object whose field value will be returned.</param>
		/// <returns>An object containing the value of the field reflected by this instance.</returns>
		/// <exception cref="T:System.Reflection.TargetException">In the .NET for Windows Store apps or the Portable Class Library, catch <see cref="T:System.Exception" /> instead.  
		///
		///
		///
		///
		///  The field is non-static and <paramref name="obj" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">A field is marked literal, but the field does not have one of the accepted literal types.</exception>
		/// <exception cref="T:System.FieldAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The caller does not have permission to access this field.</exception>
		/// <exception cref="T:System.ArgumentException">The method is neither declared nor inherited by the class of <paramref name="obj" />.</exception>
		// Token: 0x060044D6 RID: 17622
		[__DynamicallyInvokable]
		public abstract object GetValue(object obj);

		/// <summary>Returns a literal value associated with the field by a compiler.</summary>
		/// <returns>An <see cref="T:System.Object" /> that contains the literal value associated with the field. If the literal value is a class type with an element value of zero, the return value is <see langword="null" />.</returns>
		/// <exception cref="T:System.InvalidOperationException">The Constant table in unmanaged metadata does not contain a constant value for the current field.</exception>
		/// <exception cref="T:System.FormatException">The type of the value is not one of the types permitted by the Common Language Specification (CLS). See the ECMA Partition II specification Metadata Logical Format: Other Structures, Element Types used in Signatures.</exception>
		/// <exception cref="T:System.NotSupportedException">The constant value for the field is not set.</exception>
		// Token: 0x060044D7 RID: 17623 RVA: 0x000FCE8B File Offset: 0x000FB08B
		public virtual object GetRawConstantValue()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		/// <summary>When overridden in a derived class, sets the value of the field supported by the given object.</summary>
		/// <param name="obj">The object whose field value will be set.</param>
		/// <param name="value">The value to assign to the field.</param>
		/// <param name="invokeAttr">A field of <see langword="Binder" /> that specifies the type of binding that is desired (for example, <see langword="Binder.CreateInstance" /> or <see langword="Binder.ExactBinding" />).</param>
		/// <param name="binder">A set of properties that enables the binding, coercion of argument types, and invocation of members through reflection. If <paramref name="binder" /> is <see langword="null" />, then <see langword="Binder.DefaultBinding" /> is used.</param>
		/// <param name="culture">The software preferences of a particular culture.</param>
		/// <exception cref="T:System.FieldAccessException">The caller does not have permission to access this field.</exception>
		/// <exception cref="T:System.Reflection.TargetException">The <paramref name="obj" /> parameter is <see langword="null" /> and the field is an instance field.</exception>
		/// <exception cref="T:System.ArgumentException">The field does not exist on the object.  
		///  -or-  
		///  The <paramref name="value" /> parameter cannot be converted and stored in the field.</exception>
		// Token: 0x060044D8 RID: 17624
		public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);

		/// <summary>Gets the attributes associated with this field.</summary>
		/// <returns>The <see langword="FieldAttributes" /> for this field.</returns>
		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x060044D9 RID: 17625
		[__DynamicallyInvokable]
		public abstract FieldAttributes Attributes { [__DynamicallyInvokable] get; }

		/// <summary>Sets the value of the field supported by the given object.</summary>
		/// <param name="obj">The object whose field value will be set.</param>
		/// <param name="value">The value to assign to the field.</param>
		/// <exception cref="T:System.FieldAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.  
		///
		///
		///
		///
		///  The caller does not have permission to access this field.</exception>
		/// <exception cref="T:System.Reflection.TargetException">In the .NET for Windows Store apps or the Portable Class Library, catch <see cref="T:System.Exception" /> instead.  
		///
		///
		///
		///
		///  The <paramref name="obj" /> parameter is <see langword="null" /> and the field is an instance field.</exception>
		/// <exception cref="T:System.ArgumentException">The field does not exist on the object.  
		///  -or-  
		///  The <paramref name="value" /> parameter cannot be converted and stored in the field.</exception>
		// Token: 0x060044DA RID: 17626 RVA: 0x000FCE9C File Offset: 0x000FB09C
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public void SetValue(object obj, object value)
		{
			this.SetValue(obj, value, BindingFlags.Default, Type.DefaultBinder, null);
		}

		/// <summary>Gets a value indicating whether the field is public.</summary>
		/// <returns>
		///   <see langword="true" /> if this field is public; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x060044DB RID: 17627 RVA: 0x000FCEAD File Offset: 0x000FB0AD
		[__DynamicallyInvokable]
		public bool IsPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public;
			}
		}

		/// <summary>Gets a value indicating whether the field is private.</summary>
		/// <returns>
		///   <see langword="true" /> if the field is private; otherwise; <see langword="false" />.</returns>
		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x060044DC RID: 17628 RVA: 0x000FCEBA File Offset: 0x000FB0BA
		[__DynamicallyInvokable]
		public bool IsPrivate
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Private;
			}
		}

		/// <summary>Gets a value indicating whether the visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.Family" />; that is, the field is visible only within its class and derived classes.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.Family" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x060044DD RID: 17629 RVA: 0x000FCEC7 File Offset: 0x000FB0C7
		[__DynamicallyInvokable]
		public bool IsFamily
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Family;
			}
		}

		/// <summary>Gets a value indicating whether the potential visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.Assembly" />; that is, the field is visible at most to other types in the same assembly, and is not visible to derived types outside the assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the visibility of this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.Assembly" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x060044DE RID: 17630 RVA: 0x000FCED4 File Offset: 0x000FB0D4
		[__DynamicallyInvokable]
		public bool IsAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Assembly;
			}
		}

		/// <summary>Gets a value indicating whether the visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.FamANDAssem" />; that is, the field can be accessed from derived classes, but only if they are in the same assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.FamANDAssem" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x060044DF RID: 17631 RVA: 0x000FCEE1 File Offset: 0x000FB0E1
		[__DynamicallyInvokable]
		public bool IsFamilyAndAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamANDAssem;
			}
		}

		/// <summary>Gets a value indicating whether the potential visibility of this field is described by <see cref="F:System.Reflection.FieldAttributes.FamORAssem" />; that is, the field can be accessed by derived classes wherever they are, and by classes in the same assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this field is exactly described by <see cref="F:System.Reflection.FieldAttributes.FamORAssem" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x060044E0 RID: 17632 RVA: 0x000FCEEE File Offset: 0x000FB0EE
		[__DynamicallyInvokable]
		public bool IsFamilyOrAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamORAssem;
			}
		}

		/// <summary>Gets a value indicating whether the field is static.</summary>
		/// <returns>
		///   <see langword="true" /> if this field is static; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x060044E1 RID: 17633 RVA: 0x000FCEFB File Offset: 0x000FB0FB
		[__DynamicallyInvokable]
		public bool IsStatic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.Static) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the field can only be set in the body of the constructor.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="InitOnly" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x060044E2 RID: 17634 RVA: 0x000FCF09 File Offset: 0x000FB109
		[__DynamicallyInvokable]
		public bool IsInitOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.InitOnly) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the value is written at compile time and cannot be changed.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="Literal" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x060044E3 RID: 17635 RVA: 0x000FCF17 File Offset: 0x000FB117
		[__DynamicallyInvokable]
		public bool IsLiteral
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.Literal) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether this field has the <see langword="NotSerialized" /> attribute.</summary>
		/// <returns>
		///   <see langword="true" /> if the field has the <see langword="NotSerialized" /> attribute set; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x060044E4 RID: 17636 RVA: 0x000FCF25 File Offset: 0x000FB125
		public bool IsNotSerialized
		{
			get
			{
				return (this.Attributes & FieldAttributes.NotSerialized) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the corresponding <see langword="SpecialName" /> attribute is set in the <see cref="T:System.Reflection.FieldAttributes" /> enumerator.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see langword="SpecialName" /> attribute is set in <see cref="T:System.Reflection.FieldAttributes" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x060044E5 RID: 17637 RVA: 0x000FCF36 File Offset: 0x000FB136
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.SpecialName) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value indicating whether the corresponding <see langword="PinvokeImpl" /> attribute is set in <see cref="T:System.Reflection.FieldAttributes" />.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see langword="PinvokeImpl" /> attribute is set in <see cref="T:System.Reflection.FieldAttributes" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A67 RID: 2663
		// (get) Token: 0x060044E6 RID: 17638 RVA: 0x000FCF47 File Offset: 0x000FB147
		public bool IsPinvokeImpl
		{
			get
			{
				return (this.Attributes & FieldAttributes.PinvokeImpl) > FieldAttributes.PrivateScope;
			}
		}

		/// <summary>Gets a value that indicates whether the current field is security-critical or security-safe-critical at the current trust level.</summary>
		/// <returns>
		///   <see langword="true" /> if the current field is security-critical or security-safe-critical at the current trust level; <see langword="false" /> if it is transparent.</returns>
		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x060044E7 RID: 17639 RVA: 0x000FCF58 File Offset: 0x000FB158
		public virtual bool IsSecurityCritical
		{
			get
			{
				return this.FieldHandle.IsSecurityCritical();
			}
		}

		/// <summary>Gets a value that indicates whether the current field is security-safe-critical at the current trust level.</summary>
		/// <returns>
		///   <see langword="true" /> if the current field is security-safe-critical at the current trust level; <see langword="false" /> if it is security-critical or transparent.</returns>
		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x060044E8 RID: 17640 RVA: 0x000FCF74 File Offset: 0x000FB174
		public virtual bool IsSecuritySafeCritical
		{
			get
			{
				return this.FieldHandle.IsSecuritySafeCritical();
			}
		}

		/// <summary>Gets a value that indicates whether the current field is transparent at the current trust level.</summary>
		/// <returns>
		///   <see langword="true" /> if the field is security-transparent at the current trust level; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x060044E9 RID: 17641 RVA: 0x000FCF90 File Offset: 0x000FB190
		public virtual bool IsSecurityTransparent
		{
			get
			{
				return this.FieldHandle.IsSecurityTransparent();
			}
		}

		/// <summary>Gets a <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.FieldInfo" /> type.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.FieldInfo" /> type.</returns>
		// Token: 0x060044EA RID: 17642 RVA: 0x000FCFAB File Offset: 0x000FB1AB
		Type _FieldInfo.GetType()
		{
			return base.GetType();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044EB RID: 17643 RVA: 0x000FCFB3 File Offset: 0x000FB1B3
		void _FieldInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060044EC RID: 17644 RVA: 0x000FCFBA File Offset: 0x000FB1BA
		void _FieldInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x060044ED RID: 17645 RVA: 0x000FCFC1 File Offset: 0x000FB1C1
		void _FieldInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x060044EE RID: 17646 RVA: 0x000FCFC8 File Offset: 0x000FB1C8
		void _FieldInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
