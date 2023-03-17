using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Reflection
{
	/// <summary>Performs reflection on a module.</summary>
	// Token: 0x020005E0 RID: 1504
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Module))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	[Serializable]
	public abstract class Module : _Module, ISerializable, ICustomAttributeProvider
	{
		// Token: 0x0600466B RID: 18027 RVA: 0x0010007C File Offset: 0x000FE27C
		static Module()
		{
			__Filters @object = new __Filters();
			Module.FilterTypeName = new TypeFilter(@object.FilterTypeName);
			Module.FilterTypeNameIgnoreCase = new TypeFilter(@object.FilterTypeNameIgnoreCase);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Module" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600466D RID: 18029 RVA: 0x001000BB File Offset: 0x000FE2BB
		[__DynamicallyInvokable]
		public static bool operator ==(Module left, Module right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeModule) && !(right is RuntimeModule) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Module" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600466E RID: 18030 RVA: 0x001000E2 File Offset: 0x000FE2E2
		[__DynamicallyInvokable]
		public static bool operator !=(Module left, Module right)
		{
			return !(left == right);
		}

		/// <summary>Determines whether this module and the specified object are equal.</summary>
		/// <param name="o">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600466F RID: 18031 RVA: 0x001000EE File Offset: 0x000FE2EE
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			return base.Equals(o);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06004670 RID: 18032 RVA: 0x001000F7 File Offset: 0x000FE2F7
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Returns the name of the module.</summary>
		/// <returns>A <see langword="String" /> representing the name of this module.</returns>
		// Token: 0x06004671 RID: 18033 RVA: 0x001000FF File Offset: 0x000FE2FF
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.ScopeName;
		}

		/// <summary>Gets a collection that contains this module's custom attributes.</summary>
		/// <returns>A collection that contains this module's custom attributes.</returns>
		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x00100107 File Offset: 0x000FE307
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		/// <summary>Returns all custom attributes.</summary>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array of type <see langword="Object" /> containing all custom attributes.</returns>
		// Token: 0x06004673 RID: 18035 RVA: 0x0010010F File Offset: 0x000FE30F
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets custom attributes of the specified type.</summary>
		/// <param name="attributeType">The type of attribute to get.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>An array of type <see langword="Object" /> containing all custom attributes of the specified type.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a <see cref="T:System.Type" /> object supplied by the runtime. For example, <paramref name="attributeType" /> is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> object.</exception>
		// Token: 0x06004674 RID: 18036 RVA: 0x00100116 File Offset: 0x000FE316
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns a value that indicates whether the specified attribute type has been applied to this module.</summary>
		/// <param name="attributeType">The type of custom attribute to test for.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of <paramref name="attributeType" /> have been applied to this module; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a <see cref="T:System.Type" /> object supplied by the runtime. For example, <paramref name="attributeType" /> is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> object.</exception>
		// Token: 0x06004675 RID: 18037 RVA: 0x0010011D File Offset: 0x000FE31D
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns a list of <see cref="T:System.Reflection.CustomAttributeData" /> objects for the current module, which can be used in the reflection-only context.</summary>
		/// <returns>A generic list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the current module.</returns>
		// Token: 0x06004676 RID: 18038 RVA: 0x00100124 File Offset: 0x000FE324
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns the method or constructor identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodBase" /> object representing the method or constructor that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a method or constructor in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004677 RID: 18039 RVA: 0x0010012B File Offset: 0x000FE32B
		public MethodBase ResolveMethod(int metadataToken)
		{
			return this.ResolveMethod(metadataToken, null, null);
		}

		/// <summary>Returns the method or constructor identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a method or constructor in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodBase" /> object representing the method that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a method or constructor in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004678 RID: 18040 RVA: 0x00100138 File Offset: 0x000FE338
		public virtual MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the field identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a field in the module.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a field in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a field whose parent <see langword="TypeSpec" /> has a signature containing element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004679 RID: 18041 RVA: 0x00100164 File Offset: 0x000FE364
		public FieldInfo ResolveField(int metadataToken)
		{
			return this.ResolveField(metadataToken, null, null);
		}

		/// <summary>Returns the field identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a field in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object representing the field that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a field in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a field whose parent <see langword="TypeSpec" /> has a signature containing element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467A RID: 18042 RVA: 0x00100170 File Offset: 0x000FE370
		public virtual FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the type identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type in the module.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the type that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467B RID: 18043 RVA: 0x0010019C File Offset: 0x000FE39C
		public Type ResolveType(int metadataToken)
		{
			return this.ResolveType(metadataToken, null, null);
		}

		/// <summary>Returns the type identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the type that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467C RID: 18044 RVA: 0x001001A8 File Offset: 0x000FE3A8
		public virtual Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the type or member identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type or member in the module.</param>
		/// <returns>A <see cref="T:System.Reflection.MemberInfo" /> object representing the type or member that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type or member in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> or <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method).  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a property or event.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467D RID: 18045 RVA: 0x001001D4 File Offset: 0x000FE3D4
		public MemberInfo ResolveMember(int metadataToken)
		{
			return this.ResolveMember(metadataToken, null, null);
		}

		/// <summary>Returns the type or member identified by the specified metadata token, in the context defined by the specified generic type parameters.</summary>
		/// <param name="metadataToken">A metadata token that identifies a type or member in the module.</param>
		/// <param name="genericTypeArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the type where the token is in scope, or <see langword="null" /> if that type is not generic.</param>
		/// <param name="genericMethodArguments">An array of <see cref="T:System.Type" /> objects representing the generic type arguments of the method where the token is in scope, or <see langword="null" /> if that method is not generic.</param>
		/// <returns>A <see cref="T:System.Reflection.MemberInfo" /> object representing the type or member that is identified by the specified metadata token.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a type or member in the scope of the current module.  
		/// -or-  
		/// <paramref name="metadataToken" /> is a <see langword="MethodSpec" /> or <see langword="TypeSpec" /> whose signature contains element type <see langword="var" /> (a type parameter of a generic type) or <see langword="mvar" /> (a type parameter of a generic method), and the necessary generic type arguments were not supplied for either or both of <paramref name="genericTypeArguments" /> and <paramref name="genericMethodArguments" />.  
		/// -or-  
		/// <paramref name="metadataToken" /> identifies a property or event.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467E RID: 18046 RVA: 0x001001E0 File Offset: 0x000FE3E0
		public virtual MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveMember(metadataToken, genericTypeArguments, genericMethodArguments);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the signature blob identified by a metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a signature in the module.</param>
		/// <returns>An array of bytes representing the signature blob.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a valid <see langword="MemberRef" />, <see langword="MethodDef" />, <see langword="TypeSpec" />, signature, or <see langword="FieldDef" /> token in the scope of the current module.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x0600467F RID: 18047 RVA: 0x0010020C File Offset: 0x000FE40C
		public virtual byte[] ResolveSignature(int metadataToken)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveSignature(metadataToken);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the string identified by the specified metadata token.</summary>
		/// <param name="metadataToken">A metadata token that identifies a string in the string heap of the module.</param>
		/// <returns>A <see cref="T:System.String" /> containing a string value from the metadata string heap.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="metadataToken" /> is not a token for a string in the scope of the current module.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="metadataToken" /> is not a valid token in the scope of the current module.</exception>
		// Token: 0x06004680 RID: 18048 RVA: 0x00100238 File Offset: 0x000FE438
		public virtual string ResolveString(int metadataToken)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.ResolveString(metadataToken);
			}
			throw new NotImplementedException();
		}

		/// <summary>Gets a pair of values indicating the nature of the code in a module and the platform targeted by the module.</summary>
		/// <param name="peKind">When this method returns, a combination of the <see cref="T:System.Reflection.PortableExecutableKinds" /> values indicating the nature of the code in the module.</param>
		/// <param name="machine">When this method returns, one of the <see cref="T:System.Reflection.ImageFileMachine" /> values indicating the platform targeted by the module.</param>
		// Token: 0x06004681 RID: 18049 RVA: 0x00100264 File Offset: 0x000FE464
		public virtual void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				runtimeModule.GetPEKind(out peKind, out machine);
			}
			throw new NotImplementedException();
		}

		/// <summary>Gets the metadata stream version.</summary>
		/// <returns>A 32-bit integer representing the metadata stream version. The high-order two bytes represent the major version number, and the low-order two bytes represent the minor version number.</returns>
		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06004682 RID: 18050 RVA: 0x00100290 File Offset: 0x000FE490
		public virtual int MDStreamVersion
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.MDStreamVersion;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Provides an <see cref="T:System.Runtime.Serialization.ISerializable" /> implementation for serialized objects.</summary>
		/// <param name="info">The information and data needed to serialize or deserialize an object.</param>
		/// <param name="context">The context for the serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06004683 RID: 18051 RVA: 0x001002B9 File Offset: 0x000FE4B9
		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns the specified type, searching the module with the specified case sensitivity.</summary>
		/// <param name="className">The name of the type to locate. The name must be fully qualified with the namespace.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> for case-insensitive search; otherwise, <see langword="false" />.</param>
		/// <returns>A <see langword="Type" /> object representing the given type, if the type is in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The class initializers are invoked and an exception is thrown.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="className" /> is a zero-length string.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="className" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="className" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="className" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="className" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="className" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x06004684 RID: 18052 RVA: 0x001002C0 File Offset: 0x000FE4C0
		[ComVisible(true)]
		public virtual Type GetType(string className, bool ignoreCase)
		{
			return this.GetType(className, false, ignoreCase);
		}

		/// <summary>Returns the specified type, performing a case-sensitive search.</summary>
		/// <param name="className">The name of the type to locate. The name must be fully qualified with the namespace.</param>
		/// <returns>A <see langword="Type" /> object representing the given type, if the type is in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The class initializers are invoked and an exception is thrown.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="className" /> is a zero-length string.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="className" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="className" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="className" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="className" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="className" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x06004685 RID: 18053 RVA: 0x001002CB File Offset: 0x000FE4CB
		[ComVisible(true)]
		public virtual Type GetType(string className)
		{
			return this.GetType(className, false, false);
		}

		/// <summary>Returns the specified type, specifying whether to make a case-sensitive search of the module and whether to throw an exception if the type cannot be found.</summary>
		/// <param name="className">The name of the type to locate. The name must be fully qualified with the namespace.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> for case-insensitive search; otherwise, <see langword="false" />.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the specified type, if the type is declared in this module; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="className" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The class initializers are invoked and an exception is thrown.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="className" /> is a zero-length string.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" />, and the type cannot be found.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="className" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="className" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="className" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="className" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="className" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x06004686 RID: 18054 RVA: 0x001002D6 File Offset: 0x000FE4D6
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual Type GetType(string className, bool throwOnError, bool ignoreCase)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a string representing the fully qualified name and path to this module.</summary>
		/// <returns>The fully qualified module name.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permissions.</exception>
		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06004687 RID: 18055 RVA: 0x001002DD File Offset: 0x000FE4DD
		[__DynamicallyInvokable]
		public virtual string FullyQualifiedName
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Returns an array of classes accepted by the given filter and filter criteria.</summary>
		/// <param name="filter">The delegate used to filter the classes.</param>
		/// <param name="filterCriteria">An Object used to filter the classes.</param>
		/// <returns>An array of type <see langword="Type" /> containing classes that were accepted by the filter.</returns>
		/// <exception cref="T:System.Reflection.ReflectionTypeLoadException">One or more classes in a module could not be loaded.</exception>
		// Token: 0x06004688 RID: 18056 RVA: 0x001002E4 File Offset: 0x000FE4E4
		public virtual Type[] FindTypes(TypeFilter filter, object filterCriteria)
		{
			Type[] types = this.GetTypes();
			int num = 0;
			for (int i = 0; i < types.Length; i++)
			{
				if (filter != null && !filter(types[i], filterCriteria))
				{
					types[i] = null;
				}
				else
				{
					num++;
				}
			}
			if (num == types.Length)
			{
				return types;
			}
			Type[] array = new Type[num];
			num = 0;
			for (int j = 0; j < types.Length; j++)
			{
				if (types[j] != null)
				{
					array[num++] = types[j];
				}
			}
			return array;
		}

		/// <summary>Returns all the types defined within this module.</summary>
		/// <returns>An array of type <see langword="Type" /> containing types defined within the module that is reflected by this instance.</returns>
		/// <exception cref="T:System.Reflection.ReflectionTypeLoadException">One or more classes in a module could not be loaded.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x06004689 RID: 18057 RVA: 0x0010035C File Offset: 0x000FE55C
		public virtual Type[] GetTypes()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a universally unique identifier (UUID) that can be used to distinguish between two versions of a module.</summary>
		/// <returns>A <see cref="T:System.Guid" /> that can be used to distinguish between two versions of a module.</returns>
		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x0600468A RID: 18058 RVA: 0x00100364 File Offset: 0x000FE564
		public virtual Guid ModuleVersionId
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.ModuleVersionId;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a token that identifies the module in metadata.</summary>
		/// <returns>An integer token that identifies the current module in metadata.</returns>
		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x0600468B RID: 18059 RVA: 0x00100390 File Offset: 0x000FE590
		public virtual int MetadataToken
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.MetadataToken;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value indicating whether the object is a resource.</summary>
		/// <returns>
		///   <see langword="true" /> if the object is a resource; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600468C RID: 18060 RVA: 0x001003BC File Offset: 0x000FE5BC
		public virtual bool IsResource()
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.IsResource();
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the global fields defined on the module.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.FieldInfo" /> objects representing the global fields defined on the module; if there are no global fields, an empty array is returned.</returns>
		// Token: 0x0600468D RID: 18061 RVA: 0x001003E5 File Offset: 0x000FE5E5
		public FieldInfo[] GetFields()
		{
			return this.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Returns the global fields defined on the module that match the specified binding flags.</summary>
		/// <param name="bindingFlags">A bitwise combination of <see cref="T:System.Reflection.BindingFlags" /> values that limit the search.</param>
		/// <returns>An array of type <see cref="T:System.Reflection.FieldInfo" /> representing the global fields defined on the module that match the specified binding flags; if no global fields match the binding flags, an empty array is returned.</returns>
		// Token: 0x0600468E RID: 18062 RVA: 0x001003F0 File Offset: 0x000FE5F0
		public virtual FieldInfo[] GetFields(BindingFlags bindingFlags)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetFields(bindingFlags);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns a field having the specified name.</summary>
		/// <param name="name">The field name.</param>
		/// <returns>A <see langword="FieldInfo" /> object having the specified name, or <see langword="null" /> if the field does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x0600468F RID: 18063 RVA: 0x0010041A File Offset: 0x000FE61A
		public FieldInfo GetField(string name)
		{
			return this.GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Returns a field having the specified name and binding attributes.</summary>
		/// <param name="name">The field name.</param>
		/// <param name="bindingAttr">One of the <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <returns>A <see langword="FieldInfo" /> object having the specified name and binding attributes, or <see langword="null" /> if the field does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06004690 RID: 18064 RVA: 0x00100428 File Offset: 0x000FE628
		public virtual FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetField(name, bindingAttr);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns the global methods defined on the module.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects representing all the global methods defined on the module; if there are no global methods, an empty array is returned.</returns>
		// Token: 0x06004691 RID: 18065 RVA: 0x00100453 File Offset: 0x000FE653
		public MethodInfo[] GetMethods()
		{
			return this.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Returns the global methods defined on the module that match the specified binding flags.</summary>
		/// <param name="bindingFlags">A bitwise combination of <see cref="T:System.Reflection.BindingFlags" /> values that limit the search.</param>
		/// <returns>An array of type <see cref="T:System.Reflection.MethodInfo" /> representing the global methods defined on the module that match the specified binding flags; if no global methods match the binding flags, an empty array is returned.</returns>
		// Token: 0x06004692 RID: 18066 RVA: 0x00100460 File Offset: 0x000FE660
		public virtual MethodInfo[] GetMethods(BindingFlags bindingFlags)
		{
			RuntimeModule runtimeModule = this as RuntimeModule;
			if (runtimeModule != null)
			{
				return runtimeModule.GetMethods(bindingFlags);
			}
			throw new NotImplementedException();
		}

		/// <summary>Returns a method having the specified name, binding information, calling convention, and parameter types and modifiers.</summary>
		/// <param name="name">The method name.</param>
		/// <param name="bindingAttr">One of the <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <param name="binder">An object that implements <see langword="Binder" />, containing properties related to this method.</param>
		/// <param name="callConvention">The calling convention for the method.</param>
		/// <param name="types">The parameter types to search for.</param>
		/// <param name="modifiers">An array of parameter modifiers used to make binding work with parameter signatures in which the types have been modified.</param>
		/// <returns>A <see langword="MethodInfo" /> object in accordance with the specified criteria, or <see langword="null" /> if the method does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />, <paramref name="types" /> is <see langword="null" />, or <paramref name="types" /> (i) is <see langword="null" />.</exception>
		// Token: 0x06004693 RID: 18067 RVA: 0x0010048C File Offset: 0x000FE68C
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i] == null)
				{
					throw new ArgumentNullException("types");
				}
			}
			return this.GetMethodImpl(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Returns a method having the specified name and parameter types.</summary>
		/// <param name="name">The method name.</param>
		/// <param name="types">The parameter types to search for.</param>
		/// <returns>A <see langword="MethodInfo" /> object in accordance with the specified criteria, or <see langword="null" /> if the method does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />, <paramref name="types" /> is <see langword="null" />, or <paramref name="types" /> (i) is <see langword="null" />.</exception>
		// Token: 0x06004694 RID: 18068 RVA: 0x001004EC File Offset: 0x000FE6EC
		public MethodInfo GetMethod(string name, Type[] types)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i] == null)
				{
					throw new ArgumentNullException("types");
				}
			}
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, types, null);
		}

		/// <summary>Returns a method having the specified name.</summary>
		/// <param name="name">The method name.</param>
		/// <returns>A <see langword="MethodInfo" /> object having the specified name, or <see langword="null" /> if the method does not exist.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004695 RID: 18069 RVA: 0x00100546 File Offset: 0x000FE746
		public MethodInfo GetMethod(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, null, null);
		}

		/// <summary>Returns the method implementation in accordance with the specified criteria.</summary>
		/// <param name="name">The method name.</param>
		/// <param name="bindingAttr">One of the <see langword="BindingFlags" /> bit flags used to control the search.</param>
		/// <param name="binder">An object that implements <see langword="Binder" />, containing properties related to this method.</param>
		/// <param name="callConvention">The calling convention for the method.</param>
		/// <param name="types">The parameter types to search for.</param>
		/// <param name="modifiers">An array of parameter modifiers used to make binding work with parameter signatures in which the types have been modified.</param>
		/// <returns>A <see langword="MethodInfo" /> object containing implementation information as specified, or <see langword="null" /> if the method does not exist.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">
		///   <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06004696 RID: 18070 RVA: 0x00100563 File Offset: 0x000FE763
		protected virtual MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a string representing the name of the module.</summary>
		/// <returns>The module name.</returns>
		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06004697 RID: 18071 RVA: 0x0010056C File Offset: 0x000FE76C
		public virtual string ScopeName
		{
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.ScopeName;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a <see langword="String" /> representing the name of the module with the path removed.</summary>
		/// <returns>The module name with no path.</returns>
		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06004698 RID: 18072 RVA: 0x00100598 File Offset: 0x000FE798
		[__DynamicallyInvokable]
		public virtual string Name
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.Name;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the appropriate <see cref="T:System.Reflection.Assembly" /> for this instance of <see cref="T:System.Reflection.Module" />.</summary>
		/// <returns>An <see langword="Assembly" /> object.</returns>
		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06004699 RID: 18073 RVA: 0x001005C4 File Offset: 0x000FE7C4
		[__DynamicallyInvokable]
		public virtual Assembly Assembly
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeModule runtimeModule = this as RuntimeModule;
				if (runtimeModule != null)
				{
					return runtimeModule.Assembly;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a handle for the module.</summary>
		/// <returns>A <see cref="T:System.ModuleHandle" /> structure for the current module.</returns>
		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x0600469A RID: 18074 RVA: 0x001005ED File Offset: 0x000FE7ED
		public ModuleHandle ModuleHandle
		{
			get
			{
				return this.GetModuleHandle();
			}
		}

		// Token: 0x0600469B RID: 18075 RVA: 0x001005F5 File Offset: 0x000FE7F5
		internal virtual ModuleHandle GetModuleHandle()
		{
			return ModuleHandle.EmptyHandle;
		}

		/// <summary>Returns an <see langword="X509Certificate" /> object corresponding to the certificate included in the Authenticode signature of the assembly which this module belongs to. If the assembly has not been Authenticode signed, <see langword="null" /> is returned.</summary>
		/// <returns>An <see langword="X509Certificate" /> object, or <see langword="null" /> if the assembly to which this module belongs has not been Authenticode signed.</returns>
		// Token: 0x0600469C RID: 18076 RVA: 0x001005FC File Offset: 0x000FE7FC
		public virtual X509Certificate GetSignerCertificate()
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600469D RID: 18077 RVA: 0x00100603 File Offset: 0x000FE803
		void _Module.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x0600469E RID: 18078 RVA: 0x0010060A File Offset: 0x000FE80A
		void _Module.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x0600469F RID: 18079 RVA: 0x00100611 File Offset: 0x000FE811
		void _Module.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DispIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060046A0 RID: 18080 RVA: 0x00100618 File Offset: 0x000FE818
		void _Module.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>A <see langword="TypeFilter" /> object that filters the list of types defined in this module based upon the name. This field is case-sensitive and read-only.</summary>
		// Token: 0x04001CFF RID: 7423
		public static readonly TypeFilter FilterTypeName;

		/// <summary>A <see langword="TypeFilter" /> object that filters the list of types defined in this module based upon the name. This field is case-insensitive and read-only.</summary>
		// Token: 0x04001D00 RID: 7424
		public static readonly TypeFilter FilterTypeNameIgnoreCase;

		// Token: 0x04001D01 RID: 7425
		private const BindingFlags DefaultLookup = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
	}
}
