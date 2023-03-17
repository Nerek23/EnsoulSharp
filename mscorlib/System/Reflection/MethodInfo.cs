using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Discovers the attributes of a method and provides access to method metadata.</summary>
	// Token: 0x020005DB RID: 1499
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MethodInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MethodInfo : MethodBase, _MethodInfo
	{
		/// <summary>Indicates whether two <see cref="T:System.Reflection.MethodInfo" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004613 RID: 17939 RVA: 0x000FF1DC File Offset: 0x000FD3DC
		[__DynamicallyInvokable]
		public static bool operator ==(MethodInfo left, MethodInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeMethodInfo) && !(right is RuntimeMethodInfo) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.MethodInfo" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004614 RID: 17940 RVA: 0x000FF203 File Offset: 0x000FD403
		[__DynamicallyInvokable]
		public static bool operator !=(MethodInfo left, MethodInfo right)
		{
			return !(left == right);
		}

		/// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
		/// <param name="obj">An object to compare with this instance, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> equals the type and value of this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004615 RID: 17941 RVA: 0x000FF20F File Offset: 0x000FD40F
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06004616 RID: 17942 RVA: 0x000FF218 File Offset: 0x000FD418
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a method.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a method.</returns>
		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x06004617 RID: 17943 RVA: 0x000FF220 File Offset: 0x000FD420
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Method;
			}
		}

		/// <summary>Gets the return type of this method.</summary>
		/// <returns>The return type of this method.</returns>
		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x06004618 RID: 17944 RVA: 0x000FF223 File Offset: 0x000FD423
		[__DynamicallyInvokable]
		public virtual Type ReturnType
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a <see cref="T:System.Reflection.ParameterInfo" /> object that contains information about the return type of the method, such as whether the return type has custom modifiers.</summary>
		/// <returns>A <see cref="T:System.Reflection.ParameterInfo" /> object that contains information about the return type.</returns>
		/// <exception cref="T:System.NotImplementedException">This method is not implemented.</exception>
		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x06004619 RID: 17945 RVA: 0x000FF22A File Offset: 0x000FD42A
		[__DynamicallyInvokable]
		public virtual ParameterInfo ReturnParameter
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the custom attributes for the return type.</summary>
		/// <returns>An <see langword="ICustomAttributeProvider" /> object representing the custom attributes for the return type.</returns>
		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x0600461A RID: 17946
		public abstract ICustomAttributeProvider ReturnTypeCustomAttributes { get; }

		/// <summary>When overridden in a derived class, returns the <see cref="T:System.Reflection.MethodInfo" /> object for the method on the direct or indirect base class in which the method represented by this instance was first declared.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object for the first implementation of this method.</returns>
		// Token: 0x0600461B RID: 17947
		[__DynamicallyInvokable]
		public abstract MethodInfo GetBaseDefinition();

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects that represent the type arguments of a generic method or the type parameters of a generic method definition.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that represent the type arguments of a generic method or the type parameters of a generic method definition. Returns an empty array if the current method is not a generic method.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x0600461C RID: 17948 RVA: 0x000FF231 File Offset: 0x000FD431
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public override Type[] GetGenericArguments()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Returns a <see cref="T:System.Reflection.MethodInfo" /> object that represents a generic method definition from which the current method can be constructed.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object representing a generic method definition from which the current method can be constructed.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current method is not a generic method. That is, <see cref="P:System.Reflection.MethodBase.IsGenericMethod" /> returns <see langword="false" />.</exception>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x0600461D RID: 17949 RVA: 0x000FF242 File Offset: 0x000FD442
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual MethodInfo GetGenericMethodDefinition()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Substitutes the elements of an array of types for the type parameters of the current generic method definition, and returns a <see cref="T:System.Reflection.MethodInfo" /> object representing the resulting constructed method.</summary>
		/// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic method definition.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object that represents the constructed method formed by substituting the elements of <paramref name="typeArguments" /> for the type parameters of the current generic method definition.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Reflection.MethodInfo" /> does not represent a generic method definition. That is, <see cref="P:System.Reflection.MethodBase.IsGenericMethodDefinition" /> returns <see langword="false" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeArguments" /> is <see langword="null" />.  
		/// -or-  
		/// Any element of <paramref name="typeArguments" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The number of elements in <paramref name="typeArguments" /> is not the same as the number of type parameters of the current generic method definition.  
		///  -or-  
		///  An element of <paramref name="typeArguments" /> does not satisfy the constraints specified for the corresponding type parameter of the current generic method definition.</exception>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x0600461E RID: 17950 RVA: 0x000FF253 File Offset: 0x000FD453
		[__DynamicallyInvokable]
		public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Creates a delegate of the specified type from this method.</summary>
		/// <param name="delegateType">The type of the delegate to create.</param>
		/// <returns>The delegate for this method.</returns>
		// Token: 0x0600461F RID: 17951 RVA: 0x000FF264 File Offset: 0x000FD464
		[__DynamicallyInvokable]
		public virtual Delegate CreateDelegate(Type delegateType)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Creates a delegate of the specified type with the specified target from this method.</summary>
		/// <param name="delegateType">The type of the delegate to create.</param>
		/// <param name="target">The object targeted by the delegate.</param>
		/// <returns>The delegate for this method.</returns>
		// Token: 0x06004620 RID: 17952 RVA: 0x000FF275 File Offset: 0x000FD475
		[__DynamicallyInvokable]
		public virtual Delegate CreateDelegate(Type delegateType, object target)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Provides access to the <see cref="M:System.Object.GetType" /> method from COM.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the <see cref="T:System.Reflection.MethodInfo" /> type.</returns>
		// Token: 0x06004621 RID: 17953 RVA: 0x000FF286 File Offset: 0x000FD486
		Type _MethodInfo.GetType()
		{
			return base.GetType();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004622 RID: 17954 RVA: 0x000FF28E File Offset: 0x000FD48E
		void _MethodInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004623 RID: 17955 RVA: 0x000FF295 File Offset: 0x000FD495
		void _MethodInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array that receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004624 RID: 17956 RVA: 0x000FF29C File Offset: 0x000FD49C
		void _MethodInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x06004625 RID: 17957 RVA: 0x000FF2A3 File Offset: 0x000FD4A3
		void _MethodInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
