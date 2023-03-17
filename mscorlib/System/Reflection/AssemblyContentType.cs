using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Provides information about the type of code contained in an assembly.</summary>
	// Token: 0x0200059D RID: 1437
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum AssemblyContentType
	{
		/// <summary>The assembly contains .NET Framework code.</summary>
		// Token: 0x04001B6B RID: 7019
		[__DynamicallyInvokable]
		Default,
		/// <summary>The assembly contains Windows Runtime code.</summary>
		// Token: 0x04001B6C RID: 7020
		[__DynamicallyInvokable]
		WindowsRuntime
	}
}
