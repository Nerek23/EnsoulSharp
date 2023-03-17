using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Obtains information about the attributes of a member and provides access to member metadata.</summary>
	// Token: 0x020005D4 RID: 1492
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MemberInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MemberInfo : ICustomAttributeProvider, _MemberInfo
	{
		// Token: 0x060045B8 RID: 17848 RVA: 0x000FE58D File Offset: 0x000FC78D
		internal virtual bool CacheEquals(object o)
		{
			throw new NotImplementedException();
		}

		/// <summary>When overridden in a derived class, gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating the type of the member - method, constructor, event, and so on.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating the type of member.</returns>
		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x060045B9 RID: 17849
		public abstract MemberTypes MemberType { get; }

		/// <summary>Gets the name of the current member.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the name of this member.</returns>
		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x060045BA RID: 17850
		[__DynamicallyInvokable]
		public abstract string Name { [__DynamicallyInvokable] get; }

		/// <summary>Gets the class that declares this member.</summary>
		/// <returns>The <see langword="Type" /> object for the class that declares this member.</returns>
		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x060045BB RID: 17851
		[__DynamicallyInvokable]
		public abstract Type DeclaringType { [__DynamicallyInvokable] get; }

		/// <summary>Gets the class object that was used to obtain this instance of <see langword="MemberInfo" />.</summary>
		/// <returns>The <see langword="Type" /> object through which this <see langword="MemberInfo" /> object was obtained.</returns>
		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x060045BC RID: 17852
		[__DynamicallyInvokable]
		public abstract Type ReflectedType { [__DynamicallyInvokable] get; }

		/// <summary>Gets a collection that contains this member's custom attributes.</summary>
		/// <returns>A collection that contains this member's custom attributes.</returns>
		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x060045BD RID: 17853 RVA: 0x000FE594 File Offset: 0x000FC794
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		/// <summary>When overridden in a derived class, returns an array of all custom attributes applied to this member.</summary>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />. This parameter is ignored for properties and events.</param>
		/// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
		/// <exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.</exception>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type could not be loaded.</exception>
		// Token: 0x060045BE RID: 17854
		[__DynamicallyInvokable]
		public abstract object[] GetCustomAttributes(bool inherit);

		/// <summary>When overridden in a derived class, returns an array of custom attributes applied to this member and identified by <see cref="T:System.Type" />.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />. This parameter is ignored for properties and events.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero elements if no attributes assignable to <paramref name="attributeType" /> have been applied.</returns>
		/// <exception cref="T:System.TypeLoadException">A custom attribute type cannot be loaded.</exception>
		/// <exception cref="T:System.ArgumentNullException">If <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context. See How to: Load Assemblies into the Reflection-Only Context.</exception>
		// Token: 0x060045BF RID: 17855
		[__DynamicallyInvokable]
		public abstract object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>When overridden in a derived class, indicates whether one or more attributes of the specified type or of its derived types is applied to this member.</summary>
		/// <param name="attributeType">The type of custom attribute to search for. The search includes derived types.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />. This parameter is ignored for properties and events.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of <paramref name="attributeType" /> or any of its derived types is applied to this member; otherwise, <see langword="false" />.</returns>
		// Token: 0x060045C0 RID: 17856
		[__DynamicallyInvokable]
		public abstract bool IsDefined(Type attributeType, bool inherit);

		/// <summary>Returns a list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the target member.</summary>
		/// <returns>A generic list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the target member.</returns>
		// Token: 0x060045C1 RID: 17857 RVA: 0x000FE59C File Offset: 0x000FC79C
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a value that identifies a metadata element.</summary>
		/// <returns>A value which, in combination with <see cref="P:System.Reflection.MemberInfo.Module" />, uniquely identifies a metadata element.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Reflection.MemberInfo" /> represents an array method, such as <see langword="Address" />, on an array type whose element type is a dynamic type that has not been completed. To get a metadata token in this case, pass the <see cref="T:System.Reflection.MemberInfo" /> object to the <see cref="M:System.Reflection.Emit.ModuleBuilder.GetMethodToken(System.Reflection.MethodInfo)" /> method; or use the <see cref="M:System.Reflection.Emit.ModuleBuilder.GetArrayMethodToken(System.Type,System.String,System.Reflection.CallingConventions,System.Type,System.Type[])" /> method to get the token directly, instead of using the <see cref="M:System.Reflection.Emit.ModuleBuilder.GetArrayMethod(System.Type,System.String,System.Reflection.CallingConventions,System.Type,System.Type[])" /> method to get a <see cref="T:System.Reflection.MethodInfo" /> first.</exception>
		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x060045C2 RID: 17858 RVA: 0x000FE5A3 File Offset: 0x000FC7A3
		public virtual int MetadataToken
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		/// <summary>Gets the module in which the type that declares the member represented by the current <see cref="T:System.Reflection.MemberInfo" /> is defined.</summary>
		/// <returns>The <see cref="T:System.Reflection.Module" /> in which the type that declares the member represented by the current <see cref="T:System.Reflection.MemberInfo" /> is defined.</returns>
		/// <exception cref="T:System.NotImplementedException">This method is not implemented.</exception>
		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x000FE5AA File Offset: 0x000FC7AA
		[__DynamicallyInvokable]
		public virtual Module Module
		{
			[__DynamicallyInvokable]
			get
			{
				if (this is Type)
				{
					return ((Type)this).Module;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.MemberInfo" /> objects are equal.</summary>
		/// <param name="left">The <see cref="T:System.Reflection.MemberInfo" /> to compare to <paramref name="right" />.</param>
		/// <param name="right">The <see cref="T:System.Reflection.MemberInfo" /> to compare to <paramref name="left" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise <see langword="false" />.</returns>
		// Token: 0x060045C4 RID: 17860 RVA: 0x000FE5C8 File Offset: 0x000FC7C8
		[__DynamicallyInvokable]
		public static bool operator ==(MemberInfo left, MemberInfo right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			Type left2;
			Type right2;
			if ((left2 = (left as Type)) != null && (right2 = (right as Type)) != null)
			{
				return left2 == right2;
			}
			MethodBase left3;
			MethodBase right3;
			if ((left3 = (left as MethodBase)) != null && (right3 = (right as MethodBase)) != null)
			{
				return left3 == right3;
			}
			FieldInfo left4;
			FieldInfo right4;
			if ((left4 = (left as FieldInfo)) != null && (right4 = (right as FieldInfo)) != null)
			{
				return left4 == right4;
			}
			EventInfo left5;
			EventInfo right5;
			if ((left5 = (left as EventInfo)) != null && (right5 = (right as EventInfo)) != null)
			{
				return left5 == right5;
			}
			PropertyInfo left6;
			PropertyInfo right6;
			return (left6 = (left as PropertyInfo)) != null && (right6 = (right as PropertyInfo)) != null && left6 == right6;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.MemberInfo" /> objects are not equal.</summary>
		/// <param name="left">The <see cref="T:System.Reflection.MemberInfo" /> to compare to <paramref name="right" />.</param>
		/// <param name="right">The <see cref="T:System.Reflection.MemberInfo" /> to compare to <paramref name="left" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise <see langword="false" />.</returns>
		// Token: 0x060045C5 RID: 17861 RVA: 0x000FE6B8 File Offset: 0x000FC8B8
		[__DynamicallyInvokable]
		public static bool operator !=(MemberInfo left, MemberInfo right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060045C6 RID: 17862 RVA: 0x000FE6C4 File Offset: 0x000FC8C4
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060045C7 RID: 17863 RVA: 0x000FE6CD File Offset: 0x000FC8CD
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Gets a <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.MemberInfo" /> class.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.MemberInfo" /> class.</returns>
		// Token: 0x060045C8 RID: 17864 RVA: 0x000FE6D5 File Offset: 0x000FC8D5
		Type _MemberInfo.GetType()
		{
			return base.GetType();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x060045C9 RID: 17865 RVA: 0x000FE6DD File Offset: 0x000FC8DD
		void _MemberInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x060045CA RID: 17866 RVA: 0x000FE6E4 File Offset: 0x000FC8E4
		void _MemberInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x060045CB RID: 17867 RVA: 0x000FE6EB File Offset: 0x000FC8EB
		void _MemberInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x060045CC RID: 17868 RVA: 0x000FE6F2 File Offset: 0x000FC8F2
		void _MemberInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
