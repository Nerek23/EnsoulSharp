using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Specifies the type of user interface (UI) the trust manager should use for trust decisions.</summary>
	// Token: 0x0200032F RID: 815
	[ComVisible(true)]
	public enum TrustManagerUIContext
	{
		/// <summary>An Install UI.</summary>
		// Token: 0x04001089 RID: 4233
		Install,
		/// <summary>An Upgrade UI.</summary>
		// Token: 0x0400108A RID: 4234
		Upgrade,
		/// <summary>A Run UI.</summary>
		// Token: 0x0400108B RID: 4235
		Run
	}
}
