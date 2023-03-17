using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal
{
	/// <summary>Provides access to internal properties of an <see cref="T:System.ApplicationIdentity" /> object.</summary>
	// Token: 0x0200063F RID: 1599
	[ComVisible(false)]
	public static class InternalApplicationIdentityHelper
	{
		/// <summary>Gets an IDefinitionAppId Interface representing the unique identifier of an <see cref="T:System.ApplicationIdentity" /> object.</summary>
		/// <param name="id">The object from which to extract the identifier.</param>
		/// <returns>The unique identifier held by the <see cref="T:System.ApplicationIdentity" /> object.</returns>
		// Token: 0x06004DF5 RID: 19957 RVA: 0x001178D0 File Offset: 0x00115AD0
		[SecurityCritical]
		public static object GetInternalAppId(ApplicationIdentity id)
		{
			return id.Identity;
		}
	}
}
