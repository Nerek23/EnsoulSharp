using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime
{
	/// <summary>Improves the startup performance of application domains in applications that require the just-in-time (JIT) compiler by performing background compilation of methods that are likely to be executed, based on profiles created during previous compilations.</summary>
	// Token: 0x020006ED RID: 1773
	public static class ProfileOptimization
	{
		// Token: 0x06005015 RID: 20501
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void InternalSetProfileRoot(string directoryPath);

		// Token: 0x06005016 RID: 20502
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void InternalStartProfile(string profile, IntPtr ptrNativeAssemblyLoadContext);

		/// <summary>Enables optimization profiling for the current application domain, and sets the folder where the optimization profile files are stored. On a single-core computer, the method is ignored.</summary>
		/// <param name="directoryPath">The full path to the folder where profile files are stored for the current application domain.</param>
		// Token: 0x06005017 RID: 20503 RVA: 0x00119C15 File Offset: 0x00117E15
		[SecurityCritical]
		public static void SetProfileRoot(string directoryPath)
		{
			ProfileOptimization.InternalSetProfileRoot(directoryPath);
		}

		/// <summary>Starts just-in-time (JIT) compilation of the methods that were previously recorded in the specified profile file, on a background thread. Starts the process of recording current method use, which later overwrites the specified profile file.</summary>
		/// <param name="profile">The file name of the profile to use.</param>
		// Token: 0x06005018 RID: 20504 RVA: 0x00119C1D File Offset: 0x00117E1D
		[SecurityCritical]
		public static void StartProfile(string profile)
		{
			ProfileOptimization.InternalStartProfile(profile, IntPtr.Zero);
		}
	}
}
