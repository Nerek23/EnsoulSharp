using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates how an assembly should be produced.</summary>
	// Token: 0x0200093E RID: 2366
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibImporterFlags
	{
		/// <summary>No special settings. This is the default.</summary>
		// Token: 0x04002AE2 RID: 10978
		None = 0,
		/// <summary>Generates a primary interop assembly. For more information, see the <see cref="T:System.Runtime.InteropServices.PrimaryInteropAssemblyAttribute" /> attribute. A keyfile must be specified.</summary>
		// Token: 0x04002AE3 RID: 10979
		PrimaryInteropAssembly = 1,
		/// <summary>Imports all interfaces as interfaces that suppress the common language runtime's stack crawl for <see cref="F:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode" /> permission. Be sure you understand the responsibilities associated with suppressing this security check.</summary>
		// Token: 0x04002AE4 RID: 10980
		UnsafeInterfaces = 2,
		/// <summary>Imports all <see langword="SAFEARRAY" /> instances as <see cref="T:System.Array" /> instead of typed, single-dimensional, zero-based managed arrays. This option is useful when dealing with multi-dimensional, non-zero-based <see langword="SAFEARRAY" /> instances, which otherwise cannot be accessed unless you edit the resulting assembly by using the MSIL Disassembler (Ildasm.exe) and MSIL Assembler (Ilasm.exe) tools.</summary>
		// Token: 0x04002AE5 RID: 10981
		SafeArrayAsSystemArray = 4,
		/// <summary>Transforms <see langword="[out, retval]" /> parameters of methods on dispatch-only interfaces (dispinterface) into return values.</summary>
		// Token: 0x04002AE6 RID: 10982
		TransformDispRetVals = 8,
		/// <summary>Not used.</summary>
		// Token: 0x04002AE7 RID: 10983
		PreventClassMembers = 16,
		/// <summary>Uses serializable classes.</summary>
		// Token: 0x04002AE8 RID: 10984
		SerializableValueClasses = 32,
		/// <summary>Imports a type library for the x86 platform.</summary>
		// Token: 0x04002AE9 RID: 10985
		ImportAsX86 = 256,
		/// <summary>Imports a type library for the x86 64-bit platform.</summary>
		// Token: 0x04002AEA RID: 10986
		ImportAsX64 = 512,
		/// <summary>Imports a type library for the Itanium platform.</summary>
		// Token: 0x04002AEB RID: 10987
		ImportAsItanium = 1024,
		/// <summary>Imports a type library for any platform.</summary>
		// Token: 0x04002AEC RID: 10988
		ImportAsAgnostic = 2048,
		/// <summary>Uses reflection-only loading.</summary>
		// Token: 0x04002AED RID: 10989
		ReflectionOnlyLoading = 4096,
		/// <summary>Prevents inclusion of a version resource in the interop assembly. For more information, see the <see cref="M:System.Reflection.Emit.AssemblyBuilder.DefineVersionInfoResource" /> method.</summary>
		// Token: 0x04002AEE RID: 10990
		NoDefineVersionResource = 8192,
		/// <summary>Imports a library for the ARM platform.</summary>
		// Token: 0x04002AEF RID: 10991
		ImportAsArm = 16384
	}
}
