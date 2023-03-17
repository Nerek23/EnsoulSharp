using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Provides information about an <see cref="T:System.Reflection.Assembly" /> reference.</summary>
	// Token: 0x0200059C RID: 1436
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum AssemblyNameFlags
	{
		/// <summary>Specifies that no flags are in effect.</summary>
		// Token: 0x04001B65 RID: 7013
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Specifies that a public key is formed from the full public key rather than the public key token.</summary>
		// Token: 0x04001B66 RID: 7014
		[__DynamicallyInvokable]
		PublicKey = 1,
		/// <summary>Specifies that just-in-time (JIT) compiler optimization is disabled for the assembly. This is the exact opposite of the meaning that is suggested by the member name.</summary>
		// Token: 0x04001B67 RID: 7015
		EnableJITcompileOptimizer = 16384,
		/// <summary>Specifies that just-in-time (JIT) compiler tracking is enabled for the assembly.</summary>
		// Token: 0x04001B68 RID: 7016
		EnableJITcompileTracking = 32768,
		/// <summary>Specifies that the assembly can be retargeted at runtime to an assembly from a different publisher. This value supports the .NET Framework infrastructure and is not intended to be used directly from your code.</summary>
		// Token: 0x04001B69 RID: 7017
		[__DynamicallyInvokable]
		Retargetable = 256
	}
}
