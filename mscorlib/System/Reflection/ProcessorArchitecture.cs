using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Identifies the processor and bits-per-word of the platform targeted by an executable.</summary>
	// Token: 0x0200059E RID: 1438
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ProcessorArchitecture
	{
		/// <summary>An unknown or unspecified combination of processor and bits-per-word.</summary>
		// Token: 0x04001B6E RID: 7022
		[__DynamicallyInvokable]
		None,
		/// <summary>Neutral with respect to processor and bits-per-word.</summary>
		// Token: 0x04001B6F RID: 7023
		[__DynamicallyInvokable]
		MSIL,
		/// <summary>A 32-bit Intel processor, either native or in the Windows on Windows environment on a 64-bit platform (WOW64).</summary>
		// Token: 0x04001B70 RID: 7024
		[__DynamicallyInvokable]
		X86,
		/// <summary>A 64-bit Intel Itanium processor only.</summary>
		// Token: 0x04001B71 RID: 7025
		[__DynamicallyInvokable]
		IA64,
		/// <summary>A 64-bit processor based on the x64 architecture.</summary>
		// Token: 0x04001B72 RID: 7026
		[__DynamicallyInvokable]
		Amd64,
		/// <summary>An ARM processor.</summary>
		// Token: 0x04001B73 RID: 7027
		[__DynamicallyInvokable]
		Arm
	}
}
