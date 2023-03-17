using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows a permission to expose an unrestricted state.</summary>
	// Token: 0x020002E6 RID: 742
	[ComVisible(true)]
	public interface IUnrestrictedPermission
	{
		/// <summary>Returns a value indicating whether unrestricted access to the resource protected by the permission is allowed.</summary>
		/// <returns>
		///   <see langword="true" /> if unrestricted use of the resource protected by the permission is allowed; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002695 RID: 9877
		bool IsUnrestricted();
	}
}
