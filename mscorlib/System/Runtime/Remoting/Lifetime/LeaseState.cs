using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Lifetime
{
	/// <summary>Indicates the possible lease states of a lifetime lease.</summary>
	// Token: 0x020007F6 RID: 2038
	[ComVisible(true)]
	[Serializable]
	public enum LeaseState
	{
		/// <summary>The lease is not initialized.</summary>
		// Token: 0x040027F6 RID: 10230
		Null,
		/// <summary>The lease has been created, but is not yet active.</summary>
		// Token: 0x040027F7 RID: 10231
		Initial,
		/// <summary>The lease is active and has not expired.</summary>
		// Token: 0x040027F8 RID: 10232
		Active,
		/// <summary>The lease has expired and is seeking sponsorship.</summary>
		// Token: 0x040027F9 RID: 10233
		Renewing,
		/// <summary>The lease has expired and cannot be renewed.</summary>
		// Token: 0x040027FA RID: 10234
		Expired
	}
}
