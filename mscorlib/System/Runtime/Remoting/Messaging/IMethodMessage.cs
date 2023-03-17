using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Defines the method message interface.</summary>
	// Token: 0x0200082D RID: 2093
	[ComVisible(true)]
	public interface IMethodMessage : IMessage
	{
		/// <summary>Gets the URI of the specific object that the call is destined for.</summary>
		/// <returns>The URI of the remote object that contains the invoked method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F0F RID: 3855
		// (get) Token: 0x06005964 RID: 22884
		string Uri { [SecurityCritical] get; }

		/// <summary>Gets the name of the invoked method.</summary>
		/// <returns>The name of the invoked method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F10 RID: 3856
		// (get) Token: 0x06005965 RID: 22885
		string MethodName { [SecurityCritical] get; }

		/// <summary>Gets the full <see cref="T:System.Type" /> name of the specific object that the call is destined for.</summary>
		/// <returns>The full <see cref="T:System.Type" /> name of the specific object that the call is destined for.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F11 RID: 3857
		// (get) Token: 0x06005966 RID: 22886
		string TypeName { [SecurityCritical] get; }

		/// <summary>Gets an object containing the method signature.</summary>
		/// <returns>An object containing the method signature.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F12 RID: 3858
		// (get) Token: 0x06005967 RID: 22887
		object MethodSignature { [SecurityCritical] get; }

		/// <summary>Gets the number of arguments passed to the method.</summary>
		/// <returns>The number of arguments passed to the method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F13 RID: 3859
		// (get) Token: 0x06005968 RID: 22888
		int ArgCount { [SecurityCritical] get; }

		/// <summary>Gets the name of the argument passed to the method.</summary>
		/// <param name="index">The number of the requested argument.</param>
		/// <returns>The name of the specified argument passed to the method, or <see langword="null" /> if the current method is not implemented.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x06005969 RID: 22889
		[SecurityCritical]
		string GetArgName(int index);

		/// <summary>Gets a specific argument as an <see cref="T:System.Object" />.</summary>
		/// <param name="argNum">The number of the requested argument.</param>
		/// <returns>The argument passed to the method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x0600596A RID: 22890
		[SecurityCritical]
		object GetArg(int argNum);

		/// <summary>Gets an array of arguments passed to the method.</summary>
		/// <returns>An <see cref="T:System.Object" /> array containing the arguments passed to the method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F14 RID: 3860
		// (get) Token: 0x0600596B RID: 22891
		object[] Args { [SecurityCritical] get; }

		/// <summary>Gets a value indicating whether the message has variable arguments.</summary>
		/// <returns>
		///   <see langword="true" /> if the method can accept a variable number of arguments; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F15 RID: 3861
		// (get) Token: 0x0600596C RID: 22892
		bool HasVarArgs { [SecurityCritical] get; }

		/// <summary>Gets the <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> for the current method call.</summary>
		/// <returns>Gets the <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> for the current method call.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F16 RID: 3862
		// (get) Token: 0x0600596D RID: 22893
		LogicalCallContext LogicalCallContext { [SecurityCritical] get; }

		/// <summary>Gets the <see cref="T:System.Reflection.MethodBase" /> of the called method.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodBase" /> of the called method.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.</exception>
		// Token: 0x17000F17 RID: 3863
		// (get) Token: 0x0600596E RID: 22894
		MethodBase MethodBase { [SecurityCritical] get; }
	}
}
