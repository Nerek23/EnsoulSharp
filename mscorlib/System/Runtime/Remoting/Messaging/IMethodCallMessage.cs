using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Defines the method call message interface.</summary>
	// Token: 0x0200082E RID: 2094
	[ComVisible(true)]
	public interface IMethodCallMessage : IMethodMessage, IMessage
	{
		/// <summary>Gets the number of arguments in the call that are not marked as <see langword="out" /> parameters.</summary>
		/// <returns>The number of arguments in the call that are not marked as <see langword="out" /> parameters.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F18 RID: 3864
		// (get) Token: 0x0600596F RID: 22895
		int InArgCount { [SecurityCritical] get; }

		/// <summary>Returns the name of the specified argument that is not marked as an <see langword="out" /> parameter.</summary>
		/// <param name="index">The number of the requested <see langword="in" /> argument.</param>
		/// <returns>The name of a specific argument that is not marked as an <see langword="out" /> parameter.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005970 RID: 22896
		[SecurityCritical]
		string GetInArgName(int index);

		/// <summary>Returns the specified argument that is not marked as an <see langword="out" /> parameter.</summary>
		/// <param name="argNum">The number of the requested <see langword="in" /> argument.</param>
		/// <returns>The requested argument that is not marked as an <see langword="out" /> parameter.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005971 RID: 22897
		[SecurityCritical]
		object GetInArg(int argNum);

		/// <summary>Gets an array of arguments that are not marked as <see langword="out" /> parameters.</summary>
		/// <returns>An array of arguments that are not marked as <see langword="out" /> parameters.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F19 RID: 3865
		// (get) Token: 0x06005972 RID: 22898
		object[] InArgs { [SecurityCritical] get; }
	}
}
