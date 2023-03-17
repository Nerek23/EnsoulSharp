using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	/// <summary>Indicates that the implementer wants to be a lifetime lease sponsor.</summary>
	// Token: 0x020007F2 RID: 2034
	[ComVisible(true)]
	public interface ISponsor
	{
		/// <summary>Requests a sponsoring client to renew the lease for the specified object.</summary>
		/// <param name="lease">The lifetime lease of the object that requires lease renewal.</param>
		/// <returns>The additional lease time for the specified object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x0600580A RID: 22538
		[SecurityCritical]
		TimeSpan Renewal(ILease lease);
	}
}
