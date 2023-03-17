using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	/// <summary>Discovers the attributes of a parameter and provides access to parameter metadata.</summary>
	// Token: 0x020005E9 RID: 1513
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ParameterInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class ParameterInfo : _ParameterInfo, ICustomAttributeProvider, IObjectReference
	{
		/// <summary>Initializes a new instance of the <see langword="ParameterInfo" /> class.</summary>
		// Token: 0x060046F1 RID: 18161 RVA: 0x001016FD File Offset: 0x000FF8FD
		protected ParameterInfo()
		{
		}

		// Token: 0x060046F2 RID: 18162 RVA: 0x00101705 File Offset: 0x000FF905
		internal void SetName(string name)
		{
			this.NameImpl = name;
		}

		// Token: 0x060046F3 RID: 18163 RVA: 0x0010170E File Offset: 0x000FF90E
		internal void SetAttributes(ParameterAttributes attributes)
		{
			this.AttrsImpl = attributes;
		}

		/// <summary>Gets the <see langword="Type" /> of this parameter.</summary>
		/// <returns>The <see langword="Type" /> object that represents the <see langword="Type" /> of this parameter.</returns>
		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x060046F4 RID: 18164 RVA: 0x00101717 File Offset: 0x000FF917
		[__DynamicallyInvokable]
		public virtual Type ParameterType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.ClassImpl;
			}
		}

		/// <summary>Gets the name of the parameter.</summary>
		/// <returns>The simple name of this parameter.</returns>
		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x060046F5 RID: 18165 RVA: 0x0010171F File Offset: 0x000FF91F
		[__DynamicallyInvokable]
		public virtual string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.NameImpl;
			}
		}

		/// <summary>Gets a value that indicates whether this parameter has a default value.</summary>
		/// <returns>
		///   <see langword="true" /> if this parameter has a default value; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x060046F6 RID: 18166 RVA: 0x00101727 File Offset: 0x000FF927
		[__DynamicallyInvokable]
		public virtual bool HasDefaultValue
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value indicating the default value if the parameter has a default value.</summary>
		/// <returns>The default value of the parameter, or <see cref="F:System.DBNull.Value" /> if the parameter has no default value.</returns>
		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x060046F7 RID: 18167 RVA: 0x0010172E File Offset: 0x000FF92E
		[__DynamicallyInvokable]
		public virtual object DefaultValue
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value indicating the default value if the parameter has a default value.</summary>
		/// <returns>The default value of the parameter, or <see cref="F:System.DBNull.Value" /> if the parameter has no default value.</returns>
		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x060046F8 RID: 18168 RVA: 0x00101735 File Offset: 0x000FF935
		public virtual object RawDefaultValue
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the zero-based position of the parameter in the formal parameter list.</summary>
		/// <returns>An integer representing the position this parameter occupies in the parameter list.</returns>
		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x060046F9 RID: 18169 RVA: 0x0010173C File Offset: 0x000FF93C
		[__DynamicallyInvokable]
		public virtual int Position
		{
			[__DynamicallyInvokable]
			get
			{
				return this.PositionImpl;
			}
		}

		/// <summary>Gets the attributes for this parameter.</summary>
		/// <returns>A <see langword="ParameterAttributes" /> object representing the attributes for this parameter.</returns>
		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x060046FA RID: 18170 RVA: 0x00101744 File Offset: 0x000FF944
		[__DynamicallyInvokable]
		public virtual ParameterAttributes Attributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.AttrsImpl;
			}
		}

		/// <summary>Gets a value indicating the member in which the parameter is implemented.</summary>
		/// <returns>The member which implanted the parameter represented by this <see cref="T:System.Reflection.ParameterInfo" />.</returns>
		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x060046FB RID: 18171 RVA: 0x0010174C File Offset: 0x000FF94C
		[__DynamicallyInvokable]
		public virtual MemberInfo Member
		{
			[__DynamicallyInvokable]
			get
			{
				return this.MemberImpl;
			}
		}

		/// <summary>Gets a value indicating whether this is an input parameter.</summary>
		/// <returns>
		///   <see langword="true" /> if the parameter is an input parameter; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x060046FC RID: 18172 RVA: 0x00101754 File Offset: 0x000FF954
		[__DynamicallyInvokable]
		public bool IsIn
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.In) > ParameterAttributes.None;
			}
		}

		/// <summary>Gets a value indicating whether this is an output parameter.</summary>
		/// <returns>
		///   <see langword="true" /> if the parameter is an output parameter; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x060046FD RID: 18173 RVA: 0x00101761 File Offset: 0x000FF961
		[__DynamicallyInvokable]
		public bool IsOut
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Out) > ParameterAttributes.None;
			}
		}

		/// <summary>Gets a value indicating whether this parameter is a locale identifier (lcid).</summary>
		/// <returns>
		///   <see langword="true" /> if the parameter is a locale identifier; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x060046FE RID: 18174 RVA: 0x0010176E File Offset: 0x000FF96E
		[__DynamicallyInvokable]
		public bool IsLcid
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Lcid) > ParameterAttributes.None;
			}
		}

		/// <summary>Gets a value indicating whether this is a <see langword="Retval" /> parameter.</summary>
		/// <returns>
		///   <see langword="true" /> if the parameter is a <see langword="Retval" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x060046FF RID: 18175 RVA: 0x0010177B File Offset: 0x000FF97B
		[__DynamicallyInvokable]
		public bool IsRetval
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Retval) > ParameterAttributes.None;
			}
		}

		/// <summary>Gets a value indicating whether this parameter is optional.</summary>
		/// <returns>
		///   <see langword="true" /> if the parameter is optional; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x06004700 RID: 18176 RVA: 0x00101788 File Offset: 0x000FF988
		[__DynamicallyInvokable]
		public bool IsOptional
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & ParameterAttributes.Optional) > ParameterAttributes.None;
			}
		}

		/// <summary>Gets a value that identifies this parameter in metadata.</summary>
		/// <returns>A value which, in combination with the module, uniquely identifies this parameter in metadata.</returns>
		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x06004701 RID: 18177 RVA: 0x00101798 File Offset: 0x000FF998
		public virtual int MetadataToken
		{
			get
			{
				RuntimeParameterInfo runtimeParameterInfo = this as RuntimeParameterInfo;
				if (runtimeParameterInfo != null)
				{
					return runtimeParameterInfo.MetadataToken;
				}
				return 134217728;
			}
		}

		/// <summary>Gets the required custom modifiers of the parameter.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that identify the required custom modifiers of the current parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" /> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced" />.</returns>
		// Token: 0x06004702 RID: 18178 RVA: 0x001017BB File Offset: 0x000FF9BB
		public virtual Type[] GetRequiredCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		/// <summary>Gets the optional custom modifiers of the parameter.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that identify the optional custom modifiers of the current parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" /> or <see cref="T:System.Runtime.CompilerServices.IsImplicitlyDereferenced" />.</returns>
		// Token: 0x06004703 RID: 18179 RVA: 0x001017C2 File Offset: 0x000FF9C2
		public virtual Type[] GetOptionalCustomModifiers()
		{
			return EmptyArray<Type>.Value;
		}

		/// <summary>Gets the parameter type and name represented as a string.</summary>
		/// <returns>A string containing the type and the name of the parameter.</returns>
		// Token: 0x06004704 RID: 18180 RVA: 0x001017C9 File Offset: 0x000FF9C9
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.ParameterType.FormatTypeName() + " " + this.Name;
		}

		/// <summary>Gets a collection that contains this parameter's custom attributes.</summary>
		/// <returns>A collection that contains this parameter's custom attributes.</returns>
		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x06004705 RID: 18181 RVA: 0x001017E6 File Offset: 0x000FF9E6
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		/// <summary>Gets all the custom attributes defined on this parameter.</summary>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array that contains all the custom attributes applied to this parameter.</returns>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded.</exception>
		// Token: 0x06004706 RID: 18182 RVA: 0x001017EE File Offset: 0x000FF9EE
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			return EmptyArray<object>.Value;
		}

		/// <summary>Gets the custom attributes of the specified type or its derived types that are applied to this parameter.</summary>
		/// <param name="attributeType">The custom attributes identified by type.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array that contains the custom attributes of the specified type or its derived types.</returns>
		/// <exception cref="T:System.ArgumentException">The type must be a type provided by the underlying runtime system.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded.</exception>
		// Token: 0x06004707 RID: 18183 RVA: 0x001017F5 File Offset: 0x000FF9F5
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			return EmptyArray<object>.Value;
		}

		/// <summary>Determines whether the custom attribute of the specified type or its derived types is applied to this parameter.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to search for.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of <paramref name="attributeType" /> or its derived types are applied to this parameter; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a <see cref="T:System.Type" /> object supplied by the common language runtime.</exception>
		// Token: 0x06004708 RID: 18184 RVA: 0x00101810 File Offset: 0x000FFA10
		[__DynamicallyInvokable]
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			return false;
		}

		/// <summary>Returns a list of <see cref="T:System.Reflection.CustomAttributeData" /> objects for the current parameter, which can be used in the reflection-only context.</summary>
		/// <returns>A generic list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the current parameter.</returns>
		// Token: 0x06004709 RID: 18185 RVA: 0x00101827 File Offset: 0x000FFA27
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600470A RID: 18186 RVA: 0x0010182E File Offset: 0x000FFA2E
		void _ParameterInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600470B RID: 18187 RVA: 0x00101835 File Offset: 0x000FFA35
		void _ParameterInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x0600470C RID: 18188 RVA: 0x0010183C File Offset: 0x000FFA3C
		void _ParameterInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x0600470D RID: 18189 RVA: 0x00101843 File Offset: 0x000FFA43
		void _ParameterInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns the real object that should be deserialized instead of the object that the serialized stream specifies.</summary>
		/// <param name="context">The serialized stream from which the current object is deserialized.</param>
		/// <returns>The actual object that is put into the graph.</returns>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The parameter's position in the parameter list of its associated member is not valid for that member's type.</exception>
		// Token: 0x0600470E RID: 18190 RVA: 0x0010184C File Offset: 0x000FFA4C
		[SecurityCritical]
		public object GetRealObject(StreamingContext context)
		{
			if (this.MemberImpl == null)
			{
				throw new SerializationException(Environment.GetResourceString("Serialization_InsufficientState"));
			}
			MemberTypes memberType = this.MemberImpl.MemberType;
			if (memberType != MemberTypes.Constructor && memberType != MemberTypes.Method)
			{
				if (memberType != MemberTypes.Property)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_NoParameterInfo"));
				}
				ParameterInfo[] array = ((RuntimePropertyInfo)this.MemberImpl).GetIndexParametersNoCopy();
				if (array != null && this.PositionImpl > -1 && this.PositionImpl < array.Length)
				{
					return array[this.PositionImpl];
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
			else if (this.PositionImpl == -1)
			{
				if (this.MemberImpl.MemberType == MemberTypes.Method)
				{
					return ((MethodInfo)this.MemberImpl).ReturnParameter;
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
			else
			{
				ParameterInfo[] array = ((MethodBase)this.MemberImpl).GetParametersNoCopy();
				if (array != null && this.PositionImpl < array.Length)
				{
					return array[this.PositionImpl];
				}
				throw new SerializationException(Environment.GetResourceString("Serialization_BadParameterInfo"));
			}
		}

		/// <summary>The name of the parameter.</summary>
		// Token: 0x04001D31 RID: 7473
		protected string NameImpl;

		/// <summary>The <see langword="Type" /> of the parameter.</summary>
		// Token: 0x04001D32 RID: 7474
		protected Type ClassImpl;

		/// <summary>The zero-based position of the parameter in the parameter list.</summary>
		// Token: 0x04001D33 RID: 7475
		protected int PositionImpl;

		/// <summary>The attributes of the parameter.</summary>
		// Token: 0x04001D34 RID: 7476
		protected ParameterAttributes AttrsImpl;

		/// <summary>The default value of the parameter.</summary>
		// Token: 0x04001D35 RID: 7477
		protected object DefaultValueImpl;

		/// <summary>The member in which the field is implemented.</summary>
		// Token: 0x04001D36 RID: 7478
		protected MemberInfo MemberImpl;

		// Token: 0x04001D37 RID: 7479
		[OptionalField]
		private IntPtr _importer;

		// Token: 0x04001D38 RID: 7480
		[OptionalField]
		private int _token;

		// Token: 0x04001D39 RID: 7481
		[OptionalField]
		private bool bExtraConstChecked;
	}
}
