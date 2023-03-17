using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Specifies how to match versions when locating application trusts in a collection.</summary>
	// Token: 0x02000318 RID: 792
	[ComVisible(true)]
	public enum ApplicationVersionMatch
	{
		/// <summary>Match on the exact version.</summary>
		// Token: 0x04001057 RID: 4183
		MatchExactVersion,
		/// <summary>Match on all versions.</summary>
		// Token: 0x04001058 RID: 4184
		MatchAllVersions
	}
}
