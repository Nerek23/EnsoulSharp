using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	/// <summary>Defines the basic functionality of an identity object.</summary>
	// Token: 0x020002F7 RID: 759
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IIdentity
	{
		/// <summary>Gets the name of the current user.</summary>
		/// <returns>The name of the user on whose behalf the code is running.</returns>
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600277A RID: 10106
		[__DynamicallyInvokable]
		string Name { [__DynamicallyInvokable] get; }

		/// <summary>Gets the type of authentication used.</summary>
		/// <returns>The type of authentication used to identify the user.</returns>
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600277B RID: 10107
		[__DynamicallyInvokable]
		string AuthenticationType { [__DynamicallyInvokable] get; }

		/// <summary>Gets a value that indicates whether the user has been authenticated.</summary>
		/// <returns>
		///   <see langword="true" /> if the user was authenticated; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600277C RID: 10108
		[__DynamicallyInvokable]
		bool IsAuthenticated { [__DynamicallyInvokable] get; }
	}
}
