﻿using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the paths that are used to search for DLLs that provide functions for platform invokes.</summary>
	// Token: 0x02000905 RID: 2309
	[Flags]
	[__DynamicallyInvokable]
	public enum DllImportSearchPath
	{
		/// <summary>Search for the dependencies of a DLL in the folder where the DLL is located before searching other folders.</summary>
		// Token: 0x04002A4F RID: 10831
		[__DynamicallyInvokable]
		UseDllDirectoryForDependencies = 256,
		/// <summary>Include the application directory in the DLL search path.</summary>
		// Token: 0x04002A50 RID: 10832
		[__DynamicallyInvokable]
		ApplicationDirectory = 512,
		/// <summary>Include any path that was explicitly added to the process-wide search path by using the Win32 AddDllDirectory function.</summary>
		// Token: 0x04002A51 RID: 10833
		[__DynamicallyInvokable]
		UserDirectories = 1024,
		/// <summary>Include the <see langword="%WinDir%\System32" /> directory in the DLL search path.</summary>
		// Token: 0x04002A52 RID: 10834
		[__DynamicallyInvokable]
		System32 = 2048,
		/// <summary>Include the application directory, the <see langword="%WinDir%\System32" /> directory, and user directories in the DLL search path.</summary>
		// Token: 0x04002A53 RID: 10835
		[__DynamicallyInvokable]
		SafeDirectories = 4096,
		/// <summary>When searching for assembly dependencies, include the directory that contains the assembly itself, and search that directory first. This value is used by the .NET Framework, before the paths are passed to the Win32 LoadLibraryEx function.</summary>
		// Token: 0x04002A54 RID: 10836
		[__DynamicallyInvokable]
		AssemblyDirectory = 2,
		/// <summary>Search the application directory, and then call the Win32 LoadLibraryEx function with the LOAD_WITH_ALTERED_SEARCH_PATH flag. This value is ignored if any other value is specified. Operating systems that do not support the <see cref="T:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute" /> attribute use this value, and ignore other values.</summary>
		// Token: 0x04002A55 RID: 10837
		[__DynamicallyInvokable]
		LegacyBehavior = 0
	}
}
