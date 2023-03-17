using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Defines and represents a field. This class cannot be inherited.</summary>
	// Token: 0x0200060E RID: 1550
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_FieldBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class FieldBuilder : FieldInfo, _FieldBuilder
	{
		// Token: 0x06004959 RID: 18777 RVA: 0x00108B4C File Offset: 0x00106D4C
		[SecurityCritical]
		internal FieldBuilder(TypeBuilder typeBuilder, string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
		{
			if (fieldName == null)
			{
				throw new ArgumentNullException("fieldName");
			}
			if (fieldName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "fieldName");
			}
			if (fieldName[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "fieldName");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (type == typeof(void))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadFieldType"));
			}
			this.m_fieldName = fieldName;
			this.m_typeBuilder = typeBuilder;
			this.m_fieldType = type;
			this.m_Attributes = (attributes & ~FieldAttributes.ReservedMask);
			SignatureHelper fieldSigHelper = SignatureHelper.GetFieldSigHelper(this.m_typeBuilder.Module);
			fieldSigHelper.AddArgument(type, requiredCustomModifiers, optionalCustomModifiers);
			int sigLength;
			byte[] signature = fieldSigHelper.InternalGetSignature(out sigLength);
			this.m_fieldTok = TypeBuilder.DefineField(this.m_typeBuilder.GetModuleBuilder().GetNativeHandle(), typeBuilder.TypeToken.Token, fieldName, signature, sigLength, this.m_Attributes);
			this.m_tkField = new FieldToken(this.m_fieldTok, type);
		}

		// Token: 0x0600495A RID: 18778 RVA: 0x00108C6A File Offset: 0x00106E6A
		[SecurityCritical]
		internal void SetData(byte[] data, int size)
		{
			ModuleBuilder.SetFieldRVAContent(this.m_typeBuilder.GetModuleBuilder().GetNativeHandle(), this.m_tkField.Token, data, size);
		}

		// Token: 0x0600495B RID: 18779 RVA: 0x00108C8E File Offset: 0x00106E8E
		internal TypeBuilder GetTypeBuilder()
		{
			return this.m_typeBuilder;
		}

		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x0600495C RID: 18780 RVA: 0x00108C96 File Offset: 0x00106E96
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_fieldTok;
			}
		}

		/// <summary>Gets the module in which the type that contains this field is being defined.</summary>
		/// <returns>A <see cref="T:System.Reflection.Module" /> that represents the dynamic module in which this field is being defined.</returns>
		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x0600495D RID: 18781 RVA: 0x00108C9E File Offset: 0x00106E9E
		public override Module Module
		{
			get
			{
				return this.m_typeBuilder.Module;
			}
		}

		/// <summary>Indicates the name of this field. This property is read-only.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the name of this field.</returns>
		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x0600495E RID: 18782 RVA: 0x00108CAB File Offset: 0x00106EAB
		public override string Name
		{
			get
			{
				return this.m_fieldName;
			}
		}

		/// <summary>Indicates a reference to the <see cref="T:System.Type" /> object for the type that declares this field. This property is read-only.</summary>
		/// <returns>A reference to the <see cref="T:System.Type" /> object for the type that declares this field.</returns>
		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x0600495F RID: 18783 RVA: 0x00108CB3 File Offset: 0x00106EB3
		public override Type DeclaringType
		{
			get
			{
				if (this.m_typeBuilder.m_isHiddenGlobalType)
				{
					return null;
				}
				return this.m_typeBuilder;
			}
		}

		/// <summary>Indicates the reference to the <see cref="T:System.Type" /> object from which this object was obtained. This property is read-only.</summary>
		/// <returns>A reference to the <see cref="T:System.Type" /> object from which this instance was obtained.</returns>
		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x06004960 RID: 18784 RVA: 0x00108CCA File Offset: 0x00106ECA
		public override Type ReflectedType
		{
			get
			{
				if (this.m_typeBuilder.m_isHiddenGlobalType)
				{
					return null;
				}
				return this.m_typeBuilder;
			}
		}

		/// <summary>Indicates the <see cref="T:System.Type" /> object that represents the type of this field. This property is read-only.</summary>
		/// <returns>The <see cref="T:System.Type" /> object that represents the type of this field.</returns>
		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x06004961 RID: 18785 RVA: 0x00108CE1 File Offset: 0x00106EE1
		public override Type FieldType
		{
			get
			{
				return this.m_fieldType;
			}
		}

		/// <summary>Retrieves the value of the field supported by the given object.</summary>
		/// <param name="obj">The object on which to access the field.</param>
		/// <returns>An <see cref="T:System.Object" /> containing the value of the field reflected by this instance.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004962 RID: 18786 RVA: 0x00108CE9 File Offset: 0x00106EE9
		public override object GetValue(object obj)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Sets the value of the field supported by the given object.</summary>
		/// <param name="obj">The object on which to access the field.</param>
		/// <param name="val">The value to assign to the field.</param>
		/// <param name="invokeAttr">A member of <see langword="IBinder" /> that specifies the type of binding that is desired (for example, IBinder.CreateInstance, IBinder.ExactBinding).</param>
		/// <param name="binder">A set of properties and enabling for binding, coercion of argument types, and invocation of members using reflection. If binder is null, then IBinder.DefaultBinding is used.</param>
		/// <param name="culture">The software preferences of a particular culture.</param>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004963 RID: 18787 RVA: 0x00108CFA File Offset: 0x00106EFA
		public override void SetValue(object obj, object val, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Indicates the internal metadata handle for this field. This property is read-only.</summary>
		/// <returns>The internal metadata handle for this field.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06004964 RID: 18788 RVA: 0x00108D0B File Offset: 0x00106F0B
		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
			}
		}

		/// <summary>Indicates the attributes of this field. This property is read-only.</summary>
		/// <returns>The attributes of this field.</returns>
		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06004965 RID: 18789 RVA: 0x00108D1C File Offset: 0x00106F1C
		public override FieldAttributes Attributes
		{
			get
			{
				return this.m_Attributes;
			}
		}

		/// <summary>Returns all the custom attributes defined for this field.</summary>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes.</param>
		/// <returns>An array of type <see cref="T:System.Object" /> representing all the custom attributes of the constructor represented by this <see cref="T:System.Reflection.Emit.FieldBuilder" /> instance.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004966 RID: 18790 RVA: 0x00108D24 File Offset: 0x00106F24
		public override object[] GetCustomAttributes(bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns all the custom attributes defined for this field identified by the given type.</summary>
		/// <param name="attributeType">The custom attribute type.</param>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes.</param>
		/// <returns>An array of type <see cref="T:System.Object" /> representing all the custom attributes of the constructor represented by this <see cref="T:System.Reflection.Emit.FieldBuilder" /> instance.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004967 RID: 18791 RVA: 0x00108D35 File Offset: 0x00106F35
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Indicates whether an attribute having the specified type is defined on a field.</summary>
		/// <param name="attributeType">The type of the attribute.</param>
		/// <param name="inherit">Controls inheritance of custom attributes from base classes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of <paramref name="attributeType" /> is defined on this field; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported. Retrieve the field using <see cref="M:System.Type.GetField(System.String,System.Reflection.BindingFlags)" /> and call <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> on the returned <see cref="T:System.Reflection.FieldInfo" />.</exception>
		// Token: 0x06004968 RID: 18792 RVA: 0x00108D46 File Offset: 0x00106F46
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns the token representing this field.</summary>
		/// <returns>The <see cref="T:System.Reflection.Emit.FieldToken" /> object that represents the token for this field.</returns>
		// Token: 0x06004969 RID: 18793 RVA: 0x00108D57 File Offset: 0x00106F57
		public FieldToken GetToken()
		{
			return this.m_tkField;
		}

		/// <summary>Specifies the field layout.</summary>
		/// <param name="iOffset">The offset of the field within the type containing this field.</param>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="iOffset" /> is less than zero.</exception>
		// Token: 0x0600496A RID: 18794 RVA: 0x00108D60 File Offset: 0x00106F60
		[SecuritySafeCritical]
		public void SetOffset(int iOffset)
		{
			this.m_typeBuilder.ThrowIfCreated();
			TypeBuilder.SetFieldLayoutOffset(this.m_typeBuilder.GetModuleBuilder().GetNativeHandle(), this.GetToken().Token, iOffset);
		}

		/// <summary>Describes the native marshaling of the field.</summary>
		/// <param name="unmanagedMarshal">A descriptor specifying the native marshalling of this field.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="unmanagedMarshal" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x0600496B RID: 18795 RVA: 0x00108D9C File Offset: 0x00106F9C
		[SecuritySafeCritical]
		[Obsolete("An alternate API is available: Emit the MarshalAs custom attribute instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public void SetMarshal(UnmanagedMarshal unmanagedMarshal)
		{
			if (unmanagedMarshal == null)
			{
				throw new ArgumentNullException("unmanagedMarshal");
			}
			this.m_typeBuilder.ThrowIfCreated();
			byte[] array = unmanagedMarshal.InternalGetBytes();
			TypeBuilder.SetFieldMarshal(this.m_typeBuilder.GetModuleBuilder().GetNativeHandle(), this.GetToken().Token, array, array.Length);
		}

		/// <summary>Sets the default value of this field.</summary>
		/// <param name="defaultValue">The new default value for this field.</param>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		/// <exception cref="T:System.ArgumentException">The field is not one of the supported types.  
		///  -or-  
		///  The type of <paramref name="defaultValue" /> does not match the type of the field.  
		///  -or-  
		///  The field is of type <see cref="T:System.Object" /> or other reference type, <paramref name="defaultValue" /> is not <see langword="null" />, and the value cannot be assigned to the reference type.</exception>
		// Token: 0x0600496C RID: 18796 RVA: 0x00108DF0 File Offset: 0x00106FF0
		[SecuritySafeCritical]
		public void SetConstant(object defaultValue)
		{
			this.m_typeBuilder.ThrowIfCreated();
			TypeBuilder.SetConstantValue(this.m_typeBuilder.GetModuleBuilder(), this.GetToken().Token, this.m_fieldType, defaultValue);
		}

		/// <summary>Sets a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The parent type of this field is complete.</exception>
		// Token: 0x0600496D RID: 18797 RVA: 0x00108E30 File Offset: 0x00107030
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
			ModuleBuilder moduleBuilder = this.m_typeBuilder.Module as ModuleBuilder;
			this.m_typeBuilder.ThrowIfCreated();
			TypeBuilder.DefineCustomAttribute(moduleBuilder, this.m_tkField.Token, moduleBuilder.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		/// <summary>Sets a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The parent type of this field is complete.</exception>
		// Token: 0x0600496E RID: 18798 RVA: 0x00108EA0 File Offset: 0x001070A0
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			this.m_typeBuilder.ThrowIfCreated();
			ModuleBuilder mod = this.m_typeBuilder.Module as ModuleBuilder;
			customBuilder.CreateCustomAttribute(mod, this.m_tkField.Token);
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x0600496F RID: 18799 RVA: 0x00108EE9 File Offset: 0x001070E9
		void _FieldBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004970 RID: 18800 RVA: 0x00108EF0 File Offset: 0x001070F0
		void _FieldBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x06004971 RID: 18801 RVA: 0x00108EF7 File Offset: 0x001070F7
		void _FieldBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x06004972 RID: 18802 RVA: 0x00108EFE File Offset: 0x001070FE
		void _FieldBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001DFA RID: 7674
		private int m_fieldTok;

		// Token: 0x04001DFB RID: 7675
		private FieldToken m_tkField;

		// Token: 0x04001DFC RID: 7676
		private TypeBuilder m_typeBuilder;

		// Token: 0x04001DFD RID: 7677
		private string m_fieldName;

		// Token: 0x04001DFE RID: 7678
		private FieldAttributes m_Attributes;

		// Token: 0x04001DFF RID: 7679
		private Type m_fieldType;
	}
}
