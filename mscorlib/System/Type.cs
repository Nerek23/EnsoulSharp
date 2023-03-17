using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System
{
	/// <summary>Represents type declarations: class types, interface types, array types, value types, enumeration types, type parameters, generic type definitions, and open or closed constructed generic types.</summary>
	// Token: 0x02000148 RID: 328
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Type))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Type : MemberInfo, _Type, IReflect
	{
		/// <summary>Gets a <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a type or a nested type.</summary>
		/// <returns>A <see cref="T:System.Reflection.MemberTypes" /> value indicating that this member is a type or a nested type.</returns>
		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060013EC RID: 5100 RVA: 0x0003BE82 File Offset: 0x0003A082
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.TypeInfo;
			}
		}

		/// <summary>Gets the type that declares the current nested type or generic type parameter.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing the enclosing type, if the current type is a nested type; or the generic type definition, if the current type is a type parameter of a generic type; or the type that declares the generic method, if the current type is a type parameter of a generic method; otherwise, <see langword="null" />.</returns>
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060013ED RID: 5101 RVA: 0x0003BE86 File Offset: 0x0003A086
		[__DynamicallyInvokable]
		public override Type DeclaringType
		{
			[__DynamicallyInvokable]
			get
			{
				return null;
			}
		}

		/// <summary>Gets a <see cref="T:System.Reflection.MethodBase" /> that represents the declaring method, if the current <see cref="T:System.Type" /> represents a type parameter of a generic method.</summary>
		/// <returns>If the current <see cref="T:System.Type" /> represents a type parameter of a generic method, a <see cref="T:System.Reflection.MethodBase" /> that represents declaring method; otherwise, <see langword="null" />.</returns>
		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060013EE RID: 5102 RVA: 0x0003BE89 File Offset: 0x0003A089
		[__DynamicallyInvokable]
		public virtual MethodBase DeclaringMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return null;
			}
		}

		/// <summary>Gets the class object that was used to obtain this member.</summary>
		/// <returns>The <see langword="Type" /> object through which this <see cref="T:System.Type" /> object was obtained.</returns>
		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060013EF RID: 5103 RVA: 0x0003BE8C File Offset: 0x0003A08C
		[__DynamicallyInvokable]
		public override Type ReflectedType
		{
			[__DynamicallyInvokable]
			get
			{
				return null;
			}
		}

		/// <summary>Gets the <see cref="T:System.Type" /> with the specified name, specifying whether to throw an exception if the type is not found and whether to perform a case-sensitive search.</summary>
		/// <param name="typeName">The assembly-qualified name of the type to get. See <see cref="P:System.Type.AssemblyQualifiedName" />. If the type is in the currently executing assembly or in Mscorlib.dll, it is sufficient to supply the type name qualified by its namespace.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />. Specifying <see langword="false" /> also suppresses some other exception conditions, but not all of them. See the Exceptions section.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to perform a case-insensitive search for <paramref name="typeName" />, <see langword="false" /> to perform a case-sensitive search for <paramref name="typeName" />.</param>
		/// <returns>The type with the specified name. If the type is not found, the <paramref name="throwOnError" /> parameter specifies whether <see langword="null" /> is returned or an exception is thrown. In some cases, an exception is thrown regardless of the value of <paramref name="throwOnError" />. See the Exceptions section.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the type is not found.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid characters, such as an embedded tab.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> is an empty string.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> represents an array type with an invalid size.  
		/// -or-  
		/// <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid syntax. For example, "MyType[,*,]".  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the assembly or one of its dependencies was not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The assembly or one of its dependencies was found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  Version 2.0 or later of the common language runtime is currently loaded, and the assembly was compiled with a later version.</exception>
		// Token: 0x060013F0 RID: 5104 RVA: 0x0003BE90 File Offset: 0x0003A090
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName, bool throwOnError, bool ignoreCase)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeType.GetType(typeName, throwOnError, ignoreCase, false, ref stackCrawlMark);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> with the specified name, performing a case-sensitive search and specifying whether to throw an exception if the type is not found.</summary>
		/// <param name="typeName">The assembly-qualified name of the type to get. See <see cref="P:System.Type.AssemblyQualifiedName" />. If the type is in the currently executing assembly or in Mscorlib.dll, it is sufficient to supply the type name qualified by its namespace.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />. Specifying <see langword="false" /> also suppresses some other exception conditions, but not all of them. See the Exceptions section.</param>
		/// <returns>The type with the specified name. If the type is not found, the <paramref name="throwOnError" /> parameter specifies whether <see langword="null" /> is returned or an exception is thrown. In some cases, an exception is thrown regardless of the value of <paramref name="throwOnError" />. See the Exceptions section.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the type is not found.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid characters, such as an embedded tab.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> is an empty string.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> represents an array type with an invalid size.  
		/// -or-  
		/// <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid syntax. For example, "MyType[,*,]".  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the assembly or one of its dependencies was not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///
		///
		///  The assembly or one of its dependencies was found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  Version 2.0 or later of the common language runtime is currently loaded, and the assembly was compiled with a later version.</exception>
		// Token: 0x060013F1 RID: 5105 RVA: 0x0003BEAC File Offset: 0x0003A0AC
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName, bool throwOnError)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeType.GetType(typeName, throwOnError, false, false, ref stackCrawlMark);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> with the specified name, performing a case-sensitive search.</summary>
		/// <param name="typeName">The assembly-qualified name of the type to get. See <see cref="P:System.Type.AssemblyQualifiedName" />. If the type is in the currently executing assembly or in Mscorlib.dll, it is sufficient to supply the type name qualified by its namespace.</param>
		/// <returns>The type with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///
		///
		///  The assembly or one of its dependencies was found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  Version 2.0 or later of the common language runtime is currently loaded, and the assembly was compiled with a later version.</exception>
		// Token: 0x060013F2 RID: 5106 RVA: 0x0003BEC8 File Offset: 0x0003A0C8
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeType.GetType(typeName, false, false, false, ref stackCrawlMark);
		}

		/// <summary>Gets the type with the specified name, optionally providing custom methods to resolve the assembly and the type.</summary>
		/// <param name="typeName">The name of the type to get. If the <paramref name="typeResolver" /> parameter is provided, the type name can be any string that <paramref name="typeResolver" /> is capable of resolving. If the <paramref name="assemblyResolver" /> parameter is provided or if standard type resolution is used, <paramref name="typeName" /> must be an assembly-qualified name (see <see cref="P:System.Type.AssemblyQualifiedName" />), unless the type is in the currently executing assembly or in Mscorlib.dll, in which case it is sufficient to supply the type name qualified by its namespace.</param>
		/// <param name="assemblyResolver">A method that locates and returns the assembly that is specified in <paramref name="typeName" />. The assembly name is passed to <paramref name="assemblyResolver" /> as an <see cref="T:System.Reflection.AssemblyName" /> object. If <paramref name="typeName" /> does not contain the name of an assembly, <paramref name="assemblyResolver" /> is not called. If <paramref name="assemblyResolver" /> is not supplied, standard assembly resolution is performed.  
		///  Caution   Do not pass methods from unknown or untrusted callers. Doing so could result in elevation of privilege for malicious code. Use only methods that you provide or that you are familiar with.</param>
		/// <param name="typeResolver">A method that locates and returns the type that is specified by <paramref name="typeName" /> from the assembly that is returned by <paramref name="assemblyResolver" /> or by standard assembly resolution. If no assembly is provided, the <paramref name="typeResolver" /> method can provide one. The method also takes a parameter that specifies whether to perform a case-insensitive search; <see langword="false" /> is passed to that parameter.  
		///  Caution   Do not pass methods from unknown or untrusted callers.</param>
		/// <returns>The type with the specified name, or <see langword="null" /> if the type is not found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.ArgumentException">An error occurs when <paramref name="typeName" /> is parsed into a type name and an assembly name (for example, when the simple type name includes an unescaped special character).  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The assembly or one of its dependencies was found, but could not be loaded.  
		///  -or-  
		///  <paramref name="typeName" /> contains an invalid assembly name.  
		///  -or-  
		///  <paramref name="typeName" /> is a valid assembly name without a type name.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  The assembly was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		// Token: 0x060013F3 RID: 5107 RVA: 0x0003BEE4 File Offset: 0x0003A0E4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TypeNameParser.GetType(typeName, assemblyResolver, typeResolver, false, false, ref stackCrawlMark);
		}

		/// <summary>Gets the type with the specified name, specifying whether to throw an exception if the type is not found, and optionally providing custom methods to resolve the assembly and the type.</summary>
		/// <param name="typeName">The name of the type to get. If the <paramref name="typeResolver" /> parameter is provided, the type name can be any string that <paramref name="typeResolver" /> is capable of resolving. If the <paramref name="assemblyResolver" /> parameter is provided or if standard type resolution is used, <paramref name="typeName" /> must be an assembly-qualified name (see <see cref="P:System.Type.AssemblyQualifiedName" />), unless the type is in the currently executing assembly or in Mscorlib.dll, in which case it is sufficient to supply the type name qualified by its namespace.</param>
		/// <param name="assemblyResolver">A method that locates and returns the assembly that is specified in <paramref name="typeName" />. The assembly name is passed to <paramref name="assemblyResolver" /> as an <see cref="T:System.Reflection.AssemblyName" /> object. If <paramref name="typeName" /> does not contain the name of an assembly, <paramref name="assemblyResolver" /> is not called. If <paramref name="assemblyResolver" /> is not supplied, standard assembly resolution is performed.  
		///  Caution   Do not pass methods from unknown or untrusted callers. Doing so could result in elevation of privilege for malicious code. Use only methods that you provide or that you are familiar with.</param>
		/// <param name="typeResolver">A method that locates and returns the type that is specified by <paramref name="typeName" /> from the assembly that is returned by <paramref name="assemblyResolver" /> or by standard assembly resolution. If no assembly is provided, the method can provide one. The method also takes a parameter that specifies whether to perform a case-insensitive search; <see langword="false" /> is passed to that parameter.  
		///  Caution   Do not pass methods from unknown or untrusted callers.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />. Specifying <see langword="false" /> also suppresses some other exception conditions, but not all of them. See the Exceptions section.</param>
		/// <returns>The type with the specified name. If the type is not found, the <paramref name="throwOnError" /> parameter specifies whether <see langword="null" /> is returned or an exception is thrown. In some cases, an exception is thrown regardless of the value of <paramref name="throwOnError" />. See the Exceptions section.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the type is not found.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid characters, such as an embedded tab.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> is an empty string.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> represents an array type with an invalid size.  
		/// -or-  
		/// <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.ArgumentException">An error occurs when <paramref name="typeName" /> is parsed into a type name and an assembly name (for example, when the simple type name includes an unescaped special character).  
		///  -or-  
		///  <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid syntax (for example, "MyType[,*,]").  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the assembly or one of its dependencies was not found.  
		/// -or-  
		/// <paramref name="typeName" /> contains an invalid assembly name.  
		/// -or-  
		/// <paramref name="typeName" /> is a valid assembly name without a type name.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The assembly or one of its dependencies was found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  The assembly was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		// Token: 0x060013F4 RID: 5108 RVA: 0x0003BF00 File Offset: 0x0003A100
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TypeNameParser.GetType(typeName, assemblyResolver, typeResolver, throwOnError, false, ref stackCrawlMark);
		}

		/// <summary>Gets the type with the specified name, specifying whether to perform a case-sensitive search and whether to throw an exception if the type is not found, and optionally providing custom methods to resolve the assembly and the type.</summary>
		/// <param name="typeName">The name of the type to get. If the <paramref name="typeResolver" /> parameter is provided, the type name can be any string that <paramref name="typeResolver" /> is capable of resolving. If the <paramref name="assemblyResolver" /> parameter is provided or if standard type resolution is used, <paramref name="typeName" /> must be an assembly-qualified name (see <see cref="P:System.Type.AssemblyQualifiedName" />), unless the type is in the currently executing assembly or in Mscorlib.dll, in which case it is sufficient to supply the type name qualified by its namespace.</param>
		/// <param name="assemblyResolver">A method that locates and returns the assembly that is specified in <paramref name="typeName" />. The assembly name is passed to <paramref name="assemblyResolver" /> as an <see cref="T:System.Reflection.AssemblyName" /> object. If <paramref name="typeName" /> does not contain the name of an assembly, <paramref name="assemblyResolver" /> is not called. If <paramref name="assemblyResolver" /> is not supplied, standard assembly resolution is performed.  
		///  Caution   Do not pass methods from unknown or untrusted callers. Doing so could result in elevation of privilege for malicious code. Use only methods that you provide or that you are familiar with.</param>
		/// <param name="typeResolver">A method that locates and returns the type that is specified by <paramref name="typeName" /> from the assembly that is returned by <paramref name="assemblyResolver" /> or by standard assembly resolution. If no assembly is provided, the method can provide one. The method also takes a parameter that specifies whether to perform a case-insensitive search; the value of <paramref name="ignoreCase" /> is passed to that parameter.  
		///  Caution   Do not pass methods from unknown or untrusted callers.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type cannot be found; <see langword="false" /> to return <see langword="null" />. Specifying <see langword="false" /> also suppresses some other exception conditions, but not all of them. See the Exceptions section.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to perform a case-insensitive search for <paramref name="typeName" />, <see langword="false" /> to perform a case-sensitive search for <paramref name="typeName" />.</param>
		/// <returns>The type with the specified name. If the type is not found, the <paramref name="throwOnError" /> parameter specifies whether <see langword="null" /> is returned or an exception is thrown. In some cases, an exception is thrown regardless of the value of <paramref name="throwOnError" />. See the Exceptions section.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the type is not found.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid characters, such as an embedded tab.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> is an empty string.  
		/// -or-  
		/// <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> represents an array type with an invalid size.  
		/// -or-  
		/// <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" />.</exception>
		/// <exception cref="T:System.ArgumentException">An error occurs when <paramref name="typeName" /> is parsed into a type name and an assembly name (for example, when the simple type name includes an unescaped special character).  
		///  -or-  
		///  <paramref name="throwOnError" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid syntax (for example, "MyType[,*,]").  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		///  -or-  
		///  <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="throwOnError" /> is <see langword="true" /> and the assembly or one of its dependencies was not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The assembly or one of its dependencies was found, but could not be loaded.  
		///  -or-  
		///  <paramref name="typeName" /> contains an invalid assembly name.  
		///  -or-  
		///  <paramref name="typeName" /> is a valid assembly name without a type name.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  The assembly was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		// Token: 0x060013F5 RID: 5109 RVA: 0x0003BF1C File Offset: 0x0003A11C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError, bool ignoreCase)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return TypeNameParser.GetType(typeName, assemblyResolver, typeResolver, throwOnError, ignoreCase, ref stackCrawlMark);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> with the specified name, specifying whether to perform a case-sensitive search and whether to throw an exception if the type is not found. The type is loaded for reflection only, not for execution.</summary>
		/// <param name="typeName">The assembly-qualified name of the <see cref="T:System.Type" /> to get.</param>
		/// <param name="throwIfNotFound">
		///   <see langword="true" /> to throw a <see cref="T:System.TypeLoadException" /> if the type cannot be found; <see langword="false" /> to return <see langword="null" /> if the type cannot be found. Specifying <see langword="false" /> also suppresses some other exception conditions, but not all of them. See the Exceptions section.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to perform a case-insensitive search for <paramref name="typeName" />; <see langword="false" /> to perform a case-sensitive search for <paramref name="typeName" />.</param>
		/// <returns>The type with the specified name, if found; otherwise, <see langword="null" />. If the type is not found, the <paramref name="throwIfNotFound" /> parameter specifies whether <see langword="null" /> is returned or an exception is thrown. In some cases, an exception is thrown regardless of the value of <paramref name="throwIfNotFound" />. See the Exceptions section.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwIfNotFound" /> is <see langword="true" /> and the type is not found.  
		/// -or-  
		/// <paramref name="throwIfNotFound" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid characters, such as an embedded tab.  
		/// -or-  
		/// <paramref name="throwIfNotFound" /> is <see langword="true" /> and <paramref name="typeName" /> is an empty string.  
		/// -or-  
		/// <paramref name="throwIfNotFound" /> is <see langword="true" /> and <paramref name="typeName" /> represents an array type with an invalid size.  
		/// -or-  
		/// <paramref name="typeName" /> represents an array of <see cref="T:System.TypedReference" /> objects.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="typeName" /> does not include the assembly name.  
		/// -or-  
		/// <paramref name="throwIfNotFound" /> is <see langword="true" /> and <paramref name="typeName" /> contains invalid syntax; for example, "MyType[,*,]".  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has a pointer type, a <see langword="ByRef" /> type, or <see cref="T:System.Void" /> as one of its type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type that has an incorrect number of type arguments.  
		/// -or-  
		/// <paramref name="typeName" /> represents a generic type, and one of its type arguments does not satisfy the constraints for the corresponding type parameter.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="throwIfNotFound" /> is <see langword="true" /> and the assembly or one of its dependencies was not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The assembly or one of its dependencies was found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">The assembly or one of its dependencies is not valid.  
		///  -or-  
		///  The assembly was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		// Token: 0x060013F6 RID: 5110 RVA: 0x0003BF38 File Offset: 0x0003A138
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Type ReflectionOnlyGetType(string typeName, bool throwIfNotFound, bool ignoreCase)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeType.GetType(typeName, throwIfNotFound, ignoreCase, true, ref stackCrawlMark);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents a pointer to the current type.</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents a pointer to the current type.</returns>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class.</exception>
		/// <exception cref="T:System.TypeLoadException">The current type is <see cref="T:System.TypedReference" />.  
		///  -or-  
		///  The current type is a <see langword="ByRef" /> type. That is, <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x060013F7 RID: 5111 RVA: 0x0003BF52 File Offset: 0x0003A152
		[__DynamicallyInvokable]
		public virtual Type MakePointerType()
		{
			throw new NotSupportedException();
		}

		/// <summary>Gets a <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> that describes the layout of the current type.</summary>
		/// <returns>Gets a <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> that describes the gross layout features of the current type.</returns>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class.</exception>
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060013F8 RID: 5112 RVA: 0x0003BF59 File Offset: 0x0003A159
		public virtual StructLayoutAttribute StructLayoutAttribute
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents the current type when passed as a <see langword="ref" /> parameter (<see langword="ByRef" /> parameter in Visual Basic).</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents the current type when passed as a <see langword="ref" /> parameter (<see langword="ByRef" /> parameter in Visual Basic).</returns>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class.</exception>
		/// <exception cref="T:System.TypeLoadException">The current type is <see cref="T:System.TypedReference" />.  
		///  -or-  
		///  The current type is a <see langword="ByRef" /> type. That is, <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x060013F9 RID: 5113 RVA: 0x0003BF60 File Offset: 0x0003A160
		[__DynamicallyInvokable]
		public virtual Type MakeByRefType()
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object representing a one-dimensional array of the current type, with a lower bound of zero.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing a one-dimensional array of the current type, with a lower bound of zero.</returns>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
		/// <exception cref="T:System.TypeLoadException">The current type is <see cref="T:System.TypedReference" />.  
		///  -or-  
		///  The current type is a <see langword="ByRef" /> type. That is, <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.</exception>
		// Token: 0x060013FA RID: 5114 RVA: 0x0003BF67 File Offset: 0x0003A167
		[__DynamicallyInvokable]
		public virtual Type MakeArrayType()
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object representing an array of the current type, with the specified number of dimensions.</summary>
		/// <param name="rank">The number of dimensions for the array. This number must be less than or equal to 32.</param>
		/// <returns>An object representing an array of the current type, with the specified number of dimensions.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="rank" /> is invalid. For example, 0 or negative.</exception>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class.</exception>
		/// <exception cref="T:System.TypeLoadException">The current type is <see cref="T:System.TypedReference" />.  
		///  -or-  
		///  The current type is a <see langword="ByRef" /> type. That is, <see cref="P:System.Type.IsByRef" /> returns <see langword="true" />.  
		///  -or-  
		///  <paramref name="rank" /> is greater than 32.</exception>
		// Token: 0x060013FB RID: 5115 RVA: 0x0003BF6E File Offset: 0x0003A16E
		[__DynamicallyInvokable]
		public virtual Type MakeArrayType(int rank)
		{
			throw new NotSupportedException();
		}

		/// <summary>Gets the type associated with the specified program identifier (ProgID), returning null if an error is encountered while loading the <see cref="T:System.Type" />.</summary>
		/// <param name="progID">The ProgID of the type to get.</param>
		/// <returns>The type associated with the specified ProgID, if <paramref name="progID" /> is a valid entry in the registry and a type is associated with it; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="progID" /> is <see langword="null" />.</exception>
		// Token: 0x060013FC RID: 5116 RVA: 0x0003BF75 File Offset: 0x0003A175
		[SecurityCritical]
		public static Type GetTypeFromProgID(string progID)
		{
			return RuntimeType.GetTypeFromProgIDImpl(progID, null, false);
		}

		/// <summary>Gets the type associated with the specified program identifier (ProgID), specifying whether to throw an exception if an error occurs while loading the type.</summary>
		/// <param name="progID">The ProgID of the type to get.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw any exception that occurs.  
		/// -or-  
		/// <see langword="false" /> to ignore any exception that occurs.</param>
		/// <returns>The type associated with the specified program identifier (ProgID), if <paramref name="progID" /> is a valid entry in the registry and a type is associated with it; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="progID" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">The specified ProgID is not registered.</exception>
		// Token: 0x060013FD RID: 5117 RVA: 0x0003BF7F File Offset: 0x0003A17F
		[SecurityCritical]
		public static Type GetTypeFromProgID(string progID, bool throwOnError)
		{
			return RuntimeType.GetTypeFromProgIDImpl(progID, null, throwOnError);
		}

		/// <summary>Gets the type associated with the specified program identifier (progID) from the specified server, returning null if an error is encountered while loading the type.</summary>
		/// <param name="progID">The progID of the type to get.</param>
		/// <param name="server">The server from which to load the type. If the server name is <see langword="null" />, this method automatically reverts to the local machine.</param>
		/// <returns>The type associated with the specified program identifier (progID), if <paramref name="progID" /> is a valid entry in the registry and a type is associated with it; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="prodID" /> is <see langword="null" />.</exception>
		// Token: 0x060013FE RID: 5118 RVA: 0x0003BF89 File Offset: 0x0003A189
		[SecurityCritical]
		public static Type GetTypeFromProgID(string progID, string server)
		{
			return RuntimeType.GetTypeFromProgIDImpl(progID, server, false);
		}

		/// <summary>Gets the type associated with the specified program identifier (progID) from the specified server, specifying whether to throw an exception if an error occurs while loading the type.</summary>
		/// <param name="progID">The progID of the <see cref="T:System.Type" /> to get.</param>
		/// <param name="server">The server from which to load the type. If the server name is <see langword="null" />, this method automatically reverts to the local machine.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw any exception that occurs.  
		/// -or-  
		/// <see langword="false" /> to ignore any exception that occurs.</param>
		/// <returns>The type associated with the specified program identifier (progID), if <paramref name="progID" /> is a valid entry in the registry and a type is associated with it; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="progID" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.COMException">The specified progID is not registered.</exception>
		// Token: 0x060013FF RID: 5119 RVA: 0x0003BF93 File Offset: 0x0003A193
		[SecurityCritical]
		public static Type GetTypeFromProgID(string progID, string server, bool throwOnError)
		{
			return RuntimeType.GetTypeFromProgIDImpl(progID, server, throwOnError);
		}

		/// <summary>Gets the type associated with the specified class identifier (CLSID).</summary>
		/// <param name="clsid">The CLSID of the type to get.</param>
		/// <returns>
		///   <see langword="System.__ComObject" /> regardless of whether the CLSID is valid.</returns>
		// Token: 0x06001400 RID: 5120 RVA: 0x0003BF9D File Offset: 0x0003A19D
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static Type GetTypeFromCLSID(Guid clsid)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, null, false);
		}

		/// <summary>Gets the type associated with the specified class identifier (CLSID), specifying whether to throw an exception if an error occurs while loading the type.</summary>
		/// <param name="clsid">The CLSID of the type to get.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw any exception that occurs.  
		/// -or-  
		/// <see langword="false" /> to ignore any exception that occurs.</param>
		/// <returns>
		///   <see langword="System.__ComObject" /> regardless of whether the CLSID is valid.</returns>
		// Token: 0x06001401 RID: 5121 RVA: 0x0003BFA7 File Offset: 0x0003A1A7
		[SecuritySafeCritical]
		public static Type GetTypeFromCLSID(Guid clsid, bool throwOnError)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, null, throwOnError);
		}

		/// <summary>Gets the type associated with the specified class identifier (CLSID) from the specified server.</summary>
		/// <param name="clsid">The CLSID of the type to get.</param>
		/// <param name="server">The server from which to load the type. If the server name is <see langword="null" />, this method automatically reverts to the local machine.</param>
		/// <returns>
		///   <see langword="System.__ComObject" /> regardless of whether the CLSID is valid.</returns>
		// Token: 0x06001402 RID: 5122 RVA: 0x0003BFB1 File Offset: 0x0003A1B1
		[SecuritySafeCritical]
		public static Type GetTypeFromCLSID(Guid clsid, string server)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, server, false);
		}

		/// <summary>Gets the type associated with the specified class identifier (CLSID) from the specified server, specifying whether to throw an exception if an error occurs while loading the type.</summary>
		/// <param name="clsid">The CLSID of the type to get.</param>
		/// <param name="server">The server from which to load the type. If the server name is <see langword="null" />, this method automatically reverts to the local machine.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw any exception that occurs.  
		/// -or-  
		/// <see langword="false" /> to ignore any exception that occurs.</param>
		/// <returns>
		///   <see langword="System.__ComObject" /> regardless of whether the CLSID is valid.</returns>
		// Token: 0x06001403 RID: 5123 RVA: 0x0003BFBB File Offset: 0x0003A1BB
		[SecuritySafeCritical]
		public static Type GetTypeFromCLSID(Guid clsid, string server, bool throwOnError)
		{
			return RuntimeType.GetTypeFromCLSIDImpl(clsid, server, throwOnError);
		}

		/// <summary>Gets the underlying type code of the specified <see cref="T:System.Type" />.</summary>
		/// <param name="type">The type whose underlying type code to get.</param>
		/// <returns>The code of the underlying type, or <see cref="F:System.TypeCode.Empty" /> if <paramref name="type" /> is <see langword="null" />.</returns>
		// Token: 0x06001404 RID: 5124 RVA: 0x0003BFC5 File Offset: 0x0003A1C5
		[__DynamicallyInvokable]
		public static TypeCode GetTypeCode(Type type)
		{
			if (type == null)
			{
				return TypeCode.Empty;
			}
			return type.GetTypeCodeImpl();
		}

		/// <summary>Returns the underlying type code of this <see cref="T:System.Type" /> instance.</summary>
		/// <returns>The type code of the underlying type.</returns>
		// Token: 0x06001405 RID: 5125 RVA: 0x0003BFD8 File Offset: 0x0003A1D8
		protected virtual TypeCode GetTypeCodeImpl()
		{
			if (this != this.UnderlyingSystemType && this.UnderlyingSystemType != null)
			{
				return Type.GetTypeCode(this.UnderlyingSystemType);
			}
			return TypeCode.Object;
		}

		/// <summary>Gets the GUID associated with the <see cref="T:System.Type" />.</summary>
		/// <returns>The GUID associated with the <see cref="T:System.Type" />.</returns>
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06001406 RID: 5126
		public abstract Guid GUID { get; }

		/// <summary>Gets a reference to the default binder, which implements internal rules for selecting the appropriate members to be called by <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])" />.</summary>
		/// <returns>A reference to the default binder used by the system.</returns>
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06001407 RID: 5127 RVA: 0x0003C003 File Offset: 0x0003A203
		public static Binder DefaultBinder
		{
			get
			{
				if (Type.defaultBinder == null)
				{
					Type.CreateBinder();
				}
				return Type.defaultBinder;
			}
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0003C018 File Offset: 0x0003A218
		private static void CreateBinder()
		{
			if (Type.defaultBinder == null)
			{
				DefaultBinder value = new DefaultBinder();
				Interlocked.CompareExchange<Binder>(ref Type.defaultBinder, value, null);
			}
		}

		/// <summary>When overridden in a derived class, invokes the specified member, using the specified binding constraints and matching the specified argument list, modifiers and culture.</summary>
		/// <param name="name">The string containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For <see langword="IDispatch" /> members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> | <see langword="BindingFlags.Static" /> are used.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (Nothing in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />. Note that explicitly defining a <see cref="T:System.Reflection.Binder" /> object may be required for successfully invoking method overloads with variable arguments.</param>
		/// <param name="target">The object on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="args" /> array. A parameter's associated attributes are stored in the member's signature.  
		///  The default binder processes this parameter only when calling a COM component.</param>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> object representing the globalization locale to use, which may be necessary for locale-specific conversions, such as converting a numeric String to a Double.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic) to use the current thread's <see cref="T:System.Globalization.CultureInfo" />.</param>
		/// <param name="namedParameters">An array containing the names of the parameters to which the values in the <paramref name="args" /> array are passed.</param>
		/// <returns>An object representing the return value of the invoked member.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="invokeAttr" /> does not contain <see langword="CreateInstance" /> and <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="args" /> and <paramref name="modifiers" /> do not have the same length.  
		/// -or-  
		/// <paramref name="invokeAttr" /> is not a valid <see cref="T:System.Reflection.BindingFlags" /> attribute.  
		/// -or-  
		/// <paramref name="invokeAttr" /> does not contain one of the following binding flags: <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="CreateInstance" /> combined with <see langword="InvokeMethod" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetField" /> and <see langword="SetField" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetProperty" /> and <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="InvokeMethod" /> combined with <see langword="SetField" /> or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="SetField" /> and <paramref name="args" /> has more than one element.  
		/// -or-  
		/// The named parameter array is larger than the argument array.  
		/// -or-  
		/// This method is called on a COM object and one of the following binding flags was not passed in: <see langword="BindingFlags.InvokeMethod" />, <see langword="BindingFlags.GetProperty" />, <see langword="BindingFlags.SetProperty" />, <see langword="BindingFlags.PutDispProperty" />, or <see langword="BindingFlags.PutRefDispProperty" />.  
		/// -or-  
		/// One of the named parameter arrays contains a string that is <see langword="null" />.</exception>
		/// <exception cref="T:System.MethodAccessException">The specified member is a class initializer.</exception>
		/// <exception cref="T:System.MissingFieldException">The field or property cannot be found.</exception>
		/// <exception cref="T:System.MissingMethodException">No method can be found that matches the arguments in <paramref name="args" />.  
		///  -or-  
		///  No member can be found that has the argument names supplied in <paramref name="namedParameters" />.  
		///  -or-  
		///  The current <see cref="T:System.Type" /> object represents a type that contains open type parameters, that is, <see cref="P:System.Type.ContainsGenericParameters" /> returns <see langword="true" />.</exception>
		/// <exception cref="T:System.Reflection.TargetException">The specified member cannot be invoked on <paramref name="target" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method matches the binding criteria.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method represented by <paramref name="name" /> has one or more unspecified generic type parameters. That is, the method's <see cref="P:System.Reflection.MethodInfo.ContainsGenericParameters" /> property returns <see langword="true" />.</exception>
		// Token: 0x06001409 RID: 5129
		public abstract object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);

		/// <summary>Invokes the specified member, using the specified binding constraints and matching the specified argument list and culture.</summary>
		/// <param name="name">The string containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For <see langword="IDispatch" /> members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> | <see langword="BindingFlags.Static" /> are used.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />. Note that explicitly defining a <see cref="T:System.Reflection.Binder" /> object may be required for successfully invoking method overloads with variable arguments.</param>
		/// <param name="target">The object on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <param name="culture">The object representing the globalization locale to use, which may be necessary for locale-specific conversions, such as converting a numeric <see cref="T:System.String" /> to a <see cref="T:System.Double" />.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic) to use the current thread's <see cref="T:System.Globalization.CultureInfo" />.</param>
		/// <returns>An object representing the return value of the invoked member.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="invokeAttr" /> does not contain <see langword="CreateInstance" /> and <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="invokeAttr" /> is not a valid <see cref="T:System.Reflection.BindingFlags" /> attribute.  
		/// -or-  
		/// <paramref name="invokeAttr" /> does not contain one of the following binding flags: <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="CreateInstance" /> combined with <see langword="InvokeMethod" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetField" /> and <see langword="SetField" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetProperty" /> and <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="InvokeMethod" /> combined with <see langword="SetField" /> or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="SetField" /> and <paramref name="args" /> has more than one element.  
		/// -or-  
		/// This method is called on a COM object and one of the following binding flags was not passed in: <see langword="BindingFlags.InvokeMethod" />, <see langword="BindingFlags.GetProperty" />, <see langword="BindingFlags.SetProperty" />, <see langword="BindingFlags.PutDispProperty" />, or <see langword="BindingFlags.PutRefDispProperty" />.  
		/// -or-  
		/// One of the named parameter arrays contains a string that is <see langword="null" />.</exception>
		/// <exception cref="T:System.MethodAccessException">The specified member is a class initializer.</exception>
		/// <exception cref="T:System.MissingFieldException">The field or property cannot be found.</exception>
		/// <exception cref="T:System.MissingMethodException">No method can be found that matches the arguments in <paramref name="args" />.  
		///  -or-  
		///  The current <see cref="T:System.Type" /> object represents a type that contains open type parameters, that is, <see cref="P:System.Type.ContainsGenericParameters" /> returns <see langword="true" />.</exception>
		/// <exception cref="T:System.Reflection.TargetException">The specified member cannot be invoked on <paramref name="target" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method matches the binding criteria.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method represented by <paramref name="name" /> has one or more unspecified generic type parameters. That is, the method's <see cref="P:System.Reflection.MethodInfo.ContainsGenericParameters" /> property returns <see langword="true" />.</exception>
		// Token: 0x0600140A RID: 5130 RVA: 0x0003C040 File Offset: 0x0003A240
		[DebuggerStepThrough]
		[DebuggerHidden]
		public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture)
		{
			return this.InvokeMember(name, invokeAttr, binder, target, args, null, culture, null);
		}

		/// <summary>Invokes the specified member, using the specified binding constraints and matching the specified argument list.</summary>
		/// <param name="name">The string containing the name of the constructor, method, property, or field member to invoke.  
		///  -or-  
		///  An empty string ("") to invoke the default member.  
		///  -or-  
		///  For <see langword="IDispatch" /> members, a string representing the DispID, for example "[DispID=3]".</param>
		/// <param name="invokeAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted. The access can be one of the <see langword="BindingFlags" /> such as <see langword="Public" />, <see langword="NonPublic" />, <see langword="Private" />, <see langword="InvokeMethod" />, <see langword="GetField" />, and so on. The type of lookup need not be specified. If the type of lookup is omitted, <see langword="BindingFlags.Public" /> | <see langword="BindingFlags.Instance" /> | <see langword="BindingFlags.Static" /> are used.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />. Note that explicitly defining a <see cref="T:System.Reflection.Binder" /> object may be required for successfully invoking method overloads with variable arguments.</param>
		/// <param name="target">The object on which to invoke the specified member.</param>
		/// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
		/// <returns>An object representing the return value of the invoked member.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="invokeAttr" /> does not contain <see langword="CreateInstance" /> and <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="invokeAttr" /> is not a valid <see cref="T:System.Reflection.BindingFlags" /> attribute.  
		/// -or-  
		/// <paramref name="invokeAttr" /> does not contain one of the following binding flags: <see langword="InvokeMethod" />, <see langword="CreateInstance" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="CreateInstance" /> combined with <see langword="InvokeMethod" />, <see langword="GetField" />, <see langword="SetField" />, <see langword="GetProperty" />, or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetField" /> and <see langword="SetField" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains both <see langword="GetProperty" /> and <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="InvokeMethod" /> combined with <see langword="SetField" /> or <see langword="SetProperty" />.  
		/// -or-  
		/// <paramref name="invokeAttr" /> contains <see langword="SetField" /> and <paramref name="args" /> has more than one element.  
		/// -or-  
		/// This method is called on a COM object and one of the following binding flags was not passed in: <see langword="BindingFlags.InvokeMethod" />, <see langword="BindingFlags.GetProperty" />, <see langword="BindingFlags.SetProperty" />, <see langword="BindingFlags.PutDispProperty" />, or <see langword="BindingFlags.PutRefDispProperty" />.  
		/// -or-  
		/// One of the named parameter arrays contains a string that is <see langword="null" />.</exception>
		/// <exception cref="T:System.MethodAccessException">The specified member is a class initializer.</exception>
		/// <exception cref="T:System.MissingFieldException">The field or property cannot be found.</exception>
		/// <exception cref="T:System.MissingMethodException">No method can be found that matches the arguments in <paramref name="args" />.  
		///  -or-  
		///  The current <see cref="T:System.Type" /> object represents a type that contains open type parameters, that is, <see cref="P:System.Type.ContainsGenericParameters" /> returns <see langword="true" />.</exception>
		/// <exception cref="T:System.Reflection.TargetException">The specified member cannot be invoked on <paramref name="target" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method matches the binding criteria.</exception>
		/// <exception cref="T:System.NotSupportedException">The .NET Compact Framework does not currently support this method.</exception>
		/// <exception cref="T:System.InvalidOperationException">The method represented by <paramref name="name" /> has one or more unspecified generic type parameters. That is, the method's <see cref="P:System.Reflection.MethodInfo.ContainsGenericParameters" /> property returns <see langword="true" />.</exception>
		// Token: 0x0600140B RID: 5131 RVA: 0x0003C060 File Offset: 0x0003A260
		[DebuggerStepThrough]
		[DebuggerHidden]
		public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args)
		{
			return this.InvokeMember(name, invokeAttr, binder, target, args, null, null, null);
		}

		/// <summary>Gets the module (the DLL) in which the current <see cref="T:System.Type" /> is defined.</summary>
		/// <returns>The module in which the current <see cref="T:System.Type" /> is defined.</returns>
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x0600140C RID: 5132
		public new abstract Module Module { get; }

		/// <summary>Gets the <see cref="T:System.Reflection.Assembly" /> in which the type is declared. For generic types, gets the <see cref="T:System.Reflection.Assembly" /> in which the generic type is defined.</summary>
		/// <returns>An <see cref="T:System.Reflection.Assembly" /> instance that describes the assembly containing the current type. For generic types, the instance describes the assembly that contains the generic type definition, not the assembly that creates and uses a particular constructed type.</returns>
		// Token: 0x17000221 RID: 545
		// (get) Token: 0x0600140D RID: 5133
		[__DynamicallyInvokable]
		public abstract Assembly Assembly { [__DynamicallyInvokable] get; }

		/// <summary>Gets the handle for the current <see cref="T:System.Type" />.</summary>
		/// <returns>The handle for the current <see cref="T:System.Type" />.</returns>
		/// <exception cref="T:System.NotSupportedException">The .NET Compact Framework does not currently support this property.</exception>
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x0003C07D File Offset: 0x0003A27D
		[__DynamicallyInvokable]
		public virtual RuntimeTypeHandle TypeHandle
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0003C084 File Offset: 0x0003A284
		internal virtual RuntimeTypeHandle GetTypeHandleInternal()
		{
			return this.TypeHandle;
		}

		/// <summary>Gets the handle for the <see cref="T:System.Type" /> of a specified object.</summary>
		/// <param name="o">The object for which to get the type handle.</param>
		/// <returns>The handle for the <see cref="T:System.Type" /> of the specified <see cref="T:System.Object" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="o" /> is <see langword="null" />.</exception>
		// Token: 0x06001410 RID: 5136 RVA: 0x0003C08C File Offset: 0x0003A28C
		[__DynamicallyInvokable]
		public static RuntimeTypeHandle GetTypeHandle(object o)
		{
			if (o == null)
			{
				throw new ArgumentNullException(null, Environment.GetResourceString("Arg_InvalidHandle"));
			}
			return new RuntimeTypeHandle((RuntimeType)o.GetType());
		}

		// Token: 0x06001411 RID: 5137
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern RuntimeType GetTypeFromHandleUnsafe(IntPtr handle);

		/// <summary>Gets the type referenced by the specified type handle.</summary>
		/// <param name="handle">The object that refers to the type.</param>
		/// <returns>The type referenced by the specified <see cref="T:System.RuntimeTypeHandle" />, or <see langword="null" /> if the <see cref="P:System.RuntimeTypeHandle.Value" /> property of <paramref name="handle" /> is <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		// Token: 0x06001412 RID: 5138
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern Type GetTypeFromHandle(RuntimeTypeHandle handle);

		/// <summary>Gets the fully qualified name of the type, including its namespace but not its assembly.</summary>
		/// <returns>The fully qualified name of the type, including its namespace but not its assembly; or <see langword="null" /> if the current instance represents a generic type parameter, an array type, pointer type, or <see langword="byref" /> type based on a type parameter, or a generic type that is not a generic type definition but contains unresolved type parameters.</returns>
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06001413 RID: 5139
		[__DynamicallyInvokable]
		public abstract string FullName { [__DynamicallyInvokable] get; }

		/// <summary>Gets the namespace of the <see cref="T:System.Type" />.</summary>
		/// <returns>The namespace of the <see cref="T:System.Type" />; <see langword="null" /> if the current instance has no namespace or represents a generic parameter.</returns>
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06001414 RID: 5140
		[__DynamicallyInvokable]
		public abstract string Namespace { [__DynamicallyInvokable] get; }

		/// <summary>Gets the assembly-qualified name of the type, which includes the name of the assembly from which this <see cref="T:System.Type" /> object was loaded.</summary>
		/// <returns>The assembly-qualified name of the <see cref="T:System.Type" />, which includes the name of the assembly from which the <see cref="T:System.Type" /> was loaded, or <see langword="null" /> if the current instance represents a generic type parameter.</returns>
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06001415 RID: 5141
		[__DynamicallyInvokable]
		public abstract string AssemblyQualifiedName { [__DynamicallyInvokable] get; }

		/// <summary>Gets the number of dimensions in an array.</summary>
		/// <returns>An integer that contains the number of dimensions in the current type.</returns>
		/// <exception cref="T:System.NotSupportedException">The functionality of this method is unsupported in the base class and must be implemented in a derived class instead.</exception>
		/// <exception cref="T:System.ArgumentException">The current type is not an array.</exception>
		// Token: 0x06001416 RID: 5142 RVA: 0x0003C0B2 File Offset: 0x0003A2B2
		[__DynamicallyInvokable]
		public virtual int GetArrayRank()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Gets the type from which the current <see cref="T:System.Type" /> directly inherits.</summary>
		/// <returns>The <see cref="T:System.Type" /> from which the current <see cref="T:System.Type" /> directly inherits, or <see langword="null" /> if the current <see langword="Type" /> represents the <see cref="T:System.Object" /> class or an interface.</returns>
		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06001417 RID: 5143
		[__DynamicallyInvokable]
		public abstract Type BaseType { [__DynamicallyInvokable] get; }

		/// <summary>Searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and the stack is cleaned up.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the constructor to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>An object representing the constructor that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		// Token: 0x06001418 RID: 5144 RVA: 0x0003C0C4 File Offset: 0x0003A2C4
		[ComVisible(true)]
		public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
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
			return this.GetConstructorImpl(bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the constructor to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.  
		///  -or-  
		///  <see cref="F:System.Type.EmptyTypes" />.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the parameter type array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object representing the constructor that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		// Token: 0x06001419 RID: 5145 RVA: 0x0003C114 File Offset: 0x0003A314
		[ComVisible(true)]
		public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
		{
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
			return this.GetConstructorImpl(bindingAttr, binder, CallingConventions.Any, types, modifiers);
		}

		/// <summary>Searches for a public instance constructor whose parameters match the types in the specified array.</summary>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the desired constructor.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects, to get a constructor that takes no parameters. Such an empty array is provided by the <see langword="static" /> field <see cref="F:System.Type.EmptyTypes" />.</param>
		/// <returns>An object representing the public instance constructor whose parameters match the types in the parameter type array, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.</exception>
		// Token: 0x0600141A RID: 5146 RVA: 0x0003C15F File Offset: 0x0003A35F
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public ConstructorInfo GetConstructor(Type[] types)
		{
			return this.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);
		}

		/// <summary>When overridden in a derived class, searches for a constructor whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and the stack is cleaned up.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the constructor to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a constructor that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object representing the constructor that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		/// <exception cref="T:System.NotSupportedException">The current type is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> or <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder" />.</exception>
		// Token: 0x0600141B RID: 5147
		protected abstract ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Returns all the public constructors defined for the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing all the public instance constructors defined for the current <see cref="T:System.Type" />, but not including the type initializer (static constructor). If no public instance constructors are defined for the current <see cref="T:System.Type" />, or if the current <see cref="T:System.Type" /> represents a type parameter in the definition of a generic type or generic method, an empty array of type <see cref="T:System.Reflection.ConstructorInfo" /> is returned.</returns>
		// Token: 0x0600141C RID: 5148 RVA: 0x0003C16C File Offset: 0x0003A36C
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public ConstructorInfo[] GetConstructors()
		{
			return this.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the constructors defined for the current <see cref="T:System.Type" />, using the specified <see langword="BindingFlags" />.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing all constructors defined for the current <see cref="T:System.Type" /> that match the specified binding constraints, including the type initializer if it is defined. Returns an empty array of type <see cref="T:System.Reflection.ConstructorInfo" /> if no constructors are defined for the current <see cref="T:System.Type" />, if none of the defined constructors match the binding constraints, or if the current <see cref="T:System.Type" /> represents a type parameter in the definition of a generic type or generic method.</returns>
		// Token: 0x0600141D RID: 5149
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public abstract ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);

		/// <summary>Gets the initializer for the type.</summary>
		/// <returns>An object that contains the name of the class constructor for the <see cref="T:System.Type" />.</returns>
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x0003C176 File Offset: 0x0003A376
		[ComVisible(true)]
		public ConstructorInfo TypeInitializer
		{
			get
			{
				return this.GetConstructorImpl(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, Type.EmptyTypes, null);
			}
		}

		/// <summary>Searches for the specified method whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.</summary>
		/// <param name="name">The string containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and how the stack is cleaned up.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects (as provided by the <see cref="F:System.Type.EmptyTypes" /> field) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. To be only used when calling through COM interop, and only parameters that are passed by reference are handled. The default binder does not process this parameter.</param>
		/// <returns>An object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.</exception>
		// Token: 0x0600141F RID: 5151 RVA: 0x0003C188 File Offset: 0x0003A388
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

		/// <summary>Searches for the specified method whose parameters match the specified argument types and modifiers, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects (as provided by the <see cref="F:System.Type.EmptyTypes" /> field) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. To be only used when calling through COM interop, and only parameters that are passed by reference are handled. The default binder does not process this parameter.</param>
		/// <returns>An object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.</exception>
		// Token: 0x06001420 RID: 5152 RVA: 0x0003C1E8 File Offset: 0x0003A3E8
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
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
			return this.GetMethodImpl(name, bindingAttr, binder, CallingConventions.Any, types, modifiers);
		}

		/// <summary>Searches for the specified public method whose parameters match the specified argument types and modifiers.</summary>
		/// <param name="name">The string containing the name of the public method to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects (as provided by the <see cref="F:System.Type.EmptyTypes" /> field) to get a method that takes no parameters.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. To be only used when calling through COM interop, and only parameters that are passed by reference are handled. The default binder does not process this parameter.</param>
		/// <returns>An object representing the public method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and specified parameters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.</exception>
		// Token: 0x06001421 RID: 5153 RVA: 0x0003C248 File Offset: 0x0003A448
		public MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers)
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
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, types, modifiers);
		}

		/// <summary>Searches for the specified public method whose parameters match the specified argument types.</summary>
		/// <param name="name">The string containing the name of the public method to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of <see cref="T:System.Type" /> objects (as provided by the <see cref="F:System.Type.EmptyTypes" /> field) to get a method that takes no parameters.</param>
		/// <returns>An object representing the public method whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and specified parameters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.</exception>
		// Token: 0x06001422 RID: 5154 RVA: 0x0003C2A4 File Offset: 0x0003A4A4
		[__DynamicallyInvokable]
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

		/// <summary>Searches for the specified method, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001423 RID: 5155 RVA: 0x0003C2FE File Offset: 0x0003A4FE
		[__DynamicallyInvokable]
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetMethodImpl(name, bindingAttr, null, CallingConventions.Any, null, null);
		}

		/// <summary>Searches for the public method with the specified name.</summary>
		/// <param name="name">The string containing the name of the public method to get.</param>
		/// <returns>An object that represents the public method with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001424 RID: 5156 RVA: 0x0003C31A File Offset: 0x0003A51A
		[__DynamicallyInvokable]
		public MethodInfo GetMethod(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetMethodImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Any, null, null);
		}

		/// <summary>When overridden in a derived class, searches for the specified method whose parameters match the specified argument types and modifiers, using the specified binding constraints and the specified calling convention.</summary>
		/// <param name="name">The string containing the name of the method to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="callConvention">The object that specifies the set of rules to use regarding the order and layout of arguments, how the return value is passed, what registers are used for arguments, and what process cleans up the stack.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the method to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a method that takes no parameters.  
		///  -or-  
		///  <see langword="null" />. If <paramref name="types" /> is <see langword="null" />, arguments are not matched.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>An object representing the method that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		/// <exception cref="T:System.NotSupportedException">The current type is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> or <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder" />.</exception>
		// Token: 0x06001425 RID: 5157
		protected abstract MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);

		/// <summary>Returns all the public methods of the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects representing all the public methods defined for the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MethodInfo" />, if no public methods are defined for the current <see cref="T:System.Type" />.</returns>
		// Token: 0x06001426 RID: 5158 RVA: 0x0003C337 File Offset: 0x0003A537
		[__DynamicallyInvokable]
		public MethodInfo[] GetMethods()
		{
			return this.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the methods defined for the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MethodInfo" /> objects representing all methods defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MethodInfo" />, if no methods are defined for the current <see cref="T:System.Type" />, or if none of the defined methods match the binding constraints.</returns>
		// Token: 0x06001427 RID: 5159
		[__DynamicallyInvokable]
		public abstract MethodInfo[] GetMethods(BindingFlags bindingAttr);

		/// <summary>Searches for the specified field, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the data field to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An object representing the field that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001428 RID: 5160
		[__DynamicallyInvokable]
		public abstract FieldInfo GetField(string name, BindingFlags bindingAttr);

		/// <summary>Searches for the public field with the specified name.</summary>
		/// <param name="name">The string containing the name of the data field to get.</param>
		/// <returns>An object representing the public field with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">This <see cref="T:System.Type" /> object is a <see cref="T:System.Reflection.Emit.TypeBuilder" /> whose <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method has not yet been called.</exception>
		// Token: 0x06001429 RID: 5161 RVA: 0x0003C341 File Offset: 0x0003A541
		[__DynamicallyInvokable]
		public FieldInfo GetField(string name)
		{
			return this.GetField(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Returns all the public fields of the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.FieldInfo" /> objects representing all the public fields defined for the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.FieldInfo" />, if no public fields are defined for the current <see cref="T:System.Type" />.</returns>
		// Token: 0x0600142A RID: 5162 RVA: 0x0003C34C File Offset: 0x0003A54C
		[__DynamicallyInvokable]
		public FieldInfo[] GetFields()
		{
			return this.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the fields defined for the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.FieldInfo" /> objects representing all fields defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.FieldInfo" />, if no fields are defined for the current <see cref="T:System.Type" />, or if none of the defined fields match the binding constraints.</returns>
		// Token: 0x0600142B RID: 5163
		[__DynamicallyInvokable]
		public abstract FieldInfo[] GetFields(BindingFlags bindingAttr);

		/// <summary>Searches for the interface with the specified name.</summary>
		/// <param name="name">The string containing the name of the interface to get. For generic interfaces, this is the mangled name.</param>
		/// <returns>An object representing the interface with the specified name, implemented or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">The current <see cref="T:System.Type" /> represents a type that implements the same generic interface with different type arguments.</exception>
		// Token: 0x0600142C RID: 5164 RVA: 0x0003C356 File Offset: 0x0003A556
		public Type GetInterface(string name)
		{
			return this.GetInterface(name, false);
		}

		/// <summary>When overridden in a derived class, searches for the specified interface, specifying whether to do a case-insensitive search for the interface name.</summary>
		/// <param name="name">The string containing the name of the interface to get. For generic interfaces, this is the mangled name.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore the case of that part of <paramref name="name" /> that specifies the simple interface name (the part that specifies the namespace must be correctly cased).  
		/// -or-  
		/// <see langword="false" /> to perform a case-sensitive search for all parts of <paramref name="name" />.</param>
		/// <returns>An object representing the interface with the specified name, implemented or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">The current <see cref="T:System.Type" /> represents a type that implements the same generic interface with different type arguments.</exception>
		// Token: 0x0600142D RID: 5165
		public abstract Type GetInterface(string name, bool ignoreCase);

		/// <summary>When overridden in a derived class, gets all the interfaces implemented or inherited by the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the interfaces implemented or inherited by the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Type" />, if no interfaces are implemented or inherited by the current <see cref="T:System.Type" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A static initializer is invoked and throws an exception.</exception>
		// Token: 0x0600142E RID: 5166
		[__DynamicallyInvokable]
		public abstract Type[] GetInterfaces();

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects representing a filtered list of interfaces implemented or inherited by the current <see cref="T:System.Type" />.</summary>
		/// <param name="filter">The delegate that compares the interfaces against <paramref name="filterCriteria" />.</param>
		/// <param name="filterCriteria">The search criteria that determines whether an interface should be included in the returned array.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing a filtered list of the interfaces implemented or inherited by the current <see cref="T:System.Type" />, or an empty array of type <see cref="T:System.Type" /> if no interfaces matching the filter are implemented or inherited by the current <see cref="T:System.Type" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="filter" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A static initializer is invoked and throws an exception.</exception>
		// Token: 0x0600142F RID: 5167 RVA: 0x0003C360 File Offset: 0x0003A560
		public virtual Type[] FindInterfaces(TypeFilter filter, object filterCriteria)
		{
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			Type[] interfaces = this.GetInterfaces();
			int num = 0;
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (!filter(interfaces[i], filterCriteria))
				{
					interfaces[i] = null;
				}
				else
				{
					num++;
				}
			}
			if (num == interfaces.Length)
			{
				return interfaces;
			}
			Type[] array = new Type[num];
			num = 0;
			for (int j = 0; j < interfaces.Length; j++)
			{
				if (interfaces[j] != null)
				{
					array[num++] = interfaces[j];
				}
			}
			return array;
		}

		/// <summary>Returns the <see cref="T:System.Reflection.EventInfo" /> object representing the specified public event.</summary>
		/// <param name="name">The string containing the name of an event that is declared or inherited by the current <see cref="T:System.Type" />.</param>
		/// <returns>The object representing the specified public event that is declared or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001430 RID: 5168 RVA: 0x0003C3E3 File Offset: 0x0003A5E3
		[__DynamicallyInvokable]
		public EventInfo GetEvent(string name)
		{
			return this.GetEvent(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, returns the <see cref="T:System.Reflection.EventInfo" /> object representing the specified event, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of an event which is declared or inherited by the current <see cref="T:System.Type" />.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>The object representing the specified event that is declared or inherited by the current <see cref="T:System.Type" />, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001431 RID: 5169
		[__DynamicallyInvokable]
		public abstract EventInfo GetEvent(string name, BindingFlags bindingAttr);

		/// <summary>Returns all the public events that are declared or inherited by the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing all the public events which are declared or inherited by the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.EventInfo" />, if the current <see cref="T:System.Type" /> does not have public events.</returns>
		// Token: 0x06001432 RID: 5170 RVA: 0x0003C3EE File Offset: 0x0003A5EE
		[__DynamicallyInvokable]
		public virtual EventInfo[] GetEvents()
		{
			return this.GetEvents(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for events that are declared or inherited by the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.EventInfo" /> objects representing all events that are declared or inherited by the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.EventInfo" />, if the current <see cref="T:System.Type" /> does not have events, or if none of the events match the binding constraints.</returns>
		// Token: 0x06001433 RID: 5171
		[__DynamicallyInvokable]
		public abstract EventInfo[] GetEvents(BindingFlags bindingAttr);

		/// <summary>Searches for the specified property whose parameters match the specified argument types and modifiers, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>An object representing the property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		/// <exception cref="T:System.NullReferenceException">An element of <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06001434 RID: 5172 RVA: 0x0003C3F8 File Offset: 0x0003A5F8
		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			return this.GetPropertyImpl(name, bindingAttr, binder, returnType, types, modifiers);
		}

		/// <summary>Searches for the specified public property whose parameters match the specified argument types and modifiers.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>An object representing the public property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types and modifiers.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		/// <exception cref="T:System.NullReferenceException">An element of <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06001435 RID: 5173 RVA: 0x0003C426 File Offset: 0x0003A626
		public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, returnType, types, modifiers);
		}

		/// <summary>Searches for the specified property, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An object representing the property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001436 RID: 5174 RVA: 0x0003C452 File Offset: 0x0003A652
		[__DynamicallyInvokable]
		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetPropertyImpl(name, bindingAttr, null, null, null, null);
		}

		/// <summary>Searches for the specified public property whose parameters match the specified argument types.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <returns>An object representing the public property whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.</exception>
		/// <exception cref="T:System.NullReferenceException">An element of <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06001437 RID: 5175 RVA: 0x0003C46E File Offset: 0x0003A66E
		[__DynamicallyInvokable]
		public PropertyInfo GetProperty(string name, Type returnType, Type[] types)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, returnType, types, null);
		}

		/// <summary>Searches for the specified public property whose parameters match the specified argument types.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <returns>An object representing the public property whose parameters match the specified argument types, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified argument types.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.</exception>
		/// <exception cref="T:System.NullReferenceException">An element of <paramref name="types" /> is <see langword="null" />.</exception>
		// Token: 0x06001438 RID: 5176 RVA: 0x0003C499 File Offset: 0x0003A699
		public PropertyInfo GetProperty(string name, Type[] types)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (types == null)
			{
				throw new ArgumentNullException("types");
			}
			return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, null, types, null);
		}

		/// <summary>Searches for the public property with the specified name and return type.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <returns>An object representing the public property with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />, or <paramref name="returnType" /> is <see langword="null" />.</exception>
		// Token: 0x06001439 RID: 5177 RVA: 0x0003C4C4 File Offset: 0x0003A6C4
		[__DynamicallyInvokable]
		public PropertyInfo GetProperty(string name, Type returnType)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, returnType, null, null);
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0003C4F5 File Offset: 0x0003A6F5
		internal PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Type returnType)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (returnType == null)
			{
				throw new ArgumentNullException("returnType");
			}
			return this.GetPropertyImpl(name, bindingAttr, null, returnType, null, null);
		}

		/// <summary>Searches for the public property with the specified name.</summary>
		/// <param name="name">The string containing the name of the public property to get.</param>
		/// <returns>An object representing the public property with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x0600143B RID: 5179 RVA: 0x0003C525 File Offset: 0x0003A725
		[__DynamicallyInvokable]
		public PropertyInfo GetProperty(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetPropertyImpl(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public, null, null, null, null);
		}

		/// <summary>When overridden in a derived class, searches for the specified property whose parameters match the specified argument types and modifiers, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the property to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded member, coercion of argument types, and invocation of a member through reflection.  
		///  -or-  
		///  A null reference (<see langword="Nothing" /> in Visual Basic), to use the <see cref="P:System.Type.DefaultBinder" />.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="types">An array of <see cref="T:System.Type" /> objects representing the number, order, and type of the parameters for the indexed property to get.  
		///  -or-  
		///  An empty array of the type <see cref="T:System.Type" /> (that is, Type[] types = new Type[0]) to get a property that is not indexed.</param>
		/// <param name="modifiers">An array of <see cref="T:System.Reflection.ParameterModifier" /> objects representing the attributes associated with the corresponding element in the <paramref name="types" /> array. The default binder does not process this parameter.</param>
		/// <returns>An object representing the property that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="types" /> is <see langword="null" />.  
		/// -or-  
		/// One of the elements in <paramref name="types" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="types" /> is multidimensional.  
		/// -or-  
		/// <paramref name="modifiers" /> is multidimensional.  
		/// -or-  
		/// <paramref name="types" /> and <paramref name="modifiers" /> do not have the same length.</exception>
		/// <exception cref="T:System.NotSupportedException">The current type is a <see cref="T:System.Reflection.Emit.TypeBuilder" />, <see cref="T:System.Reflection.Emit.EnumBuilder" />, or <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder" />.</exception>
		// Token: 0x0600143C RID: 5180
		protected abstract PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);

		/// <summary>When overridden in a derived class, searches for the properties of the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Reflection.PropertyInfo" /> objects representing all properties of the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.PropertyInfo" />, if the current <see cref="T:System.Type" /> does not have properties, or if none of the properties match the binding constraints.</returns>
		// Token: 0x0600143D RID: 5181
		[__DynamicallyInvokable]
		public abstract PropertyInfo[] GetProperties(BindingFlags bindingAttr);

		/// <summary>Returns all the public properties of the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.PropertyInfo" /> objects representing all public properties of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.PropertyInfo" />, if the current <see cref="T:System.Type" /> does not have public properties.</returns>
		// Token: 0x0600143E RID: 5182 RVA: 0x0003C542 File Offset: 0x0003A742
		[__DynamicallyInvokable]
		public PropertyInfo[] GetProperties()
		{
			return this.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Returns the public types nested in the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing the public types nested in the current <see cref="T:System.Type" /> (the search is not recursive), or an empty array of type <see cref="T:System.Type" /> if no public types are nested in the current <see cref="T:System.Type" />.</returns>
		// Token: 0x0600143F RID: 5183 RVA: 0x0003C54C File Offset: 0x0003A74C
		public Type[] GetNestedTypes()
		{
			return this.GetNestedTypes(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the types nested in the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the types nested in the current <see cref="T:System.Type" /> that match the specified binding constraints (the search is not recursive), or an empty array of type <see cref="T:System.Type" />, if no nested types are found that match the binding constraints.</returns>
		// Token: 0x06001440 RID: 5184
		[__DynamicallyInvokable]
		public abstract Type[] GetNestedTypes(BindingFlags bindingAttr);

		/// <summary>Searches for the public nested type with the specified name.</summary>
		/// <param name="name">The string containing the name of the nested type to get.</param>
		/// <returns>An object representing the public nested type with the specified name, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001441 RID: 5185 RVA: 0x0003C556 File Offset: 0x0003A756
		public Type GetNestedType(string name)
		{
			return this.GetNestedType(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the specified nested type, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the nested type to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <returns>An object representing the nested type that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001442 RID: 5186
		[__DynamicallyInvokable]
		public abstract Type GetNestedType(string name, BindingFlags bindingAttr);

		/// <summary>Searches for the public members with the specified name.</summary>
		/// <param name="name">The string containing the name of the public members to get.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001443 RID: 5187 RVA: 0x0003C561 File Offset: 0x0003A761
		[__DynamicallyInvokable]
		public MemberInfo[] GetMember(string name)
		{
			return this.GetMember(name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>Searches for the specified members, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the members to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return an empty array.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06001444 RID: 5188 RVA: 0x0003C56C File Offset: 0x0003A76C
		[__DynamicallyInvokable]
		public virtual MemberInfo[] GetMember(string name, BindingFlags bindingAttr)
		{
			return this.GetMember(name, MemberTypes.All, bindingAttr);
		}

		/// <summary>Searches for the specified members of the specified member type, using the specified binding constraints.</summary>
		/// <param name="name">The string containing the name of the members to get.</param>
		/// <param name="type">The value to search for.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return an empty array.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public members with the specified name, if found; otherwise, an empty array.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">A derived class must provide an implementation.</exception>
		// Token: 0x06001445 RID: 5189 RVA: 0x0003C57B File Offset: 0x0003A77B
		public virtual MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Returns all the public members of the current <see cref="T:System.Type" />.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all the public members of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have public members.</returns>
		// Token: 0x06001446 RID: 5190 RVA: 0x0003C58C File Offset: 0x0003A78C
		[__DynamicallyInvokable]
		public MemberInfo[] GetMembers()
		{
			return this.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		/// <summary>When overridden in a derived class, searches for the members defined for the current <see cref="T:System.Type" />, using the specified binding constraints.</summary>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero (<see cref="F:System.Reflection.BindingFlags.Default" />), to return an empty array.</param>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all members defined for the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if no members are defined for the current <see cref="T:System.Type" />, or if none of the defined members match the binding constraints.</returns>
		// Token: 0x06001447 RID: 5191
		[__DynamicallyInvokable]
		public abstract MemberInfo[] GetMembers(BindingFlags bindingAttr);

		/// <summary>Searches for the members defined for the current <see cref="T:System.Type" /> whose <see cref="T:System.Reflection.DefaultMemberAttribute" /> is set.</summary>
		/// <returns>An array of <see cref="T:System.Reflection.MemberInfo" /> objects representing all default members of the current <see cref="T:System.Type" />.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have default members.</returns>
		// Token: 0x06001448 RID: 5192 RVA: 0x0003C596 File Offset: 0x0003A796
		[__DynamicallyInvokable]
		public virtual MemberInfo[] GetDefaultMembers()
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns a filtered array of <see cref="T:System.Reflection.MemberInfo" /> objects of the specified member type.</summary>
		/// <param name="memberType">An object that indicates the type of member to search for.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to return <see langword="null" />.</param>
		/// <param name="filter">The delegate that does the comparisons, returning <see langword="true" /> if the member currently being inspected matches the <paramref name="filterCriteria" /> and <see langword="false" /> otherwise. You can use the <see langword="FilterAttribute" />, <see langword="FilterName" />, and <see langword="FilterNameIgnoreCase" /> delegates supplied by this class. The first uses the fields of <see langword="FieldAttributes" />, <see langword="MethodAttributes" />, and <see langword="MethodImplAttributes" /> as search criteria, and the other two delegates use <see langword="String" /> objects as the search criteria.</param>
		/// <param name="filterCriteria">The search criteria that determines whether a member is returned in the array of <see langword="MemberInfo" /> objects.  
		///  The fields of <see langword="FieldAttributes" />, <see langword="MethodAttributes" />, and <see langword="MethodImplAttributes" /> can be used in conjunction with the <see langword="FilterAttribute" /> delegate supplied by this class.</param>
		/// <returns>A filtered array of <see cref="T:System.Reflection.MemberInfo" /> objects of the specified member type.  
		///  -or-  
		///  An empty array of type <see cref="T:System.Reflection.MemberInfo" />, if the current <see cref="T:System.Type" /> does not have members of type <paramref name="memberType" /> that match the filter criteria.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="filter" /> is <see langword="null" />.</exception>
		// Token: 0x06001449 RID: 5193 RVA: 0x0003C5A0 File Offset: 0x0003A7A0
		public virtual MemberInfo[] FindMembers(MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria)
		{
			MethodInfo[] array = null;
			ConstructorInfo[] array2 = null;
			FieldInfo[] array3 = null;
			PropertyInfo[] array4 = null;
			EventInfo[] array5 = null;
			Type[] array6 = null;
			int num = 0;
			if ((memberType & MemberTypes.Method) != (MemberTypes)0)
			{
				array = this.GetMethods(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (!filter(array[i], filterCriteria))
						{
							array[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array.Length;
				}
			}
			if ((memberType & MemberTypes.Constructor) != (MemberTypes)0)
			{
				array2 = this.GetConstructors(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array2.Length; i++)
					{
						if (!filter(array2[i], filterCriteria))
						{
							array2[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array2.Length;
				}
			}
			if ((memberType & MemberTypes.Field) != (MemberTypes)0)
			{
				array3 = this.GetFields(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array3.Length; i++)
					{
						if (!filter(array3[i], filterCriteria))
						{
							array3[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array3.Length;
				}
			}
			if ((memberType & MemberTypes.Property) != (MemberTypes)0)
			{
				array4 = this.GetProperties(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array4.Length; i++)
					{
						if (!filter(array4[i], filterCriteria))
						{
							array4[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array4.Length;
				}
			}
			if ((memberType & MemberTypes.Event) != (MemberTypes)0)
			{
				array5 = this.GetEvents(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array5.Length; i++)
					{
						if (!filter(array5[i], filterCriteria))
						{
							array5[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array5.Length;
				}
			}
			if ((memberType & MemberTypes.NestedType) != (MemberTypes)0)
			{
				array6 = this.GetNestedTypes(bindingAttr);
				if (filter != null)
				{
					for (int i = 0; i < array6.Length; i++)
					{
						if (!filter(array6[i], filterCriteria))
						{
							array6[i] = null;
						}
						else
						{
							num++;
						}
					}
				}
				else
				{
					num += array6.Length;
				}
			}
			MemberInfo[] array7 = new MemberInfo[num];
			num = 0;
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != null)
					{
						array7[num++] = array[i];
					}
				}
			}
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i] != null)
					{
						array7[num++] = array2[i];
					}
				}
			}
			if (array3 != null)
			{
				for (int i = 0; i < array3.Length; i++)
				{
					if (array3[i] != null)
					{
						array7[num++] = array3[i];
					}
				}
			}
			if (array4 != null)
			{
				for (int i = 0; i < array4.Length; i++)
				{
					if (array4[i] != null)
					{
						array7[num++] = array4[i];
					}
				}
			}
			if (array5 != null)
			{
				for (int i = 0; i < array5.Length; i++)
				{
					if (array5[i] != null)
					{
						array7[num++] = array5[i];
					}
				}
			}
			if (array6 != null)
			{
				for (int i = 0; i < array6.Length; i++)
				{
					if (array6[i] != null)
					{
						array7[num++] = array6[i];
					}
				}
			}
			return array7;
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> object represents a type whose definition is nested inside the definition of another type.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested inside another type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x0600144A RID: 5194 RVA: 0x0003C8AA File Offset: 0x0003AAAA
		[__DynamicallyInvokable]
		public bool IsNested
		{
			[__DynamicallyInvokable]
			get
			{
				return this.DeclaringType != null;
			}
		}

		/// <summary>Gets the attributes associated with the <see cref="T:System.Type" />.</summary>
		/// <returns>A <see cref="T:System.Reflection.TypeAttributes" /> object representing the attribute set of the <see cref="T:System.Type" />, unless the <see cref="T:System.Type" /> represents a generic type parameter, in which case the value is unspecified.</returns>
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x0003C8B8 File Offset: 0x0003AAB8
		[__DynamicallyInvokable]
		public TypeAttributes Attributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetAttributeFlagsImpl();
			}
		}

		/// <summary>Gets a combination of <see cref="T:System.Reflection.GenericParameterAttributes" /> flags that describe the covariance and special constraints of the current generic type parameter.</summary>
		/// <returns>A bitwise combination of <see cref="T:System.Reflection.GenericParameterAttributes" /> values that describes the covariance and special constraints of the current generic type parameter.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Type" /> object is not a generic type parameter. That is, the <see cref="P:System.Type.IsGenericParameter" /> property returns <see langword="false" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class.</exception>
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x0003C8C0 File Offset: 0x0003AAC0
		[__DynamicallyInvokable]
		public virtual GenericParameterAttributes GenericParameterAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> can be accessed by code outside the assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Type" /> is a public type or a public nested type such that all the enclosing types are public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x0003C8C8 File Offset: 0x0003AAC8
		[__DynamicallyInvokable]
		public bool IsVisible
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeType runtimeType = this as RuntimeType;
				if (runtimeType != null)
				{
					return RuntimeTypeHandle.IsVisible(runtimeType);
				}
				if (this.IsGenericParameter)
				{
					return true;
				}
				if (this.HasElementType)
				{
					return this.GetElementType().IsVisible;
				}
				Type type = this;
				while (type.IsNested)
				{
					if (!type.IsNestedPublic)
					{
						return false;
					}
					type = type.DeclaringType;
				}
				if (!type.IsPublic)
				{
					return false;
				}
				if (this.IsGenericType && !this.IsGenericTypeDefinition)
				{
					foreach (Type type2 in this.GetGenericArguments())
					{
						if (!type2.IsVisible)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is not declared public.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is not declared public and is not a nested type; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x0600144E RID: 5198 RVA: 0x0003C967 File Offset: 0x0003AB67
		[__DynamicallyInvokable]
		public bool IsNotPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is declared public.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is declared public and is not a nested type; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x0003C974 File Offset: 0x0003AB74
		[__DynamicallyInvokable]
		public bool IsPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.Public;
			}
		}

		/// <summary>Gets a value indicating whether a class is nested and declared public.</summary>
		/// <returns>
		///   <see langword="true" /> if the class is nested and declared public; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06001450 RID: 5200 RVA: 0x0003C981 File Offset: 0x0003AB81
		[__DynamicallyInvokable]
		public bool IsNestedPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is nested and declared private.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and declared private; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06001451 RID: 5201 RVA: 0x0003C98E File Offset: 0x0003AB8E
		[__DynamicallyInvokable]
		public bool IsNestedPrivate
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPrivate;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is nested and visible only within its own family.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only within its own family; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06001452 RID: 5202 RVA: 0x0003C99B File Offset: 0x0003AB9B
		[__DynamicallyInvokable]
		public bool IsNestedFamily
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamily;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is nested and visible only within its own assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only within its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06001453 RID: 5203 RVA: 0x0003C9A8 File Offset: 0x0003ABA8
		[__DynamicallyInvokable]
		public bool IsNestedAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedAssembly;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is nested and visible only to classes that belong to both its own family and its own assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only to classes that belong to both its own family and its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x0003C9B5 File Offset: 0x0003ABB5
		[__DynamicallyInvokable]
		public bool IsNestedFamANDAssem
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamANDAssem;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is nested and visible only to classes that belong to either its own family or to its own assembly.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is nested and visible only to classes that belong to its own family or to its own assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06001455 RID: 5205 RVA: 0x0003C9C2 File Offset: 0x0003ABC2
		[__DynamicallyInvokable]
		public bool IsNestedFamORAssem
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.VisibilityMask) == TypeAttributes.VisibilityMask;
			}
		}

		/// <summary>Gets a value indicating whether the fields of the current type are laid out automatically by the common language runtime.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="P:System.Type.Attributes" /> property of the current type includes <see cref="F:System.Reflection.TypeAttributes.AutoLayout" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x0003C9CF File Offset: 0x0003ABCF
		public bool IsAutoLayout
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.LayoutMask) == TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the fields of the current type are laid out sequentially, in the order that they were defined or emitted to the metadata.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="P:System.Type.Attributes" /> property of the current type includes <see cref="F:System.Reflection.TypeAttributes.SequentialLayout" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x0003C9DD File Offset: 0x0003ABDD
		public bool IsLayoutSequential
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.LayoutMask) == TypeAttributes.SequentialLayout;
			}
		}

		/// <summary>Gets a value indicating whether the fields of the current type are laid out at explicitly specified offsets.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="P:System.Type.Attributes" /> property of the current type includes <see cref="F:System.Reflection.TypeAttributes.ExplicitLayout" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x0003C9EB File Offset: 0x0003ABEB
		public bool IsExplicitLayout
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.LayoutMask) == TypeAttributes.ExplicitLayout;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is a class or a delegate; that is, not a value type or interface.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a class; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06001459 RID: 5209 RVA: 0x0003C9FA File Offset: 0x0003ABFA
		[__DynamicallyInvokable]
		public bool IsClass
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == TypeAttributes.NotPublic && !this.IsValueType;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is an interface; that is, not a class or a value type.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an interface; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x0600145A RID: 5210 RVA: 0x0003CA14 File Offset: 0x0003AC14
		[__DynamicallyInvokable]
		public bool IsInterface
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				RuntimeType runtimeType = this as RuntimeType;
				if (runtimeType != null)
				{
					return RuntimeTypeHandle.IsInterface(runtimeType);
				}
				return (this.GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is a value type.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a value type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x0003CA45 File Offset: 0x0003AC45
		[__DynamicallyInvokable]
		public bool IsValueType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsValueTypeImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is abstract and must be overridden.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is abstract; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x0600145C RID: 5212 RVA: 0x0003CA4D File Offset: 0x0003AC4D
		[__DynamicallyInvokable]
		public bool IsAbstract
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.Abstract) > TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is declared sealed.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is declared sealed; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x0003CA5E File Offset: 0x0003AC5E
		[__DynamicallyInvokable]
		public bool IsSealed
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.Sealed) > TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> represents an enumeration.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Type" /> represents an enumeration; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x0600145E RID: 5214 RVA: 0x0003CA6F File Offset: 0x0003AC6F
		[__DynamicallyInvokable]
		public virtual bool IsEnum
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsSubclassOf(RuntimeType.EnumType);
			}
		}

		/// <summary>Gets a value indicating whether the type has a name that requires special handling.</summary>
		/// <returns>
		///   <see langword="true" /> if the type has a name that requires special handling; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x0600145F RID: 5215 RVA: 0x0003CA7C File Offset: 0x0003AC7C
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.SpecialName) > TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> has a <see cref="T:System.Runtime.InteropServices.ComImportAttribute" /> attribute applied, indicating that it was imported from a COM type library.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> has a <see cref="T:System.Runtime.InteropServices.ComImportAttribute" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06001460 RID: 5216 RVA: 0x0003CA8D File Offset: 0x0003AC8D
		public bool IsImport
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.Import) > TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is serializable.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is serializable; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06001461 RID: 5217 RVA: 0x0003CAA0 File Offset: 0x0003ACA0
		public virtual bool IsSerializable
		{
			[__DynamicallyInvokable]
			get
			{
				if ((this.GetAttributeFlagsImpl() & TypeAttributes.Serializable) != TypeAttributes.NotPublic)
				{
					return true;
				}
				RuntimeType runtimeType = this.UnderlyingSystemType as RuntimeType;
				return runtimeType != null && runtimeType.IsSpecialSerializableType();
			}
		}

		/// <summary>Gets a value indicating whether the string format attribute <see langword="AnsiClass" /> is selected for the <see cref="T:System.Type" />.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="AnsiClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06001462 RID: 5218 RVA: 0x0003CADA File Offset: 0x0003ACDA
		public bool IsAnsiClass
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.StringFormatMask) == TypeAttributes.NotPublic;
			}
		}

		/// <summary>Gets a value indicating whether the string format attribute <see langword="UnicodeClass" /> is selected for the <see cref="T:System.Type" />.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="UnicodeClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06001463 RID: 5219 RVA: 0x0003CAEB File Offset: 0x0003ACEB
		public bool IsUnicodeClass
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.StringFormatMask) == TypeAttributes.UnicodeClass;
			}
		}

		/// <summary>Gets a value indicating whether the string format attribute <see langword="AutoClass" /> is selected for the <see cref="T:System.Type" />.</summary>
		/// <returns>
		///   <see langword="true" /> if the string format attribute <see langword="AutoClass" /> is selected for the <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06001464 RID: 5220 RVA: 0x0003CB00 File Offset: 0x0003AD00
		public bool IsAutoClass
		{
			get
			{
				return (this.GetAttributeFlagsImpl() & TypeAttributes.StringFormatMask) == TypeAttributes.AutoClass;
			}
		}

		/// <summary>Gets a value that indicates whether the type is an array.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is an array; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06001465 RID: 5221 RVA: 0x0003CB15 File Offset: 0x0003AD15
		[__DynamicallyInvokable]
		public bool IsArray
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsArrayImpl();
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06001466 RID: 5222 RVA: 0x0003CB1D File Offset: 0x0003AD1D
		internal virtual bool IsSzArray
		{
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value indicating whether the current type is a generic type.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is a generic type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06001467 RID: 5223 RVA: 0x0003CB20 File Offset: 0x0003AD20
		[__DynamicallyInvokable]
		public virtual bool IsGenericType
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> represents a generic type definition, from which other generic types can be constructed.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> object represents a generic type definition; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x0003CB23 File Offset: 0x0003AD23
		[__DynamicallyInvokable]
		public virtual bool IsGenericTypeDefinition
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets a value that indicates whether this object represents a constructed generic type. You can create instances of a constructed generic type.</summary>
		/// <returns>
		///   <see langword="true" /> if this object represents a constructed generic type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x0003CB26 File Offset: 0x0003AD26
		[__DynamicallyInvokable]
		public virtual bool IsConstructedGenericType
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> represents a type parameter in the definition of a generic type or method.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> object represents a type parameter of a generic type definition or generic method definition; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000248 RID: 584
		// (get) Token: 0x0600146A RID: 5226 RVA: 0x0003CB2D File Offset: 0x0003AD2D
		[__DynamicallyInvokable]
		public virtual bool IsGenericParameter
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets the position of the type parameter in the type parameter list of the generic type or method that declared the parameter, when the <see cref="T:System.Type" /> object represents a type parameter of a generic type or a generic method.</summary>
		/// <returns>The position of a type parameter in the type parameter list of the generic type or method that defines the parameter. Position numbers begin at 0.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current type does not represent a type parameter. That is, <see cref="P:System.Type.IsGenericParameter" /> returns <see langword="false" />.</exception>
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x0003CB30 File Offset: 0x0003AD30
		[__DynamicallyInvokable]
		public virtual int GenericParameterPosition
		{
			[__DynamicallyInvokable]
			get
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_NotGenericParameter"));
			}
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> object has type parameters that have not been replaced by specific types.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> object is itself a generic type parameter or has type parameters for which specific types have not been supplied; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700024A RID: 586
		// (get) Token: 0x0600146C RID: 5228 RVA: 0x0003CB44 File Offset: 0x0003AD44
		[__DynamicallyInvokable]
		public virtual bool ContainsGenericParameters
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.HasElementType)
				{
					return this.GetRootElementType().ContainsGenericParameters;
				}
				if (this.IsGenericParameter)
				{
					return true;
				}
				if (!this.IsGenericType)
				{
					return false;
				}
				Type[] genericArguments = this.GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (genericArguments[i].ContainsGenericParameters)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects that represent the constraints on the current generic type parameter.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that represent the constraints on the current generic type parameter.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Type" /> object is not a generic type parameter. That is, the <see cref="P:System.Type.IsGenericParameter" /> property returns <see langword="false" />.</exception>
		// Token: 0x0600146D RID: 5229 RVA: 0x0003CB9B File Offset: 0x0003AD9B
		[__DynamicallyInvokable]
		public virtual Type[] GetGenericParameterConstraints()
		{
			if (!this.IsGenericParameter)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_NotGenericParameter"));
			}
			throw new InvalidOperationException();
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is passed by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x0003CBBA File Offset: 0x0003ADBA
		[__DynamicallyInvokable]
		public bool IsByRef
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsByRefImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is a pointer.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a pointer; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x0600146F RID: 5231 RVA: 0x0003CBC2 File Offset: 0x0003ADC2
		[__DynamicallyInvokable]
		public bool IsPointer
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsPointerImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is one of the primitive types.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is one of the primitive types; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06001470 RID: 5232 RVA: 0x0003CBCA File Offset: 0x0003ADCA
		[__DynamicallyInvokable]
		public bool IsPrimitive
		{
			[__DynamicallyInvokable]
			get
			{
				return this.IsPrimitiveImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is a COM object.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a COM object; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x0003CBD2 File Offset: 0x0003ADD2
		public bool IsCOMObject
		{
			get
			{
				return this.IsCOMObjectImpl();
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06001472 RID: 5234 RVA: 0x0003CBDA File Offset: 0x0003ADDA
		internal bool IsWindowsRuntimeObject
		{
			get
			{
				return this.IsWindowsRuntimeObjectImpl();
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x0003CBE2 File Offset: 0x0003ADE2
		internal bool IsExportedToWindowsRuntime
		{
			get
			{
				return this.IsExportedToWindowsRuntimeImpl();
			}
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Type" /> encompasses or refers to another type; that is, whether the current <see cref="T:System.Type" /> is an array, a pointer, or is passed by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an array, a pointer, or is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06001474 RID: 5236 RVA: 0x0003CBEA File Offset: 0x0003ADEA
		[__DynamicallyInvokable]
		public bool HasElementType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.HasElementTypeImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> can be hosted in a context.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> can be hosted in a context; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06001475 RID: 5237 RVA: 0x0003CBF2 File Offset: 0x0003ADF2
		public bool IsContextful
		{
			get
			{
				return this.IsContextfulImpl();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Type" /> is marshaled by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is marshaled by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06001476 RID: 5238 RVA: 0x0003CBFA File Offset: 0x0003ADFA
		public bool IsMarshalByRef
		{
			get
			{
				return this.IsMarshalByRefImpl();
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x0003CC02 File Offset: 0x0003AE02
		internal bool HasProxyAttribute
		{
			get
			{
				return this.HasProxyAttributeImpl();
			}
		}

		/// <summary>Implements the <see cref="P:System.Type.IsValueType" /> property and determines whether the <see cref="T:System.Type" /> is a value type; that is, not a class or an interface.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a value type; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001478 RID: 5240 RVA: 0x0003CC0A File Offset: 0x0003AE0A
		[__DynamicallyInvokable]
		protected virtual bool IsValueTypeImpl()
		{
			return this.IsSubclassOf(RuntimeType.ValueType);
		}

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.Attributes" /> property and gets a bitmask indicating the attributes associated with the <see cref="T:System.Type" />.</summary>
		/// <returns>A <see cref="T:System.Reflection.TypeAttributes" /> object representing the attribute set of the <see cref="T:System.Type" />.</returns>
		// Token: 0x06001479 RID: 5241
		protected abstract TypeAttributes GetAttributeFlagsImpl();

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.IsArray" /> property and determines whether the <see cref="T:System.Type" /> is an array.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an array; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600147A RID: 5242
		[__DynamicallyInvokable]
		protected abstract bool IsArrayImpl();

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.IsByRef" /> property and determines whether the <see cref="T:System.Type" /> is passed by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600147B RID: 5243
		[__DynamicallyInvokable]
		protected abstract bool IsByRefImpl();

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.IsPointer" /> property and determines whether the <see cref="T:System.Type" /> is a pointer.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a pointer; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600147C RID: 5244
		[__DynamicallyInvokable]
		protected abstract bool IsPointerImpl();

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.IsPrimitive" /> property and determines whether the <see cref="T:System.Type" /> is one of the primitive types.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is one of the primitive types; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600147D RID: 5245
		[__DynamicallyInvokable]
		protected abstract bool IsPrimitiveImpl();

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.IsCOMObject" /> property and determines whether the <see cref="T:System.Type" /> is a COM object.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is a COM object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600147E RID: 5246
		protected abstract bool IsCOMObjectImpl();

		// Token: 0x0600147F RID: 5247 RVA: 0x0003CC17 File Offset: 0x0003AE17
		internal virtual bool IsWindowsRuntimeObjectImpl()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0003CC1E File Offset: 0x0003AE1E
		internal virtual bool IsExportedToWindowsRuntimeImpl()
		{
			throw new NotImplementedException();
		}

		/// <summary>Substitutes the elements of an array of types for the type parameters of the current generic type definition and returns a <see cref="T:System.Type" /> object representing the resulting constructed type.</summary>
		/// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic type.</param>
		/// <returns>A <see cref="T:System.Type" /> representing the constructed type formed by substituting the elements of <paramref name="typeArguments" /> for the type parameters of the current generic type.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current type does not represent a generic type definition. That is, <see cref="P:System.Type.IsGenericTypeDefinition" /> returns <see langword="false" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeArguments" /> is <see langword="null" />.  
		/// -or-  
		/// Any element of <paramref name="typeArguments" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The number of elements in <paramref name="typeArguments" /> is not the same as the number of type parameters in the current generic type definition.  
		///  -or-  
		///  Any element of <paramref name="typeArguments" /> does not satisfy the constraints specified for the corresponding type parameter of the current generic type.  
		///  -or-  
		///  <paramref name="typeArguments" /> contains an element that is a pointer type (<see cref="P:System.Type.IsPointer" /> returns <see langword="true" />), a by-ref type (<see cref="P:System.Type.IsByRef" /> returns <see langword="true" />), or <see cref="T:System.Void" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
		// Token: 0x06001481 RID: 5249 RVA: 0x0003CC25 File Offset: 0x0003AE25
		[__DynamicallyInvokable]
		public virtual Type MakeGenericType(params Type[] typeArguments)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Implements the <see cref="P:System.Type.IsContextful" /> property and determines whether the <see cref="T:System.Type" /> can be hosted in a context.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> can be hosted in a context; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001482 RID: 5250 RVA: 0x0003CC36 File Offset: 0x0003AE36
		protected virtual bool IsContextfulImpl()
		{
			return typeof(ContextBoundObject).IsAssignableFrom(this);
		}

		/// <summary>Implements the <see cref="P:System.Type.IsMarshalByRef" /> property and determines whether the <see cref="T:System.Type" /> is marshaled by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is marshaled by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001483 RID: 5251 RVA: 0x0003CC48 File Offset: 0x0003AE48
		protected virtual bool IsMarshalByRefImpl()
		{
			return typeof(MarshalByRefObject).IsAssignableFrom(this);
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0003CC5A File Offset: 0x0003AE5A
		internal virtual bool HasProxyAttributeImpl()
		{
			return false;
		}

		/// <summary>When overridden in a derived class, returns the <see cref="T:System.Type" /> of the object encompassed or referred to by the current array, pointer or reference type.</summary>
		/// <returns>The <see cref="T:System.Type" /> of the object encompassed or referred to by the current array, pointer, or reference type, or <see langword="null" /> if the current <see cref="T:System.Type" /> is not an array or a pointer, or is not passed by reference, or represents a generic type or a type parameter in the definition of a generic type or generic method.</returns>
		// Token: 0x06001485 RID: 5253
		[__DynamicallyInvokable]
		public abstract Type GetElementType();

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects that represent the type arguments of a closed generic type or the type parameters of a generic type definition.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects that represent the type arguments of a generic type. Returns an empty array if the current type is not a generic type.</returns>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
		// Token: 0x06001486 RID: 5254 RVA: 0x0003CC5D File Offset: 0x0003AE5D
		[__DynamicallyInvokable]
		public virtual Type[] GetGenericArguments()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Gets an array of the generic type arguments for this type.</summary>
		/// <returns>An array of the generic type arguments for this type.</returns>
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0003CC6E File Offset: 0x0003AE6E
		[__DynamicallyInvokable]
		public virtual Type[] GenericTypeArguments
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.IsGenericType && !this.IsGenericTypeDefinition)
				{
					return this.GetGenericArguments();
				}
				return Type.EmptyTypes;
			}
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents a generic type definition from which the current generic type can be constructed.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing a generic type from which the current type can be constructed.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current type is not a generic type.  That is, <see cref="P:System.Type.IsGenericType" /> returns <see langword="false" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
		// Token: 0x06001488 RID: 5256 RVA: 0x0003CC8C File Offset: 0x0003AE8C
		[__DynamicallyInvokable]
		public virtual Type GetGenericTypeDefinition()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>When overridden in a derived class, implements the <see cref="P:System.Type.HasElementType" /> property and determines whether the current <see cref="T:System.Type" /> encompasses or refers to another type; that is, whether the current <see cref="T:System.Type" /> is an array, a pointer, or is passed by reference.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Type" /> is an array, a pointer, or is passed by reference; otherwise, <see langword="false" />.</returns>
		// Token: 0x06001489 RID: 5257
		[__DynamicallyInvokable]
		protected abstract bool HasElementTypeImpl();

		// Token: 0x0600148A RID: 5258 RVA: 0x0003CCA0 File Offset: 0x0003AEA0
		internal Type GetRootElementType()
		{
			Type type = this;
			while (type.HasElementType)
			{
				type = type.GetElementType();
			}
			return type;
		}

		/// <summary>Returns the names of the members of the current enumeration type.</summary>
		/// <returns>An array that contains the names of the members of the enumeration.</returns>
		/// <exception cref="T:System.ArgumentException">The current type is not an enumeration.</exception>
		// Token: 0x0600148B RID: 5259 RVA: 0x0003CCC4 File Offset: 0x0003AEC4
		public virtual string[] GetEnumNames()
		{
			if (!this.IsEnum)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
			}
			string[] result;
			Array array;
			this.GetEnumData(out result, out array);
			return result;
		}

		/// <summary>Returns an array of the values of the constants in the current enumeration type.</summary>
		/// <returns>An array that contains the values. The elements of the array are sorted by the binary values (that is, the unsigned values) of the enumeration constants.</returns>
		/// <exception cref="T:System.ArgumentException">The current type is not an enumeration.</exception>
		// Token: 0x0600148C RID: 5260 RVA: 0x0003CCF9 File Offset: 0x0003AEF9
		public virtual Array GetEnumValues()
		{
			if (!this.IsEnum)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0003CD20 File Offset: 0x0003AF20
		private Array GetEnumRawConstantValues()
		{
			string[] array;
			Array result;
			this.GetEnumData(out array, out result);
			return result;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0003CD38 File Offset: 0x0003AF38
		private void GetEnumData(out string[] enumNames, out Array enumValues)
		{
			FieldInfo[] fields = this.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			object[] array = new object[fields.Length];
			string[] array2 = new string[fields.Length];
			for (int i = 0; i < fields.Length; i++)
			{
				array2[i] = fields[i].Name;
				array[i] = fields[i].GetRawConstantValue();
			}
			IComparer @default = Comparer.Default;
			for (int j = 1; j < array.Length; j++)
			{
				int num = j;
				string text = array2[j];
				object obj = array[j];
				bool flag = false;
				while (@default.Compare(array[num - 1], obj) > 0)
				{
					array2[num] = array2[num - 1];
					array[num] = array[num - 1];
					num--;
					flag = true;
					if (num == 0)
					{
						break;
					}
				}
				if (flag)
				{
					array2[num] = text;
					array[num] = obj;
				}
			}
			enumNames = array2;
			enumValues = array;
		}

		/// <summary>Returns the underlying type of the current enumeration type.</summary>
		/// <returns>The underlying type of the current enumeration.</returns>
		/// <exception cref="T:System.ArgumentException">The current type is not an enumeration.  
		///  -or-  
		///  The enumeration type is not valid, because it contains more than one instance field.</exception>
		// Token: 0x0600148F RID: 5263 RVA: 0x0003CE04 File Offset: 0x0003B004
		public virtual Type GetEnumUnderlyingType()
		{
			if (!this.IsEnum)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
			}
			FieldInfo[] fields = this.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields == null || fields.Length != 1)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidEnum"), "enumType");
			}
			return fields[0].FieldType;
		}

		/// <summary>Returns a value that indicates whether the specified value exists in the current enumeration type.</summary>
		/// <param name="value">The value to be tested.</param>
		/// <returns>
		///   <see langword="true" /> if the specified value is a member of the current enumeration type; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The current type is not an enumeration.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="value" /> is of a type that cannot be the underlying type of an enumeration.</exception>
		// Token: 0x06001490 RID: 5264 RVA: 0x0003CE60 File Offset: 0x0003B060
		public virtual bool IsEnumDefined(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!this.IsEnum)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
			}
			Type type = value.GetType();
			if (type.IsEnum)
			{
				if (!type.IsEquivalentTo(this))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumAndObjectMustBeSameType", new object[]
					{
						type.ToString(),
						this.ToString()
					}));
				}
				type = type.GetEnumUnderlyingType();
			}
			if (type == typeof(string))
			{
				string[] enumNames = this.GetEnumNames();
				return Array.IndexOf<object>(enumNames, value) >= 0;
			}
			if (Type.IsIntegerType(type))
			{
				Type enumUnderlyingType = this.GetEnumUnderlyingType();
				if (enumUnderlyingType.GetTypeCodeImpl() != type.GetTypeCodeImpl())
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", new object[]
					{
						type.ToString(),
						enumUnderlyingType.ToString()
					}));
				}
				Array enumRawConstantValues = this.GetEnumRawConstantValues();
				return Type.BinarySearch(enumRawConstantValues, value) >= 0;
			}
			else
			{
				if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8)
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_EnumUnderlyingTypeAndObjectMustBeSameType", new object[]
					{
						type.ToString(),
						this.GetEnumUnderlyingType()
					}));
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_UnknownEnumType"));
			}
		}

		/// <summary>Returns the name of the constant that has the specified value, for the current enumeration type.</summary>
		/// <param name="value">The value whose name is to be retrieved.</param>
		/// <returns>The name of the member of the current enumeration type that has the specified value, or <see langword="null" /> if no such constant is found.</returns>
		/// <exception cref="T:System.ArgumentException">The current type is not an enumeration.  
		///  -or-  
		///  <paramref name="value" /> is neither of the current type nor does it have the same underlying type as the current type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="value" /> is <see langword="null" />.</exception>
		// Token: 0x06001491 RID: 5265 RVA: 0x0003CFA0 File Offset: 0x0003B1A0
		public virtual string GetEnumName(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!this.IsEnum)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
			}
			Type type = value.GetType();
			if (!type.IsEnum && !Type.IsIntegerType(type))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
			}
			Array enumRawConstantValues = this.GetEnumRawConstantValues();
			int num = Type.BinarySearch(enumRawConstantValues, value);
			if (num >= 0)
			{
				string[] enumNames = this.GetEnumNames();
				return enumNames[num];
			}
			return null;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0003D024 File Offset: 0x0003B224
		private static int BinarySearch(Array array, object value)
		{
			ulong[] array2 = new ulong[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Enum.ToUInt64(array.GetValue(i));
			}
			ulong value2 = Enum.ToUInt64(value);
			return Array.BinarySearch<ulong>(array2, value2);
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0003D06C File Offset: 0x0003B26C
		internal static bool IsIntegerType(Type t)
		{
			return t == typeof(int) || t == typeof(short) || t == typeof(ushort) || t == typeof(byte) || t == typeof(sbyte) || t == typeof(uint) || t == typeof(long) || t == typeof(ulong) || t == typeof(char) || t == typeof(bool);
		}

		/// <summary>Gets a value that indicates whether the current type is security-critical or security-safe-critical at the current trust level, and therefore can perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is security-critical or security-safe-critical at the current trust level; <see langword="false" /> if it is transparent.</returns>
		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x0003D133 File Offset: 0x0003B333
		public virtual bool IsSecurityCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current type is security-safe-critical at the current trust level; that is, whether it can perform critical operations and can be accessed by transparent code.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is security-safe-critical at the current trust level; <see langword="false" /> if it is security-critical or transparent.</returns>
		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x0003D13A File Offset: 0x0003B33A
		public virtual bool IsSecuritySafeCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current type is transparent at the current trust level, and therefore cannot perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the type is security-transparent at the current trust level; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06001496 RID: 5270 RVA: 0x0003D141 File Offset: 0x0003B341
		public virtual bool IsSecurityTransparent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x0003D148 File Offset: 0x0003B348
		internal bool NeedsReflectionSecurityCheck
		{
			get
			{
				if (!this.IsVisible)
				{
					return true;
				}
				if (this.IsSecurityCritical && !this.IsSecuritySafeCritical)
				{
					return true;
				}
				if (this.IsGenericType)
				{
					foreach (Type type in this.GetGenericArguments())
					{
						if (type.NeedsReflectionSecurityCheck)
						{
							return true;
						}
					}
				}
				else if (this.IsArray || this.IsPointer)
				{
					return this.GetElementType().NeedsReflectionSecurityCheck;
				}
				return false;
			}
		}

		/// <summary>Indicates the type provided by the common language runtime that represents this type.</summary>
		/// <returns>The underlying system type for the <see cref="T:System.Type" />.</returns>
		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06001498 RID: 5272
		[__DynamicallyInvokable]
		public abstract Type UnderlyingSystemType { [__DynamicallyInvokable] get; }

		/// <summary>Determines whether the current <see cref="T:System.Type" /> derives from the specified <see cref="T:System.Type" />.</summary>
		/// <param name="c">The type to compare with the current type.</param>
		/// <returns>
		///   <see langword="true" /> if the current <see langword="Type" /> derives from <paramref name="c" />; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if <paramref name="c" /> and the current <see langword="Type" /> are equal.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="c" /> is <see langword="null" />.</exception>
		// Token: 0x06001499 RID: 5273 RVA: 0x0003D1BC File Offset: 0x0003B3BC
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual bool IsSubclassOf(Type c)
		{
			Type type = this;
			if (type == c)
			{
				return false;
			}
			while (type != null)
			{
				if (type == c)
				{
					return true;
				}
				type = type.BaseType;
			}
			return false;
		}

		/// <summary>Determines whether the specified object is an instance of the current <see cref="T:System.Type" />.</summary>
		/// <param name="o">The object to compare with the current type.</param>
		/// <returns>
		///   <see langword="true" /> if the current <see langword="Type" /> is in the inheritance hierarchy of the object represented by <paramref name="o" />, or if the current <see langword="Type" /> is an interface that <paramref name="o" /> implements. <see langword="false" /> if neither of these conditions is the case, if <paramref name="o" /> is <see langword="null" />, or if the current <see langword="Type" /> is an open generic type (that is, <see cref="P:System.Type.ContainsGenericParameters" /> returns <see langword="true" />).</returns>
		// Token: 0x0600149A RID: 5274 RVA: 0x0003D1F2 File Offset: 0x0003B3F2
		[__DynamicallyInvokable]
		public virtual bool IsInstanceOfType(object o)
		{
			return o != null && this.IsAssignableFrom(o.GetType());
		}

		/// <summary>Determines whether an instance of a specified type can be assigned to an instance of the current type.</summary>
		/// <param name="c">The type to compare with the current type.</param>
		/// <returns>
		///   <see langword="true" /> if any of the following conditions is true:  
		///
		/// <paramref name="c" /> and the current instance represent the same type.  
		///
		/// <paramref name="c" /> is derived either directly or indirectly from the current instance. <paramref name="c" /> is derived directly from the current instance if it inherits from the current instance; <paramref name="c" /> is derived indirectly from the current instance if it inherits from a succession of one or more classes that inherit from the current instance.  
		///
		/// The current instance is an interface that <paramref name="c" /> implements.  
		///
		/// <paramref name="c" /> is a generic type parameter, and the current instance represents one of the constraints of <paramref name="c" />.  
		///  In the following example, the current instance is a <see cref="T:System.Type" /> object that represents the <see cref="T:System.IO.Stream" /> class. GenericWithConstraint is a generic type whose generic type parameter must be of type    <see cref="T:System.IO.Stream" />. Passing its generic type parameter to the <see cref="M:System.Type.IsAssignableFrom(System.Type)" /> indicates that  an instance of the generic type parameter can be assigned to an <see cref="T:System.IO.Stream" /> object.  
		/// using System;
		/// using System.IO;
		///
		/// public class Example
		/// {
		///    public static void Main()
		///    {
		/// Type t = typeof(Stream);
		/// Type genericT = typeof(GenericWithConstraint&lt;&gt;);
		/// Type genericParam = genericT.GetGenericArguments()[0];
		/// Console.WriteLine(t.IsAssignableFrom(genericParam));  
		/// // Displays True.
		///    }
		/// }
		///
		/// public class GenericWithConstraint&lt;T&gt; where T : Stream
		/// {}
		/// Imports System.IO
		///
		/// Module Example
		///    Public Sub Main()
		/// Dim t As Type = GetType(Stream)
		/// Dim genericT As Type = GetType(GenericWithConstraint(Of ))
		/// Dim genericParam As Type = genericT.GetGenericArguments()(0)
		/// Console.WriteLine(t.IsAssignableFrom(genericParam))  
		/// ' Displays True.
		///    End Sub
		/// End Module
		///
		/// Public Class GenericWithConstraint(Of T As Stream)
		/// End Class
		///
		/// <paramref name="c" /> represents a value type, and the current instance represents Nullable&lt;c&gt; (Nullable(Of c) in Visual Basic).  
		///
		///
		///  <see langword="false" /> if none of these conditions are true, or if <paramref name="c" /> is <see langword="null" />.</returns>
		// Token: 0x0600149B RID: 5275 RVA: 0x0003D208 File Offset: 0x0003B408
		[__DynamicallyInvokable]
		public virtual bool IsAssignableFrom(Type c)
		{
			if (c == null)
			{
				return false;
			}
			if (this == c)
			{
				return true;
			}
			RuntimeType runtimeType = this.UnderlyingSystemType as RuntimeType;
			if (runtimeType != null)
			{
				return runtimeType.IsAssignableFrom(c);
			}
			if (c.IsSubclassOf(this))
			{
				return true;
			}
			if (this.IsInterface)
			{
				return c.ImplementInterface(this);
			}
			if (this.IsGenericParameter)
			{
				Type[] genericParameterConstraints = this.GetGenericParameterConstraints();
				for (int i = 0; i < genericParameterConstraints.Length; i++)
				{
					if (!genericParameterConstraints[i].IsAssignableFrom(c))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>Determines whether two COM types have the same identity and are eligible for type equivalence.</summary>
		/// <param name="other">The COM type that is tested for equivalence with the current type.</param>
		/// <returns>
		///   <see langword="true" /> if the COM types are equivalent; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if one type is in an assembly that is loaded for execution, and the other is in an assembly that is loaded into the reflection-only context.</returns>
		// Token: 0x0600149C RID: 5276 RVA: 0x0003D290 File Offset: 0x0003B490
		public virtual bool IsEquivalentTo(Type other)
		{
			return this == other;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0003D29C File Offset: 0x0003B49C
		internal bool ImplementInterface(Type ifaceType)
		{
			Type type = this;
			while (type != null)
			{
				Type[] interfaces = type.GetInterfaces();
				if (interfaces != null)
				{
					for (int i = 0; i < interfaces.Length; i++)
					{
						if (interfaces[i] == ifaceType || (interfaces[i] != null && interfaces[i].ImplementInterface(ifaceType)))
						{
							return true;
						}
					}
				}
				type = type.BaseType;
			}
			return false;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x0003D2F9 File Offset: 0x0003B4F9
		internal string FormatTypeName()
		{
			return this.FormatTypeName(false);
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x0003D302 File Offset: 0x0003B502
		internal virtual string FormatTypeName(bool serialization)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns a <see langword="String" /> representing the name of the current <see langword="Type" />.</summary>
		/// <returns>A <see cref="T:System.String" /> representing the name of the current <see cref="T:System.Type" />.</returns>
		// Token: 0x060014A0 RID: 5280 RVA: 0x0003D309 File Offset: 0x0003B509
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return "Type: " + this.Name;
		}

		/// <summary>Gets the types of the objects in the specified array.</summary>
		/// <param name="args">An array of objects whose types to determine.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing the types of the corresponding elements in <paramref name="args" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="args" /> is <see langword="null" />.  
		/// -or-  
		/// One or more of the elements in <paramref name="args" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The class initializers are invoked and at least one throws an exception.</exception>
		// Token: 0x060014A1 RID: 5281 RVA: 0x0003D31C File Offset: 0x0003B51C
		public static Type[] GetTypeArray(object[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			Type[] array = new Type[args.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (args[i] == null)
				{
					throw new ArgumentNullException();
				}
				array[i] = args[i].GetType();
			}
			return array;
		}

		/// <summary>Determines if the underlying system type of the current <see cref="T:System.Type" /> object is the same as the underlying system type of the specified <see cref="T:System.Object" />.</summary>
		/// <param name="o">The object whose underlying system type is to be compared with the underlying system type of the current <see cref="T:System.Type" />. For the comparison to succeed, <paramref name="o" /> must be able to be cast or converted to an object of type   <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the underlying system type of <paramref name="o" /> is the same as the underlying system type of the current <see cref="T:System.Type" />; otherwise, <see langword="false" />. This method also returns <see langword="false" /> if: .  
		///
		/// <paramref name="o" /> is <see langword="null" />.  
		///
		/// <paramref name="o" /> cannot be cast or converted to a <see cref="T:System.Type" /> object.</returns>
		// Token: 0x060014A2 RID: 5282 RVA: 0x0003D365 File Offset: 0x0003B565
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			return o != null && this.Equals(o as Type);
		}

		/// <summary>Determines if the underlying system type of the current <see cref="T:System.Type" /> is the same as the underlying system type of the specified <see cref="T:System.Type" />.</summary>
		/// <param name="o">The object whose underlying system type is to be compared with the underlying system type of the current <see cref="T:System.Type" />.</param>
		/// <returns>
		///   <see langword="true" /> if the underlying system type of <paramref name="o" /> is the same as the underlying system type of the current <see cref="T:System.Type" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060014A3 RID: 5283 RVA: 0x0003D378 File Offset: 0x0003B578
		[__DynamicallyInvokable]
		public virtual bool Equals(Type o)
		{
			return o != null && this.UnderlyingSystemType == o.UnderlyingSystemType;
		}

		/// <summary>Indicates whether two <see cref="T:System.Type" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060014A4 RID: 5284
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool operator ==(Type left, Type right);

		/// <summary>Indicates whether two <see cref="T:System.Type" /> objects are not equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060014A5 RID: 5285
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool operator !=(Type left, Type right);

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x060014A6 RID: 5286 RVA: 0x0003D390 File Offset: 0x0003B590
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			Type underlyingSystemType = this.UnderlyingSystemType;
			if (underlyingSystemType != this)
			{
				return underlyingSystemType.GetHashCode();
			}
			return base.GetHashCode();
		}

		/// <summary>Returns an interface mapping for the specified interface type.</summary>
		/// <param name="interfaceType">The interface type to retrieve a mapping for.</param>
		/// <returns>An object that represents the interface mapping for <paramref name="interfaceType" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="interfaceType" /> is not implemented by the current type.  
		/// -or-  
		/// The <paramref name="interfaceType" /> argument does not refer to an interface.  
		/// -or-  
		/// The current instance or <paramref name="interfaceType" /> argument is an open generic type; that is, the <see cref="P:System.Type.ContainsGenericParameters" /> property returns <see langword="true" />.
		/// -or-
		///  <paramref name="interfaceType" /> is a generic interface, and the current type is an array type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="interfaceType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The current <see cref="T:System.Type" /> represents a generic type parameter; that is, <see cref="P:System.Type.IsGenericParameter" /> is <see langword="true" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The invoked method is not supported in the base class. Derived classes must provide an implementation.</exception>
		// Token: 0x060014A7 RID: 5287 RVA: 0x0003D3B5 File Offset: 0x0003B5B5
		[ComVisible(true)]
		public virtual InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		/// <summary>Gets the current <see cref="T:System.Type" />.</summary>
		/// <returns>The current <see cref="T:System.Type" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">A class initializer is invoked and throws an exception.</exception>
		// Token: 0x060014A8 RID: 5288 RVA: 0x0003D3C6 File Offset: 0x0003B5C6
		[__DynamicallyInvokable]
		public new Type GetType()
		{
			return base.GetType();
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060014A9 RID: 5289 RVA: 0x0003D3CE File Offset: 0x0003B5CE
		void _Type.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">A pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x060014AA RID: 5290 RVA: 0x0003D3D5 File Offset: 0x0003B5D5
		void _Type.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
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
		// Token: 0x060014AB RID: 5291 RVA: 0x0003D3DC File Offset: 0x0003B5DC
		void _Type.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		// Token: 0x060014AC RID: 5292 RVA: 0x0003D3E3 File Offset: 0x0003B5E3
		void _Type.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>Represents the member filter used on attributes. This field is read-only.</summary>
		// Token: 0x040006CC RID: 1740
		public static readonly MemberFilter FilterAttribute = new MemberFilter(System.__Filters.Instance.FilterAttribute);

		/// <summary>Represents the case-sensitive member filter used on names. This field is read-only.</summary>
		// Token: 0x040006CD RID: 1741
		public static readonly MemberFilter FilterName = new MemberFilter(System.__Filters.Instance.FilterName);

		/// <summary>Represents the case-insensitive member filter used on names. This field is read-only.</summary>
		// Token: 0x040006CE RID: 1742
		public static readonly MemberFilter FilterNameIgnoreCase = new MemberFilter(System.__Filters.Instance.FilterIgnoreCase);

		/// <summary>Represents a missing value in the <see cref="T:System.Type" /> information. This field is read-only.</summary>
		// Token: 0x040006CF RID: 1743
		[__DynamicallyInvokable]
		public static readonly object Missing = System.Reflection.Missing.Value;

		/// <summary>Separates names in the namespace of the <see cref="T:System.Type" />. This field is read-only.</summary>
		// Token: 0x040006D0 RID: 1744
		public static readonly char Delimiter = '.';

		/// <summary>Represents an empty array of type <see cref="T:System.Type" />. This field is read-only.</summary>
		// Token: 0x040006D1 RID: 1745
		[__DynamicallyInvokable]
		public static readonly Type[] EmptyTypes = EmptyArray<Type>.Value;

		// Token: 0x040006D2 RID: 1746
		private static Binder defaultBinder;

		// Token: 0x040006D3 RID: 1747
		private const BindingFlags DefaultLookup = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

		// Token: 0x040006D4 RID: 1748
		internal const BindingFlags DeclaredOnlyLookup = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}
}
