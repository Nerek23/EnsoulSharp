using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Defines the types of connections to a class object.</summary>
	// Token: 0x02000948 RID: 2376
	[Flags]
	public enum RegistrationConnectionType
	{
		/// <summary>Once an application is connected to a class object with <see langword="CoGetClassObject" />, the class object is removed from public view so that no other applications can connect to it. This value is commonly used for single document interface (SDI) applications.</summary>
		// Token: 0x04002B13 RID: 11027
		SingleUse = 0,
		/// <summary>Multiple applications can connect to the class object through calls to <see langword="CoGetClassObject" />.</summary>
		// Token: 0x04002B14 RID: 11028
		MultipleUse = 1,
		/// <summary>Registers separate CLSCTX_LOCAL_SERVER and CLSCTX_INPROC_SERVER class factories.</summary>
		// Token: 0x04002B15 RID: 11029
		MultiSeparate = 2,
		/// <summary>Suspends registration and activation requests for the specified CLSID until there is a call to <see langword="CoResumeClassObjects" />.</summary>
		// Token: 0x04002B16 RID: 11030
		Suspended = 4,
		/// <summary>The class object is a surrogate process used to run DLL servers.</summary>
		// Token: 0x04002B17 RID: 11031
		Surrogate = 8
	}
}
