using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Defines the basic functionality of a principal object.</summary>
	// Token: 0x020002F8 RID: 760
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IPrincipal
	{
		/// <summary>Gets the identity of the current principal.</summary>
		/// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600277D RID: 10109
		[__DynamicallyInvokable]
		IIdentity Identity { [__DynamicallyInvokable] get; }

		/// <summary>Determines whether the current principal belongs to the specified role.</summary>
		/// <param name="role">The name of the role for which to check membership.</param>
		/// <returns>
		///   <see langword="true" /> if the current principal is a member of the specified role; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600277E RID: 10110
		[__DynamicallyInvokable]
		bool IsInRole(string role);
	}
}
