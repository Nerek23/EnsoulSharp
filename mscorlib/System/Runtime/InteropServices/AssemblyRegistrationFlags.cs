using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Defines a set of flags used when registering assemblies.</summary>
	// Token: 0x0200093C RID: 2364
	[Flags]
	[ComVisible(true)]
	public enum AssemblyRegistrationFlags
	{
		/// <summary>Indicates no special settings.</summary>
		// Token: 0x04002ADF RID: 10975
		None = 0,
		/// <summary>Indicates that the code base key for the assembly should be set in the registry.</summary>
		// Token: 0x04002AE0 RID: 10976
		SetCodeBase = 1
	}
}
