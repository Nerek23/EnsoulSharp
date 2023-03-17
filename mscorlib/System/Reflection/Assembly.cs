using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading;

namespace System.Reflection
{
	/// <summary>Represents an assembly, which is a reusable, versionable, and self-describing building block of a common language runtime application.</summary>
	// Token: 0x02000584 RID: 1412
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Assembly))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	[Serializable]
	public abstract class Assembly : _Assembly, IEvidenceFactory, ICustomAttributeProvider, ISerializable
	{
		/// <summary>Creates the name of a type qualified by the display name of its assembly.</summary>
		/// <param name="assemblyName">The display name of an assembly.</param>
		/// <param name="typeName">The full name of a type.</param>
		/// <returns>The full name of the type qualified by the display name of the assembly.</returns>
		// Token: 0x06004254 RID: 16980 RVA: 0x000F5DC9 File Offset: 0x000F3FC9
		public static string CreateQualifiedName(string assemblyName, string typeName)
		{
			return typeName + ", " + assemblyName;
		}

		/// <summary>Gets the currently loaded assembly in which the specified type is defined.</summary>
		/// <param name="type">An object representing a type in the assembly that will be returned.</param>
		/// <returns>The assembly in which the specified type is defined.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="type" /> is <see langword="null" />.</exception>
		// Token: 0x06004255 RID: 16981 RVA: 0x000F5DD8 File Offset: 0x000F3FD8
		public static Assembly GetAssembly(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			Module module = type.Module;
			if (module == null)
			{
				return null;
			}
			return module.Assembly;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Assembly" /> objects are equal.</summary>
		/// <param name="left">The assembly to compare to <paramref name="right" />.</param>
		/// <param name="right">The assembly to compare to <paramref name="left" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004256 RID: 16982 RVA: 0x000F5E11 File Offset: 0x000F4011
		[__DynamicallyInvokable]
		public static bool operator ==(Assembly left, Assembly right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeAssembly) && !(right is RuntimeAssembly) && left.Equals(right));
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Assembly" /> objects are not equal.</summary>
		/// <param name="left">The assembly to compare to <paramref name="right" />.</param>
		/// <param name="right">The assembly to compare to <paramref name="left" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004257 RID: 16983 RVA: 0x000F5E38 File Offset: 0x000F4038
		[__DynamicallyInvokable]
		public static bool operator !=(Assembly left, Assembly right)
		{
			return !(left == right);
		}

		/// <summary>Determines whether this assembly and the specified object are equal.</summary>
		/// <param name="o">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004258 RID: 16984 RVA: 0x000F5E44 File Offset: 0x000F4044
		[__DynamicallyInvokable]
		public override bool Equals(object o)
		{
			return base.Equals(o);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06004259 RID: 16985 RVA: 0x000F5E4D File Offset: 0x000F404D
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>Loads an assembly given its file name or path.</summary>
		/// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a filename extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyFile" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		// Token: 0x0600425A RID: 16986 RVA: 0x000F5E58 File Offset: 0x000F4058
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, false, false, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly into the reflection-only context, given its path.</summary>
		/// <param name="assemblyFile">The path of the file that contains the manifest of the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a file name extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="assemblyFile" /> is found, but could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyFile" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="assemblyFile" /> is an empty string ("").</exception>
		// Token: 0x0600425B RID: 16987 RVA: 0x000F5E74 File Offset: 0x000F4074
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, true, false, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly given its file name or path and supplying security evidence.</summary>
		/// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
		/// <param name="securityEvidence">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a filename extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.  
		///  -or-  
		///  The <paramref name="securityEvidence" /> is not ambiguous and is determined to be invalid.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyFile" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		// Token: 0x0600425C RID: 16988 RVA: 0x000F5E90 File Offset: 0x000F4090
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, Evidence securityEvidence)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, securityEvidence, null, AssemblyHashAlgorithm.None, false, false, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly given its file name or path, security evidence, hash value, and hash algorithm.</summary>
		/// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
		/// <param name="securityEvidence">Evidence for loading the assembly.</param>
		/// <param name="hashValue">The value of the computed hash code.</param>
		/// <param name="hashAlgorithm">The hash algorithm used for hashing files and for generating the strong name.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a filename extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.  
		///  -or-  
		///  The <paramref name="securityEvidence" /> is not ambiguous and is determined to be invalid.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyFile" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		// Token: 0x0600425D RID: 16989 RVA: 0x000F5EAC File Offset: 0x000F40AC
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFrom which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, securityEvidence, hashValue, hashAlgorithm, false, false, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly given its file name or path, hash value, and hash algorithm.</summary>
		/// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
		/// <param name="hashValue">The value of the computed hash code.</param>
		/// <param name="hashAlgorithm">The hash algorithm used for hashing files and for generating the strong name.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a file name extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly; for example, a 32-bit assembly in a 64-bit process. See the exception topic for more information.  
		/// -or-  
		/// <paramref name="assemblyFile" /> was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		// Token: 0x0600425E RID: 16990 RVA: 0x000F5EC8 File Offset: 0x000F40C8
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, hashValue, hashAlgorithm, false, false, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly into the load-from context, bypassing some security checks.</summary>
		/// <param name="assemblyFile">The name or path of the file that contains the manifest of the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFile" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyFile" /> is not found, or the module you are trying to load does not specify a filename extension.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly.  
		/// -or-  
		/// <paramref name="assemblyFile" /> was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		/// <exception cref="T:System.Security.SecurityException">A codebase that does not start with "file://" was specified without the required <see cref="T:System.Net.WebPermission" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="assemblyFile" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The assembly name exceeds the system-defined maximum length.</exception>
		// Token: 0x0600425F RID: 16991 RVA: 0x000F5EE4 File Offset: 0x000F40E4
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly UnsafeLoadFrom(string assemblyFile)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadFrom(assemblyFile, null, null, AssemblyHashAlgorithm.None, false, true, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly given the long form of its name.</summary>
		/// <param name="assemblyString">The long form of the assembly name.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyString" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="assemblyString" /> is a zero-length string.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyString" /> is not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyString" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyString" /> was compiled with a later version.</exception>
		// Token: 0x06004260 RID: 16992 RVA: 0x000F5F00 File Offset: 0x000F4100
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(string assemblyString)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, null, ref stackCrawlMark, false);
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x000F5F1C File Offset: 0x000F411C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type GetType_Compat(string assemblyString, string typeName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			RuntimeAssembly runtimeAssembly;
			AssemblyName assemblyName = RuntimeAssembly.CreateAssemblyName(assemblyString, false, out runtimeAssembly);
			if (runtimeAssembly == null)
			{
				if (assemblyName.ContentType == AssemblyContentType.WindowsRuntime)
				{
					return Type.GetType(typeName + ", " + assemblyString, true, false);
				}
				runtimeAssembly = RuntimeAssembly.InternalLoadAssemblyName(assemblyName, null, null, ref stackCrawlMark, true, false, false);
			}
			return runtimeAssembly.GetType(typeName, true, false);
		}

		/// <summary>Loads an assembly into the reflection-only context, given its display name.</summary>
		/// <param name="assemblyString">The display name of the assembly, as returned by the <see cref="P:System.Reflection.AssemblyName.FullName" /> property.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyString" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="assemblyString" /> is an empty string ("").</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyString" /> is not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="assemblyString" /> is found, but cannot be loaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyString" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyString" /> was compiled with a later version.</exception>
		// Token: 0x06004262 RID: 16994 RVA: 0x000F5F74 File Offset: 0x000F4174
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoad(string assemblyString)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, null, ref stackCrawlMark, true);
		}

		/// <summary>Loads an assembly given its display name, loading the assembly into the domain of the caller using the supplied evidence.</summary>
		/// <param name="assemblyString">The display name of the assembly.</param>
		/// <param name="assemblySecurity">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyString" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyString" /> is not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyString" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyString" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.  
		///  -or-  
		///  An assembly or module was loaded twice with two different evidences.</exception>
		// Token: 0x06004263 RID: 16995 RVA: 0x000F5F90 File Offset: 0x000F4190
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(string assemblyString, Evidence assemblySecurity)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoad(assemblyString, assemblySecurity, ref stackCrawlMark, false);
		}

		/// <summary>Loads an assembly given its <see cref="T:System.Reflection.AssemblyName" />.</summary>
		/// <param name="assemblyRef">The object that describes the assembly to be loaded.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyRef" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyRef" /> is not found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///
		///
		///  A file that was found could not be loaded.
		/// -or-
		/// <paramref name="assemblyRef" /> specifies a remote assembly, but the ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyRef" /> is not a valid assembly. -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyRef" /> was compiled with a later version.</exception>
		// Token: 0x06004264 RID: 16996 RVA: 0x000F5FAC File Offset: 0x000F41AC
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(AssemblyName assemblyRef)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, null, null, ref stackCrawlMark, true, false, false);
		}

		/// <summary>Loads an assembly given its <see cref="T:System.Reflection.AssemblyName" />. The assembly is loaded into the domain of the caller using the supplied evidence.</summary>
		/// <param name="assemblyRef">The object that describes the assembly to be loaded.</param>
		/// <param name="assemblySecurity">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyRef" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="assemblyRef" /> is not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyRef" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="assemblyRef" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different evidences.
		/// -or-
		/// <paramref name="assemblyRef" /> specifies a remote assembly, but the ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		// Token: 0x06004265 RID: 16997 RVA: 0x000F5FC8 File Offset: 0x000F41C8
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(AssemblyName assemblyRef, Evidence assemblySecurity)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.InternalLoadAssemblyName(assemblyRef, assemblySecurity, null, ref stackCrawlMark, true, false, false);
		}

		/// <summary>Loads an assembly from the application directory or from the global assembly cache using a partial name.</summary>
		/// <param name="partialName">The display name of the assembly.</param>
		/// <returns>The loaded assembly. If <paramref name="partialName" /> is not found, this method returns <see langword="null" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="partialName" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="partialName" /> was compiled with a later version.</exception>
		// Token: 0x06004266 RID: 16998 RVA: 0x000F5FE4 File Offset: 0x000F41E4
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadWithPartialName(string partialName)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.LoadWithPartialNameInternal(partialName, null, ref stackCrawlMark);
		}

		/// <summary>Loads an assembly from the application directory or from the global assembly cache using a partial name. The assembly is loaded into the domain of the caller using the supplied evidence.</summary>
		/// <param name="partialName">The display name of the assembly.</param>
		/// <param name="securityEvidence">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly. If <paramref name="partialName" /> is not found, this method returns <see langword="null" />.</returns>
		/// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different sets of evidence.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="partialName" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="assemblyFile" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="partialName" /> was compiled with a later version.</exception>
		// Token: 0x06004267 RID: 16999 RVA: 0x000F5FFC File Offset: 0x000F41FC
		[SecuritySafeCritical]
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly LoadWithPartialName(string partialName, Evidence securityEvidence)
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.LoadWithPartialNameInternal(partialName, securityEvidence, ref stackCrawlMark);
		}

		/// <summary>Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly. The assembly is loaded into the application domain of the caller.</summary>
		/// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rawAssembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawAssembly" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="rawAssembly" /> was compiled with a later version.</exception>
		// Token: 0x06004268 RID: 17000 RVA: 0x000F6014 File Offset: 0x000F4214
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly)
		{
			AppDomain.CheckLoadByteArraySupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, null, null, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		/// <summary>Loads the assembly from a common object file format (COFF)-based image containing an emitted assembly. The assembly is loaded into the reflection-only context of the caller's application domain.</summary>
		/// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rawAssembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawAssembly" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="rawAssembly" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="rawAssembly" /> cannot be loaded.</exception>
		// Token: 0x06004269 RID: 17001 RVA: 0x000F6038 File Offset: 0x000F4238
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly ReflectionOnlyLoad(byte[] rawAssembly)
		{
			AppDomain.CheckReflectionOnlyLoadSupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, null, null, ref stackCrawlMark, true, false, SecurityContextSource.CurrentAssembly);
		}

		/// <summary>Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly, optionally including symbols for the assembly. The assembly is loaded into the application domain of the caller.</summary>
		/// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
		/// <param name="rawSymbolStore">A byte array that contains the raw bytes representing the symbols for the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rawAssembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawAssembly" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="rawAssembly" /> was compiled with a later version.</exception>
		// Token: 0x0600426A RID: 17002 RVA: 0x000F605C File Offset: 0x000F425C
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore)
		{
			AppDomain.CheckLoadByteArraySupported();
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		/// <summary>Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly, optionally including symbols and specifying the source for the security context. The assembly is loaded into the application domain of the caller.</summary>
		/// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
		/// <param name="rawSymbolStore">A byte array that contains the raw bytes representing the symbols for the assembly.</param>
		/// <param name="securityContextSource">The source of the security context.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rawAssembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawAssembly" /> is not a valid assembly.  
		/// -or-  
		/// <paramref name="rawAssembly" /> was compiled with a later version of the common language runtime than the version that is currently loaded.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="securityContextSource" /> is not one of the enumeration values.</exception>
		// Token: 0x0600426B RID: 17003 RVA: 0x000F6080 File Offset: 0x000F4280
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityContextSource < SecurityContextSource.CurrentAppDomain || securityContextSource > SecurityContextSource.CurrentAssembly)
			{
				throw new ArgumentOutOfRangeException("securityContextSource");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, false, securityContextSource);
		}

		// Token: 0x0600426C RID: 17004 RVA: 0x000F60B4 File Offset: 0x000F42B4
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Assembly LoadImageSkipIntegrityCheck(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityContextSource < SecurityContextSource.CurrentAppDomain || securityContextSource > SecurityContextSource.CurrentAssembly)
			{
				throw new ArgumentOutOfRangeException("securityContextSource");
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, null, ref stackCrawlMark, false, true, securityContextSource);
		}

		/// <summary>Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly, optionally including symbols and evidence for the assembly. The assembly is loaded into the application domain of the caller.</summary>
		/// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
		/// <param name="rawSymbolStore">A byte array that contains the raw bytes representing the symbols for the assembly.</param>
		/// <param name="securityEvidence">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rawAssembly" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawAssembly" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="rawAssembly" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.IO.FileLoadException">An assembly or module was loaded twice with two different evidences.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="securityEvidence" /> is not <see langword="null" />.  By default, legacy CAS policy is not enabled in the .NET Framework 4; when it is not enabled, <paramref name="securityEvidence" /> must be <see langword="null" />.</exception>
		// Token: 0x0600426D RID: 17005 RVA: 0x000F60E8 File Offset: 0x000F42E8
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of Load which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlEvidence)]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly Load(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence)
		{
			AppDomain.CheckLoadByteArraySupported();
			if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				Zone hostEvidence = securityEvidence.GetHostEvidence<Zone>();
				if (hostEvidence == null || hostEvidence.SecurityZone != SecurityZone.MyComputer)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
				}
			}
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.nLoadImage(rawAssembly, rawSymbolStore, securityEvidence, ref stackCrawlMark, false, false, SecurityContextSource.CurrentAssembly);
		}

		/// <summary>Loads the contents of an assembly file on the specified path.</summary>
		/// <param name="path">The fully qualified path of the file to load.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="path" /> argument is not an absolute path.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="path" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">The <paramref name="path" /> parameter is an empty string ("") or does not exist.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="path" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="path" /> was compiled with a later version.</exception>
		// Token: 0x0600426E RID: 17006 RVA: 0x000F613A File Offset: 0x000F433A
		[SecuritySafeCritical]
		public static Assembly LoadFile(string path)
		{
			AppDomain.CheckLoadFileSupported();
			new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, path).Demand();
			return RuntimeAssembly.nLoadFile(path, null);
		}

		/// <summary>Loads an assembly given its path, loading the assembly into the domain of the caller using the supplied evidence.</summary>
		/// <param name="path">The fully qualified path of the assembly file.</param>
		/// <param name="securityEvidence">Evidence for loading the assembly.</param>
		/// <returns>The loaded assembly.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="path" /> argument is not an absolute path.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="path" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">The <paramref name="path" /> parameter is an empty string ("") or does not exist.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.
		/// -or-
		/// The ability to execute code in remote assemblies is disabled. See &lt;loadFromRemoteSources&gt;.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="path" /> is not a valid assembly.  
		/// -or-  
		/// Version 2.0 or later of the common language runtime is currently loaded and <paramref name="path" /> was compiled with a later version.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="securityEvidence" /> is not <see langword="null" />. By default, legacy CAS policy is not enabled in the .NET Framework 4; when it is not enabled, <paramref name="securityEvidence" /> must be <see langword="null" />.</exception>
		// Token: 0x0600426F RID: 17007 RVA: 0x000F6155 File Offset: 0x000F4355
		[SecuritySafeCritical]
		[Obsolete("This method is obsolete and will be removed in a future release of the .NET Framework. Please use an overload of LoadFile which does not take an Evidence parameter. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlEvidence)]
		public static Assembly LoadFile(string path, Evidence securityEvidence)
		{
			AppDomain.CheckLoadFileSupported();
			if (securityEvidence != null && !AppDomain.CurrentDomain.IsLegacyCasPolicyEnabled)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_RequiresCasPolicyImplicit"));
			}
			new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, path).Demand();
			return RuntimeAssembly.nLoadFile(path, securityEvidence);
		}

		/// <summary>Gets the assembly that contains the code that is currently executing.</summary>
		/// <returns>The assembly that contains the code that is currently executing.</returns>
		// Token: 0x06004270 RID: 17008 RVA: 0x000F6190 File Offset: 0x000F4390
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly GetExecutingAssembly()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
		}

		/// <summary>Returns the <see cref="T:System.Reflection.Assembly" /> of the method that invoked the currently executing method.</summary>
		/// <returns>The <see langword="Assembly" /> object of the method that invoked the currently executing method.</returns>
		// Token: 0x06004271 RID: 17009 RVA: 0x000F61A8 File Offset: 0x000F43A8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Assembly GetCallingAssembly()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCallersCaller;
			return RuntimeAssembly.GetExecutingAssembly(ref stackCrawlMark);
		}

		/// <summary>Gets the process executable in the default application domain. In other application domains, this is the first executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)" />.</summary>
		/// <returns>The assembly that is the process executable in the default application domain, or the first executable that was executed by <see cref="M:System.AppDomain.ExecuteAssembly(System.String)" />. Can return <see langword="null" /> when called from unmanaged code.</returns>
		// Token: 0x06004272 RID: 17010 RVA: 0x000F61C0 File Offset: 0x000F43C0
		[SecuritySafeCritical]
		public static Assembly GetEntryAssembly()
		{
			AppDomainManager appDomainManager = AppDomain.CurrentDomain.DomainManager;
			if (appDomainManager == null)
			{
				appDomainManager = new AppDomainManager();
			}
			return appDomainManager.EntryAssembly;
		}

		/// <summary>Occurs when the common language runtime class loader cannot resolve a reference to an internal module of an assembly through normal means.</summary>
		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06004273 RID: 17011 RVA: 0x000F61E7 File Offset: 0x000F43E7
		// (remove) Token: 0x06004274 RID: 17012 RVA: 0x000F61EE File Offset: 0x000F43EE
		public virtual event ModuleResolveEventHandler ModuleResolve
		{
			[SecurityCritical]
			add
			{
				throw new NotImplementedException();
			}
			[SecurityCritical]
			remove
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the location of the assembly as specified originally, for example, in an <see cref="T:System.Reflection.AssemblyName" /> object.</summary>
		/// <returns>The location of the assembly as specified originally.</returns>
		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06004275 RID: 17013 RVA: 0x000F61F5 File Offset: 0x000F43F5
		public virtual string CodeBase
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the URI, including escape characters, that represents the codebase.</summary>
		/// <returns>A URI with escape characters.</returns>
		// Token: 0x170009D3 RID: 2515
		// (get) Token: 0x06004276 RID: 17014 RVA: 0x000F61FC File Offset: 0x000F43FC
		public virtual string EscapedCodeBase
		{
			[SecuritySafeCritical]
			get
			{
				return AssemblyName.EscapeCodeBase(this.CodeBase);
			}
		}

		/// <summary>Gets an <see cref="T:System.Reflection.AssemblyName" /> for this assembly.</summary>
		/// <returns>An object that contains the fully parsed display name for this assembly.</returns>
		// Token: 0x06004277 RID: 17015 RVA: 0x000F6209 File Offset: 0x000F4409
		[__DynamicallyInvokable]
		public virtual AssemblyName GetName()
		{
			return this.GetName(false);
		}

		/// <summary>Gets an <see cref="T:System.Reflection.AssemblyName" /> for this assembly, setting the codebase as specified by <paramref name="copiedName" />.</summary>
		/// <param name="copiedName">
		///   <see langword="true" /> to set the <see cref="P:System.Reflection.Assembly.CodeBase" /> to the location of the assembly after it was shadow copied; <see langword="false" /> to set <see cref="P:System.Reflection.Assembly.CodeBase" /> to the original location.</param>
		/// <returns>An object that contains the fully parsed display name for this assembly.</returns>
		// Token: 0x06004278 RID: 17016 RVA: 0x000F6212 File Offset: 0x000F4412
		public virtual AssemblyName GetName(bool copiedName)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the display name of the assembly.</summary>
		/// <returns>The display name of the assembly.</returns>
		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06004279 RID: 17017 RVA: 0x000F6219 File Offset: 0x000F4419
		[__DynamicallyInvokable]
		public virtual string FullName
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the entry point of this assembly.</summary>
		/// <returns>An object that represents the entry point of this assembly. If no entry point is found (for example, the assembly is a DLL), <see langword="null" /> is returned.</returns>
		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x0600427A RID: 17018 RVA: 0x000F6220 File Offset: 0x000F4420
		[__DynamicallyInvokable]
		public virtual MethodInfo EntryPoint
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Returns the type of the current instance.</summary>
		/// <returns>An object that represents the <see cref="T:System.Reflection.Assembly" /> type.</returns>
		// Token: 0x0600427B RID: 17019 RVA: 0x000F6227 File Offset: 0x000F4427
		Type _Assembly.GetType()
		{
			return base.GetType();
		}

		/// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance.</summary>
		/// <param name="name">The full name of the type.</param>
		/// <returns>An object that represents the specified class, or <see langword="null" /> if the class is not found.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is invalid.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///     <paramref name="name" /> requires a dependent assembly that was found but could not be loaded.  
		///  -or-  
		///  The current assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x0600427C RID: 17020 RVA: 0x000F622F File Offset: 0x000F442F
		[__DynamicallyInvokable]
		public virtual Type GetType(string name)
		{
			return this.GetType(name, false, false);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance and optionally throws an exception if the type is not found.</summary>
		/// <param name="name">The full name of the type.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type is not found; <see langword="false" /> to return <see langword="null" />.</param>
		/// <returns>An object that represents the specified class.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is invalid.  
		/// -or-  
		/// The length of <paramref name="name" /> exceeds 1024 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" />, and the type cannot be found.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="name" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x0600427D RID: 17021 RVA: 0x000F623A File Offset: 0x000F443A
		[__DynamicallyInvokable]
		public virtual Type GetType(string name, bool throwOnError)
		{
			return this.GetType(name, throwOnError, false);
		}

		/// <summary>Gets the <see cref="T:System.Type" /> object with the specified name in the assembly instance, with the options of ignoring the case, and of throwing an exception if the type is not found.</summary>
		/// <param name="name">The full name of the type.</param>
		/// <param name="throwOnError">
		///   <see langword="true" /> to throw an exception if the type is not found; <see langword="false" /> to return <see langword="null" />.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore the case of the type name; otherwise, <see langword="false" />.</param>
		/// <returns>An object that represents the specified class.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is invalid.  
		/// -or-  
		/// The length of <paramref name="name" /> exceeds 1024 characters.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.TypeLoadException">
		///   <paramref name="throwOnError" /> is <see langword="true" />, and the type cannot be found.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="name" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="name" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="name" /> requires a dependent assembly which was compiled for a version of the runtime later than the currently loaded version.</exception>
		// Token: 0x0600427E RID: 17022 RVA: 0x000F6245 File Offset: 0x000F4445
		[__DynamicallyInvokable]
		public virtual Type GetType(string name, bool throwOnError, bool ignoreCase)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a collection of the public types defined in this assembly that are visible outside the assembly.</summary>
		/// <returns>A collection of the public types defined in this assembly that are visible outside the assembly.</returns>
		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x0600427F RID: 17023 RVA: 0x000F624C File Offset: 0x000F444C
		[__DynamicallyInvokable]
		public virtual IEnumerable<Type> ExportedTypes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetExportedTypes();
			}
		}

		/// <summary>Gets the public types defined in this assembly that are visible outside the assembly.</summary>
		/// <returns>An array that represents the types defined in this assembly that are visible outside the assembly.</returns>
		/// <exception cref="T:System.NotSupportedException">The assembly is a dynamic assembly.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">Unable to load a dependent assembly.</exception>
		// Token: 0x06004280 RID: 17024 RVA: 0x000F6254 File Offset: 0x000F4454
		[__DynamicallyInvokable]
		public virtual Type[] GetExportedTypes()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a collection of the types defined in this assembly.</summary>
		/// <returns>A collection of the types defined in this assembly.</returns>
		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06004281 RID: 17025 RVA: 0x000F625C File Offset: 0x000F445C
		[__DynamicallyInvokable]
		public virtual IEnumerable<TypeInfo> DefinedTypes
		{
			[__DynamicallyInvokable]
			get
			{
				Type[] types = this.GetTypes();
				TypeInfo[] array = new TypeInfo[types.Length];
				for (int i = 0; i < types.Length; i++)
				{
					TypeInfo typeInfo = types[i].GetTypeInfo();
					if (typeInfo == null)
					{
						throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoTypeInfo", new object[]
						{
							types[i].FullName
						}));
					}
					array[i] = typeInfo;
				}
				return array;
			}
		}

		/// <summary>Gets the types defined in this assembly.</summary>
		/// <returns>An array that contains all the types that are defined in this assembly.</returns>
		/// <exception cref="T:System.Reflection.ReflectionTypeLoadException">The assembly contains one or more types that cannot be loaded. The array returned by the <see cref="P:System.Reflection.ReflectionTypeLoadException.Types" /> property of this exception contains a <see cref="T:System.Type" /> object for each type that was loaded and <see langword="null" /> for each type that could not be loaded, while the <see cref="P:System.Reflection.ReflectionTypeLoadException.LoaderExceptions" /> property contains an exception for each type that could not be loaded.</exception>
		// Token: 0x06004282 RID: 17026 RVA: 0x000F62C0 File Offset: 0x000F44C0
		[__DynamicallyInvokable]
		public virtual Type[] GetTypes()
		{
			Module[] modules = this.GetModules(false);
			int num = modules.Length;
			int num2 = 0;
			Type[][] array = new Type[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = modules[i].GetTypes();
				num2 += array[i].Length;
			}
			int num3 = 0;
			Type[] array2 = new Type[num2];
			for (int j = 0; j < num; j++)
			{
				int num4 = array[j].Length;
				Array.Copy(array[j], 0, array2, num3, num4);
				num3 += num4;
			}
			return array2;
		}

		/// <summary>Loads the specified manifest resource, scoped by the namespace of the specified type, from this assembly.</summary>
		/// <param name="type">The type whose namespace is used to scope the manifest resource name.</param>
		/// <param name="name">The case-sensitive name of the manifest resource being requested.</param>
		/// <returns>The manifest resource; or <see langword="null" /> if no resources were specified during compilation or if the resource is not visible to the caller.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> is not a valid assembly.</exception>
		/// <exception cref="T:System.NotImplementedException">Resource length is greater than <see cref="F:System.Int64.MaxValue" />.</exception>
		// Token: 0x06004283 RID: 17027 RVA: 0x000F6344 File Offset: 0x000F4544
		[__DynamicallyInvokable]
		public virtual Stream GetManifestResourceStream(Type type, string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>Loads the specified manifest resource from this assembly.</summary>
		/// <param name="name">The case-sensitive name of the manifest resource being requested.</param>
		/// <returns>The manifest resource; or <see langword="null" /> if no resources were specified during compilation or if the resource is not visible to the caller.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.FileLoadException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.IO.IOException" />, instead.  
		///
		///
		///
		///
		///  A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> is not a valid assembly.</exception>
		/// <exception cref="T:System.NotImplementedException">Resource length is greater than <see cref="F:System.Int64.MaxValue" />.</exception>
		// Token: 0x06004284 RID: 17028 RVA: 0x000F634B File Offset: 0x000F454B
		[__DynamicallyInvokable]
		public virtual Stream GetManifestResourceStream(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the satellite assembly for the specified culture.</summary>
		/// <param name="culture">The specified culture.</param>
		/// <returns>The specified satellite assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">The assembly cannot be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The satellite assembly with a matching file name was found, but the <see langword="CultureInfo" /> did not match the one specified.</exception>
		/// <exception cref="T:System.BadImageFormatException">The satellite assembly is not a valid assembly.</exception>
		// Token: 0x06004285 RID: 17029 RVA: 0x000F6352 File Offset: 0x000F4552
		public virtual Assembly GetSatelliteAssembly(CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the specified version of the satellite assembly for the specified culture.</summary>
		/// <param name="culture">The specified culture.</param>
		/// <param name="version">The version of the satellite assembly.</param>
		/// <returns>The specified satellite assembly.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="culture" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileLoadException">The satellite assembly with a matching file name was found, but the <see langword="CultureInfo" /> or the version did not match the one specified.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">The assembly cannot be found.</exception>
		/// <exception cref="T:System.BadImageFormatException">The satellite assembly is not a valid assembly.</exception>
		// Token: 0x06004286 RID: 17030 RVA: 0x000F6359 File Offset: 0x000F4559
		public virtual Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the evidence for this assembly.</summary>
		/// <returns>The evidence for this assembly.</returns>
		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06004287 RID: 17031 RVA: 0x000F6360 File Offset: 0x000F4560
		public virtual Evidence Evidence
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the grant set of the current assembly.</summary>
		/// <returns>The grant set of the current assembly.</returns>
		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06004288 RID: 17032 RVA: 0x000F6367 File Offset: 0x000F4567
		public virtual PermissionSet PermissionSet
		{
			[SecurityCritical]
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current assembly is loaded with full trust.</summary>
		/// <returns>
		///   <see langword="true" /> if the current assembly is loaded with full trust; otherwise, <see langword="false" />.</returns>
		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06004289 RID: 17033 RVA: 0x000F636E File Offset: 0x000F456E
		public bool IsFullyTrusted
		{
			[SecuritySafeCritical]
			get
			{
				return this.PermissionSet.IsUnrestricted();
			}
		}

		/// <summary>Gets a value that indicates which set of security rules the common language runtime (CLR) enforces for this assembly.</summary>
		/// <returns>The security rule set that the CLR enforces for this assembly.</returns>
		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x0600428A RID: 17034 RVA: 0x000F637B File Offset: 0x000F457B
		public virtual SecurityRuleSet SecurityRuleSet
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets serialization information with all of the data needed to reinstantiate this assembly.</summary>
		/// <param name="info">The object to be populated with serialization information.</param>
		/// <param name="context">The destination context of the serialization.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x0600428B RID: 17035 RVA: 0x000F6382 File Offset: 0x000F4582
		[SecurityCritical]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the module that contains the manifest for the current assembly.</summary>
		/// <returns>The module that contains the manifest for the assembly.</returns>
		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x0600428C RID: 17036 RVA: 0x000F638C File Offset: 0x000F458C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual Module ManifestModule
		{
			[__DynamicallyInvokable]
			get
			{
				RuntimeAssembly runtimeAssembly = this as RuntimeAssembly;
				if (runtimeAssembly != null)
				{
					return runtimeAssembly.ManifestModule;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a collection that contains this assembly's custom attributes.</summary>
		/// <returns>A collection that contains this assembly's custom attributes.</returns>
		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x0600428D RID: 17037 RVA: 0x000F63B5 File Offset: 0x000F45B5
		[__DynamicallyInvokable]
		public virtual IEnumerable<CustomAttributeData> CustomAttributes
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetCustomAttributesData();
			}
		}

		/// <summary>Gets all the custom attributes for this assembly.</summary>
		/// <param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly" />.</param>
		/// <returns>An array that contains the custom attributes for this assembly.</returns>
		// Token: 0x0600428E RID: 17038 RVA: 0x000F63BD File Offset: 0x000F45BD
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the custom attributes for this assembly as specified by type.</summary>
		/// <param name="attributeType">The type for which the custom attributes are to be returned.</param>
		/// <param name="inherit">This argument is ignored for objects of type <see cref="T:System.Reflection.Assembly" />.</param>
		/// <returns>An array that contains the custom attributes for this assembly as specified by <paramref name="attributeType" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not a runtime type.</exception>
		// Token: 0x0600428F RID: 17039 RVA: 0x000F63C4 File Offset: 0x000F45C4
		[__DynamicallyInvokable]
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Indicates whether or not a specified attribute has been applied to the assembly.</summary>
		/// <param name="attributeType">The type of the attribute to be checked for this assembly.</param>
		/// <param name="inherit">This argument is ignored for objects of this type.</param>
		/// <returns>
		///   <see langword="true" /> if the attribute has been applied to the assembly; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> uses an invalid type.</exception>
		// Token: 0x06004290 RID: 17040 RVA: 0x000F63CB File Offset: 0x000F45CB
		[__DynamicallyInvokable]
		public virtual bool IsDefined(Type attributeType, bool inherit)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns information about the attributes that have been applied to the current <see cref="T:System.Reflection.Assembly" />, expressed as <see cref="T:System.Reflection.CustomAttributeData" /> objects.</summary>
		/// <returns>A generic list of <see cref="T:System.Reflection.CustomAttributeData" /> objects representing data about the attributes that have been applied to the current assembly.</returns>
		// Token: 0x06004291 RID: 17041 RVA: 0x000F63D2 File Offset: 0x000F45D2
		public virtual IList<CustomAttributeData> GetCustomAttributesData()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a <see cref="T:System.Boolean" /> value indicating whether this assembly was loaded into the reflection-only context.</summary>
		/// <returns>
		///   <see langword="true" /> if the assembly was loaded into the reflection-only context, rather than the execution context; otherwise, <see langword="false" />.</returns>
		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06004292 RID: 17042 RVA: 0x000F63D9 File Offset: 0x000F45D9
		[ComVisible(false)]
		public virtual bool ReflectionOnly
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Loads the module, internal to this assembly, with a common object file format (COFF)-based image containing an emitted module, or a resource file.</summary>
		/// <param name="moduleName">The name of the module. This string must correspond to a file name in this assembly's manifest.</param>
		/// <param name="rawModule">A byte array that is a COFF-based image containing an emitted module, or a resource.</param>
		/// <returns>The loaded module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="moduleName" /> or <paramref name="rawModule" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="moduleName" /> does not match a file entry in this assembly's manifest.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawModule" /> is not a valid module.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		// Token: 0x06004293 RID: 17043 RVA: 0x000F63E0 File Offset: 0x000F45E0
		public Module LoadModule(string moduleName, byte[] rawModule)
		{
			return this.LoadModule(moduleName, rawModule, null);
		}

		/// <summary>Loads the module, internal to this assembly, with a common object file format (COFF)-based image containing an emitted module, or a resource file. The raw bytes representing the symbols for the module are also loaded.</summary>
		/// <param name="moduleName">The name of the module. This string must correspond to a file name in this assembly's manifest.</param>
		/// <param name="rawModule">A byte array that is a COFF-based image containing an emitted module, or a resource.</param>
		/// <param name="rawSymbolStore">A byte array containing the raw bytes representing the symbols for the module. Must be <see langword="null" /> if this is a resource file.</param>
		/// <returns>The loaded module.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="moduleName" /> or <paramref name="rawModule" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="moduleName" /> does not match a file entry in this assembly's manifest.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="rawModule" /> is not a valid module.</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		// Token: 0x06004294 RID: 17044 RVA: 0x000F63EB File Offset: 0x000F45EB
		public virtual Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore)
		{
			throw new NotImplementedException();
		}

		/// <summary>Locates the specified type from this assembly and creates an instance of it using the system activator, using case-sensitive search.</summary>
		/// <param name="typeName">The <see cref="P:System.Type.FullName" /> of the type to locate.</param>
		/// <returns>An instance of the specified type created with the default constructor; or <see langword="null" /> if <paramref name="typeName" /> is not found. The type is resolved using the default binder, without specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags" /> set to <see langword="Public" /> or <see langword="Instance" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="typeName" /> is an empty string ("") or a string beginning with a null character.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="typeName" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="typeName" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="typeName" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="typeName" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="typeName" /> requires a dependent assembly that was compiled for a version of the runtime that is later than the currently loaded version.</exception>
		// Token: 0x06004295 RID: 17045 RVA: 0x000F63F2 File Offset: 0x000F45F2
		public object CreateInstance(string typeName)
		{
			return this.CreateInstance(typeName, false, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);
		}

		/// <summary>Locates the specified type from this assembly and creates an instance of it using the system activator, with optional case-sensitive search.</summary>
		/// <param name="typeName">The <see cref="P:System.Type.FullName" /> of the type to locate.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore the case of the type name; otherwise, <see langword="false" />.</param>
		/// <returns>An instance of the specified type created with the default constructor; or <see langword="null" /> if <paramref name="typeName" /> is not found. The type is resolved using the default binder, without specifying culture or activation attributes, and with <see cref="T:System.Reflection.BindingFlags" /> set to <see langword="Public" /> or <see langword="Instance" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="typeName" /> is an empty string ("") or a string beginning with a null character.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context.</exception>
		/// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="typeName" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="typeName" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="typeName" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="typeName" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="typeName" /> requires a dependent assembly that was compiled for a version of the runtime that is later than the currently loaded version.</exception>
		// Token: 0x06004296 RID: 17046 RVA: 0x000F6402 File Offset: 0x000F4602
		public object CreateInstance(string typeName, bool ignoreCase)
		{
			return this.CreateInstance(typeName, ignoreCase, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);
		}

		/// <summary>Locates the specified type from this assembly and creates an instance of it using the system activator, with optional case-sensitive search and having the specified culture, arguments, and binding and activation attributes.</summary>
		/// <param name="typeName">The <see cref="P:System.Type.FullName" /> of the type to locate.</param>
		/// <param name="ignoreCase">
		///   <see langword="true" /> to ignore the case of the type name; otherwise, <see langword="false" />.</param>
		/// <param name="bindingAttr">A bitmask that affects the way in which the search is conducted. The value is a combination of bit flags from <see cref="T:System.Reflection.BindingFlags" />.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects via reflection. If <paramref name="binder" /> is <see langword="null" />, the default binder is used.</param>
		/// <param name="args">An array that contains the arguments to be passed to the constructor. This array of arguments must match in number, order, and type the parameters of the constructor to be invoked. If the default constructor is desired, <paramref name="args" /> must be an empty array or <see langword="null" />.</param>
		/// <param name="culture">An instance of <see langword="CultureInfo" /> used to govern the coercion of types. If this is <see langword="null" />, the <see langword="CultureInfo" /> for the current thread is used. (This is necessary to convert a <see langword="String" /> that represents 1000 to a <see langword="Double" /> value, for example, since 1000 is represented differently by different cultures.)</param>
		/// <param name="activationAttributes">An array of one or more attributes that can participate in activation. Typically, an array that contains a single <see cref="T:System.Runtime.Remoting.Activation.UrlAttribute" /> object that specifies the URL that is required to activate a remote object.  This parameter is related to client-activated objects. Client activation is a legacy technology that is retained for backward compatibility but is not recommended for new development. Distributed applications should instead use Windows Communication Foundation.</param>
		/// <returns>An instance of the specified type, or <see langword="null" /> if <paramref name="typeName" /> is not found. The supplied arguments are used to resolve the type, and to bind the constructor that is used to create the instance.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="typeName" /> is an empty string ("") or a string beginning with a null character.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.MissingMethodException">No matching constructor was found.</exception>
		/// <exception cref="T:System.NotSupportedException">A non-empty activation attributes array is passed to a type that does not inherit from <see cref="T:System.MarshalByRefObject" />.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="typeName" /> requires a dependent assembly that could not be found.</exception>
		/// <exception cref="T:System.IO.FileLoadException">
		///   <paramref name="typeName" /> requires a dependent assembly that was found but could not be loaded.  
		/// -or-  
		/// The current assembly was loaded into the reflection-only context, and <paramref name="typeName" /> requires a dependent assembly that was not preloaded.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="typeName" /> requires a dependent assembly, but the file is not a valid assembly.  
		/// -or-  
		/// <paramref name="typeName" /> requires a dependent assembly which that was compiled for a version of the runtime that is later than the currently loaded version.</exception>
		// Token: 0x06004297 RID: 17047 RVA: 0x000F6414 File Offset: 0x000F4614
		public virtual object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
		{
			Type type = this.GetType(typeName, false, ignoreCase);
			if (type == null)
			{
				return null;
			}
			return Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
		}

		/// <summary>Gets a collection that contains the modules in this assembly.</summary>
		/// <returns>A collection that contains the modules in this assembly.</returns>
		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06004298 RID: 17048 RVA: 0x000F6445 File Offset: 0x000F4645
		[__DynamicallyInvokable]
		public virtual IEnumerable<Module> Modules
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetLoadedModules(true);
			}
		}

		/// <summary>Gets all the loaded modules that are part of this assembly.</summary>
		/// <returns>An array of modules.</returns>
		// Token: 0x06004299 RID: 17049 RVA: 0x000F644E File Offset: 0x000F464E
		public Module[] GetLoadedModules()
		{
			return this.GetLoadedModules(false);
		}

		/// <summary>Gets all the loaded modules that are part of this assembly, specifying whether to include resource modules.</summary>
		/// <param name="getResourceModules">
		///   <see langword="true" /> to include resource modules; otherwise, <see langword="false" />.</param>
		/// <returns>An array of modules.</returns>
		// Token: 0x0600429A RID: 17050 RVA: 0x000F6457 File Offset: 0x000F4657
		public virtual Module[] GetLoadedModules(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets all the modules that are part of this assembly.</summary>
		/// <returns>An array of modules.</returns>
		/// <exception cref="T:System.IO.FileNotFoundException">The module to be loaded does not specify a file name extension.</exception>
		// Token: 0x0600429B RID: 17051 RVA: 0x000F645E File Offset: 0x000F465E
		[__DynamicallyInvokable]
		public Module[] GetModules()
		{
			return this.GetModules(false);
		}

		/// <summary>Gets all the modules that are part of this assembly, specifying whether to include resource modules.</summary>
		/// <param name="getResourceModules">
		///   <see langword="true" /> to include resource modules; otherwise, <see langword="false" />.</param>
		/// <returns>An array of modules.</returns>
		// Token: 0x0600429C RID: 17052 RVA: 0x000F6467 File Offset: 0x000F4667
		public virtual Module[] GetModules(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the specified module in this assembly.</summary>
		/// <param name="name">The name of the module being requested.</param>
		/// <returns>The module being requested, or <see langword="null" /> if the module is not found.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> is not a valid assembly.</exception>
		// Token: 0x0600429D RID: 17053 RVA: 0x000F646E File Offset: 0x000F466E
		public virtual Module GetModule(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets a <see cref="T:System.IO.FileStream" /> for the specified file in the file table of the manifest of this assembly.</summary>
		/// <param name="name">The name of the specified file. Do not include the path to the file.</param>
		/// <returns>A stream that contains the specified file, or <see langword="null" /> if the file is not found.</returns>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is an empty string ("").</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">
		///   <paramref name="name" /> was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">
		///   <paramref name="name" /> is not a valid assembly.</exception>
		// Token: 0x0600429E RID: 17054 RVA: 0x000F6475 File Offset: 0x000F4675
		public virtual FileStream GetFile(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the files in the file table of an assembly manifest.</summary>
		/// <returns>An array of streams that contain the files.</returns>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">A file was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">A file was not a valid assembly.</exception>
		// Token: 0x0600429F RID: 17055 RVA: 0x000F647C File Offset: 0x000F467C
		public virtual FileStream[] GetFiles()
		{
			return this.GetFiles(false);
		}

		/// <summary>Gets the files in the file table of an assembly manifest, specifying whether to include resource modules.</summary>
		/// <param name="getResourceModules">
		///   <see langword="true" /> to include resource modules; otherwise, <see langword="false" />.</param>
		/// <returns>An array of streams that contain the files.</returns>
		/// <exception cref="T:System.IO.FileLoadException">A file that was found could not be loaded.</exception>
		/// <exception cref="T:System.IO.FileNotFoundException">A file was not found.</exception>
		/// <exception cref="T:System.BadImageFormatException">A file was not a valid assembly.</exception>
		// Token: 0x060042A0 RID: 17056 RVA: 0x000F6485 File Offset: 0x000F4685
		public virtual FileStream[] GetFiles(bool getResourceModules)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns the names of all the resources in this assembly.</summary>
		/// <returns>An array that contains the names of all the resources.</returns>
		// Token: 0x060042A1 RID: 17057 RVA: 0x000F648C File Offset: 0x000F468C
		[__DynamicallyInvokable]
		public virtual string[] GetManifestResourceNames()
		{
			throw new NotImplementedException();
		}

		/// <summary>Gets the <see cref="T:System.Reflection.AssemblyName" /> objects for all the assemblies referenced by this assembly.</summary>
		/// <returns>An array that contains the fully parsed display names of all the assemblies referenced by this assembly.</returns>
		// Token: 0x060042A2 RID: 17058 RVA: 0x000F6493 File Offset: 0x000F4693
		public virtual AssemblyName[] GetReferencedAssemblies()
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns information about how the given resource has been persisted.</summary>
		/// <param name="resourceName">The case-sensitive name of the resource.</param>
		/// <returns>An object that is populated with information about the resource's topology, or <see langword="null" /> if the resource is not found.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="resourceName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="resourceName" /> parameter is an empty string ("").</exception>
		// Token: 0x060042A3 RID: 17059 RVA: 0x000F649A File Offset: 0x000F469A
		[__DynamicallyInvokable]
		public virtual ManifestResourceInfo GetManifestResourceInfo(string resourceName)
		{
			throw new NotImplementedException();
		}

		/// <summary>Returns the full name of the assembly, also known as the display name.</summary>
		/// <returns>The full name of the assembly, or the class name if the full name of the assembly cannot be determined.</returns>
		// Token: 0x060042A4 RID: 17060 RVA: 0x000F64A4 File Offset: 0x000F46A4
		[__DynamicallyInvokable]
		public override string ToString()
		{
			string fullName = this.FullName;
			if (fullName == null)
			{
				return base.ToString();
			}
			return fullName;
		}

		/// <summary>Gets the full path or UNC location of the loaded file that contains the manifest.</summary>
		/// <returns>The location of the loaded file that contains the manifest. If the loaded file was shadow-copied, the location is that of the file after being shadow-copied. If the assembly is loaded from a byte array, such as when using the <see cref="M:System.Reflection.Assembly.Load(System.Byte[])" /> method overload, the value returned is an empty string ("").</returns>
		/// <exception cref="T:System.NotSupportedException">The current assembly is a dynamic assembly, represented by an <see cref="T:System.Reflection.Emit.AssemblyBuilder" /> object.</exception>
		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x060042A5 RID: 17061 RVA: 0x000F64C3 File Offset: 0x000F46C3
		public virtual string Location
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a string representing the version of the common language runtime (CLR) saved in the file containing the manifest.</summary>
		/// <returns>The CLR version folder name. This is not a full path.</returns>
		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x060042A6 RID: 17062 RVA: 0x000F64CA File Offset: 0x000F46CA
		[ComVisible(false)]
		public virtual string ImageRuntimeVersion
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value indicating whether the assembly was loaded from the global assembly cache.</summary>
		/// <returns>
		///   <see langword="true" /> if the assembly was loaded from the global assembly cache; otherwise, <see langword="false" />.</returns>
		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x060042A7 RID: 17063 RVA: 0x000F64D1 File Offset: 0x000F46D1
		public virtual bool GlobalAssemblyCache
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets the host context with which the assembly was loaded.</summary>
		/// <returns>An <see cref="T:System.Int64" /> value that indicates the host context with which the assembly was loaded, if any.</returns>
		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x060042A8 RID: 17064 RVA: 0x000F64D8 File Offset: 0x000F46D8
		[ComVisible(false)]
		public virtual long HostContext
		{
			get
			{
				RuntimeAssembly runtimeAssembly = this as RuntimeAssembly;
				if (runtimeAssembly != null)
				{
					return runtimeAssembly.HostContext;
				}
				throw new NotImplementedException();
			}
		}

		/// <summary>Gets a value that indicates whether the current assembly was generated dynamically in the current process by using reflection emit.</summary>
		/// <returns>
		///   <see langword="true" /> if the current assembly was generated dynamically in the current process; otherwise, <see langword="false" />.</returns>
		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x060042A9 RID: 17065 RVA: 0x000F6501 File Offset: 0x000F4701
		[__DynamicallyInvokable]
		public virtual bool IsDynamic
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}
	}
}
